<template>
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
                    <form class="needs-validation">

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
                                    <img src="assets/admin/images/profile-photo.png" class="view-profile-photo" alt="" />
                                    <div class="photo-buttons-wrapper">
                                        <div>
                                            <button class="photo-btn update-btn" type="button">Update</button>
                                            <button class="photo-btn remove-btn" type="button">Remove</button>
                                        </div>
                                        <span class="secondary-text">Recommended: Square JPG, PNG, or GIF, at least 1,000
                                            pixels
                                            per side.</span>
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
                    </form>
                </div>
            </div>
        </div>
    </AdminLayout>
</template>

<script>
import AdminLayout from '@/layouts/admin/Layout.vue'
import axios from "axios"
import api from '@/common/api.js'
import { useToast } from "vue-toastification"

export default {
    components: {
        AdminLayout,
    },
    data() {
        return {
            model: [],
        };
    },
    methods: {
        loadData() {
            axios.get(api.url + '/api/profiles').then(response => {
                this.model = response.data;
            });
        },
        update() {
            const toast = useToast();
            axios.put(api.url + '/api/profiles', this.model)
                .then(response => {
                    console.log('Response: ', response.status)

                    this.$router.push("/admin/profile")

                    if (response.status == 200) {
                        toast.success("Profile edited successfully")
                    }

                })
                .catch(error => {
                    this.errorMessage = error.message;
                    console.error("There was an error!", error)
                    toast.error("Something went wrong")
                })
        }
    },
    mounted() {
        this.loadData()
    }
}
</script>