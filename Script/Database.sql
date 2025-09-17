-- Table: public.CoreRole

-- DROP TABLE IF EXISTS public."CoreRole";

CREATE TABLE IF NOT EXISTS public."CoreRole"
(
    "RoleId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "RoleName" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "IsDeleted" boolean DEFAULT false,
    CONSTRAINT "CoreRole_pkey" PRIMARY KEY ("RoleId"),
    CONSTRAINT "CoreRole_RoleName_key" UNIQUE ("RoleName")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."CoreRole"
    OWNER to postgres;




-- Table: public.Login

-- DROP TABLE IF EXISTS public."Login";

CREATE TABLE IF NOT EXISTS public."Login"
(
    "LoginId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Email" character varying(500) COLLATE pg_catalog."default" NOT NULL,
    "Password" character varying(500) COLLATE pg_catalog."default",
    "Salt" character varying(500) COLLATE pg_catalog."default",
    "IsDeleted" boolean DEFAULT false,
    "RoleId" uuid,
    CONSTRAINT "Login_pkey" PRIMARY KEY ("LoginId"),
    CONSTRAINT "Login_Email_key" UNIQUE ("Email"),
    CONSTRAINT "Login_RoleId_fkey" FOREIGN KEY ("RoleId")
        REFERENCES public."CoreRole" ("RoleId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Login"
    OWNER to postgres;



-- Table: public.Employee

-- DROP TABLE IF EXISTS public."Employee";

CREATE TABLE IF NOT EXISTS public."Employee"
(
    "EmployeeId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "FirstName" character varying(200) COLLATE pg_catalog."default",
    "LastName" character varying(200) COLLATE pg_catalog."default",
    "Age" integer,
    "Email" character varying(300) COLLATE pg_catalog."default" NOT NULL,
    "Phone" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Qualification" character varying(200) COLLATE pg_catalog."default",
    "DepartmentId" uuid,
    "ImageUrl" character varying(500) COLLATE pg_catalog."default",
    "IsDeleted" boolean DEFAULT false,
    CONSTRAINT "Employee_pkey" PRIMARY KEY ("EmployeeId"),
    CONSTRAINT "Employee_Email_key" UNIQUE ("Email"),
    CONSTRAINT "Employee_ImageUrl_key" UNIQUE ("ImageUrl"),
    CONSTRAINT "Employee_Phone_key" UNIQUE ("Phone"),
    CONSTRAINT "Employee_DepartmentId_fkey" FOREIGN KEY ("DepartmentId")
        REFERENCES public."Department" ("DepartmentId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Employee"
    OWNER to postgres;



-- Table: public.Patient

-- DROP TABLE IF EXISTS public."Patient";

CREATE TABLE IF NOT EXISTS public."Patient"
(
    "PatientId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "FirstName" character varying(500) COLLATE pg_catalog."default",
    "LastName" character varying(500) COLLATE pg_catalog."default",
    "Email" character varying(300) COLLATE pg_catalog."default" NOT NULL,
    "Phone" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "Address" text COLLATE pg_catalog."default",
    "Gender" gender_enum NOT NULL,
    "Age" integer NOT NULL,
    "Dob" date,
    "ImageUrl" character varying(500) COLLATE pg_catalog."default",
    "IsDeleted" boolean DEFAULT false,
    CONSTRAINT "Patient_pkey" PRIMARY KEY ("PatientId"),
    CONSTRAINT "Patient_Email_key" UNIQUE ("Email"),
    CONSTRAINT "Patient_ImageUrl_key" UNIQUE ("ImageUrl"),
    CONSTRAINT "Patient_Phone_key" UNIQUE ("Phone")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Patient"
    OWNER to postgres;




-- Table: public.Department

-- DROP TABLE IF EXISTS public."Department";

CREATE TABLE IF NOT EXISTS public."Department"
(
    "DepartmentId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "DepartmentName" character varying(300) COLLATE pg_catalog."default",
    "Description" character varying(500) COLLATE pg_catalog."default",
    "IsDeleted" boolean DEFAULT false,
    CONSTRAINT "Department_pkey" PRIMARY KEY ("DepartmentId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Department"
    OWNER to postgres;




