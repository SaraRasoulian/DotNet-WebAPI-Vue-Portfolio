<template>
    <div class="experience">
        <AdminLayout>
            <div class="content-container">
                <div class="view-wrapper">
                    <div class="title-wrapper">
                        <router-link :to="{ name: 'experience-list' }" class="back-to-list-wrapper" data-toggle="tooltip"
                            data-placement="top" title="Return to list">
                            <div class="back-to-list">
                                <img src="@/assets/admin/images/back.png" class="back-icon" alt="Return" />
                            </div>
                        </router-link>
                        <h4>Edit Experience</h4>
                    </div>
                    <hr class="line" />

                    <div class="content">
                        <div class="form-container">
                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <label for="companyName" class="form-label">Company Name</label>
                                    <div class="input-group has-validation">
                                        <input type="text" v-model="model.companyName" class="form-control" id="companyName"
                                            placeholder="Company Name" maxlength="50" required>
                                    </div>
                                </div>
                            </div>                          

                            <div class="row g-3">
                                <div class="col-lg-4 col-md-6 col-sm-12">
                                    <label for="startYear" class="form-label">Start Year</label>
                                    <input type="text" v-model="model.startYear" class="form-control" id="startYear"
                                        placeholder="Start Year" maxlength="10" required>
                                </div>
                                <div class="col-lg-4 col-md-6 col-sm-12">
                                    <label for="endYear" class="form-label">End Year</label>
                                    <input type="text" v-model="model.endYear" class="form-control" id="endYear"
                                        placeholder="End Year" maxlength="10" required>
                                </div>
                            </div>

                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <label for="website" class="form-label">Website
                                        <span class="secondary-text">(Optional)</span>
                                    </label>
                                    <input type="text" v-model="model.website" class="form-control" id="website"
                                        placeholder="Website" maxlength="250" required>
                                </div>
                            </div>


                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <label for="description" class="form-label">Description
                                        <span class="secondary-text">(Optional)</span>
                                    </label>
                                    <textarea type="text" v-model="model.description" class="form-control" id="description"
                                        placeholder="description" maxlength="1000"></textarea>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6 col-md-8 col-sm-12 col-xs-12">
                                    <div class="button-container">
                                        <button class="btn btn-save" v-on:click.prevent="update()">Save</button>
                                        <router-link :to="{ name: 'experience-list' }"
                                            class="btn btn-cancel">Cancel</router-link>
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
import experiencesService from '@/services/experiencesService'
import { ref, onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useToast } from 'vue-toastification'

const model = ref([])
const router = useRouter()
const route = useRoute()
const id = route.params.id

async function loadData() {
    await experiencesService.get(id).then(response => {
        model.value = response.data
    })
}

async function update() {
    const toast = useToast()
    try {
        await experiencesService.update(id, model.value)
            .then(response => {
                router.push({ name: 'experience-list' })
                if (response.status == 200)
                    toast.success("Experience edited successfully")
            })
    } catch (errorMsg) {
        toast.error("Something went wrong")
    }
}

onMounted(loadData)
</script>