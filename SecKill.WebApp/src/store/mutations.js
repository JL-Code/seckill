import * as types from "./mutation-types";
export default {
  [types.SECKILL_GOODS](state, payload) {
    state.currentGoods = payload;
  },
  [types.SUBMIT_ORDER_SUCCESS](state, payload) {
    state.currentOrder = payload;
  }
};
