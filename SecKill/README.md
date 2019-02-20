  # 秒杀项目

1. 创建数据库
2. 搭建项目
3. 完成秒杀的前置任务(用户的注册、商品的下单)

## 秒杀优化思路
- 页面静态化 缓存
- 减少数据库访问,引入redis。
- 引入RabbitMQ队列

## 待完成功能

- [ ] 集成 IdentityServer
- [ ] 完成简易分布式session
- [ ] 秒杀商品列表获取
- [ ] 生成秒杀订单
- [ ] 页面缓存

## 项目依赖

1. OpenId 认证 Microsoft.AspNetCore.Authentication.OpenIdConnect