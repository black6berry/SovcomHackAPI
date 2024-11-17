# About project

This API was developed as part of the Sovcom Bank hackathon as a separate module. Arhetecture MVC (model-view-controller)

## Technology stack
1. EF Core v7.0.0
2. Swagger v6.2.3 
3. JwtBearer v6.0.0
4. NewtonsoftJson v6.0.0
5. Database MS SQL Server

# Installation and launch

1. Create a local folder on your computer, open GIT and enter the following commands

```
git init 
git clone https://github.com/black6berry/SovcomHackAPI.git
```

2. Create a Database "SovkomHack"
3. Change the connection string in the appsettings file.json and specify the name of your server 
4. Implement migration

```
 dotnet ef database update
```

# Screens 
<p align="center"><img src="SovkomHackAPI/Resources/img/api-points.png"/></p>
<p align="center"><img src="SovkomHackAPI/Resources/img/api-verifications.png"/></p>

