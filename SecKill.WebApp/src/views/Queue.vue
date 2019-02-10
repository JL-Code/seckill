<template>
  <div class="page-view">
    <div class="queue__imgbox">
      <img
        src="https://res.vmallres.com/cn/activity/rushbuy/20190101/cn/web/images/h_icon_queuing.gif?20180202"
      >
      <p class="queue__desc">排队中...</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "Queue",
  data() {
    return {};
  },
  methods: {
    fetchData() {}
  },
  mounted() {
    // 轮询从服务器获取排队结果
  }
};
</script>
<style lang="less">
.queue__imgbox {
  width: 270px;
  margin: 50px auto;
  text-align: center;
}
.queue__desc {
  text-align: center;
  font-weight: 600;
}
</style>

