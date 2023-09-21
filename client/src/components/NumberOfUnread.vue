<template>
  <h6 v-if="unread > 0" class="badge-wrapper"><span class="badge badge-unread">{{ unread }}</span></h6>
</template>

<script>
import messagesService from '@/services/messagesService'
export default {
  data() {
    return {
      unread: 0,
    };
  },
  methods: {
    async getUnRead() {
      await messagesService.GetNumberOfUnread().then(response => {
        this.unread = response.data
      })
    },
  },
  mounted() {
    this.getUnRead()
  }
}
</script>


