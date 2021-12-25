# DependencyInjectionV2
## Sample codes of ["Dependency Injection With .NET Core 3"](https://www.udemy.com/dependency-injection-in-net-core-2-and-aspnet-core-2/?couponCode=REFLECTIONINCRS) course on Udemy

## Personal Blog
This simple code is to demonstrate how to do simple operations with DI in .NET Core and ASP.NET Core
By default, it uses AWAS DynamoDB. To use DynamoDB, you must create your own local .aws account profile and include "user key", "secret key" and "region" in it.

### If you do not have access to AWS and AWS DynamoDB:
There is an implementation of IDataService that works with SQL Server. It is called SqlServerDataService

If you would like to switch to SQL Server you must do the following:

1. Create an empty new database in your SQL Server (or SQL Server Express)
2. Open script file from PersonalBlog\DatabaseScripts folder [(this one)](https://github.com/aussiearef/DependencyInjectionV2/blob/master/PersonalBlog/DatabaseScripts/Create_All_Objects.sql)
3. Run the script on the newly created databases to have the tables and stored procedures created
4. Go to appsettings.json, and update the "SqlConnection" key with the proper connection string that works with your database
5. Go to Startup.cs, and comment out the existing "ConfigureDataService" method which works with DynamoDB
6. Uncomment "ConfigureDataService" that works with SqlServer (injects SqlServerDataService)
