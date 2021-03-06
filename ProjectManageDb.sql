USE [master]
GO
/****** Object:  Database [ProjectManageDb]    Script Date: 12/22/2021 9:05:24 PM ******/
CREATE DATABASE [ProjectManageDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectManageDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LOCAL\MSSQL\DATA\ProjectManageDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectManageDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LOCAL\MSSQL\DATA\ProjectManageDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectManageDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectManageDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectManageDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectManageDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectManageDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectManageDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectManageDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectManageDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectManageDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManageDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectManageDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectManageDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectManageDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectManageDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectManageDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectManageDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectManageDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectManageDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectManageDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectManageDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectManageDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectManageDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectManageDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectManageDb] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectManageDb] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectManageDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectManageDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectManageDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectManageDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectManageDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectManageDb', N'ON'
GO
USE [ProjectManageDb]
GO
/****** Object:  Table [dbo].[AssignProjects]    Script Date: 12/22/2021 9:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignProjects](
	[AssignId] [int] NOT NULL,
	[ProjectId] [int] NULL,
	[UserId] [int] NULL,
	[StartDate] [nvarchar](50) NULL,
	[EndDate] [nvarchar](50) NULL,
	[Priority] [nvarchar](50) NULL,
	[AdminId] [int] NULL,
 CONSTRAINT [PK_AssignProjects] PRIMARY KEY CLUSTERED 
(
	[AssignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignProjectToCompany]    Script Date: 12/22/2021 9:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignProjectToCompany](
	[AssignCompanyId] [int] NOT NULL,
	[ProjectId] [int] NULL,
	[CompanyId] [int] NULL,
	[StartDate] [nvarchar](50) NULL,
	[EndDate] [nvarchar](50) NULL,
	[Priority] [nvarchar](50) NULL,
	[AdminId] [int] NULL,
 CONSTRAINT [PK_AssignProjectToCompany] PRIMARY KEY CLUSTERED 
(
	[AssignCompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignTicketToUser]    Script Date: 12/22/2021 9:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignTicketToUser](
	[AssignTicketId] [int] NOT NULL,
	[TicketId] [int] NULL,
	[UserId] [int] NULL,
	[DateIssued] [nvarchar](50) NULL,
	[AdminId] [int] NULL,
 CONSTRAINT [PK_AssignTicketToUser] PRIMARY KEY CLUSTERED 
(
	[AssignTicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 12/22/2021 9:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[CompanyLocation] [nvarchar](max) NULL,
	[AdminId] [int] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 12/22/2021 9:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] NOT NULL,
	[ProjectName] [nvarchar](max) NULL,
	[StartDate] [nvarchar](50) NULL,
	[EndDate] [nvarchar](50) NULL,
	[Priority] [nvarchar](50) NULL,
	[Progress] [nvarchar](50) NULL,
	[AdminId] [int] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 12/22/2021 9:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [int] NOT NULL,
	[IssueDate] [nvarchar](50) NULL,
	[AdminId] [int] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/22/2021 9:05:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[FirstName] [nvarchar](500) NULL,
	[SurName] [nvarchar](500) NULL,
	[DOB] [nvarchar](500) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](500) NULL,
	[Password] [nvarchar](500) NULL,
	[UserType] [nvarchar](50) NULL,
	[AdminId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AssignProjects] ([AssignId], [ProjectId], [UserId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1001, 1001, 1002, N'21/12/2021', N'27/12/2021', N'High', 1001)
INSERT [dbo].[AssignProjects] ([AssignId], [ProjectId], [UserId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1002, 1001, 1003, N'21/12/2021', N'27/12/2021', N'High', 1001)
INSERT [dbo].[AssignProjects] ([AssignId], [ProjectId], [UserId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1003, 1001, 1004, N'21/12/2021', N'21/12/2021', N'Medium', 1001)
INSERT [dbo].[AssignProjects] ([AssignId], [ProjectId], [UserId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1004, 1002, 1005, N'21/12/2021', N'30/12/2021', N'High', 1001)
INSERT [dbo].[AssignProjects] ([AssignId], [ProjectId], [UserId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1005, 1003, 1005, N'21/12/2021', N'30/12/2021', N'High', 1001)
INSERT [dbo].[AssignProjects] ([AssignId], [ProjectId], [UserId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1006, 1003, 1003, N'21/12/2021', N'27/12/2021', N'High', 1001)
INSERT [dbo].[AssignProjects] ([AssignId], [ProjectId], [UserId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1007, 1004, 1004, N'21/12/2021', N'30/12/2022', N'High', 1001)
GO
INSERT [dbo].[AssignProjectToCompany] ([AssignCompanyId], [ProjectId], [CompanyId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1001, 1001, 1001, N'21/12/2021', N'31/12/2021', N'High', 1001)
INSERT [dbo].[AssignProjectToCompany] ([AssignCompanyId], [ProjectId], [CompanyId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1002, 1002, 1001, N'21/12/2021', N'03/01/2022', N'High', 1001)
INSERT [dbo].[AssignProjectToCompany] ([AssignCompanyId], [ProjectId], [CompanyId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1003, 1003, 1002, N'21/12/2021', N'31/12/2021', N'Medium', 1001)
INSERT [dbo].[AssignProjectToCompany] ([AssignCompanyId], [ProjectId], [CompanyId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1004, 1001, 1002, N'21/12/2021', N'30/12/2021', N'High', 1001)
INSERT [dbo].[AssignProjectToCompany] ([AssignCompanyId], [ProjectId], [CompanyId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1005, 1004, 1003, N'21/12/2021', N'30/12/2021', N'Medium', 1001)
INSERT [dbo].[AssignProjectToCompany] ([AssignCompanyId], [ProjectId], [CompanyId], [StartDate], [EndDate], [Priority], [AdminId]) VALUES (1006, 1003, 1003, N'21/12/2021', N'05/01/2022', N'Medium', 1001)
GO
INSERT [dbo].[AssignTicketToUser] ([AssignTicketId], [TicketId], [UserId], [DateIssued], [AdminId]) VALUES (1001, 1, 1002, N'12/21/2021', 1001)
INSERT [dbo].[AssignTicketToUser] ([AssignTicketId], [TicketId], [UserId], [DateIssued], [AdminId]) VALUES (1002, 2, 1003, N'12/21/2021', 1001)
INSERT [dbo].[AssignTicketToUser] ([AssignTicketId], [TicketId], [UserId], [DateIssued], [AdminId]) VALUES (1003, 3, 1004, N'12/21/2021', 1001)
INSERT [dbo].[AssignTicketToUser] ([AssignTicketId], [TicketId], [UserId], [DateIssued], [AdminId]) VALUES (1004, 4, 1005, N'12/21/2021', 1001)
GO
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyLocation], [AdminId]) VALUES (1001, N'Alchemy Software Limited', N'Chittagong', 1001)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyLocation], [AdminId]) VALUES (1002, N'Generic Software Solution', N'Chittagong', 1001)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [CompanyLocation], [AdminId]) VALUES (1003, N'Coder Zone Solution', N'Chittagong', 1001)
GO
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [EndDate], [Priority], [Progress], [AdminId]) VALUES (1001, N'Stock management system', N'21/12/2021', N'30/12/2021', N'High', N'0', 1001)
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [EndDate], [Priority], [Progress], [AdminId]) VALUES (1002, N'School Management System', N'21/12/2021', N'30/12/2021', N'Medium', N'25%', 1001)
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [EndDate], [Priority], [Progress], [AdminId]) VALUES (1003, N'Hospital Management System', N'21/12/2021', N'01/01/2022', N'High', N'25%', 1001)
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [EndDate], [Priority], [Progress], [AdminId]) VALUES (1004, N'Catering Management System', N'21/12/2021', N'29/12/2021', N'Medium', N'100%', 1001)
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([Id], [TicketId], [IssueDate], [AdminId]) VALUES (1, 1001, N'21/12/2021', 1001)
INSERT [dbo].[Ticket] ([Id], [TicketId], [IssueDate], [AdminId]) VALUES (2, 1002, N'21/12/2021', 1001)
INSERT [dbo].[Ticket] ([Id], [TicketId], [IssueDate], [AdminId]) VALUES (3, 1003, N'21/12/2021', 1001)
INSERT [dbo].[Ticket] ([Id], [TicketId], [IssueDate], [AdminId]) VALUES (4, 1004, N'21/12/2021', 1001)
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [SurName], [DOB], [Address], [Email], [Password], [UserType], [AdminId]) VALUES (1001, N'Sakib', N'Hossain', N'02/08/1996', N'Chittagong', N'shfsakib@gmail.com', N'123', N'Admin', 1001)
INSERT [dbo].[Users] ([UserId], [FirstName], [SurName], [DOB], [Address], [Email], [Password], [UserType], [AdminId]) VALUES (1002, N'Ishraq', N'Hoque', N'21/12/1995', N'Chittagong', N'ishraq@gmail.com', N'123', N'Staff', 1001)
INSERT [dbo].[Users] ([UserId], [FirstName], [SurName], [DOB], [Address], [Email], [Password], [UserType], [AdminId]) VALUES (1003, N'Jahangir', N'Jumon', N'21/12/1994', N'Chittagong', N'jumon@gmail.com', N'123', N'Staff', 1001)
INSERT [dbo].[Users] ([UserId], [FirstName], [SurName], [DOB], [Address], [Email], [Password], [UserType], [AdminId]) VALUES (1004, N'Main', N'Uddin', N'21/12/1980', N'Noakhali', N'main@gmail.com', N'123', N'Staff', 1001)
INSERT [dbo].[Users] ([UserId], [FirstName], [SurName], [DOB], [Address], [Email], [Password], [UserType], [AdminId]) VALUES (1005, N'Sayed', N'Prince', N'21/12/1991', N'Chittagong', N'prince@gmail.com', N'123', N'Staff', 1001)
GO
USE [master]
GO
ALTER DATABASE [ProjectManageDb] SET  READ_WRITE 
GO
