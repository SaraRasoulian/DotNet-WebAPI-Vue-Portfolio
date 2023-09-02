import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [   
    {
      path: '/',
      name: 'login',
      component: () => import('../views/login.vue')
    },
    {
      path: '/profile',
      name: 'profile-view',
      component: () => import('../views/profile/view.vue')
    },
    {
      path: '/profile/edit',
      name: 'profile-edit',
      component: () => import('../views/profile/edit.vue')
    },
    {
      path: '/educations',
      name: 'list',
      component: () => import('../views/educations/list.vue')
    },
    {
      path: '/educations/add',
      name: 'add',
      component: () => import('../views/educations/add.vue')
    },
  ]
})

export default router
