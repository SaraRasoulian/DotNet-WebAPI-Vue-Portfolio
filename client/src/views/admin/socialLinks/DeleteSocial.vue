<template>
    <div class="social">
        <AdminLayout>
            <div class="content-container">
                <div class="view-wrapper">
                    <div class="title-wrapper">
                        <router-link :to="{ name: 'social-list' }" class="back-to-list-wrapper" data-toggle="tooltip"
                            data-placement="top" title="Return to list">
                            <div class="back-to-list">
                                <img src="@/assets/admin/images/back.png" class="back-icon" alt="Return" />
                            </div>
                        </router-link>
                        <h4>Delete Social Link</h4>
                    </div>
                    <hr class="line" />

                    <div class="content">
                        <div class="form-container">
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

                            <div class="row g-3">
                                <div class="col-lg-8 col-md-12 col-sm-12">
                                    <label for="discription" class="form-label">Icon</label>
                                    <div class="edit-photo-wrapper">
                                        <div v-if="model.icon !== null && model.icon !== ''">
                                            <img :src="model.icon" class="view-profile-photo" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6 col-md-8 col-sm-12 col-xs-12">
                                    <div class="button-container">
                                        <button class="btn btn-delete" v-on:click.prevent="remove()">Delete</button>
                                        <router-link :to="{ name: 'social-list' }"
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
import socialLinksService from '@/services/socialLinksService'
import { ref, onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useToast } from 'vue-toastification'

const model = ref([])
const router = useRouter()
const route = useRoute()
const id = route.params.id

async function loadData() {
    await socialLinksService.get(id).then(response => {
        model.value = response.data
    })
}

async function remove() {
    const toast = useToast()
    try {
        await socialLinksService.delete(id).then(response => {
            router.push({ name: 'social-list' })
            if (response.status == 200)
                toast.success("Social link deleted successfully")
        })
    } catch (errorMsg) {
        toast.error("Something went wrong")
    }
}

onMounted(loadData)
</script>