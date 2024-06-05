import { createRouter, createWebHistory } from '@ionic/vue-router';
import Home from '../views/Home.vue';
import PlaceOrder from '../views/PlaceOrder.vue';

const routes = [
  {
    path: '/',
    component: Home
  },
  {
    path: '/place-order/:id',
    component: PlaceOrder
  }
];

const router = createRouter({
  history: createWebHistory('/'),
  routes
});

export default router;
