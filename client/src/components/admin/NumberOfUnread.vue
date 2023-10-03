<template>
  <h6 v-if="unread > 0" class="badge-wrapper"><span class="badge badge-unread">{{ unread }}</span></h6>
</template>

<script setup>
import messagesService from '@/services/messagesService'
import { ref } from 'vue'
import { onMounted } from 'vue'

const unread = ref(0)

async function getUnRead() {
  await messagesService.GetNumberOfUnread().then(response => {
    unread.value = response.data
  })
}

onMounted(() => {
  getUnRead()
})
</script>