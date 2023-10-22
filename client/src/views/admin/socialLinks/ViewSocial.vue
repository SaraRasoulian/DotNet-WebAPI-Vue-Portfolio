<template>
    <div class="education">
        <AdminLayout>
            <div class="content-container">
                <div class="view-wrapper">
                    <div class="title-wrapper">
                        <router-link :to="{ name: 'social-list' }" class="back-to-list-wrapper" data-toggle="tooltip"
                            data-placement="top" title="Return to list">
                            <div class="back-to-list">
                                <img src="@/assets/admin/images/back.png" class="back-icon" alt="Return to list" />
                            </div>
                        </router-link>
                        <h4>View Social Link</h4>
                        <div class="buttons-wrapper">
                            <router-link :to="{ name: 'edit-social', params: { id: id } }" class="list-button"
                                data-toggle="tooltip" data-placement="top" title="Edit">
                                <img src="@/assets/admin/images/edit.svg" class="list-button-icon" alt="Edit" />
                            </router-link>

                            <router-link :to="{ name: 'delete-social', params: { id: id } }" class="list-button"
                                data-toggle="tooltip" data-placement="top" title="Delete">
                                <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="Delete" />
                            </router-link>
                        </div>
                    </div>
                    <hr class="line" />

                    <div class="content">
                        <div class="form-container">
                            <div>
                                <div class="row g-3">
                                    <div class="col-lg-8 col-md-12 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>Name</span>
                                            <p>{{ model.name }}</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="row g-3">
                                    <div class="col-lg-8 col-md-12 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>URL</span>
                                            <p>{{ model.url }}</p>
                                        </div>
                                    </div>
                                </div>

                                <div v-if="model.icon !== null && model.icon !== ''">
                                    <div class="row g-3">
                                        <div class="col-lg-8 col-md-12 col-sm-12">
                                            <div class="view-item-wrapper">
                                                <span>Icon</span>
                                                <img :src="model.icon" class="view-profile-photo" :alt="model.name">
                                            </div>
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

<script setup>
import AdminLayout from '@/layouts/admin/Layout.vue'
import socialLinksService from '@/services/socialLinksService'
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'

const model = ref([])
const route = useRoute()
const id = route.params.id

async function loadData() {
    await socialLinksService.get(id).then(response => {
        model.value = response.data
    })
}

onMounted(loadData)
</script>