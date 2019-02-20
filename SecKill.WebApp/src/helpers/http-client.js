import axios from "axios";
import Cookies from "js-cookie";

axios.interceptors.request.use(
  config => {
    var jwtToken = undefined;
    try {
      jwtToken= JSON.parse(Cookies.get("identity"));
    } catch (e) {}
    if (jwtToken && jwtToken.access_token) {
      config.headers.Authorization = "Bearer " + jwtToken.access_token;
    }
    return config;
  },
  error => {
    console.debug("interceptors.response",error)
    return Promise.reject(error.response);
  }
);

axios.interceptors.response.use(
  response => {
    return response.data;
  },
  error => {
    // TODO: 精简axios的error数据结构
    console.debug("interceptors.response",error)
    return Promise.reject(error.response);
  }
);

export default axios;
