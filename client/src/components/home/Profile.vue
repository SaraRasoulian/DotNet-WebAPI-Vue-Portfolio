<template>
  <div class="section">
    <h2 v-if="loading">Loading....</h2>
    <div v-else class="profile">
      <div class="row">
        <div class="columns" :class="{ 'eight': model.photo !== null && model.photo !== '' }">
          <h2 class="profile-title">{{ model.headline }}</h2>
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
import { onMounted, ref } from 'vue'

const loading = ref(true)
const model = ref({})

async function loadData() {
  try {
    const response = await profileService.get()
    model.value = response.data
  } finally {
    loading.value = false
  }
}

onMounted(loadData)
</script>
