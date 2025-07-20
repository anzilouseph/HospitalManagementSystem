Create EXTENSION IF NOT EXISTS "uuid-ossp"

	--Login Table
create table Login(LoginId UUID primary key Default uuid_generate_v4(),Email varchar(500) unique not null,Password varchar(500),Salt varchar(500));

ALTER TABLE Login ADD COLUMN "IsDelete" BOOLEAN DEFAULT false;
Alter table Login Add column "RoleId" UUID; foreign key (RoleId) references CoreRole (RoleId)



 --Patient Table
CREATE TYPE gender_enum AS ENUM ('MALE', 'FEMALE', 'OTHERS');
create table Patient(PatientId UUID primary key Default uuid_generate_v4(),FirstName VARCHAR(500),LastName VARCHAR(500),Email VARCHAR(300) UNIQUE NOT NULL,Phone VARCHAR(100) UNIQUE NOT NULL,Address TEXT,Gender gender_enum NOT NULL,Age INT NOT NULL,Dob DATE,ImageUrl VARCHAR(500) UNIQUE);
ALTER TABLE Patient ADD COLUMN "Password" varchar(500) ;
ALTER TABLE Patient ADD COLUMN "Salt" varchar(500) ;
ALTER TABLE Patient ADD COLUMN "IsDelete" BOOLEAN DEFAULT false;


--Department table
create table Department(DepartmentId UUID primary key default uuid_generate_v4(),DepartmentName varchar(300), Description varchar(500),IsDelete bool default false); 	


-- Doctor Table
create table Doctors(DoctorId UUID primary key default uuid_generate_v4(),Name varchar(300),Qualification varchar(300),DepartmentId UUID,Email varchar(300),IsDelete bool default false,Foreign key (DepartmentId) references Department (DepartmentId) on delete set null,Foreign key (Email) references Login (Email) on delete set null);
drop table Doctor

--DoctorsDepartment Table
CREATE TABLE DoctorDepartment (DoctorDepartmentId UUID PRIMARY KEY DEFAULT uuid_generate_v4(),DoctorId UUID NOT NULL,DepartmentId UUID NOT NULL,FOREIGN KEY (DoctorId) REFERENCES Doctor (DoctorId),FOREIGN KEY (DepartmentId) REFERENCES Department (DepartmentId),UNIQUE (DoctorId, DepartmentId),IsDelete bool default false);

--Roles Table
create table CoreRole(RoleId UUID primary key default uuid_generate_v4(),RoleName varchar(100) unique not null, IsDeleted boolean default false);
