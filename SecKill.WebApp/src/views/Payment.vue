<template>
  <div class="page-view">
    <div v-if="currentGoods">
      <span>订单提交成功，只差付款了~订单号： {{currentOrder.orderNumber}}</span>
      <div class="bottom clearfix">
        <time class="time"></time>
        <span>结算金额：</span>
        <span class="price">￥{{currentGoods.goodsPrice}}</span>
      </div>
    </div>
    <div style="padding:20px 0;text-align:right">
      <el-button type="primary">确认支付</el-button>
    </div>
  </div>
</template>


<script>
import { mapState } from "vuex";
export default {
  name: "Payment",
  data() {
    return {};
  },
  computed: {
    ...mapState(["currentGoods", "currentOrder"])
  },
  mounted() {
    if (this.currentOrder == null) {
      this.$router.push({ name: "home" });
    }
  }
};
</script>
