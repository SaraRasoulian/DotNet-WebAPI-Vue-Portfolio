<template>
    <div class="profile">
        <AdminLayout>
            <div class="content-container">
                <div class="title-wrapper">
                    <router-link :to="{ name: 'profile-view' }" class="back-to-list-wrapper" data-toggle="tooltip"
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
                                    <router-link :to="{ name: 'profile-view' }" class="btn btn-cancel">Cancel</router-link>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </AdminLayout>
    </div>
</template>

<script>
import AdminLayout from '@/layouts/admin/Layout.vue'
import profileService from '@/services/ProfileService'
import { useToast } from 'vue-toastification'

export default {
    components: {
        AdminLayout,
    },
    data() {
        return {
            model: [],
        }
    },
    methods: {
        async loadData() {
            await profileService.get().then(response => {
                this.model = response.data
            })
        },
        async update() {
            const toast = useToast()
            try {
                await profileService.update(this.model).then(response => {
                    this.$router.push("/admin/profile")
                    if (response.status == 200)
                        toast.success("Profile edited successfully")
                })
            } catch (errorMsg) {
                toast.error("Something went wrong")
            }
        },
        removePhoto() {
            this.model.photo = ''
        },
        uploadPhoto(e) {
            const selectedImage = e.target.files[0]
            this.createBase64Image(selectedImage)
        },
        createBase64Image(fileObject) {
            const reader = new FileReader()
            reader.onload = (e) => {
                this.model.photo = e.target.result
            }
            reader.readAsDataURL(fileObject)
        },
    },
    mounted() {
        this.loadData()
    }
}
</script>