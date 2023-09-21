<template>
  <div class="section fade-in-on-load">
    <div class="profile">
      <div class="row">
        <div class="eight columns">
          <h1 class="profile-titr">{{ model.headline }}</h1>
          <p class="profile-text">{{ model.about }}</p>
        </div>
        <div class="four columns img-wrapper">
          <img class="profile-img" :src="model.photo" :alt="model.firstName +' '+ model.lastName">
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import profileService from '@/services/profileService'
export default {
  data() {
    return {
      model: [],
    };
  },
  methods: {
    async loadData() {
      await profileService.get().then(response => {
        this.model = response.data
      })
    },
  },
  mounted() {
    this.loadData()
  }
}
</script>


