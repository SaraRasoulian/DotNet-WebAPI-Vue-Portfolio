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
                                <div class="input-group has-validation">
                                    <input type="password" class="form-control" placeholder="Current password">
                                </div>
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-lg-8 col-md-12 col-sm-12">
                                <label class="form-label">New password</label>
                                <input type="password" class="form-control" placeholder="New password">
                            </div>
                        </div>

                        <div class="row g-3">
                            <div class="col-lg-8 col-md-12 col-sm-12">
                                <label class="form-label">Confirm new password</label>
                                <input type="password" class="form-control" placeholder="Confirm new password">
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6 col-md-8 col-sm-12 col-xs-12">
                                <div class="button-container">
                                    <button class="btn btn-save">Save</button>
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
</script>