<template>
    <div class="messages">
        <AdminLayout>
            <div class="content-container noselect">
                <div class="title-wrapper parent-page-title">
                    <div class="list-title">
                        <h4>Messages</h4>
                        <div class="list-total">
                            <span>{{ list.length }}</span>
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
                    <div v-for="item in list" :key="item.id">
                        <div class="list-item" :class="{ 'un-read' : !item.isRead }">
                            <div class="row">
                                <div class="col-lg-3 col-md-3 col-sm-12">
                                    <span>{{ item.name }}</span>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-12">
                                    <p class="truncated truncated-email">{{ item.email }}</p>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-12">
                                    <p class="truncated">{{ item.content }}</p>
                                </div>
                            </div>
                            <div class="buttons-wrapper">
                                <router-link :to="{ name: 'view-message', params: { id: item.id } }" class="list-button"
                                    data-toggle="tooltip" data-placement="top" title="View">
                                    <img src="@/assets/admin/images/view.png" class="list-button-icon" alt="View" />
                                </router-link>
                                <router-link :to="{ name: 'delete-message', params: { id: item.id } }" class="list-button"
                                    data-toggle="tooltip" data-placement="top" title="Delete">
                                    <img src="@/assets/admin/images/delete.svg" class="list-button-icon" alt="Delete" />
                                </router-link>
                            </div>
                        </div>
                        <hr class="line" />
                    </div>
                </div>
            </div>
        </AdminLayout>
    </div>
</template>

<script setup>
import AdminLayout from '@/layouts/admin/Layout.vue'
import messagesService from '@/services/messagesService'
import { onMounted, ref } from 'vue'

const list = ref([])

async function getList() {
  await messagesService.getAll().then(response => {
    list.value = response.data
  })
}

onMounted(getList)
</script>