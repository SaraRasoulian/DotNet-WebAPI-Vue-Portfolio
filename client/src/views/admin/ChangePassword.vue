<template>
    <div class="password">
        <AdminLayout>
            <div class="content-container">
                <div class="title-wrapper parent-page-title">
                    <div class="list-title">
                        <h4>Change Password</h4>
                    </div>
                </div>
                <hr class="line" />

                <div class="content">
                    <div class="form-container">
                        <div class="row g-3">
                            <div class="col-lg-8 col-md-12 col-sm-12">
                                <label class="form-label">Current password</label>
                                <input v-model="formData.currentPassword" type="password" class="form-control"
                                    placeholder="Current password" maxlength="50">
                                <span class="validation-error" v-for="error in v$.currentPassword.$errors" :key="error.$uid">
                                    {{ error.$message }}
                                </span>
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-lg-8 col-md-12 col-sm-12">
                                <label class="form-label">New password</label>
                                <input v-model="formData.newPassword" type="password" class="form-control" placeholder="New password" maxlength="50">
                                <span class="validation-error" v-for="error in v$.newPassword.$errors" :key="error.$uid">
                                    {{ error.$message }}
                                </span>
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-lg-8 col-md-12 col-sm-12">
                                <label class="form-label">Confirm new password</label>
                                <input v-model="formData.confirmNewPassword" type="password" class="form-control" placeholder="Confirm new password"
                                    maxlength="50">
                                <span class="validation-error" v-for="error in v$.confirmNewPassword.$errors" :key="error.$uid">
                                    {{ error.$message }}
                                </span>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6 col-md-8 col-sm-12 col-xs-12">
                                <div class="button-container">
                                    <button class="btn btn-save" v-on:click.prevent="Save">Save</button>
                                    <router-link :to="{ name: 'view-profile' }" class="btn btn-cancel">Cancel</router-link>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </AdminLayout>
    </div>
</template>

<script setup>
import AdminLayout from '@/layouts/admin/Layout.vue'
import identityService from '@/services/identityService'
import { useToast } from 'vue-toastification'
import { reactive } from 'vue'
import useVuelidate from '@vuelidate/core'
import { required, minLength } from '@vuelidate/validators'

const formData = reactive({
    currentPassword: "",
    newPassword: "",
    confirmNewPassword: ""
})

const rules = {
    currentPassword: { required },
    newPassword: { required, minLength: minLength(6) },
    confirmNewPassword: { required, minLength: minLength(6) }
}
const v$ = useVuelidate(rules, formData)

const Save = async () => {
    const result = await v$.value.$validate()
    if (!result)
        return

    const toast = useToast()
    try {
        identityService.changePassword(formData).then(response => {
            v$.value.$reset()

            if (response.status == 200)
                toast.success("Password changed")
        })
    }
    catch (errorMsg) {
        toast.error("Something went wrong")
    }
}
</script>