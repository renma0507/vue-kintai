import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
 import KanriView from '../views/KanriView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    

    {
      path: '/kanri',
      name: '管理画面へ',
      component: () => import('../views/KanriView.vue'),
    },
  ],
})

export default router
