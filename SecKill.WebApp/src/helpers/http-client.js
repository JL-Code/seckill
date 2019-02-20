import axios from "axios";
import Cookies from "js-cookie";

axios.interceptors.request.use(
  config => {
    var jwtToken = JSON.parse(Cookies.get("identity"));

    if (jwtToken && jwtToken.access_token) {
      config.headers.Authorization = "Bearer " + jwtToken.access_token;
    }
    return config;
  },
  error => {
    return Promise.reject(error.response);
  }
);

axios.interceptors.response.use(
  response => {
    return response.data;
  },
  error => {
    // TODO: 精简axios的error数据结构
    return Promise.reject(error.response);
  }
);

export default axios;
