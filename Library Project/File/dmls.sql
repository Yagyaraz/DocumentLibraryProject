USE [master]
GO
/****** Object:  Database [DLMSDatabase]    Script Date: 9/26/2023 12:00:48 PM ******/
CREATE DATABASE [DLMSDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DLMSDatabase1', FILENAME = N'E:\New folder\New folder\MSSQL16.SQLEXPRESS\MSSQL\DATA\DLMSDatabase1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DLMSDatabase1_log', FILENAME = N'E:\New folder\New folder\MSSQL16.SQLEXPRESS\MSSQL\DATA\DLMSDatabase1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DLMSDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DLMSDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DLMSDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DLMSDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DLMSDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DLMSDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [DLMSDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DLMSDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DLMSDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DLMSDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DLMSDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DLMSDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DLMSDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DLMSDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DLMSDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DLMSDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DLMSDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DLMSDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DLMSDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DLMSDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DLMSDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DLMSDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DLMSDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DLMSDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DLMSDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [DLMSDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DLMSDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DLMSDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DLMSDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [DLMSDatabase]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[State_Id] [int] NOT NULL,
 CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Category_Id] [int] NOT NULL,
	[Sub_Category_Id] [int] NOT NULL,
	[Document_Source_Id] [int] NOT NULL,
	[Fiscal_Year_Id] [int] NOT NULL,
	[State_Id] [int] NOT NULL,
	[District_Id] [int] NOT NULL,
	[Palika_Id] [int] NOT NULL,
	[Document_Type_Id] [int] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document_File]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document_File](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[File_Path] [varchar](max) NOT NULL,
	[DocumentID] [int] NULL,
 CONSTRAINT [PK_Document_File] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document_Source]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document_Source](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Document_Source] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document_Type]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document_Type](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Document_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fiscal_Year]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fiscal_Year](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Fiscal_Year] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Palika]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Palika](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[District_Id] [int] NOT NULL,
 CONSTRAINT [PK_Palika] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sub_Category]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sub_Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Category_Id] [int] NOT NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Sub_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/26/2023 12:00:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [IsDelete]) VALUES (1, N'आर्थिक विकास ', 0)
