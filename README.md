# 项目说明
EF Core + PostgreSQL demo  

# 遗留问题：

一次DBContext的SaveChanges 是否为一个事物  

是否必须要在model中设置主外键关系？(考虑：同时更新主表和明细表时，如何获取关联的主表的自增主键)  

主、从表插入数据时，有以下两种方案？(提示：从表需要获取主表的ID)  
1. 主键使用GUID，不要使用自增主键
2. 使用事务，先更新主表，获取主键；然后更新从表；(插入数据比较多时，讲会比较麻烦；而且，使用事务本身会增加开销)  

https://social.msdn.microsoft.com/Forums/en-US/dc7978c0-f591-4b04-8d50-9de746b581a6/getting-the-identity-value-before-savechanges