<template>
    <div class="animated-gradient">
        <div class="texture">
            <div class="container">

                <!-- Header -->
                <div class="header">
                    <div class="text fade-in-text">
                        <h5 class="text-sm">SO NICE TO</h5>
                        <h1 class="text-lg">Meet you</h1>
                    </div>
                </div>

                <Profile />

                <Experiences />

                <Educations />

                <SocialLinks />

                <Messages />
            </div>

            <!-- Footer -->
            <div class="footer">
                <h6 class="footer-text">Designed and Developed by <a href="#" target="_self">Sara Rasoulian</a></h6>
            </div>
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
import Messages from '@/components/home/Messages.vue'

export default {
    name: 'App',
    components: {
        Profile,
        Experiences,
        Educations,
        SocialLinks,
        Messages
    }
}
</script>