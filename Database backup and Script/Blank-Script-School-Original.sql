USE [SERP]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContactNo] [nchar](20) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[JoiningDate] [datetime] NOT NULL,
	[Designation_ID] [int] NULL,
 CONSTRAINT [PK_User_Registration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([ID], [UserID], [Password], [Name], [ContactNo], [Email], [JoiningDate], [Designation_ID]) VALUES (2, N'Vaibhav03', N'12345', N'Nilesh Khendke', N'12345               ', N'nilesh.khendke@gmail.com', CAST(0x0000A5C600182B80 AS DateTime), 4)
INSERT [dbo].[Users] ([ID], [UserID], [Password], [Name], [ContactNo], [Email], [JoiningDate], [Designation_ID]) VALUES (3, N'Akash', N'123', N'Nilesh', N'9011074525          ', N'nilesh.khendke@gmail.com', CAST(0x0000A62E00ED9450 AS DateTime), 3)
INSERT [dbo].[Users] ([ID], [UserID], [Password], [Name], [ContactNo], [Email], [JoiningDate], [Designation_ID]) VALUES (10, N'Nilesh', N'12345', N'Nilesh Khendke', N'9011074525          ', N'nilesh.khendke@gmail.com', CAST(0x0000A64000AA08EA AS DateTime), 3)
INSERT [dbo].[Users] ([ID], [UserID], [Password], [Name], [ContactNo], [Email], [JoiningDate], [Designation_ID]) VALUES (11, N'admin', N'12345', N'Nilesh Khendke', N'9011074525          ', N'nilesh.khendke@gmail.com', CAST(0x0000A6A80142A03A AS DateTime), 2)
INSERT [dbo].[Users] ([ID], [UserID], [Password], [Name], [ContactNo], [Email], [JoiningDate], [Designation_ID]) VALUES (12, N'Operator', N'123', N'mahesh', N'9011074525          ', N'nilesh.khendke@gmail.com', CAST(0x0000A6A8014F9CE8 AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[UserGrants]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGrants](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Forms] [nvarchar](250) NULL,
	[ViewRecord] [nchar](10) NULL,
	[Saves] [nchar](10) NULL,
	[Updates] [nchar](10) NULL,
	[Deletes] [nchar](10) NULL,
	[Getdata] [nchar](10) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_UserGrants] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserGrants] ON
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13530, N'Master Entry View', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13531, N'Users View', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13532, N'Student View', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13533, N'Student Registration', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13534, N'Hostelers Entry', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13535, N'Student BusHolder Entry', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13536, N'Student Discount View', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13537, N'Library View', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13538, N'Books Fine Setting', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13539, N'Book Reservation', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13540, N'Book Issue', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13541, N'Book Return', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13542, N'Journal and Magazines Billing', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13543, N'Examination View', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13544, N'Examination Schedule', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13545, N'Employee All', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13546, N'Employee Registration', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13547, N'Employee Discount', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13548, N'Payroll All', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13549, N'Employee Attendance', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13550, N'Employee Advance Payment', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13551, N'Salary Payment', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13552, N'Transaction All', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13553, N'School Fees Payment', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13554, N'Hostel Fees Payment', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13555, N'Bus Fees Payment Student', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13556, N'Bus Fees Payment Staff', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13557, N'Barcode Genrator All', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13558, N'Books Barcode Genrator', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13559, N'All Records', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13560, N'Student List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13561, N'Employee List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13562, N'School Fees List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13563, N'School Fees Payment List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13564, N'Hosteler List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13565, N'Hostel Fees Payment List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13566, N'Bus Holder Student List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13567, N'Bus Fees Payment List Student', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13568, N'Bus Holder Staff List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13569, N'Bus Fees Payment List Staff', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13570, N'Due List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13571, N'Employee Attendance List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13572, N'Employee Advance Payment List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13573, N'Salary Payment List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13574, N'Book Supplier List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13575, N'Books List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13576, N'Books Reservation List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13577, N'Books Issue List Student', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13578, N'Books Issue List Staff', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13579, N'Books Return List Student', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13580, N'Books Return List Staff', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13581, N'Subject List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13582, N'Exam Schedule List', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13583, N'All Reports', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13584, N'SMS Setting', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13585, N'Backup & Recovery', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13586, N'Logs', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (13587, N'Help and About', N'True      ', N'False     ', N'True      ', N'True      ', N'True      ', 10)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15096, N'Master Entry View', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15097, N'Users View', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15098, N'Student View', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15099, N'Student Registration', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15100, N'Hostelers Entry', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15101, N'Student BusHolder Entry', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15102, N'Student Discount View', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15103, N'Library View', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15104, N'Books Fine Setting', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15105, N'Book Reservation', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15106, N'Book Issue', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15107, N'Book Return', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15108, N'Journal and Magazines Billing', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15109, N'Examination View', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15110, N'Examination Schedule', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15111, N'Employee All', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15112, N'Employee Registration', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15113, N'Employee Discount', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15114, N'Payroll All', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15115, N'Employee Attendance', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15116, N'Employee Advance Payment', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15117, N'Salary Payment', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15118, N'Transaction All', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15119, N'School Fees Payment', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15120, N'Hostel Fees Payment', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15121, N'Bus Fees Payment Student', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15122, N'Bus Fees Payment Staff', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15123, N'Barcode Genrator All', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15124, N'Books Barcode Genrator', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15125, N'All Records', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15126, N'View Student List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15127, N'View Employee List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15128, N'View School Fees List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15129, N'View School Fees Payment List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15130, N'View Hosteler List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15131, N'View Hostel Fees Payment List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15132, N'View Bus Holder Student List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15133, N'View Bus Fees Payment List Student', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15134, N'View Bus Holder Staff List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15135, N'View Bus Fees Payment List Staff', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15136, N'View Due List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15137, N'View Employee Attendance List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
GO
print 'Processed 100 total records'
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15138, N'View Employee Advance Payment List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15139, N'View Salary Payment List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15140, N'View Book Supplier List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15141, N'View Books List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15142, N'View Books Reservation List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15143, N'View Books Issue List Student', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15144, N'View Books Issue List Staff', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15145, N'View Books Return List Student', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15146, N'View Books Return List Staff', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15147, N'View Subject List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15148, N'View Exam Schedule List', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15149, N'View All Reports', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15150, N'View SMS Setting', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15151, N'View Backup & Recovery', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15152, N'View Logs', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15153, N'View Help and About', N'False     ', N'False     ', N'False     ', N'False     ', N'False     ', 3)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15792, N'Master Entry View', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15793, N'Users View', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15794, N'Student View', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15795, N'Student Registration', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15796, N'Hostelers Entry', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15797, N'Student BusHolder Entry', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15798, N'Student Discount View', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15799, N'Library View', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15800, N'Books Fine Setting', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15801, N'Book Reservation', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15802, N'Book Issue', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15803, N'Book Return', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15804, N'Journal and Magazines Billing', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15805, N'Examination View', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15806, N'Examination Schedule', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15807, N'Employee All', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15808, N'Employee Registration', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15809, N'Employee Discount', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15810, N'Payroll All', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15811, N'Employee Attendance', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15812, N'Employee Advance Payment', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15813, N'Salary Payment', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15814, N'Transaction All', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15815, N'School Fees Payment', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15816, N'Hostel Fees Payment', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15817, N'Bus Fees Payment Student', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15818, N'Bus Fees Payment Staff', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15819, N'Barcode Genrator All', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15820, N'Books Barcode Genrator', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15821, N'All Records', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15822, N'View Student List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15823, N'View Employee List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15824, N'View School Fees List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15825, N'View School Fees Payment List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15826, N'View Hosteler List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15827, N'View Hostel Fees Payment List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15828, N'View Bus Holder Student List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15829, N'View Bus Fees Payment List Student', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15830, N'View Bus Holder Staff List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15831, N'View Bus Fees Payment List Staff', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15832, N'View Due List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15833, N'View Employee Attendance List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15834, N'View Employee Advance Payment List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15835, N'View Salary Payment List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15836, N'View Book Supplier List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15837, N'View Books List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15838, N'View Books Reservation List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15839, N'View Books Issue List Student', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15840, N'View Books Issue List Staff', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15841, N'View Books Return List Student', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15842, N'View Books Return List Staff', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15843, N'View Subject List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15844, N'View Exam Schedule List', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15845, N'View All Reports', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15846, N'View SMS Setting', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15847, N'View Backup & Recovery', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15848, N'View Logs', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
INSERT [dbo].[UserGrants] ([id], [Forms], [ViewRecord], [Saves], [Updates], [Deletes], [Getdata], [UserID]) VALUES (15849, N'View Help and About', N'True      ', N'True      ', N'True      ', N'True      ', N'True      ', 11)
SET IDENTITY_INSERT [dbo].[UserGrants] OFF
/****** Object:  Table [dbo].[Supplier]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] NOT NULL,
	[SupplierMax] [nchar](30) NOT NULL,
	[SupplierName] [nchar](150) NULL,
	[Address] [nchar](200) NULL,
	[ContactNo] [nchar](15) NULL,
	[EmailID] [nchar](120) NULL,
	[S_Books] [nchar](10) NULL,
	[S_Newspaper] [nchar](10) NULL,
	[S_Magazines] [nchar](10) NULL,
	[Remarks] [nvarchar](250) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Supplier] ([SupplierID], [SupplierMax], [SupplierName], [Address], [ContactNo], [EmailID], [S_Books], [S_Newspaper], [S_Magazines], [Remarks]) VALUES (1, N'SP-1                          ', N'vaibhav patidar                                                                                                                                       ', N'indore                                                                                                                                                                                                  ', N'8349102353     ', N'vaibhavpatidar36@gmail.com                                                                                              ', N'No        ', N'Yes       ', N'No        ', N'')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierMax], [SupplierName], [Address], [ContactNo], [EmailID], [S_Books], [S_Newspaper], [S_Magazines], [Remarks]) VALUES (2, N'SP-2                          ', N'Deepak Sharma                                                                                                                                         ', N'indore                                                                                                                                                                                                  ', N'8349102353     ', N'deepak@22                                                                                                               ', N'Yes       ', N'Yes       ', N'No        ', N'no')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierMax], [SupplierName], [Address], [ContactNo], [EmailID], [S_Books], [S_Newspaper], [S_Magazines], [Remarks]) VALUES (3, N'SP-3                          ', N'Karan Malhotra                                                                                                                                        ', N'Vijaynagar Indore                                                                                                                                                                                       ', N'8989656563     ', N'Karan77@gmail.com                                                                                                       ', N'Yes       ', N'No        ', N'No        ', N'Karan is a good Supplier....!!!')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierMax], [SupplierName], [Address], [ContactNo], [EmailID], [S_Books], [S_Newspaper], [S_Magazines], [Remarks]) VALUES (4, N'SP-4                          ', N'Akshay Kumar                                                                                                                                          ', N'Mumbai                                                                                                                                                                                                  ', N'9630014949     ', N'Akshaykumar36@gmail.com                                                                                                 ', N'Yes       ', N'No        ', N'No        ', N'No Remark...!!!')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierMax], [SupplierName], [Address], [ContactNo], [EmailID], [S_Books], [S_Newspaper], [S_Magazines], [Remarks]) VALUES (5, N'SP-5                          ', N'Ahmad Khan                                                                                                                                            ', N'Mumbai                                                                                                                                                                                                  ', N'8349102353     ', N'Khan99@gmail.com                                                                                                        ', N'Yes       ', N'No        ', N'No        ', N'NO Remarks...!!!
')
/****** Object:  Table [dbo].[Subject]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectCode] [nvarchar](100) NOT NULL,
	[SubjectName] [nvarchar](max) NULL,
	[SessionID] [int] NULL,
	[SchoolID] [int] NULL,
	[ClassID] [int] NULL,
	[SubjectType] [nchar](100) NULL,
	[MaxClasses] [int] NULL,
	[TimeFrom] [nchar](30) NULL,
	[TimeTo] [nchar](30) NULL,
 CONSTRAINT [PK_Subject_1] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentDiscount]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentDiscount](
	[StudentDisID] [int] IDENTITY(1,1) NOT NULL,
	[Admission_No] [nchar](50) NULL,
	[Feetype] [nchar](50) NULL,
	[Discount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_StudentDiscount] PRIMARY KEY CLUSTERED 
(
	[StudentDisID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentBusHolder]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentBusHolder](
	[BusHolderID] [int] IDENTITY(1,1) NOT NULL,
	[Admission_No] [nchar](50) NULL,
	[Bus_ID] [int] NULL,
	[Location_ID] [int] NULL,
	[JoiningDate] [datetime] NULL,
	[Status] [nchar](10) NULL,
 CONSTRAINT [PK_StudentBusHolder] PRIMARY KEY CLUSTERED 
(
	[BusHolderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[AdmissionNo] [nchar](50) NOT NULL,
	[EnrollmentNo] [nchar](50) NULL,
	[StudentName] [nchar](100) NULL,
	[FatherName] [nchar](100) NULL,
	[FatherOcc] [nchar](80) NULL,
	[MotherName] [nchar](100) NULL,
	[MotherOcc] [nchar](80) NULL,
	[ParentContact] [nchar](15) NULL,
	[PermanentAddress] [nchar](250) NULL,
	[TemporaryAddress] [nchar](250) NULL,
	[ContactNo] [nchar](15) NULL,
	[Email] [nchar](100) NULL,
	[DOB] [nchar](30) NULL,
	[Gender] [nchar](10) NULL,
	[AdmissionDate] [datetime] NULL,
	[Category] [nchar](100) NULL,
	[Religion] [nchar](100) NULL,
	[Photo] [image] NULL,
	[Status] [nchar](35) NULL,
	[Nationality] [nchar](100) NULL,
	[ClassSection_ID] [int] NULL,
	[School_ID] [int] NULL,
	[LastSchool] [nchar](100) NULL,
	[LastClass] [nchar](100) NULL,
	[PassingYr] [int] NULL,
	[percents] [nchar](15) NULL,
	[Board] [nchar](100) NULL,
	[BloodGroup] [nchar](20) NULL,
	[Height] [nchar](30) NULL,
	[Weight] [nchar](30) NULL,
	[GuardianName] [nchar](100) NULL,
	[Address] [nchar](250) NULL,
	[GuardianContact] [nchar](15) NULL,
	[Session_ID] [int] NULL,
	[Result] [nchar](30) NULL,
	[HomeContact] [nchar](15) NULL,
	[Bus] [decimal](18, 2) NULL,
	[Class] [decimal](18, 2) NULL,
	[Hostel] [decimal](18, 2) NULL,
	[City] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[AdmissionNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffPayment]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaffPayment](
	[Id] [int] NOT NULL,
	[PaymentID] [nchar](20) NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
	[StaffID] [int] NOT NULL,
	[PresentDays] [int] NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[Advance] [decimal](18, 2) NOT NULL,
	[Deduction] [decimal](18, 2) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[ModeOfPayment] [nchar](50) NULL,
	[PaymentModeDetails] [varchar](max) NULL,
	[NetPay] [decimal](18, 2) NULL,
 CONSTRAINT [PK_StaffPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Staffdiscount]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffdiscount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Staff_ID] [int] NULL,
	[Discount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Staffdiscount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffBusHolder]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffBusHolder](
	[StaffBusHolderID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NULL,
	[Bus_ID] [int] NULL,
	[Location_ID] [int] NULL,
	[JoiningDate] [datetime] NULL,
	[Status] [nchar](10) NULL,
 CONSTRAINT [PK_StaffBusHolder] PRIMARY KEY CLUSTERED 
(
	[StaffBusHolderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffBusFeesPayment]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaffBusFeesPayment](
	[FP_ID] [nchar](10) NOT NULL,
	[MaxID] [nchar](30) NULL,
	[StaffBusHolder_ID] [int] NULL,
	[Session] [nvarchar](30) NULL,
	[Installment] [nchar](30) NULL,
	[TotalFee] [decimal](18, 2) NULL,
	[DiscountPer] [decimal](18, 2) NULL,
	[DiscountAmt] [decimal](18, 2) NULL,
	[PreviousDue] [decimal](18, 2) NULL,
	[Fine] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[TotalPaid] [decimal](18, 2) NULL,
	[ModeOfPayment] [nchar](100) NULL,
	[PaymentModeDetails] [varchar](250) NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentDue] [decimal](18, 2) NULL,
	[Location] [nchar](150) NULL,
 CONSTRAINT [PK_StaffBusFeesPayment] PRIMARY KEY CLUSTERED 
(
	[FP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaffAttendance]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffAttendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkingDate] [datetime] NULL,
	[StaffID] [int] NULL,
	[Status] [nchar](20) NULL,
	[InTime] [nchar](30) NULL,
	[OutTime] [nchar](30) NULL,
 CONSTRAINT [PK_StaffAttendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SMSSetting]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMSSetting](
	[APIURL] [nvarchar](150) NULL,
	[IsDefault] [nchar](50) NULL,
	[IsEnabled] [nchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SMSSetting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SMSSetting] ON
INSERT [dbo].[SMSSetting] ([APIURL], [IsDefault], [IsEnabled], [ID]) VALUES (N'Set Your SMS API Here...', N'Yes                                               ', N'Yes                                               ', 4)
SET IDENTITY_INSERT [dbo].[SMSSetting] OFF
/****** Object:  Table [dbo].[Setting]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[BookType] [nchar](30) NOT NULL,
	[MaxDays_Staff] [int] NULL,
	[MaxDays_Student] [int] NULL,
	[FinePerDay_Student] [decimal](18, 2) NULL,
	[FinePerDay_Staff] [decimal](18, 2) NULL,
	[MaxBooks_Staff] [int] NULL,
	[MaxBooks_Student] [int] NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[BookType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Setting] ([BookType], [MaxDays_Staff], [MaxDays_Student], [FinePerDay_Student], [FinePerDay_Staff], [MaxBooks_Staff], [MaxBooks_Student]) VALUES (N'Normal                        ', 5, 5, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), 2, 3)
INSERT [dbo].[Setting] ([BookType], [MaxDays_Staff], [MaxDays_Student], [FinePerDay_Student], [FinePerDay_Staff], [MaxBooks_Staff], [MaxBooks_Student]) VALUES (N'Reference                     ', 2, 2, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), 5, 5)
/****** Object:  Table [dbo].[Sessions]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[Session] [nvarchar](30) NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON
INSERT [dbo].[Sessions] ([SessionID], [Session]) VALUES (3, N'2015-2016')
INSERT [dbo].[Sessions] ([SessionID], [Session]) VALUES (5, N'2016-2017')
SET IDENTITY_INSERT [dbo].[Sessions] OFF
/****** Object:  Table [dbo].[Section]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[SectionName] [nvarchar](30) NOT NULL,
	[SectionID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Section_1] PRIMARY KEY CLUSTERED 
(
	[SectionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Section] ON
INSERT [dbo].[Section] ([SectionName], [SectionID]) VALUES (N'B              ', 1)
INSERT [dbo].[Section] ([SectionName], [SectionID]) VALUES (N'C              ', 2)
INSERT [dbo].[Section] ([SectionName], [SectionID]) VALUES (N'A', 3)
INSERT [dbo].[Section] ([SectionName], [SectionID]) VALUES (N'D              ', 4)
SET IDENTITY_INSERT [dbo].[Section] OFF
/****** Object:  Table [dbo].[SchoolTypes]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolTypes](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolType] [nvarchar](250) NULL,
 CONSTRAINT [PK_SchoolTypes] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SchoolTypes] ON
INSERT [dbo].[SchoolTypes] ([CategoryID], [SchoolType]) VALUES (1, N'CBSE School')
INSERT [dbo].[SchoolTypes] ([CategoryID], [SchoolType]) VALUES (5, N'MP Board')
INSERT [dbo].[SchoolTypes] ([CategoryID], [SchoolType]) VALUES (6, N'State Board School')
SET IDENTITY_INSERT [dbo].[SchoolTypes] OFF
/****** Object:  Table [dbo].[SchoolFeesPayment]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SchoolFeesPayment](
	[SFP_ID] [int] NOT NULL,
	[MaxID] [nchar](30) NULL,
	[Admission_No] [nchar](50) NULL,
	[Session] [nvarchar](30) NULL,
	[TotalFee] [decimal](18, 2) NULL,
	[DiscountPer] [decimal](18, 2) NULL,
	[DiscountAmt] [decimal](18, 2) NULL,
	[PreviousDue] [decimal](18, 2) NULL,
	[Fine] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[TotalPaid] [decimal](18, 2) NULL,
	[ModeOfPayment] [nchar](100) NULL,
	[PaymentModeDetails] [varchar](250) NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentDue] [decimal](18, 2) NULL,
	[School] [varchar](250) NULL,
	[ClassName] [nvarchar](50) NULL,
	[Section] [nvarchar](30) NULL,
 CONSTRAINT [PK_SchoolFeesPayment] PRIMARY KEY CLUSTERED 
(
	[SFP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SchoolFees]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolFees](
	[SchoolFeeID] [int] IDENTITY(1,1) NOT NULL,
	[Class_ID] [int] NULL,
	[FeeID] [int] NULL,
	[Fee] [decimal](18, 2) NULL,
	[Month] [nchar](30) NULL,
	[School_ID] [int] NULL,
 CONSTRAINT [PK_CourseFee] PRIMARY KEY CLUSTERED 
(
	[SchoolFeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[School](
	[SchoolID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolName] [varchar](250) NULL,
	[Address] [varchar](250) NULL,
	[ContactNo] [nchar](15) NULL,
	[Email] [nchar](30) NULL,
	[Fax] [nchar](50) NULL,
	[Website] [nchar](60) NULL,
	[City] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[Photo] [image] NULL,
	[Category_ID] [int] NULL,
 CONSTRAINT [PK_Schoolnfo] PRIMARY KEY CLUSTERED 
(
	[SchoolID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Scheduling]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scheduling](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExamDate] [datetime] NULL,
	[MaxMarks] [decimal](18, 2) NULL,
	[MinMarks] [decimal](18, 2) NULL,
	[StartTime] [nvarchar](30) NULL,
	[EndTime] [nvarchar](30) NULL,
	[Subject_ID] [int] NULL,
	[Schedule_ID] [int] NULL,
 CONSTRAINT [PK_Scheduling] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Return_Student]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Return_Student](
	[ReturnID] [int] IDENTITY(1,1) NOT NULL,
	[IssueID] [int] NULL,
	[ReturnDate] [datetime] NULL,
	[Fine] [decimal](18, 2) NULL,
	[Remarks] [nvarchar](250) NULL,
 CONSTRAINT [PK_Return_Student] PRIMARY KEY CLUSTERED 
(
	[ReturnID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Return_Staff]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Return_Staff](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IssueID] [int] NULL,
	[ReturnDate] [datetime] NULL,
	[Fine] [decimal](18, 2) NULL,
	[Remarks] [nvarchar](250) NULL,
 CONSTRAINT [PK_Return_Staff] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resulting]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resulting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Result_ID] [int] NULL,
	[AdmissionNo] [nchar](50) NULL,
	[Marks] [decimal](18, 2) NULL,
	[Absent] [nvarchar](10) NULL,
 CONSTRAINT [PK_Resulting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ResultID] [int] NOT NULL,
	[ScheduleID] [int] NULL,
	[SubjectID] [int] NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[ResultID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarksEntry_Join]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarksEntry_Join](
	[TBID] [int] IDENTITY(1,1) NOT NULL,
	[MarksID] [int] NOT NULL,
	[Subject_ID] [int] NOT NULL,
	[MaxMarks] [decimal](18, 2) NOT NULL,
	[MMPractical] [decimal](18, 2) NOT NULL,
	[CreditHours] [decimal](18, 2) NOT NULL,
	[OMTheory] [decimal](18, 2) NOT NULL,
	[OMPractical] [decimal](18, 2) NOT NULL,
	[OGTheory] [nvarchar](10) NULL,
	[OGPractical] [nvarchar](10) NULL,
	[FinalGrade] [nvarchar](50) NULL,
	[GradePoint] [decimal](18, 2) NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_MarksEntry_Join] PRIMARY KEY CLUSTERED 
(
	[TBID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarksEntry]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarksEntry](
	[M_ID] [int] NOT NULL,
	[AdmissionNo] [nchar](50) NULL,
	[StudentSchool] [nvarchar](250) NULL,
	[Session] [nvarchar](100) NULL,
	[StudentClass] [nvarchar](150) NULL,
	[StudentSection] [nvarchar](100) NULL,
	[EntryDate] [datetime] NULL,
	[Result] [nchar](20) NULL,
 CONSTRAINT [PK_MarksEntry] PRIMARY KEY CLUSTERED 
(
	[M_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MarksEntry] ([M_ID], [AdmissionNo], [StudentSchool], [Session], [StudentClass], [StudentSection], [EntryDate], [Result]) VALUES (1, N'A00085                                            ', N'Medicaps International School', N'2016-2017', N'1st', N'A', CAST(0x0000A69100F22189 AS DateTime), N'Pass                ')
INSERT [dbo].[MarksEntry] ([M_ID], [AdmissionNo], [StudentSchool], [Session], [StudentClass], [StudentSection], [EntryDate], [Result]) VALUES (2, N'a005                                              ', N'Medicaps International School', N'2016-2017', N'1st', N'A', CAST(0x0000A6920033C54B AS DateTime), N'Pass                ')
INSERT [dbo].[MarksEntry] ([M_ID], [AdmissionNo], [StudentSchool], [Session], [StudentClass], [StudentSection], [EntryDate], [Result]) VALUES (3, N'A-00018                                           ', N'Medicaps International School', N'2016-2017', N'1st', N'A', CAST(0x0000A6AE0042A6B0 AS DateTime), N'Pass                ')
/****** Object:  Table [dbo].[Logs]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nchar](150) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Operation] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Logs] ON
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4182, N'user-1                                                                                                                                                ', CAST(0x0000A69B01065E77 AS DateTime), N'deleted the all logs till date ''10-10-2016 3:55:15 PM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4183, N'user-1                                                                                                                                                ', CAST(0x0000A69B010698B7 AS DateTime), N'User ''Vinod'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4184, N'user-1                                                                                                                                                ', CAST(0x0000A69B0106AD63 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4185, N'admin                                                                                                                                                 ', CAST(0x0000A69B0106B9CC AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4186, N'admin                                                                                                                                                 ', CAST(0x0000A69B010912A9 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4187, N'admin                                                                                                                                                 ', CAST(0x0000A69B010AD967 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4188, N'admin                                                                                                                                                 ', CAST(0x0000A69C002C824A AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4189, N'admin                                                                                                                                                 ', CAST(0x0000A69C002F4021 AS DateTime), N'Book is Returned By Student :''Deepak kumar patidar'' Where Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4190, N'admin                                                                                                                                                 ', CAST(0x0000A69C003169B4 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4191, N'User                                                                                                                                                  ', CAST(0x0000A69C0064C50D AS DateTime), N'Book is Issued By Staff :''Veer'' Where Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4192, N'admin                                                                                                                                                 ', CAST(0x0000A69C0069B596 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4193, N'admin                                                                                                                                                 ', CAST(0x0000A69C006A43FF AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4194, N'admin                                                                                                                                                 ', CAST(0x0000A69C006BA4C3 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4195, N'User                                                                                                                                                  ', CAST(0x0000A69C010DE4D6 AS DateTime), N'Book is Issued By Student :''Deepak kumar patidar'' Where Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4196, N'User                                                                                                                                                  ', CAST(0x0000A69C011023BD AS DateTime), N'Book is Issued By Student :''Deepak kumar patidar'' Where Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4197, N'User                                                                                                                                                  ', CAST(0x0000A69C011FF585 AS DateTime), N'Book is Returned By Student :''Deepak kumar patidar'' Where Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4198, N'admin                                                                                                                                                 ', CAST(0x0000A69C017AD3C6 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4199, N'admin                                                                                                                                                 ', CAST(0x0000A69D01657A61 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4200, N'admin                                                                                                                                                 ', CAST(0x0000A69D01661EA0 AS DateTime), N'Updated Student''Deepak kumar '' having AdmissionNo''A00085'' and Class''1st'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4201, N'admin                                                                                                                                                 ', CAST(0x0000A69D016DA9BA AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4202, N'User                                                                                                                                                  ', CAST(0x0000A69F009AC559 AS DateTime), N'Book is Returned By Staff :''Veer'' Where Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4203, N'User                                                                                                                                                  ', CAST(0x0000A69F009C71EB AS DateTime), N'Added the New Employee''Vimal Patidar''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4204, N'User                                                                                                                                                  ', CAST(0x0000A69F009CE135 AS DateTime), N'Book is Issued By Staff :''Vimal Patidar'' Where Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4205, N'User                                                                                                                                                  ', CAST(0x0000A69F009D3BF7 AS DateTime), N'Book is Returned By Staff :''Vimal Patidar'' Where Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4206, N'User                                                                                                                                                  ', CAST(0x0000A69F00D282C2 AS DateTime), N'Added New Student''Mahendra Tripathi'' having AdmissionNo''A00089'' and Class''1st'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4207, N'admin                                                                                                                                                 ', CAST(0x0000A69F00D2C0DD AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4208, N'admin                                                                                                                                                 ', CAST(0x0000A69F00D3286B AS DateTime), N'Updated Student''Mahendra Tripathi'' having AdmissionNo''A00089'' and Class''1st'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4209, N'admin                                                                                                                                                 ', CAST(0x0000A69F00D38FAE AS DateTime), N'Updated Student''Raman Sharma'' having AdmissionNo''a005'' and Class''1st'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4210, N'admin                                                                                                                                                 ', CAST(0x0000A69F00D3A963 AS DateTime), N'Updated Student''Vaibhav kumar'' having AdmissionNo''A-00018'' and Class''1st'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4211, N'admin                                                                                                                                                 ', CAST(0x0000A69F00D3BBE1 AS DateTime), N'Updated Student''Deepak kumar'' having AdmissionNo''A00085'' and Class''1st'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4212, N'User                                                                                                                                                  ', CAST(0x0000A69F00D563D8 AS DateTime), N'Updated the School ''Medicaps International School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4213, N'User                                                                                                                                                  ', CAST(0x0000A69F00D58393 AS DateTime), N'Updated the School ''Medicaps International School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4214, N'User                                                                                                                                                  ', CAST(0x0000A69F00D65EB4 AS DateTime), N'Updated the School ''Medicaps International School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4215, N'User                                                                                                                                                  ', CAST(0x0000A69F0116B0E7 AS DateTime), N'Updated the Staff''Raju Tiwari'' having EmployeeID ''4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4216, N'User                                                                                                                                                  ', CAST(0x0000A69F0117AEE3 AS DateTime), N'Staff Attendance is Taken For Staff=''Raju Tiwari'' having StaffID=''EMP-4'' and Working Date ''14-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4217, N'User                                                                                                                                                  ', CAST(0x0000A69F0117E7B1 AS DateTime), N'Staff Attendance is Taken For Staff=''Vimal Patidar'' having StaffID=''EMP-5'' and Working Date ''14-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4218, N'admin                                                                                                                                                 ', CAST(0x0000A69F0118A758 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4219, N'admin                                                                                                                                                 ', CAST(0x0000A69F011962BF AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4220, N'admin                                                                                                                                                 ', CAST(0x0000A69F011B9496 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4221, N'admin                                                                                                                                                 ', CAST(0x0000A69F011BF998 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4222, N'admin                                                                                                                                                 ', CAST(0x0000A69F011D191D AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4223, N'admin                                                                                                                                                 ', CAST(0x0000A69F011E122B AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4224, N'admin                                                                                                                                                 ', CAST(0x0000A69F011F0D8D AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4225, N'admin                                                                                                                                                 ', CAST(0x0000A69F011FDCA7 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4226, N'admin                                                                                                                                                 ', CAST(0x0000A69F011FFBCB AS DateTime), N'Salary is paid For Staff'''' having StaffID ''EMP-5'' and PaymentID ''EP-1''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4227, N'admin                                                                                                                                                 ', CAST(0x0000A69F01218028 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4228, N'admin                                                                                                                                                 ', CAST(0x0000A69F0121CB65 AS DateTime), N'Salary is paid For Staff'''' having StaffID ''EMP-4'' and PaymentID ''EP-2''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4229, N'admin                                                                                                                                                 ', CAST(0x0000A6A000B3A9A6 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4230, N'admin                                                                                                                                                 ', CAST(0x0000A6A000BCDDBF AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4231, N'admin                                                                                                                                                 ', CAST(0x0000A6A000C28906 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4232, N'admin                                                                                                                                                 ', CAST(0x0000A6A000C73FEE AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4233, N'admin                                                                                                                                                 ', CAST(0x0000A6A000C9803C AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4234, N'admin                                                                                                                                                 ', CAST(0x0000A6A000CB5631 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4235, N'admin                                                                                                                                                 ', CAST(0x0000A6A000CBC8C0 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4236, N'admin                                                                                                                                                 ', CAST(0x0000A6A000CC8AAB AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4237, N'admin                                                                                                                                                 ', CAST(0x0000A6A000CFC803 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4238, N'admin                                                                                                                                                 ', CAST(0x0000A6A000D119FB AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4239, N'admin                                                                                                                                                 ', CAST(0x0000A6A000D143B4 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4240, N'admin                                                                                                                                                 ', CAST(0x0000A6A000D2942A AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4241, N'admin                                                                                                                                                 ', CAST(0x0000A6A000EF0319 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4242, N'User                                                                                                                                                  ', CAST(0x0000A6A001399136 AS DateTime), N'New Advance Payment is Taken By Staff on Date ''15-10-2016 12:00:00 AM'' having StaffID=''EMP-4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4243, N'admin                                                                                                                                                 ', CAST(0x0000A6A10006863B AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4244, N'User                                                                                                                                                  ', CAST(0x0000A6A10006C1F5 AS DateTime), N'Added the New Section ''B'' For Class''1st''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4245, N'admin                                                                                                                                                 ', CAST(0x0000A6A10006D981 AS DateTime), N'Updated Student''Deepak kumar'' having AdmissionNo''A00085'' and Class''1st'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4246, N'admin                                                                                                                                                 ', CAST(0x0000A6A1012217B9 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4247, N'admin                                                                                                                                                 ', CAST(0x0000A6A1014F488C AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4248, N'admin                                                                                                                                                 ', CAST(0x0000A6A1017B73B9 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4249, N'admin                                                                                                                                                 ', CAST(0x0000A6A10180211E AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4250, N'admin                                                                                                                                                 ', CAST(0x0000A6A101814F23 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4251, N'admin                                                                                                                                                 ', CAST(0x0000A6A10182196F AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4252, N'admin                                                                                                                                                 ', CAST(0x0000A6A101826A8D AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4253, N'admin                                                                                                                                                 ', CAST(0x0000A6A10182A85F AS DateTime), N'Book ''A0055'' is Reserved For Staff ''Vimal Patidar''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4254, N'admin                                                                                                                                                 ', CAST(0x0000A6A101834348 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4255, N'admin                                                                                                                                                 ', CAST(0x0000A6A10183A293 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4256, N'admin                                                                                                                                                 ', CAST(0x0000A6A10184CA73 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4257, N'admin                                                                                                                                                 ', CAST(0x0000A6A200FCC5A3 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4258, N'admin                                                                                                                                                 ', CAST(0x0000A6A200FE5746 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4259, N'admin                                                                                                                                                 ', CAST(0x0000A6A200FFB82B AS DateTime), N'New Bus is Added having BusNo''205''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4260, N'admin                                                                                                                                                 ', CAST(0x0000A6A200FFCAC9 AS DateTime), N'Bus is Updated having BusNo''B002''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4261, N'admin                                                                                                                                                 ', CAST(0x0000A6A2011C37A4 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4262, N'admin                                                                                                                                                 ', CAST(0x0000A6A2011CD60A AS DateTime), N'Updated the Class Type=''Nursary Class''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4263, N'admin                                                                                                                                                 ', CAST(0x0000A6A2011CE4E2 AS DateTime), N'Updated the Class Type=''Primary Class''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4264, N'admin                                                                                                                                                 ', CAST(0x0000A6A2011CF085 AS DateTime), N'Deleted the Class Type=''''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4265, N'User                                                                                                                                                  ', CAST(0x0000A6A2011EA639 AS DateTime), N'Exam Group''End Term''is Updated')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4266, N'User                                                                                                                                                  ', CAST(0x0000A6A2011EAD2A AS DateTime), N'Exam Group''Mid Term Exam''is Updated')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4267, N'admin                                                                                                                                                 ', CAST(0x0000A6A2013FB597 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4268, N'admin                                                                                                                                                 ', CAST(0x0000A6A2014021E3 AS DateTime), N'Updated Student''Deepak kumar'' having AdmissionNo''A00085'' and Class''1st'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4269, N'User                                                                                                                                                  ', CAST(0x0000A6A20140579A AS DateTime), N'StudentDiscount is Updated Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4270, N'admin                                                                                                                                                 ', CAST(0x0000A6A20141ED7D AS DateTime), N'Book ''Optimization Book of maths'' is Updated having AccessionNo=''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4271, N'admin                                                                                                                                                 ', CAST(0x0000A6A20143227D AS DateTime), N'Updated the Staff''Raju Tiwari'' having EmployeeID ''4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4272, N'admin                                                                                                                                                 ', CAST(0x0000A6A201437F3A AS DateTime), N'Staff Attendance is Taken For Staff=''Vimal Patidar'' having StaffID=''EMP-5'' and Working Date ''17-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4273, N'admin                                                                                                                                                 ', CAST(0x0000A6A2014437AF AS DateTime), N'Advance Payment is Taken By Staff on Date ''14-10-2016 12:00:00 AM'' is Updated For StaffID=''EMP-5''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4274, N'admin                                                                                                                                                 ', CAST(0x0000A6A2014D1842 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4275, N'User                                                                                                                                                  ', CAST(0x0000A6A2014DDFA0 AS DateTime), N'Book ''Optimization Book of maths'' is Updated having AccessionNo=''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4276, N'User                                                                                                                                                  ', CAST(0x0000A6A2014DFD8B AS DateTime), N'Book ''Optimization Book of maths'' is Updated having AccessionNo=''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4277, N'User                                                                                                                                                  ', CAST(0x0000A6A300253F9B AS DateTime), N'Added new HostelFeesPayment For Student''System.Windows.Forms.TextBox, Text: Deepak kumar'' and AdmissionNo''A00085''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4278, N'admin                                                                                                                                                 ', CAST(0x0000A6A30031690A AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4279, N'admin                                                                                                                                                 ', CAST(0x0000A6A30031D966 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4280, N'admin                                                                                                                                                 ', CAST(0x0000A6A300328134 AS DateTime), N'Updated HostelFeesPayment  having Student''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' and AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4281, N'admin                                                                                                                                                 ', CAST(0x0000A6A30033A97D AS DateTime), N'Successfully logged in')
GO
print 'Processed 100 total records'
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4282, N'admin                                                                                                                                                 ', CAST(0x0000A6A3003405C1 AS DateTime), N'Deleted HostelFeesPayment  having Student''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' and AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4283, N'admin                                                                                                                                                 ', CAST(0x0000A6A30034362C AS DateTime), N'Added new HostelFeesPayment For Student''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' and AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4284, N'admin                                                                                                                                                 ', CAST(0x0000A6A300345DE9 AS DateTime), N'Updated HostelFeesPayment  having Student''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' and AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4285, N'ADMIN                                                                                                                                                 ', CAST(0x0000A6A300353D49 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4286, N'ADMIN                                                                                                                                                 ', CAST(0x0000A6A3003589AA AS DateTime), N'Updated HostelFeesPayment  having Student''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' and AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4287, N'User                                                                                                                                                  ', CAST(0x0000A6A300C0D78C AS DateTime), N'New BusHolder ''Raju Tiwari is Added Successfully  Having StaffID''4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4288, N'admin                                                                                                                                                 ', CAST(0x0000A6A301324F01 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4289, N'admin                                                                                                                                                 ', CAST(0x0000A6A30132675D AS DateTime), N'Successfully backup the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4290, N'admin                                                                                                                                                 ', CAST(0x0000A6A30133F221 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4291, N'admin                                                                                                                                                 ', CAST(0x0000A6A30133FA42 AS DateTime), N'Successfully backup the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4292, N'admin                                                                                                                                                 ', CAST(0x0000A6A301351639 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4293, N'admin                                                                                                                                                 ', CAST(0x0000A6A30135A56B AS DateTime), N'Successfully restore the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4294, N'admin                                                                                                                                                 ', CAST(0x0000A6A30136802C AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4295, N'admin                                                                                                                                                 ', CAST(0x0000A6A30138F37A AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4296, N'admin                                                                                                                                                 ', CAST(0x0000A6A3013951BD AS DateTime), N'BusFeesPayment ''1st Installment''is Successfully Paid By Staff StaffID''EMP-4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4297, N'admin                                                                                                                                                 ', CAST(0x0000A6A3013960AD AS DateTime), N'BusFeesPayment ''1st Installment''is Updated For Staff having StaffID''EMP-4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4298, N'admin                                                                                                                                                 ', CAST(0x0000A6A3013BB261 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4299, N'admin                                                                                                                                                 ', CAST(0x0000A6A3013DB2FE AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4300, N'admin                                                                                                                                                 ', CAST(0x0000A6A3013E6BEA AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4301, N'admin                                                                                                                                                 ', CAST(0x0000A6A30140C331 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4302, N'admin                                                                                                                                                 ', CAST(0x0000A6A30140F931 AS DateTime), N'BusFeesPayment ''2nd Installment''is Successfully Updated For Student''Raman Sharma'' Having AdmissionNo''a005''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4303, N'admin                                                                                                                                                 ', CAST(0x0000A6A301429E35 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4304, N'admin                                                                                                                                                 ', CAST(0x0000A6A30142F321 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4305, N'admin                                                                                                                                                 ', CAST(0x0000A6A3016C8C17 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4306, N'admin                                                                                                                                                 ', CAST(0x0000A6A3016F0AE9 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4307, N'admin                                                                                                                                                 ', CAST(0x0000A6A3016FA02D AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4308, N'admin                                                                                                                                                 ', CAST(0x0000A6A3017009A6 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4309, N'admin                                                                                                                                                 ', CAST(0x0000A6A301704499 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4310, N'admin                                                                                                                                                 ', CAST(0x0000A6A301706F16 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4311, N'admin                                                                                                                                                 ', CAST(0x0000A6A30170BE55 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4312, N'admin                                                                                                                                                 ', CAST(0x0000A6A3017198E6 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4313, N'admin                                                                                                                                                 ', CAST(0x0000A6A301734D40 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4314, N'admin                                                                                                                                                 ', CAST(0x0000A6A4001DA0B8 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4315, N'admin                                                                                                                                                 ', CAST(0x0000A6A4001F015D AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4316, N'admin                                                                                                                                                 ', CAST(0x0000A6A4001FA1DD AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4317, N'admin                                                                                                                                                 ', CAST(0x0000A6A4001FF59C AS DateTime), N'Successfully backup the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4318, N'admin                                                                                                                                                 ', CAST(0x0000A6A4001FF893 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4319, N'admin                                                                                                                                                 ', CAST(0x0000A6A4013354B5 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4320, N'admin                                                                                                                                                 ', CAST(0x0000A6A60000D246 AS DateTime), N'Successfully restore the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4321, N'admin                                                                                                                                                 ', CAST(0x0000A6A60002A2D1 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4322, N'admin                                                                                                                                                 ', CAST(0x0000A6A600A575B5 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4323, N'admin                                                                                                                                                 ', CAST(0x0000A6A8009C6161 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4324, N'admin                                                                                                                                                 ', CAST(0x0000A6A8009C80C7 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4325, N'admin                                                                                                                                                 ', CAST(0x0000A6A80104AE8D AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4326, N'admin                                                                                                                                                 ', CAST(0x0000A6A80104C4BE AS DateTime), N'Updated the Class=''9th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4327, N'admin                                                                                                                                                 ', CAST(0x0000A6A801059EAC AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4328, N'User                                                                                                                                                  ', CAST(0x0000A6A80105EB54 AS DateTime), N'Added the New School ''g'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4329, N'User                                                                                                                                                  ', CAST(0x0000A6A80105F51F AS DateTime), N'Deleted the School '''' having SchoolType=''''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4330, N'admin                                                                                                                                                 ', CAST(0x0000A6A80106616F AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4331, N'admin                                                                                                                                                 ', CAST(0x0000A6A801324679 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4332, N'admin                                                                                                                                                 ', CAST(0x0000A6A80132C567 AS DateTime), N'Session ''2016-2017'' is Updated Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4333, N'admin                                                                                                                                                 ', CAST(0x0000A6A80133426A AS DateTime), N'User ''Vinod'' is Deleted  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4334, N'admin                                                                                                                                                 ', CAST(0x0000A6A801338B1B AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4335, N'User                                                                                                                                                  ', CAST(0x0000A6A801363E64 AS DateTime), N'User ''vaibhav patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4336, N'User                                                                                                                                                  ', CAST(0x0000A6A801415B47 AS DateTime), N'Updated Subject''Computer'' having School''Medicaps International School'' and Class''1st'' and Session''2016-2017''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4337, N'User                                                                                                                                                  ', CAST(0x0000A6A80142A044 AS DateTime), N'New User ''vaibhav'' is Registered  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4338, N'User                                                                                                                                                  ', CAST(0x0000A6A80142AB8D AS DateTime), N'User ''vaibhav'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4339, N'User                                                                                                                                                  ', CAST(0x0000A6A8014F9D17 AS DateTime), N'New User ''vaibhav'' is Registered  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4340, N'User                                                                                                                                                  ', CAST(0x0000A6A801516307 AS DateTime), N'User ''vaibhav'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4341, N'User                                                                                                                                                  ', CAST(0x0000A6A801516831 AS DateTime), N'User ''Vandana Patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4342, N'User                                                                                                                                                  ', CAST(0x0000A6A801518CF6 AS DateTime), N'User ''Pramod Patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4343, N'User                                                                                                                                                  ', CAST(0x0000A6A80151997E AS DateTime), N'User ''Vandana Patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4344, N'User                                                                                                                                                  ', CAST(0x0000A6A80151CE11 AS DateTime), N'User ''vaibhav patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4345, N'admin                                                                                                                                                 ', CAST(0x0000A6A900DBFAA8 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4346, N'admin                                                                                                                                                 ', CAST(0x0000A6A900DC10AB AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4347, N'admin                                                                                                                                                 ', CAST(0x0000A6A900DC533D AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4348, N'admin                                                                                                                                                 ', CAST(0x0000A6A900DC5F1B AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4349, N'vaibhav04                                                                                                                                             ', CAST(0x0000A6A900DC9EA8 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4350, N'vaibhav04                                                                                                                                             ', CAST(0x0000A6A900DD0E1F AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4351, N'admin                                                                                                                                                 ', CAST(0x0000A6A900DD2900 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4352, N'admin                                                                                                                                                 ', CAST(0x0000A6A900DEEE52 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4353, N'admin                                                                                                                                                 ', CAST(0x0000A6A90189B0E8 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4354, N'admin                                                                                                                                                 ', CAST(0x0000A6A90189D0D5 AS DateTime), N'Schooltype '''' is Deleted Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4355, N'admin                                                                                                                                                 ', CAST(0x0000A6A90189D7D1 AS DateTime), N'Schooltype '''' is Deleted Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4356, N'admin                                                                                                                                                 ', CAST(0x0000A6A90189DE27 AS DateTime), N'Schooltype '''' is Deleted Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4357, N'admin                                                                                                                                                 ', CAST(0x0000A6A9018A032E AS DateTime), N'New Schooltype ''MP Board'' is Added Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4358, N'User                                                                                                                                                  ', CAST(0x0000A6A9018A24AF AS DateTime), N'Deleted the School '''' having SchoolType=''''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4359, N'admin                                                                                                                                                 ', CAST(0x0000A6A9018A43BF AS DateTime), N'Deleted the School Fee having Class=''2nd'' and FeeName=''Cautions  Moneys''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4360, N'admin                                                                                                                                                 ', CAST(0x0000A6A9018A53DA AS DateTime), N'Deleted the School Fee having Class=''2nd'' and FeeName=''Lab Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4361, N'admin                                                                                                                                                 ', CAST(0x0000A6A9018A5CBA AS DateTime), N'Deleted the School Fee having Class=''1st'' and FeeName=''Cautions  Moneys''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4362, N'admin                                                                                                                                                 ', CAST(0x0000A6A9018A643B AS DateTime), N'Deleted the School Fee having Class=''1st'' and FeeName=''Cautions  Moneys''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4363, N'admin                                                                                                                                                 ', CAST(0x0000A6A9018AEA43 AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Cautions  Moneys''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4364, N'admin                                                                                                                                                 ', CAST(0x0000A6A9018B76C4 AS DateTime), N'Deleted Bus having BusNo''B002''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4365, N'admin                                                                                                                                                 ', CAST(0x0000A6AA00000951 AS DateTime), N'Location ''Vijaynagar '' is Updated Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4366, N'admin                                                                                                                                                 ', CAST(0x0000A6AA00001E3C AS DateTime), N'Book Supplier ''Deepak ji'' is Updated')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4367, N'admin                                                                                                                                                 ', CAST(0x0000A6AA0000305E AS DateTime), N'Book Supplier ''vaibhav patidar'' is Updated')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4368, N'admin                                                                                                                                                 ', CAST(0x0000A6AA00009AF1 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 002 Maths.'' is Updated ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4369, N'admin                                                                                                                                                 ', CAST(0x0000A6AA0000BA6C AS DateTime), N'Book ''Optimization Book of maths'' is Updated having AccessionNo=''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4370, N'admin                                                                                                                                                 ', CAST(0x0000A6AA00011C9B AS DateTime), N'Updated Book Category ''Optimization Techniques'' Having Books Classification :''000 Computer science, information & general works''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4371, N'admin                                                                                                                                                 ', CAST(0x0000A6AA0002EC4D AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4372, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E62CA8 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4373, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E6DA76 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4374, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E7A45A AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4375, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E83075 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4376, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E85297 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4377, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E85EC7 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4378, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E866AF AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4379, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E872DD AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4380, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E8B872 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4381, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E90C94 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4382, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E9275C AS DateTime), N'Successfully logged out')
GO
print 'Processed 200 total records'
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4383, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E969AC AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4384, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00E9C18C AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4385, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00FBCD9A AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4386, N'User                                                                                                                                                  ', CAST(0x0000A6AB00FC0664 AS DateTime), N'Updated the School ''Medicaps International School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4387, N'admin                                                                                                                                                 ', CAST(0x0000A6AB00FCF9E3 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4388, N'admin                                                                                                                                                 ', CAST(0x0000A6AB010102F9 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4389, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0103515C AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4390, N'admin                                                                                                                                                 ', CAST(0x0000A6AB010351C3 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4391, N'admin                                                                                                                                                 ', CAST(0x0000A6AB010609BB AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4392, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01060A0F AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4393, N'admin                                                                                                                                                 ', CAST(0x0000A6AB011F8555 AS DateTime), N'Added the Class Type=''Secondary Class''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4394, N'admin                                                                                                                                                 ', CAST(0x0000A6AB011F934C AS DateTime), N'Added the Class Type=''Higher Secondary ''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4395, N'User                                                                                                                                                  ', CAST(0x0000A6AB01210BE4 AS DateTime), N'Added the New School ''D.A.V. Public School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4396, N'User                                                                                                                                                  ', CAST(0x0000A6AB01227C7A AS DateTime), N'Added the New School ''R.A.N. Public School'' having SchoolType=''MP Board''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4397, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0122A8FD AS DateTime), N'Updated the Class=''1st''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4398, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0122B091 AS DateTime), N'Updated the Class=''2nd''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4399, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0122BF77 AS DateTime), N'Updated the Class=''4th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4400, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0122D0C3 AS DateTime), N'Updated the Class=''5th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4401, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01244051 AS DateTime), N'Added the New Class=''6th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4402, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01244FC5 AS DateTime), N'Added the New Class=''7th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4403, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01245EA7 AS DateTime), N'Added the New Class=''8th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4404, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0124A958 AS DateTime), N'Added the New Class=''9th ''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4405, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0124B752 AS DateTime), N'Added the New Class=''10th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4406, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0124DFFA AS DateTime), N'Added the New Class=''11th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4407, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0124EB65 AS DateTime), N'Added the New Class=''12th ''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4408, N'admin                                                                                                                                                 ', CAST(0x0000A6AB012507DC AS DateTime), N'Section ''A1'' is Updated Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4409, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01256CD3 AS DateTime), N'Section ''A'' is Updated Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4410, N'User                                                                                                                                                  ', CAST(0x0000A6AB0125FF23 AS DateTime), N'Updated the  Section ''A'' For Class''5th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4411, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0126709B AS DateTime), N'Added the New Class=''3rd''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4412, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01269A72 AS DateTime), N'Updated the Feename ''Caution  Money''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4413, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0126B0AB AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4414, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0126B0D5 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4415, N'admin                                                                                                                                                 ', CAST(0x0000A6AB012AA50C AS DateTime), N'New Session ''2014-2015'' is Added Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4416, N'admin                                                                                                                                                 ', CAST(0x0000A6AB012AAEF3 AS DateTime), N'Session ''2014-2019'' is Updated Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4417, N'admin                                                                                                                                                 ', CAST(0x0000A6AB012AB771 AS DateTime), N'Session ''2014-2015'' is Updated Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4418, N'admin                                                                                                                                                 ', CAST(0x0000A6AB012B5B8D AS DateTime), N'Session ''    -'' is Deleted Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4419, N'admin                                                                                                                                                 ', CAST(0x0000A6AB012C2F0C AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4420, N'admin                                                                                                                                                 ', CAST(0x0000A6AB012C2F4D AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4421, N'User                                                                                                                                                  ', CAST(0x0000A6AB01329D03 AS DateTime), N'Added the New Section ''A'' For Class''4th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4422, N'User                                                                                                                                                  ', CAST(0x0000A6AB0132AFC0 AS DateTime), N'Added the New Section ''A'' For Class''3rd''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4423, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0132BC9F AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4424, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0132BCC9 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4425, N'User                                                                                                                                                  ', CAST(0x0000A6AB01332632 AS DateTime), N'Added the New Section ''A'' For Class''6th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4426, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0142E39F AS DateTime), N'Updated the Class=''1st''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4427, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0142F403 AS DateTime), N'Updated the Class=''2nd''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4428, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01430418 AS DateTime), N'Updated the Class=''3rd''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4429, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01431F0A AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4430, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01431F3E AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4431, N'User                                                                                                                                                  ', CAST(0x0000A6AB0145C2D8 AS DateTime), N'Updated the Class=''4th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4432, N'User                                                                                                                                                  ', CAST(0x0000A6AB0145D61B AS DateTime), N'Updated the Class=''5th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4433, N'User                                                                                                                                                  ', CAST(0x0000A6AB0145E25B AS DateTime), N'Updated the Class=''6th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4434, N'User                                                                                                                                                  ', CAST(0x0000A6AB0145EE43 AS DateTime), N'Updated the Class=''7th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4435, N'User                                                                                                                                                  ', CAST(0x0000A6AB0145FA17 AS DateTime), N'Updated the Class=''8th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4436, N'User                                                                                                                                                  ', CAST(0x0000A6AB014611D6 AS DateTime), N'Updated the Class=''10th ''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4437, N'User                                                                                                                                                  ', CAST(0x0000A6AB01461CF2 AS DateTime), N'Updated the Class=''9th ''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4438, N'User                                                                                                                                                  ', CAST(0x0000A6AB014641CB AS DateTime), N'Updated the Class=''4th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4439, N'User                                                                                                                                                  ', CAST(0x0000A6AB01464C6D AS DateTime), N'Updated the Class=''5th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4440, N'User                                                                                                                                                  ', CAST(0x0000A6AB01465ECD AS DateTime), N'Updated the Class=''6th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4441, N'User                                                                                                                                                  ', CAST(0x0000A6AB0146DD4D AS DateTime), N'Updated the Class=''9th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4442, N'User                                                                                                                                                  ', CAST(0x0000A6AB0146FAB7 AS DateTime), N'Deleted the Class=''9th ''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4443, N'User                                                                                                                                                  ', CAST(0x0000A6AB01470429 AS DateTime), N'Deleted the Class=''6th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4444, N'User                                                                                                                                                  ', CAST(0x0000A6AB01472A48 AS DateTime), N'Updated the Class=''10th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4445, N'User                                                                                                                                                  ', CAST(0x0000A6AB014734E2 AS DateTime), N'Deleted the Class=''8th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4446, N'User                                                                                                                                                  ', CAST(0x0000A6AB015057D2 AS DateTime), N'Updated the Class=''10th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4447, N'User                                                                                                                                                  ', CAST(0x0000A6AB0150A58C AS DateTime), N'Updated the Class=''3rd''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4448, N'User                                                                                                                                                  ', CAST(0x0000A6AB0150AE5B AS DateTime), N'Updated the Class=''4th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4449, N'User                                                                                                                                                  ', CAST(0x0000A6AB0150BE03 AS DateTime), N'Updated the Class=''5th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4450, N'User                                                                                                                                                  ', CAST(0x0000A6AB0150CE54 AS DateTime), N'Updated the Class=''6th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4451, N'User                                                                                                                                                  ', CAST(0x0000A6AB0150D8DD AS DateTime), N'Updated the Class=''7th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4452, N'User                                                                                                                                                  ', CAST(0x0000A6AB0150E4B4 AS DateTime), N'Updated the Class=''8th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4453, N'User                                                                                                                                                  ', CAST(0x0000A6AB0150EF91 AS DateTime), N'Updated the Class=''9th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4454, N'User                                                                                                                                                  ', CAST(0x0000A6AB0151040D AS DateTime), N'Added the New Class=''10th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4455, N'User                                                                                                                                                  ', CAST(0x0000A6AB01512087 AS DateTime), N'Added the New Class=''11th ''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4456, N'User                                                                                                                                                  ', CAST(0x0000A6AB01512B58 AS DateTime), N'Added the New Class=''12th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4457, N'User                                                                                                                                                  ', CAST(0x0000A6AB01513BA4 AS DateTime), N'Updated the Class=''9th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4458, N'User                                                                                                                                                  ', CAST(0x0000A6AB0151A987 AS DateTime), N'Updated the  Section ''A'' For Class''6th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4459, N'User                                                                                                                                                  ', CAST(0x0000A6AB0151BA88 AS DateTime), N'Added the New Section ''A'' For Class''7th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4460, N'User                                                                                                                                                  ', CAST(0x0000A6AB0151C6AE AS DateTime), N'Added the New Section ''A'' For Class''8th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4461, N'User                                                                                                                                                  ', CAST(0x0000A6AB0151D8D4 AS DateTime), N'Added the New Section ''A'' For Class''9th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4462, N'User                                                                                                                                                  ', CAST(0x0000A6AB0151E1E5 AS DateTime), N'Added the New Section ''A'' For Class''11th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4463, N'User                                                                                                                                                  ', CAST(0x0000A6AB0152ADC3 AS DateTime), N'Updated the  Section ''A'' For Class''5th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4464, N'User                                                                                                                                                  ', CAST(0x0000A6AB0152B83E AS DateTime), N'Updated the  Section ''A'' For Class''6th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4465, N'User                                                                                                                                                  ', CAST(0x0000A6AB0152C01D AS DateTime), N'Updated the  Section ''A'' For Class''7th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4466, N'User                                                                                                                                                  ', CAST(0x0000A6AB0152CA26 AS DateTime), N'Updated the  Section ''A'' For Class''8th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4467, N'User                                                                                                                                                  ', CAST(0x0000A6AB0152D6DA AS DateTime), N'Updated the  Section ''A'' For Class''9th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4468, N'User                                                                                                                                                  ', CAST(0x0000A6AB0152E11C AS DateTime), N'Updated the  Section ''A'' For Class''10th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4469, N'User                                                                                                                                                  ', CAST(0x0000A6AB0152EB27 AS DateTime), N'Updated the  Section ''A'' For Class''11th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4470, N'User                                                                                                                                                  ', CAST(0x0000A6AB0152F58A AS DateTime), N'Updated the  Section ''A'' For Class''12th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4471, N'User                                                                                                                                                  ', CAST(0x0000A6AB0152FF86 AS DateTime), N'Added the New Section ''B'' For Class''11th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4472, N'admin                                                                                                                                                 ', CAST(0x0000A6AB015989A1 AS DateTime), N'Added New Student''Amit Sharma'' having AdmissionNo''A0015'' and Class''5th'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4473, N'admin                                                                                                                                                 ', CAST(0x0000A6AB015A18D1 AS DateTime), N'Updated Student''Raman Sharma'' having AdmissionNo''a005'' and Class''1st'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4474, N'admin                                                                                                                                                 ', CAST(0x0000A6AB015B7E07 AS DateTime), N'Added New Student''Akshay Kumar'' having AdmissionNo''A00455'' and Class''4th'' and School''R.A.N. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4475, N'admin                                                                                                                                                 ', CAST(0x0000A6AB015CCFE1 AS DateTime), N'Added the New Employee''Pooja Patel''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4476, N'admin                                                                                                                                                 ', CAST(0x0000A6AB015DDD58 AS DateTime), N'Added the New Employee''Mamta Ahuja''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4477, N'admin                                                                                                                                                 ', CAST(0x0000A6AB015E86A9 AS DateTime), N'New Designation ''principal'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4478, N'admin                                                                                                                                                 ', CAST(0x0000A6AB015E93AE AS DateTime), N'Designation ''Principal'' is Updated')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4479, N'admin                                                                                                                                                 ', CAST(0x0000A6AB015EBD32 AS DateTime), N'New Designation ''Bus Driver'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4480, N'admin                                                                                                                                                 ', CAST(0x0000A6AB015EDEC8 AS DateTime), N'New Designation ''Bus Cleaner'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4481, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01612D27 AS DateTime), N'New Department ''Compter Department'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4482, N'admin                                                                                                                                                 ', CAST(0x0000A6AB016142BE AS DateTime), N'Department ''Maths Department'' is Updated')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4483, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01616D27 AS DateTime), N'Department ''English Department'' is Updated')
GO
print 'Processed 300 total records'
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4484, N'admin                                                                                                                                                 ', CAST(0x0000A6AB016188BE AS DateTime), N'New Department ''Physics Department'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4485, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0161A3D2 AS DateTime), N'New Department ''Department of Education'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4486, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0162CB78 AS DateTime), N'Added the New Employee''Prashant Bhushan''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4487, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0163EE90 AS DateTime), N'Added the New Employee''Alex ''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4488, N'admin                                                                                                                                                 ', CAST(0x0000A6AB017C0FA7 AS DateTime), N'Added New Student''Rohit Patidar'' having AdmissionNo''A00477'' and Class''2nd'' and School''R.A.N. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4489, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0187AE9A AS DateTime), N'Added New Student''Robet Alex'' having AdmissionNo''A005444'' and Class''1st'' and School''D.A.V. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4490, N'admin                                                                                                                                                 ', CAST(0x0000A6AB0187E093 AS DateTime), N'Updated Student''Raman Sharma'' having AdmissionNo''a005'' and Class''2nd'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4491, N'admin                                                                                                                                                 ', CAST(0x0000A6AB01880902 AS DateTime), N'Updated Student''Deepak kumar'' having AdmissionNo''A00085'' and Class''6th'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4492, N'admin                                                                                                                                                 ', CAST(0x0000A6AC008B8EDD AS DateTime), N'Added New Student''Jaya Kumari'' having AdmissionNo''A00986'' and Class''1st'' and School''D.A.V. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4493, N'admin                                                                                                                                                 ', CAST(0x0000A6AC008CCE67 AS DateTime), N'Added New Student''Akira Sachdev'' having AdmissionNo''A000825'' and Class''10th'' and School''D.A.V. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4494, N'admin                                                                                                                                                 ', CAST(0x0000A6AC008D9265 AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Lab Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4495, N'admin                                                                                                                                                 ', CAST(0x0000A6AC008DFFE7 AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''School Development Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4496, N'admin                                                                                                                                                 ', CAST(0x0000A6AC008E5063 AS DateTime), N'added New  FeeType  ''Registration Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4497, N'admin                                                                                                                                                 ', CAST(0x0000A6AC008EB87D AS DateTime), N'added New  FeeType  ''Security Deposit (Interest free)''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4498, N'admin                                                                                                                                                 ', CAST(0x0000A6AC008EC8A8 AS DateTime), N'Deleted the Fee Type''School Fees''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4499, N'admin                                                                                                                                                 ', CAST(0x0000A6AC008EDA29 AS DateTime), N'Deleted the Fee Type''Library Fees''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4500, N'admin                                                                                                                                                 ', CAST(0x0000A6AC008F0841 AS DateTime), N'added New  FeeType  ''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4501, N'User                                                                                                                                                  ', CAST(0x0000A6AC009940EE AS DateTime), N'Added the New Class=''14''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4502, N'User                                                                                                                                                  ', CAST(0x0000A6AC00994EE4 AS DateTime), N'Added the New Class=''13th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4503, N'User                                                                                                                                                  ', CAST(0x0000A6AC009959B7 AS DateTime), N'Deleted the Class=''13th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4504, N'User                                                                                                                                                  ', CAST(0x0000A6AC00996369 AS DateTime), N'Deleted the Class=''14''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4505, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AA47EF AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Registration Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4506, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AA6056 AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Registration Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4507, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AA74A8 AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Registration Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4508, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AA88CE AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4509, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AA9E90 AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4510, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AAB723 AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4511, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AADA18 AS DateTime), N'Added the New School Fees having Class=''2nd'' and FeeName=''School Development Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4512, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AB1D15 AS DateTime), N'Added the New School Fees having Class=''2nd'' and FeeName=''Registration Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4513, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AB314A AS DateTime), N'Added the New School Fees having Class=''2nd'' and FeeName=''School Development Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4514, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AB442A AS DateTime), N'Added the New School Fees having Class=''2nd'' and FeeName=''Lab Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4515, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AB5666 AS DateTime), N'Added the New School Fees having Class=''2nd'' and FeeName=''Lab Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4516, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AB6ADA AS DateTime), N'Added the New School Fees having Class=''3rd'' and FeeName=''Lab Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4517, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AB83DD AS DateTime), N'Added the New School Fees having Class=''3rd'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4518, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00AB9A61 AS DateTime), N'Added the New School Fees having Class=''3rd'' and FeeName=''Registration Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4519, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00ABAD20 AS DateTime), N'Added the New School Fees having Class=''3rd'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4520, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00ABC1EA AS DateTime), N'Added the New School Fees having Class=''3rd'' and FeeName=''Registration Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4521, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B0C762 AS DateTime), N'Added the New School Fees having Class=''4th'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4522, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B10386 AS DateTime), N'Added the New School Fees having Class=''4th'' and FeeName=''School Development Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4523, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B1175D AS DateTime), N'Added the New School Fees having Class=''4th'' and FeeName=''Caution  Money''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4524, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B13EEB AS DateTime), N'Added the New School Fees having Class=''2nd'' and FeeName=''School Development Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4525, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B1523A AS DateTime), N'Added the New School Fees having Class=''2nd'' and FeeName=''Lab Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4526, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B16B87 AS DateTime), N'Added the New School Fees having Class=''2nd'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4527, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B17D8E AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4528, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B18EF8 AS DateTime), N'Added the New School Fees having Class=''2nd'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4529, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B3FC80 AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4530, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B40E11 AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Lab Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4531, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B4211C AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''School Development Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4532, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B43252 AS DateTime), N'Added the New School Fees having Class=''4th'' and FeeName=''Processing Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4533, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B44D82 AS DateTime), N'Added the New School Fees having Class=''4th'' and FeeName=''School Development Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4534, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B46D7A AS DateTime), N'Added the New School Fees having Class=''4th'' and FeeName=''Security Deposit (Interest free)''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4535, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B48D8C AS DateTime), N'Updated the School Fee having Class=''4th'' and FeeName=''School Development Fee''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4536, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B5CC08 AS DateTime), N'Added the New Employee''Jagdish Joshi''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4537, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B640C2 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4538, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B640EC AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4539, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00B848E3 AS DateTime), N'Updated the Staff''Raju Tiwari'' having EmployeeID ''4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4540, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00BA8AB1 AS DateTime), N'Updated the Staff''Prashant Bhushan'' having EmployeeID ''8''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4541, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00BAA5A6 AS DateTime), N'Updated the Staff''Mamta Ahuja'' having EmployeeID ''7''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4542, N'admin                                                                                                                                                 ', CAST(0x0000A6AC00BAB775 AS DateTime), N'Updated the Staff''Alex'' having EmployeeID ''9''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4543, N'admin                                                                                                                                                 ', CAST(0x0000A6AC01140ABB AS DateTime), N'Updated Student''Akira Sachdev'' having AdmissionNo''A000825'' and Class''6th'' and School''D.A.V. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4544, N'admin                                                                                                                                                 ', CAST(0x0000A6AC0119D4EA AS DateTime), N'User ''vaibhav'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4545, N'admin                                                                                                                                                 ', CAST(0x0000A6AC0119E2C8 AS DateTime), N'User ''Veer Patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4546, N'admin                                                                                                                                                 ', CAST(0x0000A6AC011A3114 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4547, N'admin                                                                                                                                                 ', CAST(0x0000A6AC011A315C AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4548, N'admin                                                                                                                                                 ', CAST(0x0000A6AC012E2F05 AS DateTime), N'Updated Student''Akira Sachdev'' having AdmissionNo''A000825'' and Class''5th'' and School''D.A.V. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4549, N'User                                                                                                                                                  ', CAST(0x0000A6AC012E6222 AS DateTime), N'Added the New Section ''A'' For Class''3rd''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4550, N'User                                                                                                                                                  ', CAST(0x0000A6AC012E728B AS DateTime), N'Updated the  Section ''A'' For Class''3rd''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4551, N'User                                                                                                                                                  ', CAST(0x0000A6AC012E7B1B AS DateTime), N'Updated the  Section ''A'' For Class''4th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4552, N'User                                                                                                                                                  ', CAST(0x0000A6AC012E8327 AS DateTime), N'Updated the  Section ''A'' For Class''5th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4553, N'User                                                                                                                                                  ', CAST(0x0000A6AC012E8D9C AS DateTime), N'Updated the  Section ''A'' For Class''6th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4554, N'User                                                                                                                                                  ', CAST(0x0000A6AC012E96C6 AS DateTime), N'Updated the  Section ''A'' For Class''7th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4555, N'User                                                                                                                                                  ', CAST(0x0000A6AC012EA675 AS DateTime), N'Updated the  Section ''A'' For Class''8th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4556, N'User                                                                                                                                                  ', CAST(0x0000A6AC012EB178 AS DateTime), N'Updated the  Section ''A'' For Class''9th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4557, N'User                                                                                                                                                  ', CAST(0x0000A6AC012EBB3A AS DateTime), N'Updated the  Section ''A'' For Class''10th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4558, N'admin                                                                                                                                                 ', CAST(0x0000A6AC012ED199 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4559, N'admin                                                                                                                                                 ', CAST(0x0000A6AC012ED1C3 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4560, N'admin                                                                                                                                                 ', CAST(0x0000A6AC0132EB0E AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4561, N'admin                                                                                                                                                 ', CAST(0x0000A6AC0132EC93 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4562, N'admin                                                                                                                                                 ', CAST(0x0000A6AC0133A04D AS DateTime), N'New Schooltype ''State Board School'' is Added Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4563, N'User                                                                                                                                                  ', CAST(0x0000A6AC0133EA3A AS DateTime), N'Updated the School ''Medicaps International School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4564, N'admin                                                                                                                                                 ', CAST(0x0000A6AC01343027 AS DateTime), N'Added the New Class=''13 th''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4565, N'admin                                                                                                                                                 ', CAST(0x0000A6AC01379F5F AS DateTime), N'Book is Issued By Student :''Rohit Patidar'' Where Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4566, N'admin                                                                                                                                                 ', CAST(0x0000A6AC01380958 AS DateTime), N'Book is Returned By Student :''Rohit Patidar'' Where Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4567, N'admin                                                                                                                                                 ', CAST(0x0000A6AC01387C36 AS DateTime), N'Exam is Schedule  having ExamName''Mid Term Exam''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4568, N'User                                                                                                                                                  ', CAST(0x0000A6AC013A2140 AS DateTime), N'BusHolder ''Raju Tiwari is Updated Successfully  Having StaffID''4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4569, N'admin                                                                                                                                                 ', CAST(0x0000A6AC013A732D AS DateTime), N'Staff Attendance is Taken For Staff=''Jagdish Joshi'' having StaffID=''EMP-10'' and Working Date ''27-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4570, N'admin                                                                                                                                                 ', CAST(0x0000A6AC013C1F1B AS DateTime), N'Added new HostelFeesPayment For Student''System.Windows.Forms.TextBox, Text: Deepak kumar'' and AdmissionNo''A00085''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4571, N'admin                                                                                                                                                 ', CAST(0x0000A6AC01429592 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4572, N'User                                                                                                                                                  ', CAST(0x0000A6AD0007C1AA AS DateTime), N'Updated Hosteler  ''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' having AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4573, N'User                                                                                                                                                  ', CAST(0x0000A6AD0007CD53 AS DateTime), N'Updated Hosteler  ''System.Windows.Forms.TextBox, Text: Deepak kumar'' having AdmissionNo''A00085''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4574, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0096BBEA AS DateTime), N'Deleted HostelFeesPayment  having Student''System.Windows.Forms.TextBox, Text: Deepak kumar'' and AdmissionNo''A00085''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4575, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0096C8FF AS DateTime), N'Deleted HostelFeesPayment  having Student''System.Windows.Forms.TextBox, Text: Deepak kumar'' and AdmissionNo''A00085''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4576, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0096D733 AS DateTime), N'Deleted HostelFeesPayment  having Student''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' and AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4577, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0096ED86 AS DateTime), N'BusFeesPayment ''2nd Installment''is Successfully Deleted For Student''Raman Sharma'' Having AdmissionNo''a005''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4578, N'admin                                                                                                                                                 ', CAST(0x0000A6AD009734B8 AS DateTime), N'BusFeesPayment ''1st Installment''is Successfully Deleted For Student''Raman Sharma'' Having AdmissionNo''a005''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4579, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00973EA0 AS DateTime), N'BusFeesPayment ''1st Installment''is Successfully Deleted For Student''Deepak kumar'' Having AdmissionNo''A00085''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4580, N'admin                                                                                                                                                 ', CAST(0x0000A6AD009774C3 AS DateTime), N'BusFeesPayment ''1stInstallment''is Deleted For Staff having StaffID''EMP-4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4581, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0097B94C AS DateTime), N'Deleted Hosteler  ''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' having AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4582, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0097C6BA AS DateTime), N'Deleted Hosteler  ''System.Windows.Forms.TextBox, Text: Deepak kumar'' having AdmissionNo''A00085''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4583, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0097FE62 AS DateTime), N'BusHolder ''Raman Sharma is Deleted Successfully  Having AdmissionNo''a005''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4584, N'admin                                                                                                                                                 ', CAST(0x0000A6AD009834D4 AS DateTime), N'BusHolder ''Deepak kumar is Deleted Successfully  Having AdmissionNo''A00085''')
GO
print 'Processed 400 total records'
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4585, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0098E289 AS DateTime), N'Successfully backup the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4586, N'admin                                                                                                                                                 ', CAST(0x0000A6AD009953AB AS DateTime), N'Updated Book Category ''Optimization Techniques'' Having Books Classification :''000 Computer science, information & general works''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4587, N'admin                                                                                                                                                 ', CAST(0x0000A6AD009A1CDA AS DateTime), N'Salary is paid For Staff'''' having StaffID ''EMP-9'' and PaymentID ''EP-3''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4588, N'admin                                                                                                                                                 ', CAST(0x0000A6AD009A2714 AS DateTime), N'Salary payment is Deleted For Staff'''' having StaffID ''EMP-9'' and PaymentID ''EP-3''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4589, N'admin                                                                                                                                                 ', CAST(0x0000A6AD009AC855 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4590, N'admin                                                                                                                                                 ', CAST(0x0000A6AD009AC8CA AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4591, N'admin                                                                                                                                                 ', CAST(0x0000A6AD009CB604 AS DateTime), N'Salary payment is Deleted For Staff'''' having StaffID ''EMP-4'' and PaymentID ''EP-2''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4592, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00A5A1E8 AS DateTime), N'Scheduled Exam is Deleted having ExamName''Mid Term Exam''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4593, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00A5B143 AS DateTime), N'Scheduled Exam is Deleted having ExamName''Mid Term Exam''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4594, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00A5D088 AS DateTime), N'Scheduled Exam is Updated having ExamName''Mid Term Exam''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4595, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B25BD0 AS DateTime), N'Added Hosteler  ''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' having AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4596, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B27F25 AS DateTime), N'New BusHolder ''Vaibhav kumar is Added Successfully  Having AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4597, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B299A4 AS DateTime), N'New BusHolder ''Mahendra Tripathi is Added Successfully  Having AdmissionNo''A00089''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4598, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B2AF51 AS DateTime), N'Added Hosteler  ''System.Windows.Forms.TextBox, Text: Rohit Patidar'' having AdmissionNo''A00477''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4599, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B325C1 AS DateTime), N'BusFeesPayment ''1st Installment''is Successfully Paid By Student''Vaibhav kumar'' Having AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4600, N'User                                                                                                                                                  ', CAST(0x0000A6AD00B445D5 AS DateTime), N'Updated the School ''D.A.V. Public School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4601, N'User                                                                                                                                                  ', CAST(0x0000A6AD00B46B1B AS DateTime), N'Updated the School ''D.A.V. Public School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4602, N'User                                                                                                                                                  ', CAST(0x0000A6AD00B4BBB1 AS DateTime), N'Updated the School ''R.A.N. Public School'' having SchoolType=''MP Board''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4603, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B58A6A AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 580 Plants (Botany)'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4604, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B77469 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 570 Life sciences; biology'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4605, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B783E3 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 570 Life sciences'' is Updated ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4606, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B79A93 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 630 Agriculture'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4607, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B7B220 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 610 Medicine & health'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4608, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B7E151 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 620 Engineering'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4609, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B7FDF7 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 740 Drawing & decorative arts'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4610, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B816A0 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: English & Old English literatures'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4611, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B8302C AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 360 Social problems & social services'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4612, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B848C4 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 310 Statistics'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4613, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B86E84 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 550 Earth sciences & geology'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4614, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B88346 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 000 Computer science, information'' is Updated ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4615, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B89B22 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 000 Computer science and  information'' is Updated ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4616, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B8B7D8 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 320 Political science'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4617, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B8CEF7 AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 340 Law'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4618, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B8E48C AS DateTime), N'Book Classification''System.Windows.Forms.TextBox, Text: 330 Economics'' is Added ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4619, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B90821 AS DateTime), N'Book Supplier ''Deepak Sharma'' is Updated')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4620, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B954E6 AS DateTime), N'New Book Supplier ''Karan Malhotra'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4621, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B9972F AS DateTime), N'New Book Supplier ''Akshay Kumar'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4622, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00B9CDB7 AS DateTime), N'New Book Supplier ''Ahmad Khan'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4623, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BABFD6 AS DateTime), N'Book Category '' Physical Geography'' is Added For Books Classification :''900 History & geography''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4624, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BAE754 AS DateTime), N'Book Category ''Anthropology'' is Added For Books Classification :''900 History & geography''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4625, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BB09D0 AS DateTime), N'Book Category '' General'' is Added For Books Classification :''300 Social sciences''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4626, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BB3B2C AS DateTime), N'Book Category ''Social history, problems, reform'' is Added For Books Classification :''300 Social sciences''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4627, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BB5A3F AS DateTime), N'Book Category ''Societies. Clubs'' is Added For Books Classification :''300 Social sciences''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4628, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BB75E2 AS DateTime), N'Book Category ''Communities. Classes. Races'' is Added For Books Classification :''300 Social sciences''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4629, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BB8A77 AS DateTime), N'Book Category ''Family. Marriage. Women'' is Added For Books Classification :''300 Social sciences''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4630, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BBA498 AS DateTime), N'Book Category '' General'' is Added For Books Classification :''340 Law''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4631, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BBC7BB AS DateTime), N'Book Category '' Local government'' is Added For Books Classification :''320 Political science''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4632, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BC115A AS DateTime), N'Book Category '' Physics'' is Added For Books Classification :''500 Science''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4633, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BC2E93 AS DateTime), N'Book Category '' Chemistry'' is Added For Books Classification :''500 Science''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4634, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BC4C1A AS DateTime), N'Book Category ''Geology'' is Added For Books Classification :''500 Science''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4635, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BC6BE3 AS DateTime), N'Book Category ''Microbiology'' is Added For Books Classification :''500 Science''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4636, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BC8713 AS DateTime), N'Book Category ''Public aspects of medicine'' is Added For Books Classification :''610 Medicine & health''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4637, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BCAD32 AS DateTime), N'Book Category ''Plant Culture'' is Added For Books Classification :''630 Agriculture''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4638, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BCC7C5 AS DateTime), N'Book Category ''Forestry'' is Added For Books Classification :''630 Agriculture''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4639, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BCDFA9 AS DateTime), N'Updated Book Category ''Chemistry'' Having Books Classification :''500 Science''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4640, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BCE83D AS DateTime), N'Updated Book Category ''Local government'' Having Books Classification :''320 Political science''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4641, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BCF005 AS DateTime), N'Updated Book Category ''Physical Geography'' Having Books Classification :''900 History & geography''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4642, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BCF75E AS DateTime), N'Updated Book Category ''Physics'' Having Books Classification :''500 Science''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4643, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BCFFC1 AS DateTime), N'Updated Book Category ''General'' Having Books Classification :''340 Law''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4644, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BD26F2 AS DateTime), N'Updated Book Category ''General'' Having Books Classification :''300 Social sciences''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4645, N'admin                                                                                                                                                 ', CAST(0x0000A6AD00BD4E48 AS DateTime), N'Book Category ''Engineering – General and civil'' is Added For Books Classification :''600 Technology''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4646, N'admin                                                                                                                                                 ', CAST(0x0000A6AD010DA1DC AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4647, N'admin                                                                                                                                                 ', CAST(0x0000A6AD010DC032 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4648, N'admin                                                                                                                                                 ', CAST(0x0000A6AD01222458 AS DateTime), N'BookSubcategory ''Marrige Problems Book'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4649, N'admin                                                                                                                                                 ', CAST(0x0000A6AD012257EC AS DateTime), N'BookSubcategory ''Political Reviews '' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4650, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0122E1C4 AS DateTime), N'BookSubcategory ''Forest World'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4651, N'admin                                                                                                                                                 ', CAST(0x0000A6AD01230D1C AS DateTime), N'BookSubcategory ''Geographical India'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4652, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0124832E AS DateTime), N'New Book ''Marrige Day'' is Added having AccessionNo=''A0012465''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4653, N'admin                                                                                                                                                 ', CAST(0x0000A6AD01251D61 AS DateTime), N'Book Category ''Computers and Programming'' is Added For Books Classification :''000 Computer science and  information''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4654, N'admin                                                                                                                                                 ', CAST(0x0000A6AD01254285 AS DateTime), N'BookSubcategory ''C Programming'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4655, N'admin                                                                                                                                                 ', CAST(0x0000A6AD012624F9 AS DateTime), N'New Book ''Let Us C Paperback (English) 12th Revised '' is Added having AccessionNo=''A0007878''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4656, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0126D164 AS DateTime), N'New Book ''Test Your C Skills Paperback '' is Added having AccessionNo=''A002525''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4657, N'admin                                                                                                                                                 ', CAST(0x0000A6AD0128610B AS DateTime), N'New Book ''Linux Kernel Development Paperback '' is Added having AccessionNo=''A001221''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4658, N'User                                                                                                                                                  ', CAST(0x0000A6AD012A7573 AS DateTime), N'Book ''Optimization Book of maths'' is Updated having AccessionNo=''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4659, N'User                                                                                                                                                  ', CAST(0x0000A6AD012A8319 AS DateTime), N'Book ''Optimization Book of maths'' is Updated having AccessionNo=''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4660, N'admin                                                                                                                                                 ', CAST(0x0000A6AE0018E911 AS DateTime), N' Reservation Cancelled of Book ''A0055'' Which is Reserved For Staff ''Vimal Patidar'' ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4661, N'admin                                                                                                                                                 ', CAST(0x0000A6AE0019225D AS DateTime), N'Book ''A0012465'' is Reserved For Staff ''Jagdish Joshi''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4662, N'User                                                                                                                                                  ', CAST(0x0000A6AE00198E73 AS DateTime), N'Added New Subject''English'' having School''D.A.V. Public School'' and Class''1st'' and Session''2016-2017''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4663, N'admin                                                                                                                                                 ', CAST(0x0000A6AE0019FA35 AS DateTime), N'Staff Attendance is Taken For Staff=''Raju Tiwari'' having StaffID=''EMP-4'' and Working Date ''29-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4664, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001A1583 AS DateTime), N'Staff Attendance is Taken For Staff=''Raju Tiwari'' having StaffID=''EMP-4'' and Working Date ''28-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4665, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001A2C37 AS DateTime), N'Staff Attendance is Taken For Staff=''Jagdish Joshi'' having StaffID=''EMP-10'' and Working Date ''28-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4666, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001A5973 AS DateTime), N'Staff Attendance is Taken For Staff=''Jagdish Joshi'' having StaffID=''EMP-10'' and Working Date ''25-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4667, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001A6A5E AS DateTime), N'Staff Attendance is Taken For Staff=''Vimal Patidar'' having StaffID=''EMP-5'' and Working Date ''29-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4668, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001A8D0D AS DateTime), N'Staff Attendance is Taken For Staff=''Vimal Patidar'' having StaffID=''EMP-5'' and Working Date ''28-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4669, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001AA74A AS DateTime), N'Staff Attendance is Taken For Staff=''Vimal Patidar'' having StaffID=''EMP-5'' and Working Date ''23-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4670, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001ABAE1 AS DateTime), N'Staff Attendance is Taken For Staff=''Jagdish Joshi'' having StaffID=''EMP-10'' and Working Date ''20-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4671, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001AD8CD AS DateTime), N'Staff Attendance is Taken For Staff=''Jagdish Joshi'' having StaffID=''EMP-10'' and Working Date ''29-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4672, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001AEE93 AS DateTime), N'Staff Attendance is Taken For Staff=''Jagdish Joshi'' having StaffID=''EMP-10'' and Working Date ''21-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4673, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001AFDE1 AS DateTime), N'Staff Attendance is Taken For Staff=''Pooja Patel'' having StaffID=''EMP-6'' and Working Date ''29-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4674, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001B0DE8 AS DateTime), N'Staff Attendance is Taken For Staff=''Pooja Patel'' having StaffID=''EMP-6'' and Working Date ''20-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4675, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001B2C9B AS DateTime), N'Staff Attendance is Taken For Staff=''Pooja Patel'' having StaffID=''EMP-6'' and Working Date ''23-10-2016 12:00:00 AM''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4676, N'User                                                                                                                                                  ', CAST(0x0000A6AE001B4D80 AS DateTime), N'New BusHolder ''Pooja Patel is Added Successfully  Having StaffID''6''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4677, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001B72B8 AS DateTime), N'New Bus is Added having BusNo''B002''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4678, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001BAAD0 AS DateTime), N'New Bus is Added having BusNo''B003''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4679, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001C0F13 AS DateTime), N'New Advance Payment is Taken By Staff on Date ''29-10-2016 12:00:00 AM'' having StaffID=''EMP-10''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4680, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001C1F80 AS DateTime), N'New Advance Payment is Taken By Staff on Date ''29-10-2016 12:00:00 AM'' having StaffID=''EMP-6''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4681, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001C2AFB AS DateTime), N'New Advance Payment is Taken By Staff on Date ''29-10-2016 12:00:00 AM'' having StaffID=''EMP-6''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4682, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001C3B13 AS DateTime), N'New Advance Payment is Taken By Staff on Date ''29-10-2016 12:00:00 AM'' having StaffID=''EMP-7''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4683, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001C4AF3 AS DateTime), N'New Advance Payment is Taken By Staff on Date ''29-10-2016 12:00:00 AM'' having StaffID=''EMP-8''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4684, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001CC114 AS DateTime), N'Salary is paid For Staff'''' having StaffID ''EMP-6'' and PaymentID ''EP-2''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4685, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001D6891 AS DateTime), N'Added Hosteler  ''System.Windows.Forms.TextBox, Text: Mahendra Tripathi'' having AdmissionNo''A00089''')
GO
print 'Processed 500 total records'
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4686, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001D8014 AS DateTime), N'Added Hosteler  ''System.Windows.Forms.TextBox, Text: Akira Sachdev'' having AdmissionNo''A000825''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4687, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001D8C8C AS DateTime), N'Added Hosteler  ''System.Windows.Forms.TextBox, Text: Deepak kumar'' having AdmissionNo''A00085''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4688, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001DA00B AS DateTime), N'Added Hosteler  ''System.Windows.Forms.TextBox, Text: Amit Sharma'' having AdmissionNo''A0015''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4689, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001DC460 AS DateTime), N'New BusHolder ''Jaya Kumari is Added Successfully  Having AdmissionNo''A00986''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4690, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001DD807 AS DateTime), N'New BusHolder ''Akira Sachdev is Added Successfully  Having AdmissionNo''A000825''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4691, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001DEBA9 AS DateTime), N'New BusHolder ''Akshay Kumar is Added Successfully  Having AdmissionNo''A00455''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4692, N'User                                                                                                                                                  ', CAST(0x0000A6AE001E1513 AS DateTime), N'New BusHolder ''Alex is Added Successfully  Having StaffID''9''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4693, N'User                                                                                                                                                  ', CAST(0x0000A6AE001E2BCF AS DateTime), N'New BusHolder ''Prashant Bhushan is Added Successfully  Having StaffID''8''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4694, N'User                                                                                                                                                  ', CAST(0x0000A6AE001E50CB AS DateTime), N'New BusHolder ''Mamta Ahuja is Added Successfully  Having StaffID''7''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4695, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001F83B4 AS DateTime), N'User ''Veer Patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4696, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001F9284 AS DateTime), N'User ''Pramod Patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4697, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001F9C33 AS DateTime), N'User ''vaibhav patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4698, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001FB600 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4699, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001FD617 AS DateTime), N'User ''Akshay Patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4700, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001FE4DE AS DateTime), N'User ''Veer Patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4701, N'admin                                                                                                                                                 ', CAST(0x0000A6AE001FF8D1 AS DateTime), N'User ''vaibhav'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4702, N'User                                                                                                                                                  ', CAST(0x0000A6AE0030FA1F AS DateTime), N'Added New Subject''English'' having School''D.A.V. Public School'' and Class''1st'' and Session''2016-2017''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4703, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00311A5A AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4704, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00311A84 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4705, N'User                                                                                                                                                  ', CAST(0x0000A6AE0031FD10 AS DateTime), N'Added New Subject''Hindi'' having School''D.A.V. Public School'' and Class''3rd'' and Session''2016-2017''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4706, N'User                                                                                                                                                  ', CAST(0x0000A6AE00322C59 AS DateTime), N'Added New Subject''Hindi'' having School''D.A.V. Public School'' and Class''2nd'' and Session''2016-2017''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4707, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00324C56 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4708, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00324C84 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4709, N'admin                                                                                                                                                 ', CAST(0x0000A6AE0036BF8B AS DateTime), N'User ''Akshay Patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4710, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00376EFC AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4711, N'admin                                                                                                                                                 ', CAST(0x0000A6AE003788E3 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4712, N'admin                                                                                                                                                 ', CAST(0x0000A6AE003975DE AS DateTime), N'User ''vaibhav'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4713, N'admin                                                                                                                                                 ', CAST(0x0000A6AE0039F3AD AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4714, N'admin                                                                                                                                                 ', CAST(0x0000A6AE003B401D AS DateTime), N'Updated Student''Rohit Patidar'' having AdmissionNo''A00477'' and Class''2nd'' and School''R.A.N. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4715, N'User                                                                                                                                                  ', CAST(0x0000A6AE003B7D9F AS DateTime), N'Updated the School ''D.A.V. Public School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4716, N'admin                                                                                                                                                 ', CAST(0x0000A6AE003BD93F AS DateTime), N'New Session ''2017-2018'' is Added Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4717, N'admin                                                                                                                                                 ', CAST(0x0000A6AE003D1A15 AS DateTime), N'BusInstallment ''2nd is Updated Successfully  For Location''Vijaynagar''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4718, N'admin                                                                                                                                                 ', CAST(0x0000A6AE003D26DE AS DateTime), N'Updated Hostel  ''Gurukul hostel''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4719, N'User                                                                                                                                                  ', CAST(0x0000A6AE003E6E5D AS DateTime), N'StudentDiscount is Updated Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4720, N'admin                                                                                                                                                 ', CAST(0x0000A6AE003F4ADC AS DateTime), N'New BusHolder ''Raman Sharma is Added Successfully  Having AdmissionNo''a005''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4721, N'admin                                                                                                                                                 ', CAST(0x0000A6AE0040C71D AS DateTime), N'Book ''A001221'' is Reserved For Staff ''Pooja Patel''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4722, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00410C87 AS DateTime), N' Reservation Cancelled of Book ''A001221'' Which is Reserved For Staff ''Pooja Patel'' ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4723, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00416239 AS DateTime), N'Issued Book is Updated Having Student :''Rohit Patidar'' and Book''s AccessionNo is''A0055''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4724, N'admin                                                                                                                                                 ', CAST(0x0000A6AE0041C24E AS DateTime), N'Exam is Schedule  having ExamName''Mid Term Exam''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4725, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00420036 AS DateTime), N'Scheduled Exam is Updated having ExamName''Mid Term Exam''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4726, N'admin                                                                                                                                                 ', CAST(0x0000A6AE004515BA AS DateTime), N'Salary is paid For Staff'''' having StaffID ''EMP-10'' and PaymentID ''EP-3''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4727, N'admin                                                                                                                                                 ', CAST(0x0000A6AE0045E689 AS DateTime), N'Added new HostelFeesPayment For Student''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' and AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4728, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00465E09 AS DateTime), N'BusFeesPayment ''2nd Installment''is Successfully Paid By Student''Jaya Kumari'' Having AdmissionNo''A00986''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4729, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00469AC6 AS DateTime), N'BusFeesPayment ''1st Installment''is Successfully Paid By Staff StaffID''EMP-4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4730, N'admin                                                                                                                                                 ', CAST(0x0000A6AE00485C3E AS DateTime), N'Successfully restore the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4731, N'admin                                                                                                                                                 ', CAST(0x0000A6AE0048F2AB AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4732, N'admin                                                                                                                                                 ', CAST(0x0000A6AF009C5487 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4733, N'admin                                                                                                                                                 ', CAST(0x0000A6AF009C553D AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4734, N'admin                                                                                                                                                 ', CAST(0x0000A6AF00AB252F AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4735, N'admin                                                                                                                                                 ', CAST(0x0000A6AF00AF1481 AS DateTime), N'BusFeesPayment ''1st Installment''is Successfully Paid By Staff StaffID''EMP-9''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4736, N'admin                                                                                                                                                 ', CAST(0x0000A6B00095D138 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4737, N'admin                                                                                                                                                 ', CAST(0x0000A6B00095D1B6 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4738, N'admin                                                                                                                                                 ', CAST(0x0000A6B000972EF1 AS DateTime), N'User ''vaibhav'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4739, N'admin                                                                                                                                                 ', CAST(0x0000A6B00097FEC2 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4740, N'User                                                                                                                                                  ', CAST(0x0000A6B00098ACD6 AS DateTime), N'Updated the School ''Medicaps International School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4741, N'User                                                                                                                                                  ', CAST(0x0000A6B00098B2E5 AS DateTime), N'Updated the School ''D.A.V. Public School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4742, N'User                                                                                                                                                  ', CAST(0x0000A6B00098B8D4 AS DateTime), N'Updated the School ''R.A.N. Public School'' having SchoolType=''MP Board''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4743, N'admin                                                                                                                                                 ', CAST(0x0000A6B000990EEB AS DateTime), N'Section ''E'' is Added Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4744, N'User                                                                                                                                                  ', CAST(0x0000A6B0009F42FC AS DateTime), N'Section ''E'' is Deleted Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4745, N'admin                                                                                                                                                 ', CAST(0x0000A6B0009FF931 AS DateTime), N'Updated Student''Mahendra Tripathi'' having AdmissionNo''A00089'' and Class''1st'' and School''Medicaps International School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4746, N'admin                                                                                                                                                 ', CAST(0x0000A6B000A0094C AS DateTime), N'Session ''    -'' is Deleted Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4747, N'admin                                                                                                                                                 ', CAST(0x0000A6B000A09876 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4748, N'admin                                                                                                                                                 ', CAST(0x0000A6B000A098A1 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4749, N'admin                                                                                                                                                 ', CAST(0x0000A6B000A9BBCF AS DateTime), N'User ''vaibhav patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4750, N'admin                                                                                                                                                 ', CAST(0x0000A6B000AA8C1F AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4751, N'User                                                                                                                                                  ', CAST(0x0000A6B000AB2B9F AS DateTime), N'Updated the School ''D.A.V. Public School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4752, N'admin                                                                                                                                                 ', CAST(0x0000A6B000AD9823 AS DateTime), N'Added the New School Fees having Class=''5th'' and FeeName=''Caution  Money''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4753, N'User                                                                                                                                                  ', CAST(0x0000A6B000AEEC05 AS DateTime), N'Added New Subject''Hindi'' having School''R.A.N. Public School'' and Class''5th'' and Session''2016-2017''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4754, N'User                                                                                                                                                  ', CAST(0x0000A6B000B0554F AS DateTime), N'StudentDiscount is Updated Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4755, N'admin                                                                                                                                                 ', CAST(0x0000A6B000B0AB18 AS DateTime), N'Added Hosteler  ''System.Windows.Forms.TextBox, Text: Robet Alex'' having AdmissionNo''A005444''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4756, N'admin                                                                                                                                                 ', CAST(0x0000A6B000B11562 AS DateTime), N'New BusHolder ''Robet Alex is Added Successfully  Having AdmissionNo''A005444''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4757, N'admin                                                                                                                                                 ', CAST(0x0000A6B000B39A4A AS DateTime), N'Book ''A001221'' is Reserved For Staff ''Alex''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4758, N'admin                                                                                                                                                 ', CAST(0x0000A6B000B3E20C AS DateTime), N' Reservation Cancelled of Book ''A001221'' Which is Reserved For Staff ''Alex'' ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4759, N'admin                                                                                                                                                 ', CAST(0x0000A6B000B48DCA AS DateTime), N'Book is Issued By Student :''Rohit Patidar'' Where Book''s AccessionNo is''A0007878''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4760, N'admin                                                                                                                                                 ', CAST(0x0000A6B000B4E8D2 AS DateTime), N'Book is Returned By Student :''Rohit Patidar'' Where Book''s AccessionNo is''A0007878''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4761, N'admin                                                                                                                                                 ', CAST(0x0000A6B000B595CB AS DateTime), N'Updated Student''Jaya Kumari'' having AdmissionNo''A00986'' and Class''1st'' and School''D.A.V. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4762, N'admin                                                                                                                                                 ', CAST(0x0000A6B000B92D0D AS DateTime), N'New Advance Payment is Taken By Staff on Date ''31-10-2016 12:00:00 AM'' having StaffID=''EMP-9''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4763, N'admin                                                                                                                                                 ', CAST(0x0000A6B000B99A69 AS DateTime), N'Salary is paid For Staff'''' having StaffID ''EMP-4'' and PaymentID ''EP-4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4764, N'admin                                                                                                                                                 ', CAST(0x0000A6B000BA961B AS DateTime), N'Added new HostelFeesPayment For Student''System.Windows.Forms.TextBox, Text: Vaibhav kumar'' and AdmissionNo''A-00018''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4765, N'admin                                                                                                                                                 ', CAST(0x0000A6B000BABDA1 AS DateTime), N'BusFeesPayment ''1st Installment''is Successfully Paid By Student''Mahendra Tripathi'' Having AdmissionNo''A00089''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4766, N'admin                                                                                                                                                 ', CAST(0x0000A6B000BD329D AS DateTime), N'Successfully restore the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4767, N'admin                                                                                                                                                 ', CAST(0x0000A6B000BDFAE5 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4768, N'admin                                                                                                                                                 ', CAST(0x0000A6B001014DDE AS DateTime), N'User ''vaibhav patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4769, N'admin                                                                                                                                                 ', CAST(0x0000A6B001020BFC AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4770, N'admin                                                                                                                                                 ', CAST(0x0000A6B00103A801 AS DateTime), N'New Department ''Chemistry Department'' is Added')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4771, N'admin                                                                                                                                                 ', CAST(0x0000A6B00104212C AS DateTime), N'Added the New School Fees having Class=''4th'' and FeeName=''Security Deposit (Interest free)''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4772, N'admin                                                                                                                                                 ', CAST(0x0000A6B00105B4A9 AS DateTime), N'Updated Hostel  ''Gurukul hostel''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4773, N'admin                                                                                                                                                 ', CAST(0x0000A6B0010758B0 AS DateTime), N'Book ''Linux Kernel Development Paperback'' is Updated having AccessionNo=''A001221''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4774, N'admin                                                                                                                                                 ', CAST(0x0000A6B001081C62 AS DateTime), N'Updated Student''Robet Alex'' having AdmissionNo''A005444'' and Class''1st'' and School''D.A.V. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4775, N'admin                                                                                                                                                 ', CAST(0x0000A6B001084F23 AS DateTime), N'Updated the Staff''Pooja Patel'' having EmployeeID ''6''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4776, N'User                                                                                                                                                  ', CAST(0x0000A6B00108A5A4 AS DateTime), N'StudentDiscount is Updated Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4777, N'admin                                                                                                                                                 ', CAST(0x0000A6B0010CD06F AS DateTime), N'Book ''A002525'' is Reserved For Staff ''Alex''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4778, N'admin                                                                                                                                                 ', CAST(0x0000A6B0010D13F8 AS DateTime), N' Reservation Cancelled of Book ''A002525'' Which is Reserved For Staff ''Alex'' ')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4779, N'admin                                                                                                                                                 ', CAST(0x0000A6B0010D9257 AS DateTime), N'Book is Issued By Student :''Vaibhav kumar'' Where Book''s AccessionNo is''A002525''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4780, N'admin                                                                                                                                                 ', CAST(0x0000A6B0010DEAFE AS DateTime), N'Book is Returned By Student :''Vaibhav kumar'' Where Book''s AccessionNo is''A002525''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4781, N'admin                                                                                                                                                 ', CAST(0x0000A6B0010F5A6F AS DateTime), N'BusHolder ''Pooja Patel is Updated Successfully  Having StaffID''6''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4782, N'admin                                                                                                                                                 ', CAST(0x0000A6B001118BA7 AS DateTime), N'BusFeesPayment ''2nd Installment''is Successfully Paid By Staff StaffID''EMP-4''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4783, N'admin                                                                                                                                                 ', CAST(0x0000A6B00116D172 AS DateTime), N'Successfully restore the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4784, N'admin                                                                                                                                                 ', CAST(0x0000A6B001176EFF AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4785, N'admin                                                                                                                                                 ', CAST(0x0000A6C800C051BB AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4786, N'admin                                                                                                                                                 ', CAST(0x0000A6C800C0520A AS DateTime), N'Successfully logged in')
GO
print 'Processed 600 total records'
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4787, N'User                                                                                                                                                  ', CAST(0x0000A6C800C21F27 AS DateTime), N'Updated the School ''D.A.V. Public School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4788, N'admin                                                                                                                                                 ', CAST(0x0000A6C800C3C6AE AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4789, N'admin                                                                                                                                                 ', CAST(0x0000A6C800C4DE84 AS DateTime), N'Added the New School Fees having Class=''1st'' and FeeName=''Caution  Money''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4790, N'admin                                                                                                                                                 ', CAST(0x0000A6C800C664D3 AS DateTime), N'Book ''Let Us C Paperback (English) 12th Revised'' is Updated having AccessionNo=''A0007878''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4791, N'admin                                                                                                                                                 ', CAST(0x0000A6C800C6FED8 AS DateTime), N'Updated Student''Robet Alex'' having AdmissionNo''A005444'' and Class''1st'' and School''D.A.V. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4792, N'admin                                                                                                                                                 ', CAST(0x0000A6C800CA8FCD AS DateTime), N'Successfully restore the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4793, N'admin                                                                                                                                                 ', CAST(0x0000A6C800CDB0D6 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4794, N'admin                                                                                                                                                 ', CAST(0x0000A6CD00D5F16A AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4795, N'admin                                                                                                                                                 ', CAST(0x0000A6CD00DBC468 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4796, N'admin                                                                                                                                                 ', CAST(0x0000A6D700E81699 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4797, N'admin                                                                                                                                                 ', CAST(0x0000A6D700E81720 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4798, N'admin                                                                                                                                                 ', CAST(0x0000A6D700EC1361 AS DateTime), N'User ''vaibhav patidar'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4799, N'admin                                                                                                                                                 ', CAST(0x0000A6D700EC45B1 AS DateTime), N'Successfully logged in')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4800, N'User                                                                                                                                                  ', CAST(0x0000A6D700ECB59D AS DateTime), N'Updated the School ''Medicaps International School'' having SchoolType=''CBSE School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4801, N'admin                                                                                                                                                 ', CAST(0x0000A6D700EE644D AS DateTime), N'Book ''Let Us C Paperback (English) 12th Revised'' is Updated having AccessionNo=''A0007878''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4802, N'admin                                                                                                                                                 ', CAST(0x0000A6D700EEC0C2 AS DateTime), N'Updated Student''Robet Alex'' having AdmissionNo''A005444'' and Class''1st'' and School''D.A.V. Public School''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4803, N'admin                                                                                                                                                 ', CAST(0x0000A6D700EEE360 AS DateTime), N'Updated the Staff''Mamta Ahuja'' having EmployeeID ''7''')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4804, N'admin                                                                                                                                                 ', CAST(0x0000A6D700F0E62F AS DateTime), N'Successfully restore the database')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4805, N'admin                                                                                                                                                 ', CAST(0x0000A6D700F1CCB7 AS DateTime), N'Successfully logged out')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4806, N'admin                                                                                                                                                 ', CAST(0x0000AB9C018A3357 AS DateTime), N'User ''Nilesh Khendke'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4807, N'admin                                                                                                                                                 ', CAST(0x0000AB9C018A66AD AS DateTime), N'User ''Nilesh Khendke'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4808, N'admin                                                                                                                                                 ', CAST(0x0000AB9C018A92E4 AS DateTime), N'User ''Nilesh'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4809, N'admin                                                                                                                                                 ', CAST(0x0000AB9C018AB428 AS DateTime), N'User ''Nilesh Khendke'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4810, N'admin                                                                                                                                                 ', CAST(0x0000AB9C018AC8F7 AS DateTime), N'User ''vaibhav'' is Updated  Successfully')
INSERT [dbo].[Logs] ([Id], [UserID], [Date], [Operation]) VALUES (4811, N'admin                                                                                                                                                 ', CAST(0x0000AB9C018ADAC6 AS DateTime), N'User ''mahesh'' is Updated  Successfully')
SET IDENTITY_INSERT [dbo].[Logs] OFF
/****** Object:  Table [dbo].[Locations]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[LocationID] [int] NOT NULL,
	[Location] [nchar](150) NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Locations] ([LocationID], [Location]) VALUES (1, N'Vijaynagar                                                                                                                                            ')
INSERT [dbo].[Locations] ([LocationID], [Location]) VALUES (4, N'L.I.G                                                                                                                                                 ')
/****** Object:  Table [dbo].[JMB]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JMB](
	[JMBID] [int] IDENTITY(1,1) NOT NULL,
	[Sub_No] [nchar](200) NULL,
	[BillNo] [nchar](200) NULL,
	[BillDate] [datetime] NULL,
	[Amount] [decimal](18, 2) NULL,
	[PaidON] [datetime] NULL,
	[IssueNo] [nchar](100) NULL,
	[Month] [nchar](30) NULL,
	[Year] [nchar](20) NULL,
 CONSTRAINT [PK_JMB] PRIMARY KEY CLUSTERED 
(
	[JMBID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JM]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JM](
	[SubNo] [nchar](200) NOT NULL,
	[Title] [nchar](200) NULL,
	[SubscriptionDate] [datetime] NULL,
	[Subscription] [nchar](100) NULL,
	[SubscriptionDateFrom] [datetime] NULL,
	[SubscriptionDateTo] [datetime] NULL,
	[SupplierID] [int] NULL,
 CONSTRAINT [PK_JM_1] PRIMARY KEY CLUSTERED 
(
	[SubNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HostelInstallment]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HostelInstallment](
	[IHID] [int] IDENTITY(1,1) NOT NULL,
	[Installment] [nchar](30) NULL,
	[Charges] [decimal](18, 2) NULL,
	[Hostel_ID] [int] NULL,
	[Class_ID] [int] NULL,
	[School_ID] [int] NULL,
 CONSTRAINT [PK_HostelInstallment] PRIMARY KEY CLUSTERED 
(
	[IHID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HostelFeesPayment]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HostelFeesPayment](
	[HFP_ID] [int] NOT NULL,
	[MaxID] [nchar](30) NULL,
	[HostelNames] [nvarchar](max) NULL,
	[Hosteler_ID] [int] NULL,
	[Session] [nvarchar](30) NULL,
	[Installment] [nchar](30) NULL,
	[TotalFee] [decimal](18, 2) NULL,
	[DiscountAmt] [decimal](18, 2) NULL,
	[PreviousDue] [decimal](18, 2) NULL,
	[Fine] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[TotalPaid] [decimal](18, 2) NULL,
	[ModeOfPayment] [nchar](100) NULL,
	[PaymentModeDetails] [varchar](250) NULL,
	[Paymentdate] [datetime] NULL,
	[PaymentDue] [decimal](18, 2) NULL,
	[School] [varchar](250) NULL,
	[Classname] [nvarchar](50) NULL,
	[Section] [nvarchar](30) NULL,
	[DiscountPer] [decimal](18, 2) NULL,
 CONSTRAINT [PK_HostelFeesPayment] PRIMARY KEY CLUSTERED 
(
	[HFP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hosteler]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hosteler](
	[HostelerID] [int] IDENTITY(1,1) NOT NULL,
	[Admission_No] [nchar](50) NULL,
	[Hostel_ID] [int] NULL,
	[JoiningDate] [datetime] NULL,
	[Status] [nchar](10) NULL,
 CONSTRAINT [PK_Hosteler] PRIMARY KEY CLUSTERED 
(
	[HostelerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hostel]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hostel](
	[HostelID] [int] IDENTITY(1,1) NOT NULL,
	[Hostelname] [nchar](150) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [nchar](15) NULL,
	[Mobile] [nchar](15) NULL,
	[Incharge] [nchar](100) NULL,
 CONSTRAINT [PK_HostelInfo] PRIMARY KEY CLUSTERED 
(
	[HostelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Hostel] ON
INSERT [dbo].[Hostel] ([HostelID], [Hostelname], [Address], [Phone], [Mobile], [Incharge]) VALUES (1, N'Gurukul hostel                                                                                                                                        ', N'Rau', N'9630014949     ', N'9630014949     ', N'vaibhav                                                                                             ')
INSERT [dbo].[Hostel] ([HostelID], [Hostelname], [Address], [Phone], [Mobile], [Incharge]) VALUES (2, N'MR Hostel                                                                                                                                             ', N'A.B. Road Indore', N'0742723544     ', N'230530         ', N'deepak                                                                                              ')
INSERT [dbo].[Hostel] ([HostelID], [Hostelname], [Address], [Phone], [Mobile], [Incharge]) VALUES (5, N'Minakshi hostel                                                                                                                                       ', N'Bangalore', N'8349102353     ', N'8349102353     ', N'monu                                                                                                ')
SET IDENTITY_INSERT [dbo].[Hostel] OFF
/****** Object:  Table [dbo].[Grades]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[GradeID] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [nvarchar](50) NULL,
	[ScoreFrom] [decimal](18, 2) NULL,
	[ScoreTo] [decimal](18, 2) NULL,
	[Remark] [nvarchar](250) NULL,
	[GradePoint] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[GradeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Grades] ON
INSERT [dbo].[Grades] ([GradeID], [Grade], [ScoreFrom], [ScoreTo], [Remark], [GradePoint]) VALUES (6, N'A+', CAST(90.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), N'Outstanding', CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Grades] ([GradeID], [Grade], [ScoreFrom], [ScoreTo], [Remark], [GradePoint]) VALUES (7, N'A', CAST(80.00 AS Decimal(18, 2)), CAST(89.00 AS Decimal(18, 2)), N'Excellent', CAST(3.80 AS Decimal(18, 2)))
INSERT [dbo].[Grades] ([GradeID], [Grade], [ScoreFrom], [ScoreTo], [Remark], [GradePoint]) VALUES (8, N'B+', CAST(70.00 AS Decimal(18, 2)), CAST(79.00 AS Decimal(18, 2)), N'Very Good', CAST(3.20 AS Decimal(18, 2)))
INSERT [dbo].[Grades] ([GradeID], [Grade], [ScoreFrom], [ScoreTo], [Remark], [GradePoint]) VALUES (9, N'B', CAST(60.00 AS Decimal(18, 2)), CAST(69.00 AS Decimal(18, 2)), N'Good', CAST(2.80 AS Decimal(18, 2)))
INSERT [dbo].[Grades] ([GradeID], [Grade], [ScoreFrom], [ScoreTo], [Remark], [GradePoint]) VALUES (10, N'C+', CAST(50.00 AS Decimal(18, 2)), CAST(59.00 AS Decimal(18, 2)), N'Fair', CAST(2.40 AS Decimal(18, 2)))
INSERT [dbo].[Grades] ([GradeID], [Grade], [ScoreFrom], [ScoreTo], [Remark], [GradePoint]) VALUES (11, N'C', CAST(40.00 AS Decimal(18, 2)), CAST(49.00 AS Decimal(18, 2)), N'Average', CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[Grades] ([GradeID], [Grade], [ScoreFrom], [ScoreTo], [Remark], [GradePoint]) VALUES (12, N'D', CAST(33.00 AS Decimal(18, 2)), CAST(39.00 AS Decimal(18, 2)), N'Below Average', CAST(1.60 AS Decimal(18, 2)))
INSERT [dbo].[Grades] ([GradeID], [Grade], [ScoreFrom], [ScoreTo], [Remark], [GradePoint]) VALUES (13, N'E', CAST(0.00 AS Decimal(18, 2)), CAST(33.00 AS Decimal(18, 2)), N'Fail', CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Grades] OFF
/****** Object:  Table [dbo].[Fee]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Feename] [varchar](250) NULL,
 CONSTRAINT [PK_Fee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Fee] ON
INSERT [dbo].[Fee] ([Id], [Feename]) VALUES (1, N'Tution Fees')
INSERT [dbo].[Fee] ([Id], [Feename]) VALUES (16, N'Caution  Money')
INSERT [dbo].[Fee] ([Id], [Feename]) VALUES (18, N'Lab Fee')
INSERT [dbo].[Fee] ([Id], [Feename]) VALUES (19, N'School Development Fee')
INSERT [dbo].[Fee] ([Id], [Feename]) VALUES (32, N'Registration Fee')
INSERT [dbo].[Fee] ([Id], [Feename]) VALUES (33, N'Security Deposit (Interest free)')
INSERT [dbo].[Fee] ([Id], [Feename]) VALUES (34, N'Processing Fee')
SET IDENTITY_INSERT [dbo].[Fee] OFF
/****** Object:  Table [dbo].[ExamSchedule]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamSchedule](
	[ScheduleID] [int] NOT NULL,
	[ExamID] [int] NULL,
	[School_ID] [int] NULL,
	[Session_ID] [int] NULL,
	[ClassSection_ID] [int] NULL,
 CONSTRAINT [PK_ExamSchedule] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamMaster]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamMaster](
	[ExamID] [int] IDENTITY(1,1) NOT NULL,
	[ExamName] [nvarchar](max) NULL,
	[ExamType] [nvarchar](100) NULL,
 CONSTRAINT [PK_ExamMaster] PRIMARY KEY CLUSTERED 
(
	[ExamID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ExamMaster] ON
INSERT [dbo].[ExamMaster] ([ExamID], [ExamName], [ExamType]) VALUES (1, N'Mid Term Exam', N'Marks and Grades')
INSERT [dbo].[ExamMaster] ([ExamID], [ExamName], [ExamType]) VALUES (2, N'End Term', N'Grades')
SET IDENTITY_INSERT [dbo].[ExamMaster] OFF
/****** Object:  Table [dbo].[Employee]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EMPID] [int] NOT NULL,
	[EMPMAXID] [nchar](30) NULL,
	[EmployeeName] [nvarchar](100) NULL,
	[Gender] [nchar](10) NULL,
	[DOB] [nvarchar](30) NULL,
	[FatherName] [nvarchar](100) NULL,
	[MotherName] [nvarchar](100) NULL,
	[ContactNo] [nchar](15) NULL,
	[DateOfJoining] [datetime] NULL,
	[Email] [nchar](30) NULL,
	[City] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[Address] [nvarchar](250) NULL,
	[Department_ID] [int] NULL,
	[Designation_ID] [int] NULL,
	[Salary] [decimal](18, 2) NULL,
	[Status] [nchar](30) NULL,
	[Religion] [nvarchar](100) NOT NULL,
	[BloodGroup] [nvarchar](40) NULL,
	[Photo] [image] NULL,
	[Discount] [decimal](18, 2) NULL,
	[SchoolID] [int] NULL,
	[AccountName] [nchar](150) NULL,
	[AccountNumber] [nchar](100) NULL,
	[Bank] [varchar](250) NULL,
	[Branch] [nchar](150) NULL,
	[IFSCcode] [nchar](100) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EMPID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocumentMaster]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentMaster](
	[DocumentName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_DocumentMaster_1] PRIMARY KEY CLUSTERED 
(
	[DocumentName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DocumentMaster] ([DocumentName]) VALUES (N'.Character Certificate')
INSERT [dbo].[DocumentMaster] ([DocumentName]) VALUES (N'10th Marksheet')
INSERT [dbo].[DocumentMaster] ([DocumentName]) VALUES (N'12th MarkSheet')
INSERT [dbo].[DocumentMaster] ([DocumentName]) VALUES (N'Leaving certificate')
INSERT [dbo].[DocumentMaster] ([DocumentName]) VALUES (N'Transfer Certificate')
INSERT [dbo].[DocumentMaster] ([DocumentName]) VALUES (N'Two passport size self-attest Photos')
/****** Object:  Table [dbo].[Doc]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doc](
	[DocID] [int] IDENTITY(1,1) NOT NULL,
	[Document_Name] [nvarchar](150) NULL,
	[Admission_No] [nchar](50) NULL,
 CONSTRAINT [PK_Doc] PRIMARY KEY CLUSTERED 
(
	[DocID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designations](
	[DesignationID] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [nvarchar](200) NULL,
 CONSTRAINT [PK_Designations] PRIMARY KEY CLUSTERED 
(
	[DesignationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Designations] ON
INSERT [dbo].[Designations] ([DesignationID], [Designation]) VALUES (1, N'Teacher')
INSERT [dbo].[Designations] ([DesignationID], [Designation]) VALUES (2, N'Admin')
INSERT [dbo].[Designations] ([DesignationID], [Designation]) VALUES (3, N'Operator')
INSERT [dbo].[Designations] ([DesignationID], [Designation]) VALUES (4, N'Super Admin')
INSERT [dbo].[Designations] ([DesignationID], [Designation]) VALUES (5, N'Principal')
INSERT [dbo].[Designations] ([DesignationID], [Designation]) VALUES (6, N'Bus Driver')
INSERT [dbo].[Designations] ([DesignationID], [Designation]) VALUES (7, N'Bus Cleaner')
SET IDENTITY_INSERT [dbo].[Designations] OFF
/****** Object:  Table [dbo].[Department]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (22, N'English Department')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (23, N'Maths Department')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (24, N'Compter Department')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (25, N'Physics Department')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (26, N'Department of Education')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (27, N'Chemistry Department')
SET IDENTITY_INSERT [dbo].[Department] OFF
/****** Object:  Table [dbo].[CourseFeePayment_Join]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseFeePayment_Join](
	[CFID] [int] IDENTITY(1,1) NOT NULL,
	[FeeId] [int] NULL,
	[Fee] [decimal](18, 2) NULL,
	[Month] [nchar](50) NULL,
	[SF_PaymentID] [int] NULL,
 CONSTRAINT [PK_CourseFeePayment_Join] PRIMARY KEY CLUSTERED 
(
	[CFID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassTypes]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassTypes](
	[ClassTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ClassType] [nvarchar](250) NULL,
 CONSTRAINT [PK_ClassTypes] PRIMARY KEY CLUSTERED 
(
	[ClassTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ClassTypes] ON
INSERT [dbo].[ClassTypes] ([ClassTypeID], [ClassType]) VALUES (1, N'Nursary Class')
INSERT [dbo].[ClassTypes] ([ClassTypeID], [ClassType]) VALUES (4, N'Primary Class')
INSERT [dbo].[ClassTypes] ([ClassTypeID], [ClassType]) VALUES (5, N'Secondary Class')
INSERT [dbo].[ClassTypes] ([ClassTypeID], [ClassType]) VALUES (6, N'Higher Secondary ')
SET IDENTITY_INSERT [dbo].[ClassTypes] OFF
/****** Object:  Table [dbo].[ClassSection]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassSection](
	[ClassSectionID] [int] IDENTITY(1,1) NOT NULL,
	[Class_ID] [int] NULL,
	[Section_ID] [int] NULL,
 CONSTRAINT [PK_ClassSection] PRIMARY KEY CLUSTERED 
(
	[ClassSectionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classifications]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classifications](
	[Classification] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Classifications] PRIMARY KEY CLUSTERED 
(
	[Classification] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'000 Computer science and  information')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'002 Maths.')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'100 Philosophy & psychology')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'200 Religion')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'300 Social sciences')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'310 Statistics')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'320 Political science')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'330 Economics')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'340 Law')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'360 Social problems & social services')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'500 Science')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'550 Earth sciences & geology')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'570 Life sciences')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'580 Plants (Botany)')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'600 Technology')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'610 Medicine & health')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'620 Engineering')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'630 Agriculture')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'700 Arts & recreation')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'740 Drawing & decorative arts')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'800 Literature')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'900 History & geography')
INSERT [dbo].[Classifications] ([Classification]) VALUES (N'English & Old English literatures')
/****** Object:  Table [dbo].[Class]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NULL,
	[ClassType_ID] [int] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusInstallment]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusInstallment](
	[InstallmentID] [int] IDENTITY(1,1) NOT NULL,
	[Installment] [nchar](30) NULL,
	[Charges] [decimal](18, 2) NULL,
	[Location_ID] [int] NULL,
 CONSTRAINT [PK_BusInstallment] PRIMARY KEY CLUSTERED 
(
	[InstallmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BusFeesPayment]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BusFeesPayment](
	[BFP_ID] [int] NOT NULL,
	[MaxID] [nchar](30) NULL,
	[Session] [nvarchar](30) NULL,
	[Installment] [nchar](30) NULL,
	[TotalFee] [decimal](18, 2) NULL,
	[DiscountPer] [decimal](18, 2) NULL,
	[DiscountAmt] [decimal](18, 2) NULL,
	[PreviousDue] [decimal](18, 2) NULL,
	[Fine] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[TotalPaid] [decimal](18, 2) NULL,
	[ModeOfPayment] [nchar](100) NULL,
	[PaymentModeDetails] [varchar](250) NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentDue] [decimal](18, 2) NULL,
	[BusHolder_ID] [int] NULL,
	[Location] [nchar](150) NULL,
	[School] [varchar](250) NULL,
	[Classname] [nvarchar](50) NULL,
	[Section] [nvarchar](30) NULL,
 CONSTRAINT [PK_BusFeesPayment] PRIMARY KEY CLUSTERED 
(
	[BFP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bus]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bus](
	[BusID] [int] IDENTITY(1,1) NOT NULL,
	[BusNo] [nchar](100) NULL,
	[DriverName] [nchar](100) NULL,
	[ContactNo] [nchar](20) NULL,
	[SupporterName] [nchar](100) NULL,
	[Scontactno] [nchar](20) NULL,
 CONSTRAINT [PK_Bus] PRIMARY KEY CLUSTERED 
(
	[BusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bus] ON
INSERT [dbo].[Bus] ([BusID], [BusNo], [DriverName], [ContactNo], [SupporterName], [Scontactno]) VALUES (2, N'B001                                                                                                ', N'vaibhav patidar                                                                                     ', N'8349102353          ', N'vaibhav patidar                                                                                     ', N'8349102353          ')
INSERT [dbo].[Bus] ([BusID], [BusNo], [DriverName], [ContactNo], [SupporterName], [Scontactno]) VALUES (4, N'B002                                                                                                ', N'Amit Sigh                                                                                           ', N'9630014949          ', N'Anuj                                                                                                ', N'8349102353          ')
INSERT [dbo].[Bus] ([BusID], [BusNo], [DriverName], [ContactNo], [SupporterName], [Scontactno]) VALUES (5, N'B003                                                                                                ', N'Rahul                                                                                               ', N'9098300298          ', N'Rakesh                                                                                              ', N'9696963696          ')
SET IDENTITY_INSERT [dbo].[Bus] OFF
/****** Object:  Table [dbo].[BooksSubCategory]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksSubCategory](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryName] [nchar](200) NULL,
	[Category_ID] [int] NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BooksCategory]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksCategory](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nchar](200) NULL,
	[Classification] [nvarchar](300) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookReservation]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookReservation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccessionNo] [nchar](150) NULL,
	[StaffID] [int] NULL,
	[R_Date] [datetime] NULL,
	[Status] [nchar](100) NULL,
	[Remarks] [nvarchar](250) NULL,
 CONSTRAINT [PK_BookReservation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookIssue_Student]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookIssue_Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IssueDate] [datetime] NULL,
	[DueDate] [datetime] NULL,
	[AccessionNo] [nchar](150) NULL,
	[AdmissionNo] [nchar](50) NULL,
	[Status] [nchar](50) NULL,
	[Remarks] [nvarchar](250) NULL,
 CONSTRAINT [PK_BookIssue_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookIssue_Staff]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookIssue_Staff](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IssueDate] [datetime] NULL,
	[DueDate] [datetime] NULL,
	[AccessionNo] [nchar](150) NULL,
	[StaffID] [int] NULL,
	[Status] [nchar](50) NULL,
	[Remarks] [nvarchar](250) NULL,
 CONSTRAINT [PK_BookIssue_Staff] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book_RI]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_RI](
	[IssueID] [int] NOT NULL,
	[ReservationID] [int] NOT NULL,
 CONSTRAINT [PK_Book_RI] PRIMARY KEY CLUSTERED 
(
	[IssueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Book_RI] ([IssueID], [ReservationID]) VALUES (0, 1)
/****** Object:  Table [dbo].[Book]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[AccessionNo] [nchar](150) NOT NULL,
	[BookTitle] [nvarchar](250) NULL,
	[EntryDate] [datetime] NULL,
	[Author] [nvarchar](250) NULL,
	[JointAuthors] [nvarchar](250) NULL,
	[SubCategoryID] [int] NULL,
	[Barcode] [nchar](150) NULL,
	[ISBN] [nchar](150) NULL,
	[Volume] [nchar](150) NULL,
	[Edition] [nchar](150) NULL,
	[Publisher] [nchar](200) NULL,
	[PlaceOfPublisher] [nchar](200) NULL,
	[PublishingYear] [nchar](50) NULL,
	[Section] [nchar](150) NULL,
	[Language] [nchar](150) NULL,
	[Price] [decimal](18, 2) NULL,
	[SupplierID] [int] NULL,
	[BillNo] [nchar](150) NULL,
	[BillDate] [datetime] NULL,
	[Condition] [nchar](100) NULL,
	[Status] [nchar](100) NULL,
	[Remarks] [nvarchar](250) NULL,
	[NoOfPages] [int] NULL,
	[BookPosition] [nchar](150) NULL,
	[BarcodeImage] [image] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[AccessionNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttendanceMaster]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttendanceMaster](
	[AttendanceID] [int] NOT NULL,
	[AttendanceDate] [datetime] NULL,
	[StaffID] [int] NULL,
	[SubjectID] [int] NULL,
 CONSTRAINT [PK_AttendanceMaster] PRIMARY KEY CLUSTERED 
(
	[AttendanceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Attendance_ID] [int] NULL,
	[Status] [nchar](10) NULL,
	[Admission_No] [nchar](50) NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvanceEntry]    Script Date: 04/13/2020 23:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvanceEntry](
	[AdvanceID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Deduction] [decimal](18, 2) NULL,
	[WorkingDate] [datetime] NULL,
 CONSTRAINT [PK_AdvanceEntry] PRIMARY KEY CLUSTERED 
(
	[AdvanceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_BusFeesPayment_TotalFee]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[BusFeesPayment] ADD  CONSTRAINT [DF_BusFeesPayment_TotalFee]  DEFAULT ((0.00)) FOR [TotalFee]
GO
/****** Object:  Default [DF_BusFeesPayment_DiscountPer]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[BusFeesPayment] ADD  CONSTRAINT [DF_BusFeesPayment_DiscountPer]  DEFAULT ((0.00)) FOR [DiscountPer]
GO
/****** Object:  Default [DF_BusFeesPayment_DiscountAmt]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[BusFeesPayment] ADD  CONSTRAINT [DF_BusFeesPayment_DiscountAmt]  DEFAULT ((0.00)) FOR [DiscountAmt]
GO
/****** Object:  Default [DF_BusFeesPayment_PreviousDue]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[BusFeesPayment] ADD  CONSTRAINT [DF_BusFeesPayment_PreviousDue]  DEFAULT ((0.00)) FOR [PreviousDue]
GO
/****** Object:  Default [DF_BusFeesPayment_Fine]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[BusFeesPayment] ADD  CONSTRAINT [DF_BusFeesPayment_Fine]  DEFAULT ((0.00)) FOR [Fine]
GO
/****** Object:  Default [DF_BusFeesPayment_GrandTotal]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[BusFeesPayment] ADD  CONSTRAINT [DF_BusFeesPayment_GrandTotal]  DEFAULT ((0.00)) FOR [GrandTotal]
GO
/****** Object:  Default [DF_BusFeesPayment_TotalPaid]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[BusFeesPayment] ADD  CONSTRAINT [DF_BusFeesPayment_TotalPaid]  DEFAULT ((0.00)) FOR [TotalPaid]
GO
/****** Object:  Default [DF_CourseFeePayment_Join_Fee]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[CourseFeePayment_Join] ADD  CONSTRAINT [DF_CourseFeePayment_Join_Fee]  DEFAULT ((0.00)) FOR [Fee]
GO
/****** Object:  Default [DF_Employee_Discount]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Discount]  DEFAULT ((0.00)) FOR [Discount]
GO
/****** Object:  Default [DF_Grades_ScoreFrom]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[Grades] ADD  CONSTRAINT [DF_Grades_ScoreFrom]  DEFAULT ((0.00)) FOR [ScoreFrom]
GO
/****** Object:  Default [DF_Grades_ScoreTo]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[Grades] ADD  CONSTRAINT [DF_Grades_ScoreTo]  DEFAULT ((0.00)) FOR [ScoreTo]
GO
/****** Object:  Default [DF_MarksEntry_Join_MaxMarks]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[MarksEntry_Join] ADD  CONSTRAINT [DF_MarksEntry_Join_MaxMarks]  DEFAULT ((0.00)) FOR [MaxMarks]
GO
/****** Object:  Default [DF_MarksEntry_Join_MMPractical]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[MarksEntry_Join] ADD  CONSTRAINT [DF_MarksEntry_Join_MMPractical]  DEFAULT ((0.00)) FOR [MMPractical]
GO
/****** Object:  Default [DF_MarksEntry_Join_CreditHours]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[MarksEntry_Join] ADD  CONSTRAINT [DF_MarksEntry_Join_CreditHours]  DEFAULT ((0.00)) FOR [CreditHours]
GO
/****** Object:  Default [DF_MarksEntry_Join_OMTheory]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[MarksEntry_Join] ADD  CONSTRAINT [DF_MarksEntry_Join_OMTheory]  DEFAULT ((0.00)) FOR [OMTheory]
GO
/****** Object:  Default [DF_MarksEntry_Join_OMPractical]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[MarksEntry_Join] ADD  CONSTRAINT [DF_MarksEntry_Join_OMPractical]  DEFAULT ((0.00)) FOR [OMPractical]
GO
/****** Object:  Default [DF_MarksEntry_Join_GradePoint]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[MarksEntry_Join] ADD  CONSTRAINT [DF_MarksEntry_Join_GradePoint]  DEFAULT ((0.00)) FOR [GradePoint]
GO
/****** Object:  Default [DF_Resulting_Marks]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[Resulting] ADD  CONSTRAINT [DF_Resulting_Marks]  DEFAULT ((0.00)) FOR [Marks]
GO
/****** Object:  Default [DF_SchoolFeesPayment_TotalFee]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[SchoolFeesPayment] ADD  CONSTRAINT [DF_SchoolFeesPayment_TotalFee]  DEFAULT ((0.00)) FOR [TotalFee]
GO
/****** Object:  Default [DF_SchoolFeesPayment_DiscountPer]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[SchoolFeesPayment] ADD  CONSTRAINT [DF_SchoolFeesPayment_DiscountPer]  DEFAULT ((0.00)) FOR [DiscountPer]
GO
/****** Object:  Default [DF_SchoolFeesPayment_DiscountAmt]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[SchoolFeesPayment] ADD  CONSTRAINT [DF_SchoolFeesPayment_DiscountAmt]  DEFAULT ((0.00)) FOR [DiscountAmt]
GO
/****** Object:  Default [DF_SchoolFeesPayment_PreviousDue]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[SchoolFeesPayment] ADD  CONSTRAINT [DF_SchoolFeesPayment_PreviousDue]  DEFAULT ((0.00)) FOR [PreviousDue]
GO
/****** Object:  Default [DF_SchoolFeesPayment_Fine]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[SchoolFeesPayment] ADD  CONSTRAINT [DF_SchoolFeesPayment_Fine]  DEFAULT ((0.00)) FOR [Fine]
GO
/****** Object:  Default [DF_SchoolFeesPayment_GrandTotal]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[SchoolFeesPayment] ADD  CONSTRAINT [DF_SchoolFeesPayment_GrandTotal]  DEFAULT ((0.00)) FOR [GrandTotal]
GO
/****** Object:  Default [DF_SchoolFeesPayment_TotalPaid]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[SchoolFeesPayment] ADD  CONSTRAINT [DF_SchoolFeesPayment_TotalPaid]  DEFAULT ((0.00)) FOR [TotalPaid]
GO
/****** Object:  Default [DF_SchoolFeesPayment_PaymentDue]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[SchoolFeesPayment] ADD  CONSTRAINT [DF_SchoolFeesPayment_PaymentDue]  DEFAULT ((0.00)) FOR [PaymentDue]
GO
/****** Object:  Default [DF_StaffPayment_PresentDays]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[StaffPayment] ADD  CONSTRAINT [DF_StaffPayment_PresentDays]  DEFAULT ((0)) FOR [PresentDays]
GO
/****** Object:  Default [DF_StaffPayment_Salary]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[StaffPayment] ADD  CONSTRAINT [DF_StaffPayment_Salary]  DEFAULT ((0.00)) FOR [Salary]
GO
/****** Object:  Default [DF_StaffPayment_Advance]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[StaffPayment] ADD  CONSTRAINT [DF_StaffPayment_Advance]  DEFAULT ((0.00)) FOR [Advance]
GO
/****** Object:  Default [DF_StaffPayment_Deduction]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[StaffPayment] ADD  CONSTRAINT [DF_StaffPayment_Deduction]  DEFAULT ((0.00)) FOR [Deduction]
GO
/****** Object:  Default [DF_StaffPayment_NetPay]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[StaffPayment] ADD  CONSTRAINT [DF_StaffPayment_NetPay]  DEFAULT ((0.00)) FOR [NetPay]
GO
/****** Object:  Default [DF_Student_Bus]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_Bus]  DEFAULT ((0.00)) FOR [Bus]
GO
/****** Object:  Default [DF_Student_Class]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_Class]  DEFAULT ((0.00)) FOR [Class]
GO
/****** Object:  Default [DF_Student_Hostel]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_Hostel]  DEFAULT ((0.00)) FOR [Hostel]
GO
/****** Object:  Default [DF_StudentDiscount_Discount]    Script Date: 04/13/2020 23:59:00 ******/
ALTER TABLE [dbo].[StudentDiscount] ADD  CONSTRAINT [DF_StudentDiscount_Discount]  DEFAULT ((0.00)) FOR [Discount]
GO
