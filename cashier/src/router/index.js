import Vue from 'vue'
import VueRouter from 'vue-router'

/* View imports */
import Start from '../views/Start.vue'
import Cashier from '../views/Cashier.vue'


Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Start',
    component: Start
  },
  {
    path: '/cashier',
    name: 'Cashier',
    component: Cashier
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