INSERT [dbo].[Category] ([Id], [Name], [IsDelete]) VALUES (2, N'विनिमय ', 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (1, N'काठमाडौँ', 1)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (3, N'भक्तपुर', 1)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (5, N'ललितपुर', 1)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (6, N'चितवन', 1)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (7, N'बारा', 2)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (8, N'पर्सा', 2)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (10, N'सिराह', 2)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (11, N'सप्तरी', 2)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (12, N'झापा', 3)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (13, N'ईलाम', 3)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (15, N'कास्की', 4)
INSERT [dbo].[District] ([Id], [Name], [State_Id]) VALUES (16, N'म्याग्दी', 4)
SET IDENTITY_INSERT [dbo].[District] OFF
GO
SET IDENTITY_INSERT [dbo].[Document] ON 

INSERT [dbo].[Document] ([Id], [Name], [Category_Id], [Sub_Category_Id], [Document_Source_Id], [Fiscal_Year_Id], [State_Id], [District_Id], [Palika_Id], [Document_Type_Id], [IsDelete]) VALUES (1, N'मौद्रिक नीति (२०८०)', 1, 1, 1, 1, 1, 1, 2, 1, NULL)
INSERT [dbo].[Document] ([Id], [Name], [Category_Id], [Sub_Category_Id], [Document_Source_Id], [Fiscal_Year_Id], [State_Id], [District_Id], [Palika_Id], [Document_Type_Id], [IsDelete]) VALUES (2, N'नागरिकता ', 1, 1, 1, 1, 1, 1, 4, 2, NULL)
INSERT [dbo].[Document] ([Id], [Name], [Category_Id], [Sub_Category_Id], [Document_Source_Id], [Fiscal_Year_Id], [State_Id], [District_Id], [Palika_Id], [Document_Type_Id], [IsDelete]) VALUES (3, N'नागरिकता ', 1, 1, 2, 1, 3, 12, 21, 2, NULL)
INSERT [dbo].[Document] ([Id], [Name], [Category_Id], [Sub_Category_Id], [Document_Source_Id], [Fiscal_Year_Id], [State_Id], [District_Id], [Palika_Id], [Document_Type_Id], [IsDelete]) VALUES (4, N'नागरिकता ', 1, 1, 1, 1, 1, 1, 2, 2, NULL)
INSERT [dbo].[Document] ([Id], [Name], [Category_Id], [Sub_Category_Id], [Document_Source_Id], [Fiscal_Year_Id], [State_Id], [District_Id], [Palika_Id], [Document_Type_Id], [IsDelete]) VALUES (5, N'मौद्रिक नीति (२०८०)', 2, 2, 1, 1, 1, 1, 2, 1, 1)
INSERT [dbo].[Document] ([Id], [Name], [Category_Id], [Sub_Category_Id], [Document_Source_Id], [Fiscal_Year_Id], [State_Id], [District_Id], [Palika_Id], [Document_Type_Id], [IsDelete]) VALUES (6, N'नागरिकता ', 1, 1, 1, 1, 1, 1, 2, 1, 1)
INSERT [dbo].[Document] ([Id], [Name], [Category_Id], [Sub_Category_Id], [Document_Source_Id], [Fiscal_Year_Id], [State_Id], [District_Id], [Palika_Id], [Document_Type_Id], [IsDelete]) VALUES (7, N'लाईसेन्स', 1, 1, 1, 1, 1, 1, 2, 1, 1)
INSERT [dbo].[Document] ([Id], [Name], [Category_Id], [Sub_Category_Id], [Document_Source_Id], [Fiscal_Year_Id], [State_Id], [District_Id], [Palika_Id], [Document_Type_Id], [IsDelete]) VALUES (8, N'मौद्रिक नीति (२०८०)', 1, 1, 1, 1, 1, 1, 2, 1, 0)
SET IDENTITY_INSERT [dbo].[Document] OFF
GO
SET IDENTITY_INSERT [dbo].[Document_File] ON 

INSERT [dbo].[Document_File] ([Id], [Name], [File_Path], [DocumentID]) VALUES (1, N'gd.png', N'/File/', NULL)
INSERT [dbo].[Document_File] ([Id], [Name], [File_Path], [DocumentID]) VALUES (2, N'gd.png', N'/File/', NULL)
INSERT [dbo].[Document_File] ([Id], [Name], [File_Path], [DocumentID]) VALUES (3, N'maxresdefault.jpg', N'/File/', NULL)
SET IDENTITY_INSERT [dbo].[Document_File] OFF
GO
SET IDENTITY_INSERT [dbo].[Document_Source] ON 

INSERT [dbo].[Document_Source] ([Id], [Name], [IsDelete]) VALUES (1, N'सरकार ', 0)
INSERT [dbo].[Document_Source] ([Id], [Name], [IsDelete]) VALUES (2, N'स्थानीय तह ', 0)
SET IDENTITY_INSERT [dbo].[Document_Source] OFF
GO
SET IDENTITY_INSERT [dbo].[Document_Type] ON 

INSERT [dbo].[Document_Type] ([Id], [Name], [IsDelete]) VALUES (1, N'कानुन', 0)
INSERT [dbo].[Document_Type] ([Id], [Name], [IsDelete]) VALUES (2, N'अनुसन्धान ', 0)
SET IDENTITY_INSERT [dbo].[Document_Type] OFF
GO
SET IDENTITY_INSERT [dbo].[Fiscal_Year] ON 

INSERT [dbo].[Fiscal_Year] ([Id], [Name], [Active], [IsDelete]) VALUES (1, N'2071', 1, 0)
INSERT [dbo].[Fiscal_Year] ([Id], [Name], [Active], [IsDelete]) VALUES (2, N'2073', 0, 0)
SET IDENTITY_INSERT [dbo].[Fiscal_Year] OFF
GO
SET IDENTITY_INSERT [dbo].[Palika] ON 

INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (2, N'किर्तिपुर ', 1)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (3, N'काठमाडौँ', 1)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (4, N'बुढानिलकण्ठ', 1)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (5, N'भक्तपुर', 3)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (11, N'मध्यपुरठिमी', 3)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (12, N'चागुनारायण', 3)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (13, N'ललितपुर', 5)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (14, N'गोदावरी', 5)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (15, N'भरतपुर', 6)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (16, N'माडी', 6)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (17, N'कन्काई', 12)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (19, N'भद्रपुर', 12)
INSERT [dbo].[Palika] ([Id], [Name], [District_Id]) VALUES (21, N'अर्जुनधारा', 12)
SET IDENTITY_INSERT [dbo].[Palika] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([Id], [Name]) VALUES (1, N'बागमती')
INSERT [dbo].[State] ([Id], [Name]) VALUES (2, N'मधेश ')
INSERT [dbo].[State] ([Id], [Name]) VALUES (3, N'कोशी')
INSERT [dbo].[State] ([Id], [Name]) VALUES (4, N'गण्डकी ')
SET IDENTITY_INSERT [dbo].[State] OFF
GO
SET IDENTITY_INSERT [dbo].[Sub_Category] ON 

INSERT [dbo].[Sub_Category] ([Id], [Name], [Category_Id], [IsDelete]) VALUES (1, N'बैंक ', 1, 0)
INSERT [dbo].[Sub_Category] ([Id], [Name], [Category_Id], [IsDelete]) VALUES (2, N'सहकारी ', 2, 0)
SET IDENTITY_INSERT [dbo].[Sub_Category] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [Password]) VALUES (1, N'yagya', N'123')
INSERT [dbo].[User] ([Id], [UserName], [Password]) VALUES (2, N'tapesh', N'123')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK_District_State] FOREIGN KEY([State_Id])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK_District_State]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Category] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Category]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_District] FOREIGN KEY([District_Id])
REFERENCES [dbo].[District] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_District]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Document_Source] FOREIGN KEY([Document_Source_Id])
REFERENCES [dbo].[Document_Source] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Document_Source]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Document_Type] FOREIGN KEY([Document_Type_Id])
REFERENCES [dbo].[Document_Type] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Document_Type]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Fiscal_Year] FOREIGN KEY([Fiscal_Year_Id])
REFERENCES [dbo].[Fiscal_Year] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Fiscal_Year]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Palika] FOREIGN KEY([Palika_Id])
REFERENCES [dbo].[Palika] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Palika]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_State] FOREIGN KEY([State_Id])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_State]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Sub_Category] FOREIGN KEY([Sub_Category_Id])
REFERENCES [dbo].[Sub_Category] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Sub_Category]
GO
ALTER TABLE [dbo].[Document_File]  WITH CHECK ADD  CONSTRAINT [FK_Document_File_Document] FOREIGN KEY([DocumentID])
REFERENCES [dbo].[Document] ([Id])
GO
ALTER TABLE [dbo].[Document_File] CHECK CONSTRAINT [FK_Document_File_Document]
GO
ALTER TABLE [dbo].[Palika]  WITH CHECK ADD  CONSTRAINT [FK_Palika_District] FOREIGN KEY([District_Id])
REFERENCES [dbo].[District] ([Id])
GO
ALTER TABLE [dbo].[Palika] CHECK CONSTRAINT [FK_Palika_District]
GO
ALTER TABLE [dbo].[Sub_Category]  WITH CHECK ADD  CONSTRAINT [FK_Sub_Category_Category] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Sub_Category] CHECK CONSTRAINT [FK_Sub_Category_Category]
GO
USE [master]
GO
ALTER DATABASE [DLMSDatabase] SET  READ_WRITE 
GO
