Create DATABASE [OrganizationalStructureOfTheCompany]
GO

USE [OrganizationalStructureOfTheCompany]
GO
/****** Object:  Table [dbo].[companies]    Script Date: 9/11/2024 12:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[code] [nvarchar](max) NOT NULL,
	[directorId] [int] NOT NULL,
	[divisionsId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_companies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departments]    Script Date: 9/11/2024 12:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[code] [nvarchar](max) NOT NULL,
	[headOfDepartmentId] [int] NOT NULL,
	[projectId] [int] NULL,
 CONSTRAINT [PK_departments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[divisions]    Script Date: 9/11/2024 12:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[divisions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[code] [nvarchar](max) NOT NULL,
	[headOfDivisionId] [int] NOT NULL,
	[companyId] [int] NOT NULL,
	[projectsId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_divisions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 9/11/2024 12:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NULL,
	[firstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[phoneNumber] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[projects]    Script Date: 9/11/2024 12:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[projects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[code] [nvarchar](max) NOT NULL,
	[projectManagerId] [int] NOT NULL,
	[divisionId] [int] NULL,
	[departmentsId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_projects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[companies] ON 

INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (2, N'Meta', N'MT032', 4, N'[9,10]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (5, N'Google', N'GG022', 6, N'[18]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (6, N'Apple', N'AP014', 5, N'[17,35,36,37]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (7, N'Continental', N'CN000', 9, N'[11,12]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (24, N'Tech Solutions', N'TS001', 10, N'[13,20]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (25, N'Green Energy', N'GE002', 12, N'[14,34]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (26, N'Alpha Innovations', N'AI003', 15, N'[19]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (27, N'Beta Systems', N'BS004', 18, N'[15,21,22]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (28, N'CyberCore', N'CC005', 22, N'[24,33]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (29, N'EcoDynamics', N'ED006', 25, N'[25,27]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (30, N'FutureTech', N'FT007', 11, N'[26]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (31, N'Prime Solutions', N'PS008', 14, N'[23,28]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (32, N'Visionary Labs', N'VL009', 19, N'[16]')
INSERT [dbo].[companies] ([id], [name], [code], [directorId], [divisionsId]) VALUES (33, N'NexGen Industries', N'NG010', 29, N'[29,30,31,32]')
SET IDENTITY_INSERT [dbo].[companies] OFF
GO
SET IDENTITY_INSERT [dbo].[departments] ON 

INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (1, N'Human Resources', N'HR', 12, 19)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (2, N'Information Technology', N'IT', 23, 4)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (3, N'Finance', N'FIN', 34, 9)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (4, N'Marketing', N'MKT', 45, 16)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (5, N'Sales', N'SAL', 21, 19)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (6, N'Customer Service', N'CS', 37, 10)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (7, N'Research and Development', N'R&D', 29, 12)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (8, N'Legal', N'LEG', 48, 5)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (9, N'Operations', N'OPS', 51, 14)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (10, N'Product Management', N'PM', 13, 10)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (11, N'Engineering', N'ENG', 32, 24)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (12, N'Procurement', N'PROC', 25, 13)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (13, N'Administration', N'ADM', 50, 10)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (14, N'Training and Development', N'T&D', 42, 14)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (15, N'Supply Chain Management', N'SCM', 54, 4)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (16, N'Quality Assurance', N'QA', 27, 11)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (17, N'Business Development', N'BD', 35, 9)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (18, N'Corporate Communications', N'CC', 19, 3)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (20, N'Facilities Management', N'FM', 31, 13)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (21, N'Project Management', N'PMT', 14, 1)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (22, N'Internal Audit', N'IA', 22, 7)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (23, N'Business Intelligence', N'BI', 38, 22)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (24, N'Customer Experience', N'CX', 47, 23)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (25, N'Compliance', N'COMP', 40, 17)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (26, N'Investor Relations', N'IR', 52, 19)
INSERT [dbo].[departments] ([id], [name], [code], [headOfDepartmentId], [projectId]) VALUES (27, N'Public Relations', N'PR', 26, 24)
SET IDENTITY_INSERT [dbo].[departments] OFF
GO
SET IDENTITY_INSERT [dbo].[divisions] ON 

INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (9, N'string', N'string', 8, 2, N'[24]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (10, N'Marketing', N'MKT001', 12, 2, N'[25]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (11, N'Finance', N'FIN002', 17, 7, N'[8]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (12, N'Human Resources', N'HR003', 25, 7, N'[]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (13, N'Information Technology', N'IT004', 21, 24, N'[13]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (14, N'Research and Development', N'RND005', 13, 25, N'[22]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (15, N'Sales', N'SLS006', 19, 27, N'[19,23]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (16, N'Legal', N'LGL007', 15, 32, N'[]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (17, N'Operations', N'OPS008', 28, 6, N'[20]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (18, N'Customer Support', N'CSP009', 22, 5, N'[21]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (19, N'Product Management', N'PM010', 10, 26, N'[5,18]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (20, N'Procurement', N'PRC011', 11, 24, N'[]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (21, N'Quality Assurance', N'QA012', 26, 27, N'[]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (22, N'Public Relations', N'PR013', 14, 27, N'[3,10]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (23, N'Corporate Strategy', N'CS014', 18, 31, N'[]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (24, N'Business Development', N'BD015', 23, 28, N'[4]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (25, N'Risk Management', N'RM016', 29, 29, N'[12,15]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (26, N'Supply Chain Management', N'SCM017', 20, 30, N'[]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (27, N'Data Analytics', N'DA018', 16, 29, N'[9]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (28, N'Investor Relations', N'IR019', 27, 31, N'[]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (29, N'Training and Development', N'TD020', 24, 33, N'[1]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (30, N'Engineering', N'ENG021', 13, 33, N'[]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (31, N'Environmental Sustainability', N'ES022', 19, 33, N'[6]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (32, N'Corporate Governance', N'CG023', 12, 33, N'[7,17]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (33, N'Innovation', N'INN024', 15, 28, N'[11,14]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (34, N'Logistics', N'LOG025', 22, 25, N'[2]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (35, N'Compliance', N'CMP026', 28, 6, N'[16]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (36, N'Event Management', N'EM027', 21, 6, N'[]')
INSERT [dbo].[divisions] ([id], [name], [code], [headOfDivisionId], [companyId], [projectsId]) VALUES (37, N'Customer Experience', N'CX028', 17, 6, N'[]')
SET IDENTITY_INSERT [dbo].[divisions] OFF
GO
SET IDENTITY_INSERT [dbo].[employees] ON 

INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (4, NULL, N'Jozef', N'Kocur', N'0941231483', N'kocur@gmail.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (5, N'Ing.', N'Maroš', N'Vankúš', N'0915263748', N'marosko@gmail.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (6, N'Mgr.', N'Natália', N'Medveďová', N'+421962738153', N'medvedova@gmail.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (8, N'', N'Igor', N'Fran', N'+421 900 014 235', N'igor.fran@gmail.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (9, N'Ing.', N'Martin', N'Novak', N'+421 900 123 456', N'martin.novak@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (10, N'Mgr.', N'Anna', N'Kovacova', N'+421 900 234 567', N'anna.kovacova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (11, N'Bc.', N'Peter', N'Hajduk', N'+421 900 345 678', N'peter.hajduk@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (12, N'Dr.', N'Eva', N'Kralova', N'+421 900 456 789', N'eva.kralova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (13, N'Ing.', N'Jozef', N'Varga', N'+421 900 567 890', N'jozef.varga@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (14, N'Mgr.', N'Lucia', N'Mikulasova', N'+421 900 678 901', N'lucia.mikulasova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (15, N'Bc.', N'Andrej', N'Horvath', N'+421 900 789 012', N'andrej.horvath@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (16, N'Dr.', N'Veronika', N'Stankova', N'+421 900 890 123', N'veronika.stankova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (17, N'Ing.', N'Jana', N'Brezina', N'+421 900 901 234', N'jana.brezina@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (18, N'Mgr.', N'Miroslav', N'Lukac', N'+421 900 012 345', N'miroslav.lukac@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (19, N'Bc.', N'Monika', N'Bajcova', N'+421 900 123 456', N'monika.bajcova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (20, N'Dr.', N'Roman', N'Sulek', N'+421 900 234 567', N'roman.sulek@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (21, N'Ing.', N'Karol', N'Kudlak', N'+421 900 345 678', N'karol.kudlak@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (22, N'Mgr.', N'Jozefa', N'Nemcova', N'+421 900 456 789', N'jozefa.nemcova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (23, N'Bc.', N'Igor', N'Horak', N'+421 900 567 890', N'igor.horak@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (24, N'Dr.', N'Katarina', N'Strakova', N'+421 900 678 901', N'katarina.strakova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (25, N'Ing.', N'Tomas', N'Gajdos', N'+421 900 789 012', N'tomas.gajdos@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (26, N'Mgr.', N'Zuzana', N'Benova', N'+421 900 890 123', N'zuzana.benova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (27, N'Bc.', N'Martin', N'Dusan', N'+421 900 901 234', N'martin.dusan@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (28, N'Dr.', N'Marta', N'Kondrak', N'+421 900 012 345', N'marta.kondrak@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (29, N'Ing.', N'Juraj', N'Vojtech', N'+421 900 123 456', N'juraj.vojtech@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (30, N'Dr.', N'Alice', N'Johnson', N'555-1234-567', N'alice.johnson@company.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (31, N'Prof.', N'John', N'Doe', N'555-9876-543', N'john.doe@company.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (32, N'', N'Emily', N'Clark', N'555-6543-210', N'emily.clark@company.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (33, N'Dr.', N'Raj', N'Singh', N'555-1122-334', N'raj.singh@company.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (34, N'Prof.', N'Susan', N'Baker', N'555-2233-445', N'susan.baker@company.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (35, N'', N'Maria', N'Gomez', N'555-3344-556', N'maria.gomez@company.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (36, N'', N'David', N'Smith', N'555-4455-667', N'david.smith@company.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (37, N'Dr.', N'Linda', N'Nguyen', N'555-5566-778', N'linda.nguyen@company.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (38, N'Prof.', N'James', N'Brown', N'555-6677-889', N'james.brown@company.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (39, N'', N'Angela', N'White', N'555-7788-990', N'angela.white@company.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (40, N'Ing', N'Martin', N'Novák', N'+421 902 345 678', N'martin.novak@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (41, N'Mgr', N'Jana', N'Kováčová', N'+421 905 678 901', N'jana.kovacova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (42, N'', N'Peter', N'Horváth', N'+421 908 123 456', N'peter.horvath@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (43, N'MUDr', N'Eva', N'Sokolová', N'+421 907 234 567', N'eva.sokolova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (45, N'Ing', N'Tomáš', N'Černý', N'+421 904 345 678', N'tomas.cerny@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (46, N'', N'Nina', N'Petrášová', N'+421 903 456 789', N'nina.petrasova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (47, N'Mgr', N'Marek', N'Šebek', N'+421 906 567 890', N'marek.sebek@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (48, N'Ing', N'Lukáš', N'Šimek', N'+421 901 678 901', N'lukas.simek@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (49, N'', N'Simona', N'Miháliková', N'+421 902 789 012', N'simona.mihalikova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (50, N'MUDr', N'Pavol', N'Varga', N'+421 905 890 123', N'pavol.varga@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (51, N'Mgr', N'Gabriela', N'Zelená', N'+421 907 901 234', N'gabriela.zelena@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (52, N'', N'Richard', N'Krajný', N'+421 904 012 345', N'richard.krajny@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (53, N'Ing', N'Alena', N'Benešová', N'+421 903 123 456', N'alena.benesova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (54, N'', N'Jakub', N'Kolek', N'+421 902 234 567', N'jakub.kolek@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (55, N'MUDr', N'Martina', N'Doležalová', N'+421 908 345 678', N'martina.dolezalova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (56, N'Mgr', N'Mária', N'Pavlovičová', N'+421 905 456 789', N'maria.pavlovicova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (57, N'', N'Juraj', N'Hric', N'+421 901 567 890', N'juraj.hric@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (58, N'Ing', N'Monika', N'Majerová', N'+421 903 678 901', N'monika.majerova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (59, N'', N'Miroslav', N'Kubiš', N'+421 902 789 012', N'miroslav.kubis@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (60, N'MUDr', N'Helena', N'Krajčírová', N'+421 906 890 123', N'helena.krajcirova@example.com')
INSERT [dbo].[employees] ([id], [title], [firstName], [LastName], [phoneNumber], [email]) VALUES (61, N'Mgr', N'Stanislav', N'Pletka', N'+421 904 901 234', N'stanislav.pletka@example.com')
SET IDENTITY_INSERT [dbo].[employees] OFF
GO
SET IDENTITY_INSERT [dbo].[projects] ON 

INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (1, N'Revamp Marketing Strategy', N'RMS2024', 12, 29, N'[21]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (2, N'Customer Experience Enhancement', N'CEE2024', 23, 34, N'[]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (3, N'AI-Driven Analytics Platform', N'ADAP2024', 34, 22, N'[18]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (4, N'Global Expansion Initiative', N'GEI2024', 45, 24, N'[2,15]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (5, N'Product Line Diversification', N'PLD2024', 56, 19, N'[8]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (6, N'Digital Transformation Roadmap', N'DTR2024', 11, 31, N'[]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (7, N'Sustainability Integration Plan', N'SIP2024', 14, 32, N'[22]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (8, N'Enterprise Resource Optimization', N'ERO2024', 19, 11, N'[]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (9, N'Customer Data Security Upgrade', N'CDSU2024', 21, 27, N'[3,17]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (10, N'Supply Chain Modernization', N'SCM2024', 25, 22, N'[6,10,13]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (11, N'Cloud Infrastructure Migration', N'CIM2024', 27, 33, N'[16]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (12, N'Employee Engagement Program', N'EEP2024', 32, 25, N'[7]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (13, N'New Product Development', N'NPD2024', 37, 13, N'[12,20]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (14, N'Brand Revitalization Campaign', N'BRC2024', 42, 33, N'[9,14]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (15, N'Innovation Hub Launch', N'IHL2024', 47, 25, N'[]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (16, N'Mobile App Enhancement', N'MAE2024', 49, 35, N'[4]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (17, N'Regulatory Compliance Initiative', N'RCI2024', 51, 32, N'[25]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (18, N'Customer Support Automation', N'CSA2024', 53, 19, N'[]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (19, N'Workplace Wellness Program', N'WWP2024', 56, 15, N'[1,5,26]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (20, N'Data-Driven Marketing Campaign', N'DDMC2024', 15, 17, N'[]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (21, N'IT Infrastructure Upgrade', N'IIU2024', 18, 18, N'[]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (22, N'Customer Journey Mapping', N'CJM2024', 22, 14, N'[23]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (23, N'Sales Strategy Overhaul', N'SSO2024', 28, 15, N'[24]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (24, N'E-commerce Platform Redesign', N'EPR2024', 31, 9, N'[11,27]')
INSERT [dbo].[projects] ([id], [name], [code], [projectManagerId], [divisionId], [departmentsId]) VALUES (25, N'Corporate Social Responsibility', N'CSR2024', 35, 10, N'[]')
SET IDENTITY_INSERT [dbo].[projects] OFF
GO
ALTER TABLE [dbo].[companies] ADD  DEFAULT (N'[]') FOR [divisionsId]
GO
ALTER TABLE [dbo].[divisions] ADD  DEFAULT ((0)) FOR [companyId]
GO
ALTER TABLE [dbo].[divisions] ADD  DEFAULT (N'[]') FOR [projectsId]
GO
ALTER TABLE [dbo].[projects] ADD  DEFAULT (N'[]') FOR [departmentsId]
GO
ALTER TABLE [dbo].[companies]  WITH CHECK ADD  CONSTRAINT [FK_companies_employees_directorId] FOREIGN KEY([directorId])
REFERENCES [dbo].[employees] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[companies] CHECK CONSTRAINT [FK_companies_employees_directorId]
GO
ALTER TABLE [dbo].[departments]  WITH CHECK ADD  CONSTRAINT [FK_departments_employees_headOfDepartmentId] FOREIGN KEY([headOfDepartmentId])
REFERENCES [dbo].[employees] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[departments] CHECK CONSTRAINT [FK_departments_employees_headOfDepartmentId]
GO
ALTER TABLE [dbo].[divisions]  WITH CHECK ADD  CONSTRAINT [FK_divisions_employees_headOfDivisionId] FOREIGN KEY([headOfDivisionId])
REFERENCES [dbo].[employees] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[divisions] CHECK CONSTRAINT [FK_divisions_employees_headOfDivisionId]
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD  CONSTRAINT [FK_projects_employees_projectManagerId] FOREIGN KEY([projectManagerId])
REFERENCES [dbo].[employees] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[projects] CHECK CONSTRAINT [FK_projects_employees_projectManagerId]
GO
