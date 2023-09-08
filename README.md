<p align="center">
    <a href="" target="_blank">
      <img src="./docs/img/Logo.png" width="280" />
    </a>
</p>


<h1 align="center">Token Chat</h1>
<p align="center"><strong>一个支持上万用户的Chat系统！</strong></p>


<div align="center">
    <a href="#公众号"><img src="https://img.shields.io/badge/公众号-Token的技术分享-blue.svg?style=plasticr"></a>
    <a href="#技术交流"><img src="https://img.shields.io/badge/交流群-加入开发-green.svg?style=plasticr"></a>
    <a href="https://github.com/239573049/chat"><img src="https://img.shields.io/badge/github-项目地址-yellow.svg?style=plasticr"></a>
    <a href="https://gitee.com/hejiale010426/chat"><img src="https://img.shields.io/badge/码云-项目地址-orange.svg?style=plasticr"></a>
    <a href="https://github.com/239573049/chat/blob/master/LICENSE" target="_blank">
        <img alt="License: Apache-2.0" src="https://img.shields.io/badge/License-Apache--2.0-blue.svg">
    </a> 
    <a href="https://github.com/239573049/chat" target="_blank">
        <img alt="License" src="https://img.shields.io/github/stars/239573049/chat">
    </a>
</div>

## 项目介绍

基于SignalR实现的Chat聊天，支持横向扩展，以便支撑上万用户同时在线聊天。
采用DDD领域驱动设计模式，CQRS架构模式，分离读写模型，架构更清晰，并且维护成本更低。

### 后端架构设计

 - ASP.NET Core 7
 - PostgreSQL
 - Redis
 - [MasaFramework](https://docs.masastack.com/framework/concepts/overview)
 - DDD领域驱动设计模式 CQRS架构模式   
 - SignalR （实现对话并且使用redis支持横向扩展）
   
### 前端架构
 - React 
 - [Semi UI](https://semi.design/zh-CN/start/getting-started)
 - Axios
 - Vite
 - Avalonia

## 项目使用

 - [Docker compose部署](./docs/Install.md)
 - [Window 单机部署](./docs/Window-DevOps.md)
 - [数据迁移](./docs/Migration.md)
 - [好友关系设计](./docs/Friend-Chart.md)

## 技术交流

qq群：737776595

## 公众号

<p align="center">
    <a href="" target="_blank">
      <img src="./docs/img/qrcode.jpg" width="280" />
    </a>
</p>



