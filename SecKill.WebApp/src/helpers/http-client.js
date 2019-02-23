import axios from "axios";
import Cookies from "js-cookie";
import router from "../router";

const identityKey = "identity";

axios.interceptors.request.use(
  config => {
    var jwtToken = undefined;
    try {
      jwtToken = JSON.parse(Cookies.get(identityKey));
    } catch (e) {}
    if (jwtToken && jwtToken.access_token) {
      config.headers.Authorization = "Bearer " + jwtToken.access_token;
    }
    return config;
  },
  error => {
    console.debug("interceptors.response", error);
    return Promise.reject(error.response);
  }
);

axios.interceptors.response.use(
  response => {
    return response.data;
  },
  error => {
    const { data } = error.response;
    // TODO: 精简axios的error数据结构
    console.debug("interceptors.response", error);
    if (error.response) {
      switch (error.response.status) {
        case 401:
          // 身份过期
          Cookies.set(identityKey, null);
          router.push({ name: "login" });
          return Promise.reject(data);
        default:
          break;
      }
    }
    return Promise.reject(data || error.response);
  }
);

export default axios;
