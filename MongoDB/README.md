# Using MongoDB .NET Driver with .NET Core WebAPI

## To install
- Visual Studio Community 2017, including .NET Core options
- MongoDB and Robo 3T on ubutun

## Getting started

1. Run the following command to connect to MongoDB on default port 27017
mongod --dbpath <data_directory_path>

2. Connect to the default Notes database mongo

3. Using database
use NotesDb

4.Create a Note collection using following command:
db.createCollection('Notes')


6. Verify data
db.Books.find({}).pretty()

7. Install nutget package
Install-Package MongoDB.Driver -Version {VERSION}