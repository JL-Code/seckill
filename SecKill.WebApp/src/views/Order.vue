<template>
  <div class="page-view">
    <!-- 地址界面 -->
    <el-row class="address-view">
      <el-col>
        <el-card shadow="hover">
          <b>收货地址</b>
          <div style="padding: 14px;">
            <span>{{orderAddress.consignee}}</span>
            <span>{{orderAddress.mobile}}</span>
            <div>{{orderAddress.address}}</div>
            <div>{{orderAddress.addressDetail}}</div>
          </div>
        </el-card>
      </el-col>
    </el-row>
    <!-- 商品界面 -->
    <el-row class="goods-view" v-if="currentGoods">
      <el-col>
        <el-card shadow="hover">
          <img :src="currentGoods.pictureUrl" style="width:100px;height:100px">
          <div style="padding: 14px;">
            <span>{{ currentGoods.goodsName }}</span>
            <div class="bottom clearfix">
              <time class="time"></time>
              <span>结算金额：</span>
              <span class="price">￥{{currentGoods.goodsPrice}}</span>
            </div>
          </div>
        </el-card>
      </el-col>
    </el-row>
    <el-row style="text-align:right;">
      <!-- <el-button type="danger">删除订单</el-button> -->
      <el-button type="primary" :loading="loading" @click="submitOrder">提交订单</el-button>
    </el-row>
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "Order",
  data() {
    return {
      loading: false,
      orderAddress: {
        // 收货人
        consignee: "蒋勇",
        mobile: "17783195924",
        address: "重庆 重庆 南岸区 海棠溪街道", // 省 市 县/区 街道组成 provinceName cityName districtName streetName
        addressDetail: "南岸区烟雨路江南体育馆旁（原罗家坝段）和黄御峰 23栋 8-1"
      }
    };
  },
  computed: {
    ...mapState(["currentGoods"])
  },
  mounted() {
    if (this.currentGoods == null) {
      this.$router.push({ name: "home" });
    }
  },
  methods: {
    submitOrder() {
      const loading = this.$loading({
        lock: true,
        text: "正在提交订单...",
        spinner: "el-icon-loading"
      });
      this.loading = true;
      var order = {
        orderId: this.$route.query.orderId,
        goodsId: this.currentGoods.goodsId,
        goodsName: this.currentGoods.goodsName,
        goodsPrice: this.currentGoods.goodsPrice,
        quantity: this.currentGoods.quantity,
        address: `${this.orderAddress.consignee}${this.orderAddress.mobile}${
          this.orderAddress.address
        }${this.orderAddress.addressDetail}`
      };
      // 成功后调整支付界面
      this.$http
        .post("/api/order", order)
        .then(res => {
          loading.close();
          this.$store.commit("SUBMIT_ORDER_SUCCESS", res);
          this.$router.push({ name: "payment" });
        })
        .catch(err => {
          this.loading = false;
          loading.close();
          err.message && alert(err.message);
        });
    }
  }
};
</script>
<style lang="less">
.page-view {
  width: 80%;
  margin: 0 auto;
}
.el-row {
  margin-bottom: 10px;
  &:last-child {
    margin-bottom: 0;
  }
}
</style>
