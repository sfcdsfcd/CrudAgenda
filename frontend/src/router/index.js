import { createRouter, createWebHistory } from 'vue-router';
import Home from '../components/Home.vue';
import authRoutes from './authRoutes';
import contatoRoutes from './contatoRoutes';
import { isAuthenticated } from '../utils/auth';

const routes = [
  { path: '/', component: Home, name: 'Home' },
  ...contatoRoutes,
  ...authRoutes
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
});

router.beforeEach((to, from, next) => {
  if (!isAuthenticated() && to.path !== '/') {
    next('/');
  } else {
    next();
  }
});

export default router;