# Configure MongoDB

1. Run the following command to connect to MongoDB on default port 27017
mongod --dbpath <data_directory_path>
2. Connect to the default test database
mongo
3. Using database
use BookstoreDb
4.Create a Books collection using following command:
db.createCollection('Books')
5. Insert data
db.Books.insertMany([{'Name':'Design Patterns','Price':54.93,'Category':'Computers','Author':'Ralph Johnson'}, 
{'Name':'Clean Code','Price':43.15,'Category':'Computers','Author':'Robert C. Martin'}])
6. Verify data
db.Books.find({}).pretty()

7. Install nutget package
Install-Package MongoDB.Driver -Version {VERSION}