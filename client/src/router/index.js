import { createRouter, createWebHistory } from 'vue-router'

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
      component: () => import('../views/admin/Login.vue')
    },


    {
      path: '/admin/profile',
      name: 'view-profile',
      component: () => import('../views/admin/profile/ViewProfile.vue')
    },
    {
      path: '/admin/profile/edit',
      name: 'edit-profile',
      component: () => import('../views/admin/profile/EditProfile.vue')
    },


    {
      path: '/admin/educations',
      name: 'education-list',
      component: () => import('../views/admin/educations/EducationList.vue')
    },
    {
      path: '/admin/educations/add',
      name: 'add-education',
      component: () => import('../views/admin/educations/AddEducation.vue')
    },
    {
      path: '/admin/educations/:id',
      name: 'view-education',
      component: () => import('../views/admin/educations/ViewEducation.vue')
    },    
    {
      path: '/admin/educations/edit/:id',
      name: 'edit-education',
      component: () => import('../views/admin/educations/EditEducation.vue')
    },
    {
      path: '/admin/educations/delete/:id',
      name: 'delete-education',
      component: () => import('../views/admin/educations/DeleteEducation.vue')
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
  ]
})

export default router
