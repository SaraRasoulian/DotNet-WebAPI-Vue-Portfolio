<template>
    <div class="gradient-wrapper">
        <div class="container">
            <div class="gradient gradient-top-left"></div>
            <div class="gradient gradient-top-mid"></div>
            <div class="gradient gradient-top-right"></div>
            <HomeHeader />
            <div class="gradient gradient-right fade-in-on-scroll"></div>
            <div class="gradient gradient-right-sm fade-in-on-scroll"></div>
            <Profile class="fade-in-on-scroll" />
            <div class="gradient gradient-left fade-in-on-scroll"></div>
            <div class="gradient gradient-left-sm fade-in-on-scroll"></div>
            <Experiences class="fade-in-on-scroll" />
            <Educations class="fade-in-on-scroll" />
            <SocialLinks class="fade-in-on-scroll" />
            <SendMessage class="fade-in-on-scroll" />
            <div class="gradient gradient-bottom-left"></div>
            <div class="gradient gradient-bottom-left-sm"></div>
            <div class="gradient gradient-bottom-right"></div>
            <div class="gradient gradient-bottom-right-sm"></div>
        </div>
        <HomeFooter />
    </div>
</template>

<style>
@import '@/assets/home/css/reset.css';
@import '@/assets/home/css/skeleton.css';
@import '@/assets/home/css/style.css';
@import '@/assets/home/css/animated-gradient.css';
</style>

<script setup>
import Profile from "@/components/home/Profile.vue"
import Experiences from "@/components/home/Experiences.vue"
import Educations from "@/components/home/Educations.vue"
import SocialLinks from "@/components/home/SocialLinks.vue"
import SendMessage from "@/components/home/SendMessage.vue"
import HomeHeader from "@/components/home/HomeHeader.vue"
import HomeFooter from "@/components/home/HomeFooter.vue"

import { ref, onMounted, onBeforeUnmount } from "vue"

const pageTop = ref(0)
const pageBottom = ref(0)
const tags = ref([])

onMounted(() => {
    window.addEventListener("scroll", checkVisibility)
    checkVisibility()
})

onBeforeUnmount(() => {
    window.removeEventListener("scroll", checkVisibility)
})

const checkVisibility = () => {
    pageTop.value = window.pageYOffset || document.documentElement.scrollTop
    pageBottom.value = pageTop.value + window.innerHeight

    tags.value = document.querySelectorAll(".fade-in-on-scroll")

    tags.value.forEach((tag) => {
        const tagTop = tag.getBoundingClientRect().top + pageTop.value
        if (tagTop < pageBottom.value) {
            tag.classList.add("visible")
        } else {
            tag.classList.remove("visible")
        }
    })
}
</script>