use CitusTrg

Create Table Department (
  DeptUniqueId int identity Primary key,
  DeptNo varchar(100) unique not null,
  DeptName varchar(100) not null,
  Location varchar(100) not null 
)

Create table Employee (
  EmpUniqueId int identity primary key,
  EmpNo varchar(100) unique not null,
  EmpName varchar(100) not null,
  Designation varchar(100) not null,
  Salary int not null,
  DeptUniqueId int not null
  Foreign key  References Department(DeptUniqueId)
)