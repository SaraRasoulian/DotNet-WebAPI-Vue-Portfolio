import { createRouter, createWebHistory } from 'vue-router'
import identityService from '@/services/identityService'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import('@/views/home/Home.vue')
    },

    {
      path: '/admin/login',
      name: 'login',
      component: () => import('@/views/admin/Login.vue')
    },

    {
      path: '/admin/change-password',
      name: 'change-password',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/ChangePassword.vue')
    },

    {
      path: '/admin/profile',
      name: 'view-profile',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/profile/ViewProfile.vue')
    },
    {
      path: '/admin/profile/edit',
      name: 'edit-profile',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/profile/EditProfile.vue')
    },

    {
      path: '/admin/educations',
      name: 'education-list',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/educations/EducationList.vue')
    },
    {
      path: '/admin/educations/add',
      name: 'add-education',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/educations/AddEducation.vue')
    },
    {
      path: '/admin/educations/:id',
      name: 'view-education',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/educations/ViewEducation.vue')
    },
    {
      path: '/admin/educations/edit/:id',
      name: 'edit-education',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/educations/EditEducation.vue')
    },
    {
      path: '/admin/educations/delete/:id',
      name: 'delete-education',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/educations/DeleteEducation.vue')
    },

    {
      path: '/admin/messages',
      name: 'message-list',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/messages/MessageList.vue')
    },
    {
      path: '/admin/messages/:id',
      name: 'view-message',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/messages/ViewMessage.vue')
    },
    {
      path: '/admin/messages/delete/:id',
      name: 'delete-message',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/messages/DeleteMessage.vue')
    },

    {
      path: '/admin/socials',
      name: 'social-list',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/socialLinks/SocialList.vue')
    },
    {
      path: '/admin/socials/add',
      name: 'add-social',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/socialLinks/AddSocial.vue')
    },
    {
      path: '/admin/socials/:id',
      name: 'view-social',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/socialLinks/ViewSocial.vue')
    },
    {
      path: '/admin/socials/edit/:id',
      name: 'edit-social',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/socialLinks/EditSocial.vue')
    },
    {
      path: '/admin/socials/delete/:id',
      name: 'delete-social',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/socialLinks/DeleteSocial.vue')
    },

    {
      path: '/admin/experiences',
      name: 'experience-list',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/experiences/ExperienceList.vue')
    },
    {
      path: '/admin/experiences/add',
      name: 'add-experience',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/experiences/AddExperience.vue')
    },
    {
      path: '/admin/experiences/:id',
      name: 'view-experience',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/experiences/ViewExperience.vue')
    },
    // {
    //   path: '/admin/experiences/edit/:id',
    //   name: 'edit-experience',
    //   beforeEnter: authenticateAndRoute,
    //   component: () => import('@/views/admin/experiences/EditExperience.vue')
    // },
    {
      path: '/admin/experiences/delete/:id',
      name: 'delete-experience',
      beforeEnter: authenticateAndRoute,
      component: () => import('@/views/admin/experiences/DeleteExperience.vue')
    }
  ]
})

async function authenticateAndRoute(to, from, next) {
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
