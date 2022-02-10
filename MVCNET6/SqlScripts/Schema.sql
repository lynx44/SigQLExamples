USE [master]
GO
/****** Object:  Database [SigQL_MVCNET6]    Script Date: 2/4/2022 10:10:58 PM ******/
CREATE DATABASE [SigQL_MVCNET6]
GO
USE [SigQL_MVCNET6]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2/4/2022 10:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))
GO
/****** Object:  Table [dbo].[WorkLog]    Script Date: 2/4/2022 10:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_WorkLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))
GO
/****** Object:  View [dbo].[vwLatestEmployeeStartDates]    Script Date: 2/4/2022 10:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwLatestEmployeeStartDates]
AS
SELECT dbo.Employee.Id, dbo.Employee.Name, MAX(dbo.WorkLog.StartDate) AS StartDate
FROM   dbo.Employee INNER JOIN
         dbo.WorkLog ON dbo.Employee.Id = dbo.WorkLog.EmployeeId
GROUP BY dbo.Employee.Id, dbo.Employee.Name
GO
/****** Object:  UserDefinedFunction [dbo].[itvfWorkingEmployeesForMonth]    Script Date: 2/4/2022 10:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--drop function itvfWorkingEmployeesForMonth
CREATE FUNCTION [dbo].[itvfWorkingEmployeesForMonth]
(	
	@Month int,
	@Year int
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT distinct Employee.Id, Employee.Name
	from Employee
	inner join WorkLog on WorkLog.EmployeeId=Employee.Id
	where DATEPART(month, WorkLog.StartDate) = @Month and DATEPART(year, WorkLog.StartDate) = @year
)
GO