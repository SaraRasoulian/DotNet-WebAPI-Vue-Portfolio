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
                        <h4>View Message</h4>

                        <div class="buttons-wrapper">
                            <router-link :to="{ name: 'delete-message', params: { id: model.id } }" class="list-button"
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
                                        <span class="bold">{{ model.name }}</span>
                                        <span> ({{ model.email }})</span>
                                    </div>
                                    <div class="buttons-wrapper">
                                        <span class="secondary-text">{{ model.sentAt }} ({{ model.timeAgo }})</span>
                                    </div>
                                </div>
                                <p>{{ model.content }}</p>
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
import { useRoute } from 'vue-router'

const model = ref([])
const route = useRoute()
const id = route.params.id

async function loadData() {
    await messagesService.get(id).then(response => {
        model.value = response.data
    })
}
async function markAsRead() {
    await messagesService.markAsRead(id)
}

onMounted(() => {
    loadData()
    markAsRead()
})
</script>