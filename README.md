# aspcore-database

Guide line to connect with type of database by asp.net core

## Project structure 


1. App.Api 

- Maps to the layers that hold the Web, UI and Presenter concerns. In the context of our API, this means input in the 
form of http request over the network (e.g GET/POST) and return its output as content formatted as JSON/HTML/XML
The Presenters contain .NET framework-specific references and types, so they also live here as per The Dependency Rule
we don't want to pass any of them inward

2. App.Core

- Maps to the layers that hold the Use Case and Entity concerns and is also where our External Interfaces  get defined
These innermost layers contain our domain objects and business rules. The code in this layer is mostly pure C# - no network
connection, databases, etc. allowed. Interfaces represents those dependencies and their implementation get injected into 
our use cases as we'll see shortly.

3. App.Infrastructure 

- Maps to the layers that hold the Database and Gateway concerns. In here, we define data entities, database access 
(typically in the shape of repositories), integration with other network services, caches, etc. This project/layer
contains the physical implementation of the interface defined in our domain layer.

