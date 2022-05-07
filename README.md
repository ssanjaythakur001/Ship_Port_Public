# Overview

Here we have created a single page application, which is responsible for creat, update, read and delete operations for ship.
The application has two part 1)Backend ,where we have written all the service endpoints 2)FrontEnd with reactUI

## Next Steps

- You can find the repo here 

## Getting Started
The application created in Visual Studio Code and it supports below features

1)CRUD operation for Ship
2)Used EntityFrame Core in-memory
3)Container deployment with docker image
4)Five service end points 
  a)GetShip b)GetAllShips c)Post d)UpdateShip e)DeleteShip
5)All service end points are async to give better user experience 
6)Unit and behaviour test cases written with the help of Moq and Xunit  
7)Validations happens at both UI and Service level

## Application Run

To run this application we need to first make all these services up.We can do this with the help of Run command (Ctl+F5 , and for debug its F5) or by directly click on docker explorer and then right click on image and run. To make the service up with the help of docker,first your docker should be up and running

Once service gets up, we can run the front end application with the help of below comment on power shell
1)npm start
2)npm i(dependency resolved)

Npm start command will take you to the landing page. At intial, we dont have have any record ,so first we need to add records by clicking on Add button on top left corner from UI.

## Deployment

We have added a docker file and based on this file, docker image gets generated which is responsible to deploye oyr application in container.

### Software dependencies

1)Microsoft.NET.Sdk.Web
2)Target Framework-netcoreapp3.1
3)Microsoft.EntityFrameworkCore.InMemory (Version 5.0.0.0) 
4)Moq(Version 4.17.2)
5)Xunit(Version 2.4.2-pre.12)
6)Npm(node) version 16.13.1
7)Docker


#### Required

1. [Visual Studio Code latest version](https://visualstudio.microsoft.com/downloads/)
2. [.NET Core Latest LTS](https://www.microsoft.com/net/download/dotnet-core/)

  
#### Nice-To-Have


## Local Build and Test

1) -Hit Ctl-F5 or F5 for debug

## Development Environment Test

Development

## Contribute

1. Endpoints created.
2. Test cases created
3. Docker image added.
4. Validations created
