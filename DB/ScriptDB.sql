USE [master]
GO
/****** Object:  Database [TestFinanzauto]    Script Date: 27/04/2024 6:16:05 p. m. ******/
CREATE DATABASE [TestFinanzauto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestFinanzauto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TestFinanzauto.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestFinanzauto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TestFinanzauto_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TestFinanzauto] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestFinanzauto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestFinanzauto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestFinanzauto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestFinanzauto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestFinanzauto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestFinanzauto] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestFinanzauto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestFinanzauto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestFinanzauto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestFinanzauto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestFinanzauto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestFinanzauto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestFinanzauto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestFinanzauto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestFinanzauto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestFinanzauto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestFinanzauto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestFinanzauto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestFinanzauto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestFinanzauto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestFinanzauto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestFinanzauto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestFinanzauto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestFinanzauto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestFinanzauto] SET  MULTI_USER 
GO
ALTER DATABASE [TestFinanzauto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestFinanzauto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestFinanzauto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestFinanzauto] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestFinanzauto] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TestFinanzauto] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TestFinanzauto] SET QUERY_STORE = OFF
GO
USE [TestFinanzauto]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 27/04/2024 6:16:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NameCourse] [varchar](50) NOT NULL,
	[Hourlyintensity] [tinyint] NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 27/04/2024 6:16:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CourseId] [bigint] NOT NULL,
	[StudentId] [bigint] NOT NULL,
	[TeacherId] [bigint] NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 27/04/2024 6:16:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Document] [varchar](11) NOT NULL,
	[Names] [varchar](100) NOT NULL,
	[Surname] [varchar](100) NOT NULL,
	[Phone] [varchar](12) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 27/04/2024 6:16:06 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Document] [varchar](11) NOT NULL,
	[Names] [varchar](100) NOT NULL,
	[Surname] [varchar](100) NOT NULL,
	[Phone] [varchar](12) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Courses] ADD  DEFAULT (getdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[Ratings] ADD  DEFAULT (getdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (getdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[Teachers] ADD  DEFAULT (getdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
USE [master]
GO
ALTER DATABASE [TestFinanzauto] SET  READ_WRITE 
GO
