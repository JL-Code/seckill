<template>
  <el-row :gutter="10">
    <el-col :span="6" v-for="(goods, index) in data" :key="index">
      <el-card :body-style="{ padding: '0px' }">
        <img :src="goods.img" class="image">
        <div style="padding: 14px;">
          <span>{{ goods.goodsName }}</span>
          <div class="bottom clearfix">
            <time class="time"></time>
            <span>秒杀价：</span>
            <span class="price">￥{{goods.price}}</span>
            <el-button
              type="text"
              :disabled="disabled"
              class="button"
              @click="seckill"
            >{{actionName}}</el-button>
          </div>
        </div>
      </el-card>
    </el-col>
  </el-row>
</template>

<script>
import dayjs from "dayjs";
export default {
  name: "SeckillGoods",
  props: {
    data: { type: Array, default: () => [] }
  },
  data() {
    return {
      duration: 0,
      actionName: "即将开始",
      disabled: true
    };
  },
  computed: {
    startDate() {
      if (this.data.length) {
        return dayjs(this.data[0].startDate);
      }
      return null;
    },
    endDate() {
      if (this.data.length) {
        return dayjs(this.data[0].endDate);
      }
      return null;
    }
  },
  methods: {
    setTimer() {
      // 设置定时器
      this.timer = setInterval(() => {
        var currentDate = dayjs(Date.now());

        if (
          currentDate.isAfter(this.startDate) &&
          currentDate.isBefore(this.endDate)
        ) {
          this.enable();
          console.debug("clearInterval");
          clearInterval(this.timer);
        }
      }, 100);
      // console.debug("setTimer", this.timer);
    },
    enable() {
      this.disabled = false;
      this.actionName = "立即秒杀";
    },
    seckill() {
      this.$router.push({ name: "order" });
    }
  },
  mounted() {
    // 组件挂载的时候设置定时器
    this.setTimer();
  }
};
</script>
<style>
.time {
  font-size: 13px;
  color: #999;
}
.price {
  color: red;
  font: 12px/1.5 Microsoft YaHei, tahoma, arial, Hiragino Sans GB, \\5b8b\4f53,
    sans-serif;
  font-weight: bold;
  font-size: 24px;
}
.bottom {
  margin-top: 13px;
  line-height: 12px;
}

.button {
  padding: 0;
  float: right;
}

.image {
  width: 100%;
  display: block;
}

.clearfix:before,
.clearfix:after {
  display: table;
  content: "";
}

.clearfix:after {
  clear: both;
}
</style>
