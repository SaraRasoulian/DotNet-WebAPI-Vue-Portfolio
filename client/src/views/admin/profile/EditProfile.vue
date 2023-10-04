<template>
    <div class="profile">
        <AdminLayout>
            <div class="content-container">
                <div class="title-wrapper">
                    <router-link :to="{ name: 'view-profile' }" class="back-to-list-wrapper" data-toggle="tooltip"
                        data-placement="top" title="Return to view">
                        <div class="back-to-list">
                            <img src="@/assets/admin/images/back.png" class="back-icon" alt="Return to view" />
                        </div>
                    </router-link>
                    <h4>Edit Profile</h4>
                </div>
                <hr class="line" />

                <div class="content">
                    <div class="form-container">
                        <div class="row g-3">
                            <div class="col-lg-4 col-md-6 col-sm-12">
                                <label class="form-label">First Name</label>
                                <input v-model="model.firstName" type="text" class="form-control" placeholder="First Name">
                            </div>
                            <div class="col-lg-4 col-md-6 col-sm-12">
                                <label class="form-label">Last Name</label>
                                <input v-model="model.lastName" type="text" class="form-control" placeholder="Last Name">
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-lg-8 col-md-12 col-sm-12">
                                <label class="form-label">Email</label>
                                <div class="input-group has-validation">
                                    <input v-model="model.email" type="email" class="form-control" placeholder="Email">
                                </div>
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-lg-8 col-md-12 col-sm-12">
                                <label class="form-label">Headline</label>
                                <input v-model="model.headline" type="text" class="form-control" placeholder="Headline">
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-lg-8 col-md-12 col-sm-12">
                                <label class="form-label">About</label>
                                <textarea v-model="model.about" type="text" class="form-control"
                                    placeholder="About"></textarea>
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-lg-8 col-md-12 col-sm-12">
                                <label for="discription" class="form-label">Photo
                                    <span class="secondary-text">(Optional)</span>
                                </label>
                                <div class="edit-photo-wrapper">
                                    <div v-if="model.photo !== null && model.photo !== ''">
                                        <img :src="model.photo" class="view-profile-photo" :alt="model.firstName" />
                                    </div>
                                    <div class="photo-buttons-wrapper">
                                        <div class="button-container">

                                            <label for="file-upload" class="photo-btn update-btn">Upload</label>
                                            <input @change="uploadPhoto" id="file-upload" type="file" accept="image/*" />

                                            <div v-if="model.photo !== null && model.photo !== ''">
                                                <button v-on:click.prevent="removePhoto()"
                                                    class="photo-btn remove-btn">Remove</button>
                                            </div>
                                        </div>
                                        <span class="secondary-text">Recommended: Square JPG, PNG, or GIF, at least
                                            1,000 pixels per side.</span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6 col-md-8 col-sm-12 col-xs-12">
                                <div class="button-container">
                                    <button class="btn btn-save" v-on:click.prevent="update()">Save</button>
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
import profileService from '@/services/ProfileService'
import { useToast } from 'vue-toastification'
import { useRouter } from 'vue-router'
import { onMounted, ref } from 'vue'

const model = ref({})

async function loadData() {
    await profileService.get().then(response => {
        model.value = response.data
    })
}

onMounted(loadData)

function update() {
    const toast = useToast()
    try {
        profileService.update(model.value).then(response => {
            if (response.status == 200)
                toast.success("Profile edited successfully")

            const router = useRouter()
            //router.push('/admin/profile')
            router.push({ path: '/admin/profile' })

        })
    } catch (errorMsg) {
        toast.error("Something went wrong")
    }
}

function removePhoto() {
    model.value.photo = ''
}

function uploadPhoto(e) {
    const selectedImage = e.target.files[0]
    createBase64Image(selectedImage)
}

function createBase64Image(fileObject) {
    const reader = new FileReader()
    reader.onload = (e) => {
        model.value.photo = e.target.result
    }
    reader.readAsDataURL(fileObject)
}
</script>
