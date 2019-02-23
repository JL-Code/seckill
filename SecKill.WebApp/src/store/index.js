import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

import mutations from "./mutations";

const state = {
  currentGoods: null,
  currentOrder: null
};

const store = new Vuex.Store({
  state,
  mutations
});

export default store;
