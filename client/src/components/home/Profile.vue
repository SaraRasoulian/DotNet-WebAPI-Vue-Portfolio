<template>
  <div class="section fade-in-on-load">
    <div class="profile">
      <div class="row">
        <div class="columns" :class="{ 'eight': model.photo !== null && model.photo !== '' }">
          <h1 class="profile-titr">{{ model.headline }}</h1>
          <p class="profile-text">{{ model.about }}</p>
        </div>
        <div v-if="model.photo !== null && model.photo !== ''" class="four columns img-wrapper">
          <img class="profile-img" :src="model.photo" :alt="model.firstName + ' ' + model.lastName">
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import profileService from '@/services/profileService'
import { onMounted } from 'vue'
import { ref } from 'vue'

const model = ref({})

async function getProfile() {
  await profileService.get().then(response => {
    model.value = response.data
  })
}

onMounted(getProfile)
</script>