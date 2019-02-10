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
    <el-row class="goods-view">
      <el-col>
        <el-card shadow="hover">
          <img :src="goods.img" style="width:100px;height:100px">
          <div style="padding: 14px;">
            <span>{{ goods.goodsName }}</span>
            <div class="bottom clearfix">
              <time class="time"></time>
              <span>结算金额：</span>
              <span class="price">￥{{goods.price}}</span>
            </div>
          </div>
        </el-card>
      </el-col>
    </el-row>
    <el-row style="text-align:right;">
      <el-button type="primary" @click="submitOrder">提交订单</el-button>
    </el-row>
  </div>
</template>

<script>
export default {
  name: "Order",
  data() {
    return {
      goods: {
        img:
          "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png",
        goodsName:
          "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）",
        price: 1.09,
        startDate: "2019-02-10 20:43:00",
        endDate: "2019-02-11 00:00:00",
        status: ""
      },
      orderAddress: {
        // 收货人
        consignee: "蒋勇",
        mobile: "17783195924",
        address: "重庆 重庆 南岸区 海棠溪街道", // 省 市 县/区 街道组成 provinceName cityName districtName streetName
        addressDetail: "南岸区烟雨路江南体育馆旁（原罗家坝段）和黄御峰 23栋 8-1"
      }
    };
  },
  methods: {
    submitOrder() {
      // 成功后调整支付界面
      this.$router.push({ name: "payment" });
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
