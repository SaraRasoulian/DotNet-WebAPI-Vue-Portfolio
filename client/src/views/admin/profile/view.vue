<template>
    <div class="profile">
        <AdminLayout>
            <div class="content-container">
                <div class="view-wrapper">

                    <div class="title-wrapper parent-page-title">
                        <div class="list-title">
                            <h4>View Profile</h4>
                        </div>
                        <div class="buttons-wrapper">
                            <router-link :to="{ name: 'profile-edit' }" class="list-button" data-toggle="tooltip"
                                data-placement="top" title="Edit">
                                <img src="@/assets/admin/images/edit.svg" class="list-button-icon" alt="Edit">
                            </router-link>
                        </div>
                    </div>

                    <hr class="line" />

                    <div class="content">
                        <div class="form-container">
                            <div class="row g-3">
                                <div class="col-lg-4 col-md-6 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>First Name</span>
                                        <p>{{ model.firstName }}</p>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>Last Name</span>
                                        <p>{{ model.lastName }}</p>
                                    </div>
                                </div>
                            </div>

                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>Email</span>
                                        <p>{{ model.email }}</p>
                                    </div>
                                </div>
                            </div>

                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>Headline</span>
                                        <p>{{ model.headline }}</p>
                                    </div>
                                </div>
                            </div>

                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>About</span>
                                        <p>{{ model.about }}</p>
                                    </div>
                                </div>
                            </div>

                            <div v-if="model.photo !== null && model.photo !== ''">
                                <div class="row g-3">
                                    <div class="col-lg-8 col-md-12 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>Photo</span>
                                            <img :src="model.photo" class="view-profile-photo" :alt="model.firstName">
                                        </div>
                                    </div>
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
import profileService from '@/services/profileService'

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
        async loadData() {
            await profileService.get().then(response => {
                this.model = response.data
            })
        },
    },
    mounted() {
        this.loadData()
    }
}
</script>