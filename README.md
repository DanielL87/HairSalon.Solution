# _Hair Salon Independent Project_

#### _C# application with SQL database that allows users to add clientss in salon categories. 12.07.2018_

#### By _**Daniel Lira**_

## Description

_A C# application that is connected to a SQL database with tables for Stylists and Clients. Users can add to the client lists within stylist categories. Client contains name, stylist Id type properties._

## Setup/Installation Requirements

* _Clone this repository: $ git clone https://github.com/kwolfenb/CS-Yelp-Project-SQL.git_
* _To edit the project, open the project in your preferred text editor._
* CREATE DATABASE daniel_lira;
* USE daniel_lira database;
> CREATE TABLE stylist (id serial PRIMARY KEY, name VARCHAR(255));
> CREATE TABLE client (id serial PRIMARY KEY, name VARCHAR(255), stylist id INT);
* _To run the program, first navigate to the location of the Yelp file then run dotnet restore, dotnet build, and dotnet run._
* _When program is running open a web browser and go to localhost:5000 to view program._
* _To run the tests navigate to the Yelp.Tests folder and use these commands: $ dotnet restore and dotnet test._ 

## Support and contact details

* _Daniel Lira - devidra87@gmail.com_

### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| Program can take new user input for Stylist types | "John" | List: John |
| Program can take new user input for Client types | "Henry" | List: Henry |
| Program will relate Stylist with Client types based on Stylist ID | "John" -> "Henry" | "John" -> "Henry" |


## Technologies Used

* _C#_
* _.NET_
* _MSTests_
* _MVC_
* _Razor_
* _Mono_

### License

*This software is licensed under the MIT license.*

Copyright (c) 2018 **_Daniel Lira_**
