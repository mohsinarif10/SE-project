USE [master]
GO
/****** Object:  Database [Library_system]    Script Date: 1/19/2021 2:32:45 PM ******/
CREATE DATABASE [Library_system]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library_system', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Library_system.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Library_system_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Library_system_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Library_system] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library_system].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library_system] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library_system] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library_system] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library_system] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library_system] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library_system] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Library_system] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Library_system] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library_system] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library_system] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library_system] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library_system] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library_system] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library_system] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library_system] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library_system] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Library_system] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library_system] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library_system] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library_system] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library_system] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library_system] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library_system] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library_system] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Library_system] SET  MULTI_USER 
GO
ALTER DATABASE [Library_system] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library_system] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library_system] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library_system] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Library_system]
GO
/****** Object:  Table [dbo].[tbl_admin]    Script Date: 1/19/2021 2:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_admin](
	[admin_id] [int] IDENTITY(401,1) NOT NULL,
	[admin_password] [varchar](50) NOT NULL,
	[admin_username] [varchar](50) NOT NULL,
	[ImagePath] [varchar](max) NOT NULL,
	[admin_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_admin] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_tbl_admin] UNIQUE NONCLUSTERED 
(
	[admin_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_librarian]    Script Date: 1/19/2021 2:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_librarian](
	[lib_id] [int] IDENTITY(200,1) NOT NULL,
	[lib_username] [varchar](50) NOT NULL,
	[lib_password] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phonenumber] [varchar](50) NOT NULL,
	[NIC] [varchar](50) NOT NULL,
	[ImagePath] [varchar](max) NOT NULL,
	[repeat_password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_librarian] PRIMARY KEY CLUSTERED 
(
	[lib_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblBooksCategory]    Script Date: 1/19/2021 2:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblBooksCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblBooksMembers]    Script Date: 1/19/2021 2:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblBooksMembers](
	[registrationID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[IssuedDate] [varchar](50) NOT NULL,
	[ExpiryDate] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblBooksMembers] PRIMARY KEY CLUSTERED 
(
	[registrationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLogin]    Script Date: 1/19/2021 2:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLogin](
	[Loginid] [int] IDENTITY(9763,1) NOT NULL,
	[memberID] [int] NULL,
	[lib_id] [int] NULL,
	[admin_id] [int] NULL,
	[log_pasword] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblLogin_1] PRIMARY KEY CLUSTERED 
(
	[Loginid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNewBooks_registration]    Script Date: 1/19/2021 2:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNewBooks_registration](
	[BookID] [int] IDENTITY(103,1) NOT NULL,
	[BookName] [varchar](50) NOT NULL,
	[BookAuthor] [varchar](50) NOT NULL,
	[BookPublisher] [varchar](50) NOT NULL,
	[BookPrice] [varchar](50) NOT NULL,
	[BookCategory] [int] NOT NULL,
	[ImagePath] [varchar](max) NOT NULL,
 CONSTRAINT [PK_NewBooks_registration] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNewMembers_registration]    Script Date: 1/19/2021 2:32:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNewMembers_registration](
	[memberID] [int] IDENTITY(101,1) NOT NULL,
	[member_username] [varchar](50) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[Phonenumber] [varchar](50) NOT NULL,
	[NIC] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Date_of_birth] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[member_Password] [varchar](50) NOT NULL,
	[RepeatPassword] [varchar](50) NOT NULL,
	[ImagePath] [varchar](max) NOT NULL,
 CONSTRAINT [PK_tblNewMembers_registration_1] PRIMARY KEY CLUSTERED 
(
	[memberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_tblNewMembers_registration] UNIQUE NONCLUSTERED 
(
	[member_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblBooksMembers]  WITH CHECK ADD  CONSTRAINT [FK_tblBooksMembers_tblNewBooks_registration] FOREIGN KEY([BookID])
REFERENCES [dbo].[tblNewBooks_registration] ([BookID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblBooksMembers] CHECK CONSTRAINT [FK_tblBooksMembers_tblNewBooks_registration]
GO
ALTER TABLE [dbo].[tblBooksMembers]  WITH CHECK ADD  CONSTRAINT [FK_tblBooksMembers_tblNewMembers_registration] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tblNewMembers_registration] ([memberID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblBooksMembers] CHECK CONSTRAINT [FK_tblBooksMembers_tblNewMembers_registration]
GO
ALTER TABLE [dbo].[tblLogin]  WITH CHECK ADD  CONSTRAINT [FK_tblLogin_tbl_admin] FOREIGN KEY([admin_id])
REFERENCES [dbo].[tbl_admin] ([admin_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblLogin] CHECK CONSTRAINT [FK_tblLogin_tbl_admin]
GO
ALTER TABLE [dbo].[tblLogin]  WITH CHECK ADD  CONSTRAINT [FK_tblLogin_tbl_librarian] FOREIGN KEY([lib_id])
REFERENCES [dbo].[tbl_librarian] ([lib_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblLogin] CHECK CONSTRAINT [FK_tblLogin_tbl_librarian]
GO
ALTER TABLE [dbo].[tblLogin]  WITH CHECK ADD  CONSTRAINT [FK_tblLogin_tblNewMembers_registration] FOREIGN KEY([memberID])
REFERENCES [dbo].[tblNewMembers_registration] ([memberID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblLogin] CHECK CONSTRAINT [FK_tblLogin_tblNewMembers_registration]
GO
ALTER TABLE [dbo].[tblNewBooks_registration]  WITH CHECK ADD  CONSTRAINT [FK_tblNewBooks_registration_tblBooksCategory] FOREIGN KEY([BookCategory])
REFERENCES [dbo].[tblBooksCategory] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblNewBooks_registration] CHECK CONSTRAINT [FK_tblNewBooks_registration_tblBooksCategory]
GO
USE [master]
GO
ALTER DATABASE [Library_system] SET  READ_WRITE 
GO
