<template>
  <div class="page-view">
    <div>
      <span>订单提交成功，只差付款了~订单号： 3352779684</span>
      <div class="bottom clearfix">
        <time class="time"></time>
        <span>结算金额：</span>
        <span class="price">￥{{goods.price}}</span>
      </div>
    </div>
    <div style="padding:20px 0;text-align:right">
      <el-button type="primary">确认支付</el-button>
    </div>
  </div>
</template>


<script>
export default {
  name: "Payment",
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
      }
    };
  }
};
</script>
