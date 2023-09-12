import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [   
    {
      path: '/',
      name: 'home',
      component: () => import('../views/home/home.vue')
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
      name: 'educations-list',
      component: () => import('../views/admin/educations/list.vue')
    },
    {
      path: '/admin/educations/add',
      name: 'educations-add',
      component: () => import('../views/admin/educations/add.vue')
    },
    {
      path: '/admin/educations/:id',
      name: 'educations-view',
      component: () => import('../views/admin/educations/view.vue')
    },    
    {
      path: '/admin/educations/edit/:id',
      name: 'educations-edit',
      component: () => import('../views/admin/educations/edit.vue')
    },
    {
      path: '/admin/educations/delete/:id',
      name: 'educations-delete',
      component: () => import('../views/admin/educations/delete.vue')
    },


    {
      path: '/admin/messages',
      name: 'messages-list',
      component: () => import('../views/admin/messages/list.vue')
    },
    {
      path: '/admin/messages/:id',
      name: 'messages-view',
      component: () => import('../views/admin/messages/view.vue')
    },
    {
      path: '/admin/messages/delete/:id',
      name: 'messages-delete',
      component: () => import('../views/admin/messages/delete.vue')
    },
  ]
})

export default router
