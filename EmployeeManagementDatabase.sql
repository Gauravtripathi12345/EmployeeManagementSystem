create database EmployeeManagementDatabase;
use EmployeeManagementDatabase;

create table Department(
DeptCode int primary key identity(100,1),
DeptName varchar(20),
);

insert into Department values('HR');

create table Employee(
EmpCode int primary key identity(1,1),
DateOfBirth DateTime,
EmpName varchar(30),
Email varchar(30),
DeptCode int foreign key references Department (DeptCode)
)

--insert into table Employee values ()