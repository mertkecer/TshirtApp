USE [master]
GO
/****** Object:  Database [TshirtApp]    Script Date: 3/13/2022 11:41:38 AM ******/
CREATE DATABASE [TshirtApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TshirtApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TshirtApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TshirtApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TshirtApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TshirtApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TshirtApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TshirtApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TshirtApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TshirtApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TshirtApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TshirtApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [TshirtApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TshirtApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TshirtApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TshirtApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TshirtApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TshirtApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TshirtApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TshirtApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TshirtApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TshirtApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TshirtApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TshirtApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TshirtApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TshirtApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TshirtApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TshirtApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TshirtApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TshirtApp] SET RECOVERY FULL 
GO
ALTER DATABASE [TshirtApp] SET  MULTI_USER 
GO
ALTER DATABASE [TshirtApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TshirtApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TshirtApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TshirtApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TshirtApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TshirtApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TshirtApp', N'ON'
GO
ALTER DATABASE [TshirtApp] SET QUERY_STORE = OFF
GO
USE [TshirtApp]
GO
/****** Object:  Table [dbo].[enmColors]    Script Date: 3/13/2022 11:41:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[enmColors](
	[Id] [int] NOT NULL,
	[Value] [varchar](50) NULL,
 CONSTRAINT [PK_enmColors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[enmFabrics]    Script Date: 3/13/2022 11:41:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[enmFabrics](
	[Id] [int] NOT NULL,
	[Value] [varchar](50) NULL,
 CONSTRAINT [PK_enmFabrics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tshirt]    Script Date: 3/13/2022 11:41:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tshirt](
	[Id] [int] NOT NULL,
	[Name] [varchar](300) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TshirtImages]    Script Date: 3/13/2022 11:41:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TshirtImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TshirtId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[FabricId] [int] NOT NULL,
	[ImagePath] [varchar](500) NULL,
 CONSTRAINT [PK_TshirtImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[enmColors] ([Id], [Value]) VALUES (1, N'White')
INSERT [dbo].[enmColors] ([Id], [Value]) VALUES (2, N'Yellow')
INSERT [dbo].[enmColors] ([Id], [Value]) VALUES (3, N'Green')
GO
INSERT [dbo].[enmFabrics] ([Id], [Value]) VALUES (1, N'Cotton')
INSERT [dbo].[enmFabrics] ([Id], [Value]) VALUES (2, N'Linen')
INSERT [dbo].[enmFabrics] ([Id], [Value]) VALUES (3, N'Silk')
GO
INSERT [dbo].[Tshirt] ([Id], [Name]) VALUES (1, N'Skeleton t-shirt')
INSERT [dbo].[Tshirt] ([Id], [Name]) VALUES (2, N'Unicorn t-shirt')
INSERT [dbo].[Tshirt] ([Id], [Name]) VALUES (3, N'Star wars t-shirt')
GO
SET IDENTITY_INSERT [dbo].[TshirtImages] ON 

INSERT [dbo].[TshirtImages] ([Id], [TshirtId], [ColorId], [FabricId], [ImagePath]) VALUES (44, 1, 2, 1, N'Images/yellowtshirt.jpg_3a1d248e-5566-44ba-ab17-483e5fc4a6e6.jpg')
INSERT [dbo].[TshirtImages] ([Id], [TshirtId], [ColorId], [FabricId], [ImagePath]) VALUES (45, 1, 2, 2, N'Images/yellowtshirt.jpg_c74481c8-fec1-4be1-89c3-2a1d994cd5ef.jpg')
INSERT [dbo].[TshirtImages] ([Id], [TshirtId], [ColorId], [FabricId], [ImagePath]) VALUES (46, 1, 2, 3, N'Images/yellowtshirt.jpg_76a32467-88d2-4806-b499-12b48f699f28.jpg')
INSERT [dbo].[TshirtImages] ([Id], [TshirtId], [ColorId], [FabricId], [ImagePath]) VALUES (61, 1, 1, 1, N'Images/white-t-shirt.jpg_36dbd4c3-4735-45b3-b183-f2ed70db4da5.jpg')
INSERT [dbo].[TshirtImages] ([Id], [TshirtId], [ColorId], [FabricId], [ImagePath]) VALUES (64, 1, 1, 1, N'Images/white-t-shirt.jpg_68b2afe1-0d28-4712-b5bb-5269bb7a2d67.jpg')
INSERT [dbo].[TshirtImages] ([Id], [TshirtId], [ColorId], [FabricId], [ImagePath]) VALUES (70, 1, 3, 1, N'Images/greentshirt.jpg_dfd91f5e-4a1d-4d8a-9e7c-ce134e30e81f.jpg')
INSERT [dbo].[TshirtImages] ([Id], [TshirtId], [ColorId], [FabricId], [ImagePath]) VALUES (72, 1, 3, 2, N'Images/greentshirt.jpg_0953317c-0abd-4949-9530-3f57838304a1.jpg')
INSERT [dbo].[TshirtImages] ([Id], [TshirtId], [ColorId], [FabricId], [ImagePath]) VALUES (73, 1, 3, 3, N'Images/greentshirt.jpg_2dd4103d-5768-432f-936a-2e0010178ed6.jpg')
INSERT [dbo].[TshirtImages] ([Id], [TshirtId], [ColorId], [FabricId], [ImagePath]) VALUES (74, 1, 3, 2, N'Images/greentshirt.jpg_1eeff5dd-4934-4079-b17d-593a9f1cb121.jpg')
SET IDENTITY_INSERT [dbo].[TshirtImages] OFF
GO
ALTER TABLE [dbo].[TshirtImages]  WITH CHECK ADD  CONSTRAINT [FK_TshirtImages_enmColors] FOREIGN KEY([ColorId])
REFERENCES [dbo].[enmColors] ([Id])
GO
ALTER TABLE [dbo].[TshirtImages] CHECK CONSTRAINT [FK_TshirtImages_enmColors]
GO
ALTER TABLE [dbo].[TshirtImages]  WITH CHECK ADD  CONSTRAINT [FK_TshirtImages_enmFabrics] FOREIGN KEY([FabricId])
REFERENCES [dbo].[enmFabrics] ([Id])
GO
ALTER TABLE [dbo].[TshirtImages] CHECK CONSTRAINT [FK_TshirtImages_enmFabrics]
GO
ALTER TABLE [dbo].[TshirtImages]  WITH CHECK ADD  CONSTRAINT [FK_TshirtImages_Tshirt] FOREIGN KEY([TshirtId])
REFERENCES [dbo].[Tshirt] ([Id])
GO
ALTER TABLE [dbo].[TshirtImages] CHECK CONSTRAINT [FK_TshirtImages_Tshirt]
GO
USE [master]
GO
ALTER DATABASE [TshirtApp] SET  READ_WRITE 
GO
