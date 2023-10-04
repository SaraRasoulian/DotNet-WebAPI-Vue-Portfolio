<template>
    <div class="education">
        <AdminLayout>
            <div class="content-container">
                <div class="view-wrapper">
                    <div class="title-wrapper">
                        <router-link :to="{ name: 'education-list' }" class="back-to-list-wrapper" data-toggle="tooltip"
                            data-placement="top" title="Return to list">
                            <div class="back-to-list">
                                <img src="@/assets/admin/images/back.png" class="back-icon" alt="Return to list" />
                            </div>
                        </router-link>
                        <h4>View Education</h4>
                        <div class="buttons-wrapper">
                            <router-link :to="{ name: 'edit-education', params: { id: id } }" class="list-button"
                                data-toggle="tooltip" data-placement="top" title="Edit">
                                <img src="@/assets/admin/images/edit.svg" class="list-button-icon" alt="Edit" />
                            </router-link>

                            <router-link :to="{ name: 'delete-education', params: { id: id } }" class="list-button"
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
                                            <span>Degree</span>
                                            <p>{{ model.degree }}</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="row g-3">
                                    <div class="col-lg-8 col-md-12 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>Field of study</span>
                                            <p>{{ model.fieldOfStudy }}</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="row g-3">
                                    <div class="col-lg-8 col-md-12 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>School</span>
                                            <p>{{ model.school }}</p>
                                        </div>
                                    </div>
                                </div>

                                <div class="row g-3">
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>Start Year</span>
                                            <p>{{ model.startYear }}</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>End Year</span>
                                            <p>{{ model.endYear }}</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="row g-3" v-if="model.description !== ''">
                                    <div class="col-lg-8 col-md-12 col-sm-12">
                                        <div class="view-item-wrapper">
                                            <span>Description</span>
                                            <p>{{ model.description }}</p>
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
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import AdminLayout from '@/layouts/admin/Layout.vue'
import educationsService from '@/services/educationsService'

const model = ref([])
const route = useRoute()
const id = route.params.id

async function loadData() {
    await educationsService.get(id).then(response => {
        model.value = response.data
    })
}

onMounted(loadData)
</script>