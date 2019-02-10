<template>
  <div class="seckill-time">距离活动开始还剩：{{time}}</div>
</template>

<script>
import dayjs from "dayjs";
export default {
  name: "CountDown",
  props: {
    startDate: [String, Number, Date],
    endDate: [String, Number, Date]
  },
  data() {
    return {
      time: "loading...",
      duration: 1000
    };
  },
  methods: {
    setTimer() {
      this.timer = setInterval(() => {
        var startDate = dayjs(this.startDate);
        var currentDate = dayjs(Date.now());
        var diff = startDate.diff(currentDate);
        console.log("diff", diff);
        diff -= 1000;
        if (diff < 0) {
          diff = 0;
          this.time = "00:00:00";
          clearInterval(this.timer);
          return;
        }
        this.time = dayjs(diff).format("HH:mm:ss");
      }, this.duration);
    }
  },
  mounted() {
    this.setTimer();
  }
};
</script>
<style lang="less">
.seckill-time {
  text-align: center;
  font-size: 18px;
  font-weight: bold;
}
</style>
