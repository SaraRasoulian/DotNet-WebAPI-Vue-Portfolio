<template>
  <div v-if="list.length > 0" class="section fade-in-on-scroll">
    <div class="section-header">
      <img src="@/assets/home/images/education.png" class="section-header-icon">
      <h3 class="section-titr">My Study</h3>
      <div class="section-line"></div>
    </div>
    <div class="section-content">
      <div v-for="item in list" :key="item.id" class="timeline-item row">
        <div class="timeline-item-header">
          <p>{{ item.degree }}, {{ item.fieldOfStudy }}</p>
        </div>
        <div>
          <p>{{ item.school }}</p>
          <p>{{ item.description }}</p>
          <p>{{ item.startYear }} - {{ item.endYear }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import educationsService from '@/services/educationsService'

export default {
  data() {
    return {
      list: []
    }
  },
  methods: {
    async getList() {
      await educationsService.getAll().then(response => {
        this.list = response.data
        console.log('List: ', this.list.length)
      })
    },
  },
  mounted() {
    this.getList()
  }
}
</script>