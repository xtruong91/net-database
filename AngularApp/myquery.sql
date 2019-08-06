Create table tblEmployee(      
    EmployeeId int IDENTITY(1,1) NOT NULL,      
    Name varchar(20) NOT NULL,      
    City varchar(20) NOT NULL,      
    Department varchar(20) NOT NULL,      
    Gender varchar(6) NOT NULL      
);

Create procedure spAddEmployee         
(        
    @Name VARCHAR(20),         
    @City VARCHAR(20),        
    @Department VARCHAR(20),        
    @Gender VARCHAR(6)        
)        
as         
Begin         
    Insert into tblEmployee (Name,City,Department, Gender)         
    Values (@Name,@City,@Department, @Gender)         
End

Create procedure spUpdateEmployee        
(        
   @EmpId INTEGER ,      
   @Name VARCHAR(20),       
   @City VARCHAR(20),      
   @Department VARCHAR(20),      
   @Gender VARCHAR(6)      
)        
as        
begin        
   Update tblEmployee         
   set Name=@Name,        
   City=@City,        
   Department=@Department,      
   Gender=@Gender        
   where EmployeeId=@EmpId        
End

Create procedure spDeleteEmployee       
(        
   @EmpId int        
)        
as         
begin        
   Delete from tblEmployee where EmployeeId=@EmpId        
End

Create procedure spGetAllEmployees      
as      
Begin      
    select *      
    from tblEmployee   
    order by EmployeeId      
End