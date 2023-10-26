create database dbDemoDatabase
create table areas(
area varchar(100)constraint pk_area primary key,zipcode char(5))

create table Employees(
employee_id int identity(100,1)constraint pk_emp_id primary key,
name varchar (50) not null,age int default 18,
area varchar(100) constraint fk_area foreign key references areas(area)) 

create table skills(
skill varchar(20) constraint pk_skill primary  key,
skill_description varchar(100))



create table EmployeesSkills(
employee_id int constraint fk_emp_id foreign key references employees(employee_id),
skill_name varchar(20) constraint fk_skill foreign key references Skills(skill),skill_level float,
constraint pk_emp_skill primary key(employee_id,skill_name))

sp_help EmployeesSkills
insert into Areas values('ABC','12345'),('BBB','12345'),('CCC','54321')

insert into skills(skill,skill_description) values('C','PLT'),('C++','OOPS'),('JAVA','WEB'),('SQL','RDBMS')
insert into Employees values('Ramu',23,'ABC'),('Somu',34,'BBB'),('Bimu',27,'ABC')
insert into EmployeesSkills values(101,'C',7),(101,'C++',7),(101,'Java',6),(102,'Java',7),(102,'SQL',8)
SELECT * FROM Employees

drop table Employees

update EmployeesSkills set skill_level=8 where employee_id=101 and skill_name='C'

update Employees set age=29 where employee_id=102

--update name and age of employee 102
update Employees set name='Komu' ,age=22 where employee_id=102