<template>
  <div class="content-container login-container">
    <div class="title-wrapper parent-page-title">
      <div class="login-title">
        <h4>Login</h4>
      </div>
    </div>
    <hr class="line" />
    <div class="content">
      <div class="form-container">

        <div class="row g-3">
          <div class="col-lg-21 col-md-12 col-sm-12">
            <label for="user-name" class="form-label">User Name</label>
            <input v-model="formData.username" type="text" id="user-name" class="form-control" placeholder="User Name"
              maxlength="25">
            <span class="validation-error" v-for="error in v$.username.$errors" :key="error.$uid">
              {{ error.$message }}
            </span>
          </div>
        </div>

        <div class="row g-3">
          <div class="col-lg-12 col-md-12 col-sm-12">
            <label for="password" class="form-label">Password</label>
            <input v-model="formData.password" type="password" id="password" class="form-control" placeholder="Password"
              maxlength="25">
            <span class="validation-error" v-for="error in v$.password.$errors" :key="error.$uid">
              {{ error.$message }}
            </span>
          </div>
        </div>

        <div class="row">
          <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="login-buttons">
              <button class="btn btn-login" v-on:click.prevent="Login">
                <span>Login</span>
              </button>

              <RouterLink to="/" class="back-home">
                Back to home page
              </RouterLink>
            </div>
          </div>
        </div>

      </div>
    </div>

  </div>
</template>

<style>
@import '@/assets/admin/css/style.css';
@import '@/assets/admin/css/login.css';
</style>

<script setup>
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import identityService from '@/services/identityService'
import { useToast } from 'vue-toastification'
import { reactive } from 'vue'
import useVuelidate from '@vuelidate/core'
import { required, minLength } from '@vuelidate/validators'

const formData = reactive({
  username: "",
  password: ""
})

const rules = {
  username: {
    required,
    minLength: minLength(4),
  },
  password: {
    required,
    minLength: minLength(6),
  }
}

const v$ = useVuelidate(rules, formData)

const Login = async () => {
  const result = await v$.value.$validate()
  if (!result)
    return

  const toast = useToast()
  try {
    identityService.login(formData).then(response => {
      ClearForm()
      v$.value.$reset()

      if (response.status == 200) {
        toast.success("welcome!")
        //save Token in localstorage or cookie
        //redirect to view profile in admin panel
      }
      else {
        toast.error("Username or password is incorrect.")
      }
    })
  }
  catch (errorMsg) {
    toast.error("Something went wrong")
  }
};

const ClearForm = () => {
  formData.username = formData.password = ''
}
</script>