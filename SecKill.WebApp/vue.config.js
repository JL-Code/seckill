module.exports = {
  devServer: {
    disableHostCheck: true, //禁用主机检查
    // proxy: "http://localhost:5000"
    proxy: {
      "/api": {
        target: "http://192.168.31.54:8080",
        changeOrigin: true,
        ws: true,
        pathRewrite: {
          "^/api": "/api"
        }
      }
    }
  }
};
