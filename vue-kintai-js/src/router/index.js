import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
 import KanriView from '../views/KanriView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    
    {
      path:'/',
      component: () => import('../views/HomeView.vue'),
      
    },

    {
      path: '/kanri',
      name: '管理画面へ',
      component: () => import('../views/KanriView.vue'),
    },
    {
      path: '/Home',
      name: 'ホーム画面へ',
      component: () => import('../views/HomeView.vue'),
    },
  ],
})

export default router
