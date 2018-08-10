# 项目说明
该项目是EF Core + PosggreSQL的学习Demo

# 技术栈
* 系统：linux  
* 框架：.net core web api
* ORM框架：ef core
* db: postgresql

# 运行说明
> 前提条件  
配置数据库链接字符串：\PGDemo\PGDemo ： appsettings.json,appsettings.Development.json,appsettings.Test.json, appsettings.Production.json  
配置Repository项目下的链接字符串，用于数据库迁移：\PGDemo\PGDemo.Repository ： appsettings.json  

1. 数据库迁移  
执行\PGDemo\PGDemo.Repository\migration.bat, 完成数据库迁移。执行完成生成的表结构如：\PGDemo\Db\table-relationship.JPG  

2. 插入测试数据  
执行\PGDemo\Db\data.sql插入测试数据

3. 运行程序，默认会打开swagger api页面  

