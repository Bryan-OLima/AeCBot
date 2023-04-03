# AeCBot
This project is a Selenium RPA that bring informations of <a href="https://www.aec.com.br/">AEC</a> website.

### Used Technologies

<li> Selenium WebDriver
<li> Swagger
<li> DotNet6
<li> MYSQL

## You Should Know

<strong>The main sln is into AeCBot folder!</strong>

## Code Organization

![image](https://user-images.githubusercontent.com/85527991/229471529-41ab5977-6bbf-401c-8c0f-0998edf85489.png)

This structure was used for better understanding of the code. Where it was separated as best as possible to be able to isolate each one with its context.

## Important Methods
### AeCConsults.cs

<strong>
  <ol>
    <li>Start()</li>
      <ol>
        <li>StartProgram()</li>
        <li>FindData</li>
      </ol>
  </ol> 
</strong>

1. Start() - This is the core method. It will needed to start the bot for web scrapping pre search based. The parameter in it (entry) is to validation proposal.

1.i StartProgram() - Will receive the same parameter from start to make some loops with user interactions, and do all the processes that was made elsewhere.
1.ii FindData() - The main proposal of it is access AEC and get data search based on business rules.

### AeCDAL.cs

This layer have all methods that use to interact with API.

# API
## DataBaseConfiguration
In appsettings.Development.json you will need to set up you ```MYSQL``` database. If you do not have a database setted, don't worry. 
You can set a DB name in string connection and the API will create a database.
```     
  "ConnectionStrings": {
    "ConnectionMysql": "Server=yourserver;database=yourdatabasename;uid=yourid;pwd=yourpassword"
  }
```
And your archive will be like this:

![image](https://user-images.githubusercontent.com/85527991/229472841-4513ceed-9e60-4bda-9167-f5f2be74fcb9.png)
