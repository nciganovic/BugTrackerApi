# BugTrackerApi
.NET Core Web API for bug tracker 

## Documentation

### Introduction
BugTrackerApi is api for tracking bugs. It is supposed to be used by the IT companies to keep track of the current tasks and projects.

- If user is unauthorized his only available action is to login or register.
- If user is authorized he can have different roles and based on theese roles he can preform certain actions.

### Database schema
![alt text](https://raw.githubusercontent.com/nciganovic/BugTrackerApi/main/Screenshot_2.png)
> Ignore column types like bynary and integer. Column types can be seen under Domain project.

### Controllers
I will now explain what are controllers supposed to do so you can get a clear picture of the capabilities of this project.

#### Account
- Unauthorized users can preform login and register operations. If user registers successfully, he will be notified via email.
- During registration password taken from user will be hased and and only hash and salt will be stored in database. Code for this is available at BugTracker/Application/Hash
- If user is authorized he can change his inforamtions at /api/account/changeProfile

#### ApplicationUser
- ApplicationUser table is table that is representing users of application.
- Controller contains methods for CRUD operations.

#### Attachment
- Is a pdf file or image that is used to better describe goal of the task.
- Controller contains methods for CRUD operations.
- Files are stored in wwwroot/images
