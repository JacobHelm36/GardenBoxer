import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
// @ts-ignore
import Garden from "./views/Garden.vue";
// @ts-ignore
import CreateGarden from "./views/CreateGarden.vue";
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard,
      beforeEnter: authGuard
    },
    {
      path: "/garden/:id",
      name: "garden",
      component: Garden,
      beforeEnter: authGuard
    },
    {
      path: "/create-garden",
      name: "create",
      component: CreateGarden,
      beforeEnter: authGuard
    }
  ]
});
