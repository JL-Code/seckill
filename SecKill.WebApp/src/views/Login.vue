<template>
  <div style="width:400px;margin:50px auto;">
    <el-form :model="form" :rules="rules" ref="form" label-width="80px" label-position="left">
      <el-form-item label="账号" prop="account">
        <el-input v-model="form.account"></el-input>
      </el-form-item>
      <el-form-item label="密码" prop="password">
        <el-input type="password" v-model="form.password"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button
          type="primary"
          @click="submitForm"
          :loading="loading"
          :disabled="loading"
        >{{displayName}}</el-button>
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
      loading: false,
      form: {
        account: "jiangy",
        password: "1"
      },
      rules: {
        account: [
          {
            required: true,
            message: "请输入账号"
          }
        ],
        password: [
          {
            required: true,
            message: "请输入密码"
          }
        ]
      }
    };
  },
  computed: {
    displayName() {
      return this.loading ? "登录中..." : "立即登录";
    }
  },
  methods: {
    submitForm() {
      this.$refs.form.validate(valid => {
        if (valid) {
          this.loading = true;
          this.$http({
            url: "/api/account",
            method: "post",
            data: this.form
          })
            .then(res => {
              Cookies.set("identity", res);
              this.$router.push({ name: "home" });
            })
            .catch(({ data }) => {
              this.loading = false;
              alert(data.title);
              console.log(data);
            });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    }
  }
};
</script>
