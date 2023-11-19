<template>
    <div v-if="list.length > 0" class="section">
        <div class="section-header">
            <img src="@/assets/home/images/journey.png" class="section-header-icon">
            <h3 class="section-titr">My Journey</h3>
            <div class="section-line"></div>
        </div>
        <div class="section-content">
            <div v-for="item in list" :key="item.id" class="timeline-item row">
                <div class="three columns">
                    <div class="timeline-item-header">
                        <a :href="item.website" target="_self">
                            <p>{{ item.companyName }}</p>
                        </a>
                        <p>{{ item.startYear }} - {{ item.endYear }}</p>
                    </div>
                </div>
                <div class="nine columns">
                    <p>{{ item.description }}</p>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import experiencesService from '@/services/experiencesService'
import { onMounted, ref } from 'vue'

const list = ref([])

async function getList() {
    await experiencesService.getAll().then(response => {
        list.value = response.data
    })
}

onMounted(getList)
</script>