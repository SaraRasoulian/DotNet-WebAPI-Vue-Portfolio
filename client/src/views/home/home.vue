<template>
    <div class="animated-gradient">
        <div class="texture">
            <div class="container">
                <HomeHeader />

                <Profile />

                <Experiences />

                <Educations />

                <SocialLinks />

                <SendMessage />
            </div>
            <HomeFooter />
        </div>
    </div>
</template>

<style>
@import '@/assets/home/css/reset.css';
@import '@/assets/home/css/skeleton.css';
@import '@/assets/home/css/style.css';
</style>

<script>
import Profile from '@/components/home/Profile.vue'
import Experiences from '@/components/home/Experiences.vue'
import Educations from '@/components/home/Educations.vue'
import SocialLinks from '@/components/home/SocialLinks.vue'
import SendMessage from '@/components/home/SendMessage.vue'
import HomeHeader from '@/components/home/HomeHeader.vue'
import HomeFooter from '@/components/home/HomeFooter.vue'

export default {
    name: 'App',
    components: {
        Profile,
        Experiences,
        Educations,
        SocialLinks,
        SendMessage,
        HomeHeader,
        HomeFooter
    }
}
</script>