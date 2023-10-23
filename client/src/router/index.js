import { createRouter, createWebHistory } from 'vue-router'
import identityService from '@/services/identityService'

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

async function guardMyRoute(to, from, next) {
  const authStatus = await isAuthenticated()
  if (authStatus) {
    next()
  } else {
    next('/admin/login')
  }
}

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
      meta: { title: 'Profile' }
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
      meta: { title: 'Education' }
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
      component: () => import('../views/admin/messages/MessageList.vue')
    },
    {
      path: '/admin/messages/:id',
      name: 'view-message',
      component: () => import('../views/admin/messages/ViewMessage.vue')
    },
    {
      path: '/admin/messages/delete/:id',
      name: 'delete-message',
      component: () => import('../views/admin/messages/DeleteMessage.vue')
    },

    {
      path: '/admin/socials',
      name: 'social-list',
      component: () => import('../views/admin/socialLinks/SocialList.vue')
    },
    {
      path: '/admin/socials/add',
      name: 'add-social',
      component: () => import('../views/admin/socialLinks/AddSocial.vue')
    },
    {
      path: '/admin/socials/:id',
      name: 'view-social',
      component: () => import('../views/admin/socialLinks/ViewSocial.vue')
    },
    {
      path: '/admin/socials/edit/:id',
      name: 'edit-social',
      component: () => import('../views/admin/socialLinks/EditSocial.vue')
    },
    {
      path: '/admin/socials/delete/:id',
      name: 'delete-social',
      component: () => import('../views/admin/socialLinks/DeleteSocial.vue')
    }
  ]
})

export default router
