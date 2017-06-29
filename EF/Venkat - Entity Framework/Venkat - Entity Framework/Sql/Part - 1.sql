
-- DROP TABLE IF EXISTS [Venkat - Entity Framework].[Departments];

IF OBJECT_ID('[Venkat - Entity Framework].[Departments]') IS NOT NULL
   DROP TABLE [Venkat - Entity Framework].[Departments]
GO

CREATE TABLE Departments
(
     ID int primary key identity,
     Name nvarchar(50),
     Location nvarchar(50)
);

IF OBJECT_ID('[Venkat - Entity Framework].[Employees]') IS NOT NULL
   DROP TABLE [Venkat - Entity Framework].Employees
GO

CREATE TABLE Employees
(
     ID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     Salary int,
     DepartmentId int foreign key references Departments(Id)
);

INSERT INTO Departments VALUES ('IT', 'New York');
INSERT INTO Departments VALUES ('HR', 'London');
INSERT INTO Departments VALUES ('Payroll', 'Sydney');

INSERT INTO Employees VALUES ('Mark', 'Hastings', 'Male', 60000, 1);
INSERT INTO Employees VALUES ('Steve', 'Pound', 'Male', 45000, 3);
INSERT INTO Employees VALUES ('Ben', 'Hoskins', 'Male', 70000, 1);
INSERT INTO Employees VALUES ('Philip', 'Hastings', 'Male', 45000, 2);
INSERT INTO Employees VALUES ('Mary', 'Lambeth', 'Female', 30000, 2);
INSERT INTO Employees VALUES ('Valarie', 'Vikings', 'Female', 35000, 3);
INSERT INTO Employees VALUES ('John', 'Stanmore', 'Male', 80000, 1);
