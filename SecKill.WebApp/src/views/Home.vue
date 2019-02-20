<template>
  <div class="home">
    <el-row style="margin-bottom:5px">
      <el-col>
        <el-card shadow="never">
          <count-down :start-date="startDate"></count-down>
        </el-card>
      </el-col>
    </el-row>
    <seckill-goods :data="seckillGoods"></seckill-goods>
    {{watchObj}}
    <el-button @click="test">测试</el-button>
    <el-button @click="getTestResult">获取值</el-button>
  </div>
</template>

<script>
import dayjs from "dayjs";
import CountDown from "@/components/CountDown";
import SeckillGoods from "@/components/SeckillGoods";
export default {
  name: "Home",
  components: { SeckillGoods, CountDown },
  data() {
    return {
      watchObj: {
        value: ""
      },
      seckillGoods: [
        {
          img:
            "https://res.vmallres.com/pimages//product/6901443281213/800_800_1546486249080mp.png",
          goodsName:
            "华为（HUAWEI） mate20pro手机 馥蕾红 8G+256G 全网通（UD屏内指纹版）",
          price: 1.09,
          startDate: "2019-02-10 21:56:00",
          endDate: "2019-02-11 00:00:00",
          status: ""
        }
      ]
    };
  },
  watch: {
    watchObj: {
      immediate: false,
      deep: true,
      handler(val) {
        console.log("watchTest", val);
      }
    },
    "watchObj.value": {
      immediate: true,
      handler(val) {
        console.log("watchObj.value", val);
      }
    }
  },
  computed: {
    startDate() {
      if (this.seckillGoods.length) {
        return this.seckillGoods[0].startDate;
      }
      return null;
    },
    endDate() {
      if (this.seckillGoods.length) {
        return this.seckillGoods[0].endDate;
      }
      return null;
    }
  },
  methods: {
    test() {
      var data = "test_" + Date.now();
      this.watchObj.value = data;
      console.log("test method ==>", data, this.watchObj);
    },
    getTestResult() {
      console.log("getTestResult", this.watchObj);
    }
  }
};
</script>
