USE [master]
GO
/****** Object:  Database [Student_Management_System]    Script Date: 14-09-2020 15:24:38 ******/
CREATE DATABASE [Student_Management_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Student_Management_System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Student_Management_System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Student_Management_System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Student_Management_System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Student_Management_System] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Student_Management_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Student_Management_System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Student_Management_System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Student_Management_System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Student_Management_System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Student_Management_System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Student_Management_System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Student_Management_System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Student_Management_System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Student_Management_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Student_Management_System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Student_Management_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Student_Management_System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Student_Management_System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Student_Management_System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Student_Management_System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Student_Management_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Student_Management_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Student_Management_System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Student_Management_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Student_Management_System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Student_Management_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Student_Management_System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Student_Management_System] SET RECOVERY FULL 
GO
ALTER DATABASE [Student_Management_System] SET  MULTI_USER 
GO
ALTER DATABASE [Student_Management_System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Student_Management_System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Student_Management_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Student_Management_System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Student_Management_System] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Student_Management_System', N'ON'
GO
ALTER DATABASE [Student_Management_System] SET QUERY_STORE = OFF
GO
USE [Student_Management_System]
GO
/****** Object:  Table [dbo].[ClassDetails]    Script Date: 14-09-2020 15:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Class] [nvarchar](50) NULL,
 CONSTRAINT [PK_ClassDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentDetails]    Script Date: 14-09-2020 15:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Gender] [int] NULL,
	[BirthDate] [date] NULL,
	[Email] [nvarchar](200) NULL,
	[ContactNumber] [nvarchar](12) NULL,
	[Class] [int] NULL,
	[Address] [nvarchar](200) NULL,
	[Street] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[Country] [nvarchar](50) NULL,
	[PinCode] [int] NULL,
 CONSTRAINT [PK_StudentDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 14-09-2020 15:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserFlag] [nchar](10) NOT NULL,
 CONSTRAINT [PK_UserLogin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ClassDetails] ON 

INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (1, N'First')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (2, N'Second')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (3, N'Third')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (4, N'Fourth')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (5, N'Fifth')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (6, N'Sixth')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (7, N'Seventh')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (8, N'Eighth')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (9, N'Ninth')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (10, N'Tenth')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (11, N'Eleventh')
INSERT [dbo].[ClassDetails] ([Id], [Class]) VALUES (12, N'twelfth')
SET IDENTITY_INSERT [dbo].[ClassDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[UserLogin] ON 

INSERT [dbo].[UserLogin] ([ID], [UserName], [Password], [UserFlag]) VALUES (2, N'Admin', N'Admin@123', N'A         ')
SET IDENTITY_INSERT [dbo].[UserLogin] OFF
GO
ALTER TABLE [dbo].[StudentDetails]  WITH CHECK ADD  CONSTRAINT [FK_StudentDetails_ClassDetails] FOREIGN KEY([Class])
REFERENCES [dbo].[ClassDetails] ([Id])
GO
ALTER TABLE [dbo].[StudentDetails] CHECK CONSTRAINT [FK_StudentDetails_ClassDetails]
GO
/****** Object:  StoredProcedure [dbo].[usp_AddEditStudent]    Script Date: 14-09-2020 15:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_AddEditStudent]
	(  
		@Id nvarchar(50) = NULL,  
		@Name NVARCHAR(200) = NULL,  
		@Gender int = NULL,  
		@BirthDate date = NULL,  
		@Email NVARCHAR(200) = NULL,  
		@ContactNumber NVARCHAR(12) =NULL,
		@Class int =NULL,
		  @Address NVARCHAR(200) =NULL,
		  @Street NVARCHAR(100) =NULL,
		  @City NVARCHAR(100)=NULL,
		  @State NVARCHAR(100)=NULL,
		  @Country NVARCHAR(100)=NULL,
		  @PinCode int =NULL,
		@ActionType NVARCHAR(25)  
)  
AS
BEGIN
	

	SET NOCOUNT ON;
	

    IF @ActionType = 'SaveData'  
    BEGIN  
        IF NOT EXISTS (SELECT * FROM StudentDetails WHERE Id=@Id)  
        BEGIN  
            INSERT INTO StudentDetails (
    	[Name]
      ,[Gender]
      ,[BirthDate]
      ,[Email]
      ,[ContactNumber]
      ,[Class]
      ,[Address]
      ,[Street]
      ,[City]
      ,[State]
      ,[Country]
      ,[PinCode])  
            VALUES (
      @Name
      ,@Gender
      ,@BirthDate
      ,@Email
      ,@ContactNumber
      ,@Class
      ,@Address
      ,@Street
      ,@City
      ,@State
      ,@Country
      ,@PinCode)  

			INSERT INTO [UserLogin] ([UserName],[Password],[UserFlag])
			VALUES (TRIM(@Name),@Name+'@123','S')
        END  
        ELSE  
        BEGIN  
            UPDATE StudentDetails 
			SET 
			Name=@Name
			, Gender=@Gender
			,BirthDate=@BirthDate
			,Email=@Email
			,ContactNumber=@ContactNumber
			,Class=@Class
			,Address=@Address
			,Street=@Street
			,City=@City
			,State=@State
			,Country=@Country
			,PinCode=@PinCode
			WHERE Id=@Id  
        END  
    END  
    IF @ActionType = 'DeleteData'  
    BEGIN  
        DELETE StudentDetails WHERE Id=@Id  
    END  
    IF @ActionType = 'FetchData'  
    BEGIN  
        SELECT * FROM StudentDetails  
    END  
    IF @ActionType = 'FetchRecord'  
    BEGIN  
        SELECT * FROM StudentDetails   
        WHERE Id=@Id  
    END  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectClass]    Script Date: 14-09-2020 15:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_SelectClass] 

AS
BEGIN
	SET NOCOUNT ON;
	select 0 as 'Id', '--Select Class--' as Class
	Union
	SELECT Id as 'Id', Class as'Clas'
	from ClassDetails
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectGender]    Script Date: 14-09-2020 15:24:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_SelectGender] 

AS
BEGIN
	SET NOCOUNT ON;
	select 0 as 'Id', '--Select Gender--' as Gender
	Union
	SELECT 1 as 'Id', 'Male' as'Gender'
	Union
	SELECT 2 as 'Id', 'Female' as'Gender'

END
GO
USE [master]
GO
ALTER DATABASE [Student_Management_System] SET  READ_WRITE 
GO
