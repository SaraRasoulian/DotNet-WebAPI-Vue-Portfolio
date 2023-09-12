<template>
    <div class="messages">
        <AdminLayout>
            <div class="content-container noselect">
                <div class="title-wrapper parent-page-title">
                    <div class="list-title">
                        <h4>Messages</h4>
                        <div class="list-total">
                            <span>5</span>
                            <span>total</span>
                        </div>
                    </div>
                </div>

                <hr class="line" />

                <div class="content">
                    <!--list header-->
                    <div class="list-header">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-12"><span>Name</span></div>
                            <div class="col-lg-3 col-md-3 col-sm-12"><span>Email</span></div>
                            <div class="col-lg-3 col-md-3 col-sm-12"><span>Content</span></div>
                        </div>
                        <div class="message-control-header">
                            <span>Controls</span>
                        </div>
                    </div>

                    <!--list items-->
                    <div class="list-item un-read">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-12"><span>Miguel Fernandez</span></div>
                            <div class="col-lg-3 col-md-3 col-sm-12">
                                <p class="truncated truncated-email">miguel.fernandez@example.com</p>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <p class="truncated">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed
                                    ultricies eu erat at ultricies.</p>
                            </div>
                        </div>
                        <div class="buttons-wrapper">
                            <router-link :to="{ name: 'messages-view', params: { id: 1 } }" class="list-button"
                                data-toggle="tooltip" data-placement="top" title="View">
                                <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="View" />
                            </router-link>
                            <router-link :to="{ name: 'messages-delete', params: { id: 1 } }" class="list-button"
                                data-toggle="tooltip" data-placement="top" title="Delete">
                                <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="Delete" />
                            </router-link>
                        </div>
                    </div>
                    <hr class="line" />

                    <div class="list-item un-read">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-12"><span>Alicia Berenson</span></div>
                            <div class="col-lg-3 col-md-3 col-sm-12">
                                <p class="truncated truncated-email">alicia@example.com</p>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <p class="truncated">Phasellus at velit magna. Vestibulum nec eros nunc. Nunc fringilla,
                                    mi sed volutpat venenatis, purus risus rutrum velit, sit amet semper justo orci non
                                    nunc. Aliquam erat volutpat. Nam elementum turpis eget sagittis ullamcorper.</p>
                            </div>
                        </div>
                        <div class="buttons-wrapper">
                            <a href="message-view.html" class="list-button" data-toggle="tooltip" data-placement="top"
                                title="View">
                                <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="" />
                            </a>
                            <a href="message-delete.html" class="list-button" data-toggle="tooltip" data-placement="top"
                                title="Delete">
                                <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="" />
                            </a>
                        </div>
                    </div>
                    <hr class="line" />

                    <div class="list-item">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-12"><span>Sofia Petrova</span></div>
                            <div class="col-lg-3 col-md-3 col-sm-12">
                                <p class="truncated truncated-email">sofia.petrova@example.com</p>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <p class="truncated">Sed viverra elit vel felis rutrum iaculis. Sed fringilla elit ut
                                    posuere mollis.</p>
                            </div>
                        </div>
                        <div class="buttons-wrapper">
                            <a href="message-view.html" class="list-button" data-toggle="tooltip" data-placement="top"
                                title="View">
                                <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="" />
                            </a>
                            <a href="message-delete.html" class="list-button" data-toggle="tooltip" data-placement="top"
                                title="Delete">
                                <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="" />
                            </a>
                        </div>
                    </div>
                    <hr class="line" />

                    <div class="list-item">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-12"><span>Alexander Parker</span></div>
                            <div class="col-lg-3 col-md-3 col-sm-12">
                                <p class="truncated truncated-email">alex.parker@example.com</p>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <p class="truncated">Aliquam tempor, nulla eget tristique congue, nisl enim tincidunt
                                    justo, ut faucibus purus sem id leo. Nulla facilisi.</p>
                            </div>
                        </div>
                        <div class="buttons-wrapper">
                            <a href="message-view.html" class="list-button" data-toggle="tooltip" data-placement="top"
                                title="View">
                                <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="" />
                            </a>
                            <a href="message-delete.html" class="list-button" data-toggle="tooltip" data-placement="top"
                                title="Delete">
                                <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="" />
                            </a>
                        </div>
                    </div>
                    <hr class="line" />

                    <div class="list-item">
                        <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-12"><span>Muhammad Ali</span></div>
                            <div class="col-lg-3 col-md-3 col-sm-12">
                                <p class="truncated truncated-email">muhammad.ali@example.com</p>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-12">
                                <p class="truncated">Nam elementum turpis eget sagittis ullamcorper. Pellentesque
                                    habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.
                                </p>
                            </div>
                        </div>
                        <div class="buttons-wrapper">
                            <a href="message-view.html" class="list-button" data-toggle="tooltip" data-placement="top"
                                title="View">
                                <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="" />
                            </a>
                            <a href="message-delete.html" class="list-button" data-toggle="tooltip" data-placement="top"
                                title="Delete">
                                <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="" />
                            </a>
                        </div>
                    </div>
                    <hr class="line" />

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