import { createRouter, createWebHistory } from 'vue-router'
import identityService from '@/services/identityService'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import('../views/home/Home.vue')
    },

    {
      path: '/admin/login',
      name: 'login',
      component: () => import('../views/admin/Login.vue'),
      meta: { title: 'Login' }
    },

    {
      path: '/admin/profile',
      name: 'view-profile',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/profile/ViewProfile.vue'),
      meta: { title: 'View Profile' }
    },
    {
      path: '/admin/profile/edit',
      name: 'edit-profile',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/profile/EditProfile.vue'),
      meta: { title: 'Edit Profile' }
    },

    {
      path: '/admin/educations',
      name: 'education-list',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/educations/EducationList.vue'),
      meta: { title: 'Educations' }
    },
    {
      path: '/admin/educations/add',
      name: 'add-education',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/educations/AddEducation.vue'),
      meta: { title: 'Add Education' }
    },
    {
      path: '/admin/educations/:id',
      name: 'view-education',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/educations/ViewEducation.vue'),
      meta: { title: 'View Education' }
    },
    {
      path: '/admin/educations/edit/:id',
      name: 'edit-education',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/educations/EditEducation.vue'),
      meta: { title: 'Edit Education' }
    },
    {
      path: '/admin/educations/delete/:id',
      name: 'delete-education',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/educations/DeleteEducation.vue'),
      meta: { title: 'Delete Education' }
    },

    {
      path: '/admin/messages',
      name: 'message-list',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/messages/MessageList.vue'),
      meta: { title: 'Messages' }
    },
    {
      path: '/admin/messages/:id',
      name: 'view-message',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/messages/ViewMessage.vue'),
      meta: { title: 'View Message' }
    },
    {
      path: '/admin/messages/delete/:id',
      name: 'delete-message',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/messages/DeleteMessage.vue'),
      meta: { title: 'Delete Message' }
    },

    {
      path: '/admin/socials',
      name: 'social-list',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/socialLinks/SocialList.vue'),
      meta: { title: 'Social Links' }
    },
    {
      path: '/admin/socials/add',
      name: 'add-social',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/socialLinks/AddSocial.vue'),
      meta: { title: 'Add Social Link' }
    },
    {
      path: '/admin/socials/:id',
      name: 'view-social',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/socialLinks/ViewSocial.vue'),
      meta: { title: 'View Social Link' }
    },
    {
      path: '/admin/socials/edit/:id',
      name: 'edit-social',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/socialLinks/EditSocial.vue'),
      meta: { title: 'Edit Social Link' }
    },
    {
      path: '/admin/socials/delete/:id',
      name: 'delete-social',
      beforeEnter: guardMyRoute,
      component: () => import('../views/admin/socialLinks/DeleteSocial.vue'),
      meta: { title: 'Delete Social Link' }
    }
  ]
})

async function guardMyRoute(to, from, next) {
  const authStatus = await isAuthenticated()
  if (authStatus) {
    next()
  } else {
    next('/admin/login')
  }
}

async function isAuthenticated() {
  try {
    const response = await identityService.validateToken()
    if (response.status === 200) {
      return true
    } else {
      return false
    }
  } catch (error) {
    return false
  }
}

export default router
