<template>
    <div class="animated-gradient-del">
        <div class="texture">
            <div class="container">
                <div class="gradient-1"></div>
                <div class="gradient-2"></div>
                <div class="gradient-3"></div>
                <HomeHeader />

                <Profile class="fade-in-on-scroll" />

                <Experiences class="fade-in-on-scroll" />

                <Educations class="fade-in-on-scroll" />

                <SocialLinks class="fade-in-on-scroll" />

                <SendMessage class="fade-in-on-scroll" />
            </div>
            <HomeFooter />
        </div>
    </div>
</template>

<style>
@import '@/assets/home/css/reset.css';
@import '@/assets/home/css/skeleton.css';
@import '@/assets/home/css/style.css';
@import '@/assets/home/css/radial-gradient.css';
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