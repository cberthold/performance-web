# Performance Web

This is a simple application that can be used to describe and investigate multitudes of performance problems in general computing.   The application is a react-redux application on top of .NET Core 2.  It uses SQL Server for its back-end which can also describe performance problems of complex applications at the database layer.

## Download database

A copy of the database backup file exists at the following link [WWI.ZIP](https://1drv.ms/u/s!AmuFonlDt0nzh0kI2j78Mou6FMMW)

## Install and Run Application

All requirements should be met if you have Visual Studio 2017 v15.3+.  Otherwise you will need nodejs, dotnet core 2, and npm installed globally.

dev.bat can be run to begin the initial installation and run.

## Scenario

This is a Sales Performance Dashboard application based on Wide World Importers (modified).  It is Shared Multi-Tenant, meaning you have access to multiple tenants data at one time based on your login. 

Changes were made to the application that do not perform well in production.  A subset of that data has been made available (WWI.zip).  

Users are complaining that the dashboard application takes a long time to load and as more tenants and/or data is added, performance gets worse.  

There is also a weather forecast application that seems somewhat slow too.  No changes have been made in that area but it is being reported as getting slower with time.