基于最新.Net Core 2.1.5实现的Restful API快速开发框架

**项目说明** 
- 采用.Net Core 2.1开发，集成了SqlSugar、Newtonsoft.Json、EPPlus、ZXing、NLog等，实现的Restful API快速开发框架。
- 通过反射机制，直接添加继承基类并实现，其余的代码交给系统自动完成，可快速完成开发任务
- 支持MySQL、Oracle、SQL Server、PostgreSQL等主流数据库
  <br>

 **技术选型：** 

- 核心框架：.Net Core 2.1.5
- ORM：sqlSugarCore 4.6.0.4
- Excel操作：EPPlus.Core 1.5.4
- 二维码生成：ZXing.Net
- 定时器：TimeJob 2.0.0
- 日志管理：NLog 4.5.11
- 页面交互：ASP.Net Razor

<br>

**项目结构** 
```
DotNetCoreFrame
├─Common     公共模块
│ 
├─configs      配置项
│    ├─db  数据库SQL脚本
│    │ 
│    └──modules  模块
│         ├─job 定时任务
│         ├─oss 文件存储
│         └─sys 系统管理
│    
│——Files   上传下载文件       
│ 
|
|——Properties
|		└──launchSettings.json  Core配置
|
├─Methods-api        API接口服务
│ 
├─Controllers  
│        ├─HomeController     页面
│        ├─ValuesController   API接口
│        └─FileController     文件上传下载          
│     
|
│-ServiceCore 核心库
```

<br>

 **软件需求** 
- .Net Core 2.1.5 SDK
- Visual Studio 2017
- .Net Framework 4.5+

<br>

**使用方式**

1. 接口地址：

Post地址：<http://localhost:16544/api/values/Post/>

上传文件地址：<http://localhost:16544/home/UploadFile>

接口测试地址：http://localhost:16544

2. 请求格式：

```
{
	"Method": "[接口名称]",
	"Criteria": {
		[接口参数]
	},
	"DefaultFlags": {
		[固定标记]
	}
}
```

3. 返回成功：

```
{
	"Result": "Success",
	"Content": {}
}
```

4. 返回失败：

```
{
    "Result": "Failed",
    "Reason": "[错误原因]"
}
```

 **注：**

调用请求接口时固定标记每个接口都必须传,如果给后台传的json为object，则返回为object类型；

为方便同时调用多个接口，可给后台传请求数组，则返回数据也为数组；

<br>

**项目演示**

<p align="center">
  <img height="600" src="./template/img/1.png?sanitize=true">
  <img height="600" src="./template/img/2.png?sanitize=true">
  <img height="600" src="./template/img/3.png?sanitize=true">
</p>

<br>