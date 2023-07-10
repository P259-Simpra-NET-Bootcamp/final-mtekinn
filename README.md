[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/EBv50WFu)
# SimpraFinal Project

## Introduction

`SimpraFinal` is a .NET Core based project which provides an example of implementing various functionality including user registration and login, and role based authorization.

## Project Structure

The project is structured into two main parts:

1. **SimpraFinal.Data**: This part contains all the data entities and database-related functionality like migrations, context, etc. It uses Entity Framework Core as the ORM.

2. **SimpraFinal.Business**: This is the business logic layer of the application where all the business rules and logic are implemented. It contains services, repositories and other related files.

3. **SimpraFinal.API**: This layer is the application interface that serves endpoints to interact with the application services and resources. It uses ASP.NET Core Web API framework and follows REST architectural style.

