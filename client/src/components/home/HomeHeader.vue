<template>
    <div class="header">
        <div class="header-text-wrapper fade-in-text">
            <h5 class="text-sm">so nice to</h5>
            <h1 class="text-lg">Meet you</h1>
        </div>
        <img ref="scrollDownIcon" src="@/assets/home/images/scroll-down.gif" class="scroll-down fade-out-on-scroll">
    </div>
</template>
<script setup>
import { ref, onMounted } from 'vue'

// Fade out on scroll down
const scrollY = ref(0)
const scrollDownIcon = ref(null)

const handleScroll = () => {
    scrollY.value = window.scrollY
    if (scrollY.value >= 100) {
        scrollDownIcon.value.classList.add('fade-out')
    } else {
        scrollDownIcon.value.classList.remove('fade-out')
    }
}
onMounted(() => {
    // Listen for the scroll event
    window.addEventListener('scroll', handleScroll)
})
</script>