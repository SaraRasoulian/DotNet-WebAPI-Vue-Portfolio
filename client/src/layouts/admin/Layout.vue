<script setup>
import { RouterLink } from 'vue-router'
</script>
<template>
    <div class="" :class="{ 'min-sidebar': isSidebarMinimized }">
        <div class="desktop-navbar noselect">
            <!-- Header -->
            <div class="fixed-top header wraper">
                <nav class="top-navbar navbar navbar-expand-lg">
                    <div class="container">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item dropdown">
                                <a class="nav-link dropdown-toggle wraper-div" href="#" data-bs-toggle="dropdown"
                                    aria-expanded="false">
                                    <img src="@/assets/admin/images/profile-photo.png" class="profile-photo" alt="">
                                    <span>Sara</span>
                                </a>
                                <ul class="dropdown-menu">
                                    <li>
                                        <router-link :to="{ name: 'edit-profile' }" class="dropdown-item">
                                            <img src="@/assets/admin/images/profile.png" class="sidebar-icon dropdown-icon"
                                                alt="Edit profile">
                                            Edit profile
                                        </router-link>
                                    </li>
                                    <li>
                                        <a class="dropdown-item" href="#">
                                            <img src="@/assets/admin/images/password.png" class="sidebar-icon dropdown-icon"
                                                alt="">
                                            Password
                                        </a>
                                    </li>
                                    <li>
                                        <router-link :to="{ name: 'login' }" class="dropdown-item">
                                            <img src="@/assets/admin/images/logout.png" class="sidebar-icon dropdown-icon"
                                                alt="Log out">
                                            Log out
                                        </router-link>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
            <!-- Sidebar -->
            <div class="sidebar">
                <ul class="nav flex-column">

                    <li class="sidebar-title">
                        <div class="toggle-sidebar-wrapper">
                            <div class="toggle-sidebar" v-on:click="toggleSidebar">
                                <img src="@/assets/admin/images/menu.svg" class="sidebar-icon" alt="">
                            </div>
                            <span>Admin Panel</span>
                        </div>
                    </li>

                    <li class="nav-item nav-profile">
                        <router-link :to="{ name: 'view-profile' }" class="nav-link">
                            <div class="nav-link-inner">
                                <img src="@/assets/admin/images/profile.png" class="sidebar-icon" alt="">
                                <span>Profile</span>
                            </div>
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">
                            <div class="nav-link-inner">
                                <img src="@/assets/admin/images/experiences.png" class="sidebar-icon" alt="">
                                <span>Experiences</span>
                            </div>
                        </a>
                    </li>
                    <li class="nav-item nav-educations">
                        <router-link :to="{ name: 'education-list' }" class="nav-link">
                            <div class="nav-link-inner">
                                <img src="@/assets/admin/images/educations.png" class="sidebar-icon" alt="">
                                <span>Educations</span>
                            </div>
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">
                            <div class="nav-link-inner">
                                <img src="@/assets/admin/images/social-links.png" class="sidebar-icon" alt="">
                                <span>Social Links</span>
                            </div>
                        </a>
                    </li>
                    <li class="nav-item nav-messages">
                        <router-link :to="{ name: 'message-list' }" class="nav-link">
                            <div class="nav-link-inner">
                                <img src="@/assets/admin/images/messages.png" class="sidebar-icon" alt="Messages">
                                <span>Messages</span>
                                <NumberOfUnread/>
                            </div>
                        </router-link>
                    </li>
                </ul>
            </div>
        </div>
        <div class="mobile-navbar noselect">
            <div>
                <div class="navbar-content" id="navbarContent" :class="{ 'display': isMobileNavbarVisible }">
                    <ul class="nav flex-column">
                        <li class="">
                            <div class="profile-container">
                                <img src="@/assets/admin/images/profile-photo.png" class="profile-photo" alt="">
                                <span>Sara Rasoulian</span>
                            </div>
                            <hr />
                        </li>
                        <li class="nav-item nav-profile">
                            <router-link :to="{ name: 'view-profile' }" class="nav-link">
                                <div class="nav-link-inner">
                                    <img src="@/assets/admin/images/profile.png" class="sidebar-icon" alt="">
                                    <span>Profile</span>
                                </div>
                            </router-link>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <div class="nav-link-inner">
                                    <img src="@/assets/admin/images/experiences.png" class="sidebar-icon" alt="">
                                    <span>Experiences</span>
                                </div>
                            </a>
                        </li>
                        <li class="nav-item nav-educations">
                            <router-link :to="{ name: 'education-list' }" class="nav-link">
                                <div class="nav-link-inner">
                                    <img src="@/assets/admin/images/educations.png" class="sidebar-icon" alt="">
                                    <span>Educations</span>
                                </div>
                            </router-link>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <div class="nav-link-inner">
                                    <img src="@/assets/admin/images/social-links.png" class="sidebar-icon" alt="">
                                    <span>Social Links</span>
                                </div>
                            </a>
                        </li>
                        <li class="nav-item nav-messages">
                            <router-link :to="{ name: 'message-list' }" class="nav-link">
                                <div class="nav-link-inner">
                                    <img src="@/assets/admin/images/messages.png" class="sidebar-icon" alt="Messages">
                                    <span>Messages</span>
                                    <NumberOfUnread/>
                                </div>
                            </router-link>
                        </li>
                        <hr class="line" />
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <div class="nav-link-inner">
                                    <img src="@/assets/admin/images/password.png" class="sidebar-icon" alt="">
                                    <span>Password</span>
                                </div>
                            </a>
                        </li>
                        <li class="nav-item">
                            <router-link :to="{ name: 'login' }" class="nav-link">
                                <div class="nav-link-inner">
                                    <img src="@/assets/admin/images/logout.png" class="sidebar-icon" alt="">
                                    <span>Log Out</span>
                                </div>
                            </router-link>
                        </li>
                    </ul>
                </div>
                <div class="navbar-background" :class="{ 'display': isMobileNavbarVisible }"
                    v-on:click="toggleMobileNavbar">
                </div>
                <div class="navbar-top">
                    <div v-on:click="toggleMobileNavbar">
                        <img src="@/assets/admin/images/menu.svg" class="navbar-icon" alt="">
                    </div>
                </div>
            </div>
        </div>
        <slot />
    </div>
</template>

<style>
@import '@/assets/admin/css/navbar.css';
@import '@/assets/admin/css/style.css';
</style>

<script>
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import NumberOfUnread from '@/components/admin/NumberOfUnread.vue'

export default {
    name: 'App',
    components: {
        NumberOfUnread
    },
    data() {
        return {
            isMobileNavbarVisible: false,
            isSidebarMinimized: false
        }
    },
    methods: {
        toggleMobileNavbar() {
            this.isMobileNavbarVisible = !this.isMobileNavbarVisible
        },
        toggleSidebar() {
            this.isSidebarMinimized = !this.isSidebarMinimized
        }
    }
}
</script>