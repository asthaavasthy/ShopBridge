USE [master]
GO
/****** Object:  Database [Product]    Script Date: 7/5/2021 11:08:55 AM ******/
CREATE DATABASE [Product]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Product', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Product.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Product_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Product_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Product] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Product].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Product] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Product] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Product] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Product] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Product] SET ARITHABORT OFF 
GO
ALTER DATABASE [Product] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Product] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Product] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Product] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Product] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Product] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Product] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Product] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Product] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Product] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Product] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Product] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Product] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Product] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Product] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Product] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Product] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Product] SET RECOVERY FULL 
GO
ALTER DATABASE [Product] SET  MULTI_USER 
GO
ALTER DATABASE [Product] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Product] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Product] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Product] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Product] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Product', N'ON'
GO
USE [Product]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/5/2021 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Item]    Script Date: 7/5/2021 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 7/5/2021 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 7/5/2021 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unique_user] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserContext]    Script Date: 7/5/2021 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserContext](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserContext] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_Item_UserId]    Script Date: 7/5/2021 11:08:55 AM ******/
CREATE NONCLUSTERED INDEX [IX_Item_UserId] ON [dbo].[User]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_RoleId]    Script Date: 7/5/2021 11:08:55 AM ******/
CREATE NONCLUSTERED INDEX [IX_User_RoleId] ON [dbo].[User]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_User_UserId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Roles_RoleId]
GO
/****** Object:  StoredProcedure [dbo].[GetAllItems]    Script Date: 7/5/2021 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAllItems]
(
@User_ID int

)
AS
BEGIN  
    SET NOCOUNT ON;  
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	SELECT * from Item Where UserId = @User_ID
	END

GO
/****** Object:  StoredProcedure [dbo].[pAddItem]    Script Date: 7/5/2021 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[pAddItem]
(
@User_ID int,
@Name nvarchar(max),
@Description nvarchar(max),
@Price nvarchar(max)
)
AS
BEGIN  
     
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	 Insert Into  Item
	 Values(@Name,@Description,@Price,@User_ID)
	END

GO
/****** Object:  StoredProcedure [dbo].[pDeleteItem]    Script Date: 7/5/2021 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[pDeleteItem]
(
@User_ID int,
@Item_ID int
)
AS
BEGIN  
    IF EXISTS(Select 1 from item where USERID = @User_ID AND ID = @Item_ID)
	DELETE FROM item where USERID = @User_ID AND ID = @Item_ID
	END

GO
/****** Object:  StoredProcedure [dbo].[pGetUserDetailsByUserName]    Script Date: 7/5/2021 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[pGetUserDetailsByUserName]
(
@UserName nvarchar(50)

)
AS
BEGIN  
    SET NOCOUNT ON;  
    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
	SELECT UserId,UserName,U.RoleId,RoleName from [User] U
	join Roles R
	on r.RoleId = U.UserId
	Where UserName = @UserName
	END

GO
/****** Object:  StoredProcedure [dbo].[pUpdateItem]    Script Date: 7/5/2021 11:08:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[pUpdateItem]
(
@User_ID int,
@Item_ID int,
@Name nvarchar(max),
@Description nvarchar(max),
@Price nvarchar(max)
)
AS
BEGIN  
   
	UPDATE item 
	SET Name = @Name,
	Description = @Description,
	Price = @Price,
	UserId = @User_ID
	where  ID = @Item_ID
	END



	
GO
USE [master]
GO
ALTER DATABASE [Product] SET  READ_WRITE 
GO
