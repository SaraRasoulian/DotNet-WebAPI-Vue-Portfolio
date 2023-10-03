<template>
  <div class="form fade-in-on-scroll">
    <div class="form-header">
      <h1>Say Hi</h1>
    </div>
    <div>
      <form>
        <div class="row">
          <div class="six columns form-item">
            <input type="text" placeholder="Your name" v-model="formData.name" maxlength="70" />
            <span class="validation-error" v-for="error in v$.name.$errors" :key="error.$uid">
              {{ error.$message }}
            </span>
          </div>
          <div class="six columns form-item">
            <input type="email" placeholder="Your email" v-model="formData.email" maxlength="200" />
            <span class="validation-error" v-for="error in v$.email.$errors" :key="error.$uid">
              {{ error.$message }}
            </span>
          </div>
        </div>
        <div class="form-item">
          <textarea placeholder="Hi Sara …" v-model="formData.content" maxlength="1000"></textarea>
          <span class="validation-error" v-for="error in v$.content.$errors" :key="error.$uid">
            {{ error.$message }}
          </span>
        </div>
        <div class="row">
          <div class="six columns">
            <button class="button send-button icon-rotate" v-on:click.prevent="Send">
              <span>Send</span>
              <img class="icon" src="@/assets/home/images/send.png" alt="Send">
            </button>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>


<script setup>
import messagesService from '@/services/messagesService'
import { useToast } from 'vue-toastification'
import { reactive } from 'vue'
import useVuelidate from '@vuelidate/core';
import { required, email } from '@vuelidate/validators';

const formData = reactive({
  name: "",
  email: "",
  content: ""
});

const rules = {
  name: { required },
  email: { required, email },
  content: { required }
}
const v$ = useVuelidate(rules, formData)

const Send = async () => {
  const result = await v$.value.$validate();
  if (!result)
    return

  const toast = useToast()
  try {
    messagesService.create(formData).then(response => {
      ClearForm()
      v$.value.$reset()

      if (response.status == 200)
        toast.success("Message sent. Thank you!")
    })
  }
  catch (errorMsg) {
    toast.error("Something went wrong")
  }
};

const ClearForm = () => {
  formData.name = formData.email = formData.content = ''
}
</script>


