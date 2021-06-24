# Random Holiday location Generator

The task for the project is to build:

- an application that generates "Objects" upon a set of predefined rules

create an application with 4 microservices that communicate with eachother, within the architecture for this application there is a frontend built in [ASP.NET](http://asp.NET) MVC, service 1 generates a random destination, service 2 generates a random city and service 3 the merge service which makes a call to get information from service 1 and 2;

- Front-End (MVC Controller) - The main service which will render templates used to interact with the application, this will be responsible for communicating with the services.
- service 1 (destination: API): generates a destination for the user
- service 2 (cities API): calls service 1 to get the destination and map it to the correct city
- service 4: Service 4: Collects and formats the data from Services 2 & 3, returning it tothe front-end to be displayed.

---

# Introduction

This documentation details the steps of creating this random holiday destination generator, the focus was on the automation of continuous deployment, intergration and cloud infrastructure 

Holiday Destinations is a simple app that allows you to get a random destination generated for you 

---

# Trello Board

A kanban-style Trello Board was used for project tracking. Agile methodology was implemented where possible, in line with the project brief (i.e. Product and Sprint backlogs).

![Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled.png](Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled.png)

I started by populating the 'Product Backlog' field with user stories and the 'Sprint Backlog' field with tasks that when completed, would satisfy the user stories. As the project developed, changes were constantly made to the board. This helped me to keep track of what was in progress, what was finished, and so on. By the project due date (15th June), all User Stories were met, and issues had been fixed. Although there were two remaining tasks. First, integration testing, and second, CRUD functionality. These would have improved the quality of my project, however they were not part of the MVP.

---

# Risk assessment

[Untitled](https://www.notion.so/2c9a44ee5a3b4b55bad7667fa5a3438c)

---

# Achitecture

the project was designed witha microservice architecture in mind, defined as a collection of automated services , which should be self-contained and profide functionality to a single business objective.

As stated above the holiday generator app consist of 4 services: Frontend, service 1 (destinations), Service 2 (cities) service 3 (merge).

   

---

# service 1 (destinations), Service 2 (cities) service 3 (merge)

These 3 services were built using [ASP.NET](http://asp.NET) web API framework, each service has a controller, when a request is made to the service the methods handle the requests.

Destinations

![Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%201.png](Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%201.png)

cities 

![Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%202.png](Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%202.png)

merge

![Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%203.png](Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%203.png)

merge service makes a request to the cities service - the cities services makes a request to the destination service in order to map the correct city to the destination before returing a response to the merge controller which is in turn being called by the front end which prints the result 

---

# CI/CD pipeline

![Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%204.png](Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%204.png)

The diagram illustrates that when a push to the main branch happens the CI/CD pipeline is started triggering the GitHub actions service and deploys the application. A GitHub Actions pipeline was used to test, build and deploy the project to Azure resources that were set up and configured by a terraform script.

A snippet of the terraform code:

The code shows that if when when the resources are being created they don't have default names it will supply the values stored in  in the variables, it also shows the creation of the resource group and app service plan as well as the pricing tier the full code can be found in [main.tf](http://main.tf) 

![Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%205.png](Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%205.png)

Here is a snippet of the main.yml file:

this snippet shows the building of the destination-service which is run on linux and configured using workflow variables, The whole pipeline runs every time the main branch is pushed to, to allow for continuous deployment and integration.

![Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%206.png](Random%20Holiday%20location%20Generator%203151f71c779e4b99ae5776e00416a8e3/Untitled%206.png)

---

# terraform job

This provisions all of the resources required for this project, terraform is a toll that allows for infrastructure as code and resources to be provision quickly and repeatably.

# **Project Drawbacks & Future Improvements**

### **Lack of Integration Testing**

There was no Integration Testing. This is a disadvantage as it decreases application validity. What's more, there is no way to verify whether the application works in unity. Ultimately, this goes against a TDD approach. In future, I will expand my knowledge on how to carry out Integration Testing, putting some time aside to focus on this as well as testing in general.

### **No CRUD Functionality**

Unfortunately, due to time restrictions, this was not part of the end product. This should be noted for future improvements, as it would greatly improve my application and project.