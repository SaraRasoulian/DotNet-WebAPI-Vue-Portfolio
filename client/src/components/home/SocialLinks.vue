<template>
    <div v-if="list.length > 0" class="section">
        <div class="section-header">
            <img src="@/assets/home/images/contact.png" class="section-header-icon">
            <h3 class="section-titr">Contact</h3>
            <div class="section-line"></div>
        </div>
        <div class="section-content">
            <div class="social center-content">
                <div v-for="item in list" :key="item.id" class="social-item">
                    <a :href="item.url" target="_self" class="hvr-underline-from-left">
                        <div class="social-item-inner">
                            <img :src="item.icon" class="social-item-img">
                            <span class="social-title">{{ item.name }}</span>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import socialLinksService from '@/services/socialLinksService'
import { onMounted, ref } from 'vue'

const list = ref([])

async function getList() {
  await socialLinksService.getAll().then(response => {
    list.value = response.data
  })
}

onMounted(getList)
</script>