import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [   
    {
      path: '/',
      name: 'home',
      component: () => import('../views/home/landing.vue')
    },
    {
      path: '/admin/login',
      name: 'login',
      component: () => import('../views/admin/login.vue')
    },
    {
      path: '/admin/profile',
      name: 'profile-view',
      component: () => import('../views/admin/profile/view.vue')
    },
    {
      path: '/admin/profile/edit',
      name: 'profile-edit',
      component: () => import('../views/admin/profile/edit.vue')
    },
    {
      path: '/admin/educations',
      name: 'education-list',
      component: () => import('../views/admin/educations/list.vue')
    },
    {
      path: '/admin/educations/add',
      name: 'education-add',
      component: () => import('../views/admin/educations/add.vue')
    },
    {
      path: '/admin/educations/:id',
      name: 'education-view',
      component: () => import('../views/admin/educations/view.vue')
    },
  ]
})

export default router
