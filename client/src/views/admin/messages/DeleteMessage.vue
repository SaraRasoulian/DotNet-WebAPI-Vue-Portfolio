<template>
    <div class="messages">
        <AdminLayout>
            <div class="content-container">
                <div class="view-wrapper">
                    <div class="title-wrapper">
                        <router-link :to="{ name: 'message-list' }" class="back-to-list-wrapper" data-toggle="tooltip"
                            data-placement="top" title="Return to list">
                            <div class="back-to-list">
                                <img src="@/assets/admin/images/back.png" class="back-icon" alt="Return to list" />
                            </div>
                        </router-link>
                        <h4>Delete Message</h4>
                    </div>
                    <hr class="line" />

                    <div class="content">
                        <div class="form-container">
                            <div class="row g-3">
                                <div class="message-head">
                                    <div>
                                        <span class="bold">{{ model.name }}</span>
                                        <span> ({{ model.email }})</span>
                                    </div>
                                    <div class="buttons-wrapper">
                                        <span class="secondary-text">{{ model.sentAt }} ({{ model.timeAgo }})</span>
                                    </div>
                                </div>
                                <p>{{ model.content }}</p>
                            </div>

                            <div class="row">
                                <div class="col-lg-6 col-md-8 col-sm-12 col-xs-12">
                                    <div class="button-container">
                                        <button class="btn btn-delete" v-on:click.prevent="remove()">Delete</button>
                                        <router-link :to="{ name: 'message-list' }"
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
import messagesService from '@/services/messagesService'
import { ref, onMounted } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useToast } from 'vue-toastification'

const model = ref([])
const router = useRouter()
const route = useRoute()
const id = route.params.id

async function loadData() {
    await messagesService.get(id).then(response => {
        model.value = response.data
    })
}

async function remove() {
    const toast = useToast()
    try {
        await messagesService.delete(id).then(response => {
            router.push({ name: 'message-list' })
            if (response.status == 200)
                toast.success("Message deleted successfully")
        })
    } catch (errorMsg) {
        toast.error("Something went wrong")
    }
}

onMounted(loadData)
</script>