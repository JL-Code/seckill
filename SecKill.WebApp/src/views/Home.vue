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
    <el-button @click="validateAccessToken">验证AccessToken</el-button>
    <el-button @click="redirectOrders">订单中心</el-button>
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
      seckillGoods: []
    };
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
  mounted() {
    this.fetchData();
  },
  methods: {
    fetchData() {
      const loading = this.$loading({
        lock: true,
        text: "正在加载商品数据...",
        spinner: "el-icon-loading"
      });
      this.$http
        .get("/api/seckillgoods")
        .then(data => {
          loading.close();
          this.seckillGoods = data;
        })
        .catch(err => {
          loading.close();
          alert(err.message);
        });
    },
    test() {
      var data = "test_" + Date.now();
      this.watchObj.value = data;
      console.log("test method ==>", data, this.watchObj);
    },
    getTestResult() {
      console.log("getTestResult", this.watchObj);
    },
    validateAccessToken() {
      this.$http.get("/api/values").then(data => {
        alert(data);
      });
    },
    redirectOrders() {
      this.$router.push({ name: "orders" });
    }
  }
};
</script>
