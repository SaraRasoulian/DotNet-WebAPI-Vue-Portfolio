<template>
    <div class="messages">
        <AdminLayout>
            <div class="content-container">
                <div class="view-wrapper">
                    <div class="title-wrapper">
                        <router-link :to="{ name: 'messages-list' }" class="back-to-list-wrapper" data-toggle="tooltip"
                            data-placement="top" title="Return to list">
                            <div class="back-to-list">
                                <img src="@/assets/admin/images/back.png" class="back-icon" alt="Return to list" />
                            </div>
                        </router-link>
                        <h4>View Message</h4>

                        <div class="buttons-wrapper">
                            <router-link :to="{ name: 'messages-delete', params: { id: 1 } }" class="list-button"
                                data-toggle="tooltip" data-placement="top" title="Delete">
                                <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="" />
                            </router-link>
                        </div>
                    </div>
                    <hr class="line" />

                    <div class="content">
                        <div class="form-container">
                            <div class="row g-3">
                                <div class="message-head">
                                    <div>
                                        <span class="bold">Alicia Berenson</span>
                                        <span> (alicia@example.com)</span>
                                    </div>
                                    <div class="buttons-wrapper">
                                        <span class="secondary-text">May 20, 2023, 11:52 PM (17 hours ago)</span>
                                    </div>
                                </div>
                                <p>Phasellus at velit magna. Vestibulum nec eros nunc. Nunc fringilla, mi sed volutpat
                                    venenatis, purus risus rutrum velit, sit amet semper justo orci non nunc. Aliquam
                                    erat volutpat. Nam elementum turpis eget sagittis ullamcorper.</p>
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

export default {
    components: {
        AdminLayout,
    }
}
</script>