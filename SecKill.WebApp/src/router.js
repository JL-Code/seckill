import Vue from "vue";
import Router from "vue-router";
import Cookies from "js-cookie";

import Home from "./views/Home.vue";
import Login from "./views/Login.vue";
import Order from "./views/Order.vue";
import Payment from "./views/Payment.vue";
import Queue from "./views/Queue.vue";
import CascaderTest from "./views/CascaderTest.vue";
import CascaderTest1 from "./views/CascaderTest1.vue";

Vue.use(Router);

const router = new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/login",
      name: "login",
      component: Login
    },
    {
      path: "/order",
      name: "order",
      component: Order
    },
    {
      path: "/payment",
      name: "payment",
      component: Payment
    },
    {
      path: "/cascaderTest",
      name: "cascaderTest",
      component: CascaderTest
    },
    {
      path: "/cascaderTest1",
      name: "cascaderTest1",
      component: CascaderTest1
    },
    {
      path: "/queue",
      name: "queue",
      component: Queue
    },
    {
      path: "/about",
      name: "about",
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () =>
        import(/* webpackChunkName: "about" */ "./views/About.vue")
    }
  ]
});
// 拦截非法路由
router.beforeEach((to, from, next) => {
  var identity = Cookies.get("identity");
  if (to.name === "login" || identity) {
    next();
  } else {
    next({ name: "login" });
  }
});

export default router;
