<template>
    <AdminLayout>
        <div class="content-container">
            <div class="view-wrapper">

                <div class="title-wrapper parent-page-title">
                    <div class="list-title">
                        <h4>View Profile</h4>
                    </div>
                    <div class="buttons-wrapper">
                        <RouterLink to="/profile/edit" class="list-button" data-toggle="tooltip" data-placement="top"
                            title="Edit">
                            <img src="@/assets/images/edit.svg" class="list-button-icon" alt="">
                        </RouterLink>
                    </div>
                </div>

                <hr class="line" />

                <div class="content">
                    <div class="form-container">
                        <div>

                            <div class="row g-3">
                                <div class="col-lg-4 col-md-6 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>First Name</span>
                                        <p>Sara</p>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>Last Name</span>
                                        <p>Rasoulian</p>
                                    </div>
                                </div>
                            </div>

                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>Email</span>
                                        <p>Example@gmail.com</p>
                                    </div>
                                </div>
                            </div>

                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>Headline</span>
                                        <p>My name is Sara</p>
                                    </div>
                                </div>
                            </div>

                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>About</span>
                                        <p>In publishing and graphic design, Lorem ipsum is a placeholder text commonly used
                                            to
                                            demonstrate the visual form of a document or a typeface without relying on
                                            meaningful content. Lorem ipsum may be used as a placeholder before final copy
                                            is
                                            available.</p>
                                    </div>
                                </div>
                            </div>

                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <div class="view-item-wrapper">
                                        <span>Photo</span>
                                        <img src="assets/images/profile-photo.png" class="view-profile-photo" alt="">
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </AdminLayout>
</template>

<script>
import AdminLayout from '@/layouts/AdminLayout.vue'

export default {
    components: {
        AdminLayout,
    }
}
</script>