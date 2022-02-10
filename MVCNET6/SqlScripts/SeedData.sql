SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (1, N'Linda')
GO
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (2, N'Elroy')
GO
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (3, N'Ted')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkLog] ON 
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (3, CAST(N'2022-02-03T17:29:44.897' AS DateTime), 3)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (4, CAST(N'2022-02-03T21:07:28.110' AS DateTime), 1)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (5, CAST(N'2022-02-03T21:07:28.110' AS DateTime), 2)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (6, CAST(N'2022-02-03T21:07:28.110' AS DateTime), 3)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (8, CAST(N'2022-02-03T21:07:28.527' AS DateTime), 2)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (9, CAST(N'2022-02-03T21:07:28.527' AS DateTime), 3)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (10, CAST(N'2022-02-03T21:07:31.300' AS DateTime), 1)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (11, CAST(N'2022-02-03T21:07:31.300' AS DateTime), 2)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (12, CAST(N'2022-02-03T21:07:31.300' AS DateTime), 3)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (13, CAST(N'2022-01-24T00:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (14, CAST(N'2022-02-04T21:45:06.630' AS DateTime), 1)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (15, CAST(N'2022-02-04T21:45:06.630' AS DateTime), 2)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (16, CAST(N'2022-02-04T21:45:06.630' AS DateTime), 3)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (17, CAST(N'2022-01-04T21:46:58.950' AS DateTime), 1)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (18, CAST(N'2021-12-04T21:46:58.950' AS DateTime), 2)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (19, CAST(N'2021-11-04T21:46:58.950' AS DateTime), 3)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (20, CAST(N'2022-03-04T21:47:16.347' AS DateTime), 1)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (21, CAST(N'2022-04-04T21:47:16.347' AS DateTime), 2)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (22, CAST(N'2022-05-04T21:47:16.347' AS DateTime), 3)
GO
INSERT [dbo].[WorkLog] ([Id], [StartDate], [EmployeeId]) VALUES (23, CAST(N'2022-01-18T00:00:00.000' AS DateTime), 2)
GO
SET IDENTITY_INSERT [dbo].[WorkLog] OFF
GO
ALTER TABLE [dbo].[WorkLog]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
