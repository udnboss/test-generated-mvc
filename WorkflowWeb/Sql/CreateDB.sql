USE [master]
GO
/****** Object:  Database [IMS]    Script Date: 8/18/2020 1:12:24 PM ******/
CREATE DATABASE [IMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\IMS.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\IMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [IMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [IMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IMS] SET RECOVERY FULL 
GO
ALTER DATABASE [IMS] SET  MULTI_USER 
GO
ALTER DATABASE [IMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [IMS]
GO
/****** Object:  Table [dbo].[TIMS_Contractor]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_Contractor](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_TIMS_Contractor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_Discipline]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_Discipline](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_TIMS_Discipline] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_Phase]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_Phase](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_TIMS_Phase] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_Project]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_Project](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_TIMS_Project] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectActionItem]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectActionItem](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ProjectID] [uniqueidentifier] NULL,
	[InterfaceAgreementID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_ProjectActionItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectActionItemWorkflow]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectActionItemWorkflow](
	[ID] [uniqueidentifier] NOT NULL,
	[WorkflowTypeID] [nvarchar](50) NULL,
	[ActionItemID] [uniqueidentifier] NULL,
	[DateInitiated] [datetime] NULL,
	[LeadStateID] [nvarchar](50) NULL,
	[InterfaceStateID] [nvarchar](50) NULL,
	[UserID] [uniqueidentifier] NULL,
	[IsDraft] [bit] NULL,
 CONSTRAINT [PK_TIMS_ProjectActionItemWorkflow] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectArea]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectArea](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ProjectID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_ProjectArea] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectAttachment]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectAttachment](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ProjectInterfacePointWorkflowID] [uniqueidentifier] NULL,
	[ProjectInterfaceAgreementWorkflowID] [uniqueidentifier] NULL,
	[ProjectActionItemWorkflowID] [uniqueidentifier] NULL,
	[PackageID] [uniqueidentifier] NULL,
	[Filename] [nvarchar](max) NULL,
	[DateUploaded] [datetime] NULL,
	[UserID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_ProjectAttachment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectComment]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectComment](
	[ID] [uniqueidentifier] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[ProjectInterfacePointWorkflowID] [uniqueidentifier] NULL,
	[ProjectInterfaceAgreementWorkflowID] [uniqueidentifier] NULL,
	[ProjectActionItemWorkflowID] [uniqueidentifier] NULL,
	[UserID] [uniqueidentifier] NULL,
	[DateAdded] [datetime] NULL,
 CONSTRAINT [PK_TIMS_ProjectComment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectContractor]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectContractor](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ProjectID] [uniqueidentifier] NULL,
	[ContractorID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_ProjectContractor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectDiscipline]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectDiscipline](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ProjectID] [uniqueidentifier] NULL,
	[DisciplineID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_ProjectDiscipline] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectDisciplineInterfaceType]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectDisciplineInterfaceType](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ProjectIDisciplineID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_ProjectDisciplineInterfaceType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectDisciplineInterfaceTypeField]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectDisciplineInterfaceTypeField](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[InterfaceTypeID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_ProjectDisciplineInterfaceTypeField] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectInterfaceAgreement]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectInterfaceAgreement](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[InterfacePointID] [uniqueidentifier] NULL,
	[RequestorPackageID] [uniqueidentifier] NULL,
	[ResponderPackageID] [uniqueidentifier] NULL,
	[RequestorUserID] [uniqueidentifier] NULL,
	[RequestorTechnicalContactID] [uniqueidentifier] NULL,
	[ResponderInterfaceManagerID] [uniqueidentifier] NULL,
	[ResponderTechnicalContactID] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NULL,
	[NeedDate] [datetime] NULL,
	[IssuedDate] [datetime] NULL,
	[AcceptedDate] [datetime] NULL,
	[ResponseDate] [datetime] NULL,
	[CloseDate] [datetime] NULL,
 CONSTRAINT [PK_TIMS_ProjectInterfaceAgreement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectInterfaceAgreementWorkflow]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow](
	[ID] [uniqueidentifier] NOT NULL,
	[WorkflowTypeID] [nvarchar](50) NULL,
	[InterfaceAgreementID] [uniqueidentifier] NULL,
	[DateInitiated] [datetime] NULL,
	[LeadStateID] [nvarchar](50) NULL,
	[InterfaceStateID] [nvarchar](50) NULL,
	[UserID] [uniqueidentifier] NULL,
	[IsDraft] [bit] NULL,
	[DisciplineID] [uniqueidentifier] NULL,
	[SystemID] [uniqueidentifier] NULL,
	[AreaID] [uniqueidentifier] NULL,
	[ShortDescription] [nvarchar](max) NULL,
	[DetailedDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_TIMS_ProjectInterfaceAgreementWorkflow] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectInterfacePoint]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectInterfacePoint](
	[ID] [uniqueidentifier] NOT NULL,
	[ProjectID] [uniqueidentifier] NULL,
	[LeadPackageID] [uniqueidentifier] NULL,
	[InterfacePackageID] [uniqueidentifier] NULL,
	[SupportPackageID] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NULL,
	[IssueDate] [datetime] NULL,
	[FinalizeDate] [datetime] NULL,
	[CloseDate] [datetime] NULL,
 CONSTRAINT [PK_TIMS_ProjectInterfacePoint] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectInterfacePointFieldEntry]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectInterfacePointFieldEntry](
	[ID] [uniqueidentifier] NOT NULL,
	[InterfacePointWorkflowID] [uniqueidentifier] NULL,
	[InterfaceTypeFieldID] [uniqueidentifier] NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_TIMS_ProjectInterfacePointFieldEntry] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectInterfacePointWorkflow]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow](
	[ID] [uniqueidentifier] NOT NULL,
	[WorkflowTypeID] [nvarchar](50) NULL,
	[InterfacePointID] [uniqueidentifier] NULL,
	[DateInitiated] [datetime] NULL,
	[LeadStateID] [nvarchar](50) NULL,
	[InterfaceStateID] [nvarchar](50) NULL,
	[SupportStateID] [nvarchar](50) NULL,
	[ProjectAreaID] [uniqueidentifier] NULL,
	[ProjectPhysicalAreaID] [uniqueidentifier] NULL,
	[PhaseID] [nvarchar](50) NULL,
	[InterfaceTypeID] [uniqueidentifier] NULL,
	[UserID] [uniqueidentifier] NULL,
	[IsDraft] [bit] NULL,
 CONSTRAINT [PK_TIMS_ProjectInterfacePointWorkflow] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectPackage]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectPackage](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ProjectID] [uniqueidentifier] NULL,
	[ProjectContractorID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_ProjectPackage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_ProjectPhysicalArea]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_ProjectPhysicalArea](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[ProjectID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_ProjectPhysicalArea] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_Role]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_Role](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_TIMS_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_User]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_User](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_TIMS_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_UserRole]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_UserRole](
	[ID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[ProjectID] [uniqueidentifier] NULL,
	[ProjectPackageID] [uniqueidentifier] NULL,
	[RoleID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_UserRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_UserWatchlistItem]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_UserWatchlistItem](
	[ID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[ProjectInterfacePointID] [uniqueidentifier] NULL,
	[ProjectInterfaceAgreementID] [uniqueidentifier] NULL,
	[ProjectActionItemID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TIMS_UserWatchlistItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_WorkflowAction]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_WorkflowAction](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_TIMS_WorkflowAction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_WorkflowState]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_WorkflowState](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_TIMS_WorkflowState] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIMS_WorkflowType]    Script Date: 8/18/2020 1:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIMS_WorkflowType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_TIMS_WorkflowType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TIMS_Contractor] ADD  CONSTRAINT [DF_TIMS_Contractor_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_Discipline] ADD  CONSTRAINT [DF_TIMS_Discipline_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_Phase] ADD  CONSTRAINT [DF_TIMS_Phase_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_Project] ADD  CONSTRAINT [DF_TIMS_Project_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItem] ADD  CONSTRAINT [DF_TIMS_ProjectActionItem_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItemWorkflow] ADD  CONSTRAINT [DF_TIMS_ProjectActionItemWorkflow_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectArea] ADD  CONSTRAINT [DF_TIMS_ProjectArea_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment] ADD  CONSTRAINT [DF_TIMS_ProjectAttachment_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectComment] ADD  CONSTRAINT [DF_TIMS_ProjectComment_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectContractor] ADD  CONSTRAINT [DF_TIMS_ProjectContractor_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectDiscipline] ADD  CONSTRAINT [DF_TIMS_ProjectDiscipline_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectDisciplineInterfaceType] ADD  CONSTRAINT [DF_TIMS_ProjectDisciplineInterfaceType_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectDisciplineInterfaceTypeField] ADD  CONSTRAINT [DF_TIMS_ProjectDisciplineInterfaceTypeField_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreement] ADD  CONSTRAINT [DF_TIMS_ProjectInterfaceAgreement_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow] ADD  CONSTRAINT [DF_TIMS_ProjectInterfaceAgreementWorkflow_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePoint] ADD  CONSTRAINT [DF_TIMS_ProjectInterfacePoint_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointFieldEntry] ADD  CONSTRAINT [DF_TIMS_ProjectInterfacePointFieldEntry_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow] ADD  CONSTRAINT [DF_TIMS_ProjectInterfacePointWorkflow_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectPackage] ADD  CONSTRAINT [DF_TIMS_ProjectPackage_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectPhysicalArea] ADD  CONSTRAINT [DF_TIMS_ProjectPhysicalArea_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_Role] ADD  CONSTRAINT [DF_TIMS_Role_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_User] ADD  CONSTRAINT [DF_TIMS_User_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_UserRole] ADD  CONSTRAINT [DF_TIMS_UserRole_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_UserWatchlistItem] ADD  CONSTRAINT [DF_TIMS_UserWatchlistItem_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_WorkflowType] ADD  CONSTRAINT [DF_TIMS_WorkflowType_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItem]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectActionItem_TIMS_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[TIMS_Project] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItem] NOCHECK CONSTRAINT [FK_TIMS_ProjectActionItem_TIMS_Project]
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItem]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectActionItem_TIMS_ProjectInterfaceAgreement] FOREIGN KEY([InterfaceAgreementID])
REFERENCES [dbo].[TIMS_ProjectInterfaceAgreement] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItem] NOCHECK CONSTRAINT [FK_TIMS_ProjectActionItem_TIMS_ProjectInterfaceAgreement]
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItemWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectActionItemWorkflow_TIMS_ProjectActionItem] FOREIGN KEY([ActionItemID])
REFERENCES [dbo].[TIMS_ProjectActionItem] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItemWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectActionItemWorkflow_TIMS_ProjectActionItem]
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItemWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectActionItemWorkflow_TIMS_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[TIMS_User] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItemWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectActionItemWorkflow_TIMS_User]
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItemWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectActionItemWorkflow_TIMS_WorkflowType] FOREIGN KEY([WorkflowTypeID])
REFERENCES [dbo].[TIMS_WorkflowType] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectActionItemWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectActionItemWorkflow_TIMS_WorkflowType]
GO
ALTER TABLE [dbo].[TIMS_ProjectArea]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectArea_TIMS_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[TIMS_Project] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectArea] NOCHECK CONSTRAINT [FK_TIMS_ProjectArea_TIMS_Project]
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectAttachment_TIMS_ProjectActionItemWorkflow] FOREIGN KEY([ProjectActionItemWorkflowID])
REFERENCES [dbo].[TIMS_ProjectActionItemWorkflow] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment] NOCHECK CONSTRAINT [FK_TIMS_ProjectAttachment_TIMS_ProjectActionItemWorkflow]
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectAttachment_TIMS_ProjectInterfaceAgreementWorkflow] FOREIGN KEY([ProjectInterfaceAgreementWorkflowID])
REFERENCES [dbo].[TIMS_ProjectInterfaceAgreementWorkflow] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment] NOCHECK CONSTRAINT [FK_TIMS_ProjectAttachment_TIMS_ProjectInterfaceAgreementWorkflow]
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectAttachment_TIMS_ProjectInterfacePointWorkflow] FOREIGN KEY([ProjectInterfacePointWorkflowID])
REFERENCES [dbo].[TIMS_ProjectInterfacePointWorkflow] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment] NOCHECK CONSTRAINT [FK_TIMS_ProjectAttachment_TIMS_ProjectInterfacePointWorkflow]
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectAttachment_TIMS_ProjectPackage] FOREIGN KEY([PackageID])
REFERENCES [dbo].[TIMS_ProjectPackage] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment] NOCHECK CONSTRAINT [FK_TIMS_ProjectAttachment_TIMS_ProjectPackage]
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectAttachment_TIMS_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[TIMS_User] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectAttachment] NOCHECK CONSTRAINT [FK_TIMS_ProjectAttachment_TIMS_User]
GO
ALTER TABLE [dbo].[TIMS_ProjectComment]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectComment_TIMS_ProjectActionItemWorkflow] FOREIGN KEY([ProjectActionItemWorkflowID])
REFERENCES [dbo].[TIMS_ProjectActionItemWorkflow] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectComment] NOCHECK CONSTRAINT [FK_TIMS_ProjectComment_TIMS_ProjectActionItemWorkflow]
GO
ALTER TABLE [dbo].[TIMS_ProjectComment]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectComment_TIMS_ProjectInterfaceAgreementWorkflow] FOREIGN KEY([ProjectInterfaceAgreementWorkflowID])
REFERENCES [dbo].[TIMS_ProjectInterfaceAgreementWorkflow] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectComment] NOCHECK CONSTRAINT [FK_TIMS_ProjectComment_TIMS_ProjectInterfaceAgreementWorkflow]
GO
ALTER TABLE [dbo].[TIMS_ProjectComment]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectComment_TIMS_ProjectInterfacePointWorkflow] FOREIGN KEY([ProjectInterfacePointWorkflowID])
REFERENCES [dbo].[TIMS_ProjectInterfacePointWorkflow] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectComment] NOCHECK CONSTRAINT [FK_TIMS_ProjectComment_TIMS_ProjectInterfacePointWorkflow]
GO
ALTER TABLE [dbo].[TIMS_ProjectComment]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectComment_TIMS_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[TIMS_User] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectComment] NOCHECK CONSTRAINT [FK_TIMS_ProjectComment_TIMS_User]
GO
ALTER TABLE [dbo].[TIMS_ProjectContractor]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectContractor_TIMS_Contractor] FOREIGN KEY([ContractorID])
REFERENCES [dbo].[TIMS_Contractor] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectContractor] NOCHECK CONSTRAINT [FK_TIMS_ProjectContractor_TIMS_Contractor]
GO
ALTER TABLE [dbo].[TIMS_ProjectContractor]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectContractor_TIMS_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[TIMS_Project] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectContractor] NOCHECK CONSTRAINT [FK_TIMS_ProjectContractor_TIMS_Project]
GO
ALTER TABLE [dbo].[TIMS_ProjectDiscipline]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectDiscipline_TIMS_Discipline] FOREIGN KEY([DisciplineID])
REFERENCES [dbo].[TIMS_Discipline] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectDiscipline] NOCHECK CONSTRAINT [FK_TIMS_ProjectDiscipline_TIMS_Discipline]
GO
ALTER TABLE [dbo].[TIMS_ProjectDiscipline]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectDiscipline_TIMS_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[TIMS_Project] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectDiscipline] NOCHECK CONSTRAINT [FK_TIMS_ProjectDiscipline_TIMS_Project]
GO
ALTER TABLE [dbo].[TIMS_ProjectDisciplineInterfaceType]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectDisciplineInterfaceType_TIMS_ProjectDiscipline] FOREIGN KEY([ProjectIDisciplineID])
REFERENCES [dbo].[TIMS_ProjectDiscipline] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectDisciplineInterfaceType] NOCHECK CONSTRAINT [FK_TIMS_ProjectDisciplineInterfaceType_TIMS_ProjectDiscipline]
GO
ALTER TABLE [dbo].[TIMS_ProjectDisciplineInterfaceTypeField]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectDisciplineInterfaceTypeField_TIMS_ProjectDisciplineInterfaceType] FOREIGN KEY([InterfaceTypeID])
REFERENCES [dbo].[TIMS_ProjectDisciplineInterfaceType] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectDisciplineInterfaceTypeField] NOCHECK CONSTRAINT [FK_TIMS_ProjectDisciplineInterfaceTypeField_TIMS_ProjectDisciplineInterfaceType]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreement]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfaceAgreement_TIMS_ProjectInterfacePoint] FOREIGN KEY([InterfacePointID])
REFERENCES [dbo].[TIMS_ProjectInterfacePoint] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreement] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfaceAgreement_TIMS_ProjectInterfacePoint]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreement]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfaceAgreement_TIMS_ProjectPackage] FOREIGN KEY([RequestorPackageID])
REFERENCES [dbo].[TIMS_ProjectPackage] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreement] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfaceAgreement_TIMS_ProjectPackage]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreement]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfaceAgreement_TIMS_ProjectPackage1] FOREIGN KEY([ResponderPackageID])
REFERENCES [dbo].[TIMS_ProjectPackage] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreement] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfaceAgreement_TIMS_ProjectPackage1]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfaceAgreementWorkflow_TIMS_ProjectArea] FOREIGN KEY([AreaID])
REFERENCES [dbo].[TIMS_ProjectArea] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfaceAgreementWorkflow_TIMS_ProjectArea]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfaceAgreementWorkflow_TIMS_ProjectDiscipline] FOREIGN KEY([DisciplineID])
REFERENCES [dbo].[TIMS_ProjectDiscipline] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfaceAgreementWorkflow_TIMS_ProjectDiscipline]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfaceAgreementWorkflow_TIMS_ProjectInterfaceAgreement] FOREIGN KEY([InterfaceAgreementID])
REFERENCES [dbo].[TIMS_ProjectInterfaceAgreement] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfaceAgreementWorkflow_TIMS_ProjectInterfaceAgreement]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfaceAgreementWorkflow_TIMS_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[TIMS_User] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfaceAgreementWorkflow_TIMS_User]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfaceAgreementWorkflow_TIMS_WorkflowType] FOREIGN KEY([WorkflowTypeID])
REFERENCES [dbo].[TIMS_WorkflowType] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfaceAgreementWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfaceAgreementWorkflow_TIMS_WorkflowType]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePoint]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePoint_TIMS_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[TIMS_Project] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePoint] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePoint_TIMS_Project]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePoint]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePoint_TIMS_ProjectPackage] FOREIGN KEY([LeadPackageID])
REFERENCES [dbo].[TIMS_ProjectPackage] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePoint] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePoint_TIMS_ProjectPackage]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePoint]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePoint_TIMS_ProjectPackage1] FOREIGN KEY([InterfacePackageID])
REFERENCES [dbo].[TIMS_ProjectPackage] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePoint] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePoint_TIMS_ProjectPackage1]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePoint]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePoint_TIMS_ProjectPackage2] FOREIGN KEY([SupportPackageID])
REFERENCES [dbo].[TIMS_ProjectPackage] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePoint] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePoint_TIMS_ProjectPackage2]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointFieldEntry]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointFieldEntry_TIMS_ProjectDisciplineInterfaceTypeField] FOREIGN KEY([InterfaceTypeFieldID])
REFERENCES [dbo].[TIMS_ProjectDisciplineInterfaceTypeField] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointFieldEntry] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointFieldEntry_TIMS_ProjectDisciplineInterfaceTypeField]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointFieldEntry]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointFieldEntry_TIMS_ProjectInterfacePointWorkflow] FOREIGN KEY([InterfacePointWorkflowID])
REFERENCES [dbo].[TIMS_ProjectInterfacePointWorkflow] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointFieldEntry] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointFieldEntry_TIMS_ProjectInterfacePointWorkflow]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_Phase] FOREIGN KEY([PhaseID])
REFERENCES [dbo].[TIMS_Phase] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_Phase]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_ProjectArea] FOREIGN KEY([ProjectAreaID])
REFERENCES [dbo].[TIMS_ProjectArea] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_ProjectArea]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_ProjectDisciplineInterfaceType] FOREIGN KEY([InterfaceTypeID])
REFERENCES [dbo].[TIMS_ProjectDisciplineInterfaceType] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_ProjectDisciplineInterfaceType]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_ProjectPhysicalArea] FOREIGN KEY([ProjectPhysicalAreaID])
REFERENCES [dbo].[TIMS_ProjectPhysicalArea] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_ProjectPhysicalArea]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[TIMS_User] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_User]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_WorkflowState] FOREIGN KEY([LeadStateID])
REFERENCES [dbo].[TIMS_WorkflowState] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_WorkflowState]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_WorkflowState1] FOREIGN KEY([InterfaceStateID])
REFERENCES [dbo].[TIMS_WorkflowState] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_WorkflowState1]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_WorkflowState2] FOREIGN KEY([SupportStateID])
REFERENCES [dbo].[TIMS_WorkflowState] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_WorkflowState2]
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_WorkflowType] FOREIGN KEY([WorkflowTypeID])
REFERENCES [dbo].[TIMS_WorkflowType] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectInterfacePointWorkflow] NOCHECK CONSTRAINT [FK_TIMS_ProjectInterfacePointWorkflow_TIMS_WorkflowType]
GO
ALTER TABLE [dbo].[TIMS_ProjectPackage]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectPackage_TIMS_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[TIMS_Project] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectPackage] NOCHECK CONSTRAINT [FK_TIMS_ProjectPackage_TIMS_Project]
GO
ALTER TABLE [dbo].[TIMS_ProjectPackage]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectPackage_TIMS_ProjectContractor] FOREIGN KEY([ProjectContractorID])
REFERENCES [dbo].[TIMS_ProjectContractor] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectPackage] NOCHECK CONSTRAINT [FK_TIMS_ProjectPackage_TIMS_ProjectContractor]
GO
ALTER TABLE [dbo].[TIMS_ProjectPhysicalArea]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_ProjectPhysicalArea_TIMS_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[TIMS_Project] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_ProjectPhysicalArea] NOCHECK CONSTRAINT [FK_TIMS_ProjectPhysicalArea_TIMS_Project]
GO
ALTER TABLE [dbo].[TIMS_UserRole]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_UserRole_TIMS_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[TIMS_Project] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_UserRole] NOCHECK CONSTRAINT [FK_TIMS_UserRole_TIMS_Project]
GO
ALTER TABLE [dbo].[TIMS_UserRole]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_UserRole_TIMS_ProjectPackage] FOREIGN KEY([ProjectPackageID])
REFERENCES [dbo].[TIMS_ProjectPackage] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_UserRole] NOCHECK CONSTRAINT [FK_TIMS_UserRole_TIMS_ProjectPackage]
GO
ALTER TABLE [dbo].[TIMS_UserRole]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_UserRole_TIMS_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[TIMS_Role] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_UserRole] NOCHECK CONSTRAINT [FK_TIMS_UserRole_TIMS_Role]
GO
ALTER TABLE [dbo].[TIMS_UserRole]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_UserRole_TIMS_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[TIMS_User] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_UserRole] NOCHECK CONSTRAINT [FK_TIMS_UserRole_TIMS_User]
GO
ALTER TABLE [dbo].[TIMS_UserWatchlistItem]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_UserWatchlistItem_TIMS_ProjectActionItem] FOREIGN KEY([ProjectActionItemID])
REFERENCES [dbo].[TIMS_ProjectActionItem] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_UserWatchlistItem] NOCHECK CONSTRAINT [FK_TIMS_UserWatchlistItem_TIMS_ProjectActionItem]
GO
ALTER TABLE [dbo].[TIMS_UserWatchlistItem]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_UserWatchlistItem_TIMS_ProjectInterfaceAgreement] FOREIGN KEY([ProjectInterfaceAgreementID])
REFERENCES [dbo].[TIMS_ProjectInterfaceAgreement] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_UserWatchlistItem] NOCHECK CONSTRAINT [FK_TIMS_UserWatchlistItem_TIMS_ProjectInterfaceAgreement]
GO
ALTER TABLE [dbo].[TIMS_UserWatchlistItem]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_UserWatchlistItem_TIMS_ProjectInterfacePoint] FOREIGN KEY([ProjectInterfacePointID])
REFERENCES [dbo].[TIMS_ProjectInterfacePoint] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_UserWatchlistItem] NOCHECK CONSTRAINT [FK_TIMS_UserWatchlistItem_TIMS_ProjectInterfacePoint]
GO
ALTER TABLE [dbo].[TIMS_UserWatchlistItem]  WITH NOCHECK ADD  CONSTRAINT [FK_TIMS_UserWatchlistItem_TIMS_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[TIMS_User] ([ID])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TIMS_UserWatchlistItem] NOCHECK CONSTRAINT [FK_TIMS_UserWatchlistItem_TIMS_User]
GO
USE [master]
GO
ALTER DATABASE [IMS] SET  READ_WRITE 
GO
