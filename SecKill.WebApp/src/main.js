import Vue from "vue";
import ElementUI from "element-ui";
import "element-ui/lib/theme-chalk/index.css";
import HttpClient from "./helpers/http-client";
import VueAxios from "vue-axios";
import App from "./App.vue";
import router from "./router";

Vue.config.productionTip = false;

Vue.use(VueAxios, HttpClient);
Vue.use(ElementUI);

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
