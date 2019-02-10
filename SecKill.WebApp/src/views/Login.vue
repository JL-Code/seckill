<template>
  <div style="width:400px;margin:50px auto;">
    <el-form label-width="80px" label-position="top">
      <el-form-item label="用户名">
        <el-input v-model="form.userName"></el-input>
      </el-form-item>
      <el-form-item label="密码">
        <el-input type="password" v-model="form.password"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="submitForm">立即登录</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import Cookies from "js-cookie";
export default {
  name: "Login",
  data() {
    return {
      form: {
        userName: "",
        password: ""
      }
    };
  },
  methods: {
    submitForm() {
      Cookies.set("identity", {
        userName: this.form.userName,
        password: this.form.password
      });
      this.$router.push({ name: "home" });
    }
  }
};
</script>
