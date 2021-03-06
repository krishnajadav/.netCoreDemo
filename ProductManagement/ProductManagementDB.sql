USE [master]
GO
/****** Object:  Database [ProductManagementDB]    Script Date: 6/7/2021 23:14:16 ******/
CREATE DATABASE [ProductManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProductManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProductManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProductManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProductManagementDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProductManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductManagementDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ProductManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProductManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProductManagementDB', N'ON'
GO
ALTER DATABASE [ProductManagementDB] SET QUERY_STORE = OFF
GO
USE [ProductManagementDB]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 6/7/2021 23:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Product_Category_ID] [int] NOT NULL,
	[Product_Category] [varchar](200) NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Product_Category_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/7/2021 23:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[Product_Name] [varchar](250) NOT NULL,
	[Product_SKU] [varchar](50) NOT NULL,
	[Product_Price] [decimal](10, 2) NOT NULL,
	[Product_Description] [varchar](max) NULL,
	[Is_Active] [bit] NOT NULL,
	[Created_Date] [datetime] NOT NULL,
	[Product_Category_ID] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ProductCategory] ([Product_Category_ID], [Product_Category]) VALUES (1, N'Electronics')
INSERT [dbo].[ProductCategory] ([Product_Category_ID], [Product_Category]) VALUES (2, N'Food')
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Product_ID], [Product_Name], [Product_SKU], [Product_Price], [Product_Description], [Is_Active], [Created_Date], [Product_Category_ID]) VALUES (3, N'Mobile', N'aadv', CAST(40.37 AS Decimal(10, 2)), N'ghjfghdfgdfgdfgdgf', 1, CAST(N'2021-06-07T20:18:02.677' AS DateTime), 2)
INSERT [dbo].[Products] ([Product_ID], [Product_Name], [Product_SKU], [Product_Price], [Product_Description], [Is_Active], [Created_Date], [Product_Category_ID]) VALUES (5, N'Biscuit', N'jjjpl', CAST(10.21 AS Decimal(10, 2)), N'ghfghgh', 0, CAST(N'2021-06-07T20:18:02.677' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategory] FOREIGN KEY([Product_Category_ID])
REFERENCES [dbo].[ProductCategory] ([Product_Category_ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategory]
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteProduct]    Script Date: 6/7/2021 23:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROCEDURE [dbo].[SP_DeleteProduct]
	@Product_ID int
	AS
BEGIN

DELETE FROM Products WHERE Product_ID=@Product_ID;

End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductCategory]    Script Date: 6/7/2021 23:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetProductCategory] 
AS
BEGIN

SELECT * FROM ProductCategory;

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProducts]    Script Date: 6/7/2021 23:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetProducts] 
AS
BEGIN

SELECT P.Product_ID,
P.Product_Name,
P.Product_Price,
P.Product_SKU,
P.Product_Description,
P.Is_Active,
P.Created_Date,
PC.Product_Category_ID,
PC.Product_Category 
FROM Products AS P INNER JOIN ProductCategory AS PC 
ON P.Product_Category_ID=PC.Product_Category_ID;

END
GO
/****** Object:  StoredProcedure [dbo].[SP_InUPProduct]    Script Date: 6/7/2021 23:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[SP_InUPProduct]
	@Product_ID int,
	@Product_Name   varchar(250),
	@Product_Price decimal(10,2),
	@Product_SKU varchar(50),
	@Product_Description varchar(max),
	@Is_Active bit,
	@Product_Category_ID int
	AS
BEGIN

    if exists (Select 1 from Products where Product_ID=@Product_ID)
    begin
		update Products set Product_Name=@Product_Name,Product_SKU=@Product_SKU,Product_Price=@Product_Price,Product_Description=@Product_Description,Is_Active=@Is_Active,Product_Category_ID=@Product_Category_ID where Product_ID=@Product_ID
    End
    Else
    Begin
		insert into Products(Product_Name,Product_SKU,Product_Price,Product_Description,Is_Active,Product_Category_ID,Created_Date)values(@Product_Name,@Product_SKU,@Product_Price,@Product_Description,@Is_Active,@Product_Category_ID,getdate())  --fire insert query
End


End
GO
USE [master]
GO
ALTER DATABASE [ProductManagementDB] SET  READ_WRITE 
GO
