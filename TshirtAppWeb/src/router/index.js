import Vue from 'vue'
import Router from 'vue-router'
import TshirtList from '@/components/tshirts/TshirtList'
import TshirtUpdate from '@/components/tshirts/TshirtUpdate'
import NotFound from '@/components/error-page/NotFound'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'TshirtList',
      component: TshirtList
    },
    {
      path: '/update/:id',
      name: 'TshirtUpdate',
      component: TshirtUpdate
    },
    {
      path: '*',
      name: 'NotFound',
      component: NotFound
    }
  ]
})
