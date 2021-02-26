USE [master]
GO
/****** Object:  Database [CashierSystem]    Script Date: 2021-02-26 13:43:46 ******/
CREATE DATABASE [CashierSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CashierSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CashierSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CashierSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CashierSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CashierSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CashierSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CashierSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CashierSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CashierSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CashierSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CashierSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [CashierSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CashierSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CashierSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CashierSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CashierSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CashierSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CashierSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CashierSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CashierSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CashierSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CashierSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CashierSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CashierSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CashierSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CashierSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CashierSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CashierSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CashierSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [CashierSystem] SET  MULTI_USER 
GO
ALTER DATABASE [CashierSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CashierSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CashierSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CashierSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CashierSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CashierSystem', N'ON'
GO
ALTER DATABASE [CashierSystem] SET QUERY_STORE = OFF
GO
USE [CashierSystem]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 2021-02-26 13:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[Price] [float] NOT NULL,
	[Stock] [int] NOT NULL,
	[Image] [varchar](50) NULL,
	[SellerID] [int] NOT NULL,
	[Description] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2021-02-26 13:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [varchar](10) NOT NULL,
	[PIN] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [cs_unique] UNIQUE NONCLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD FOREIGN KEY([SellerID])
REFERENCES [dbo].[Users] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/****** Object:  StoredProcedure [dbo].[AddItem]    Script Date: 2021-02-26 13:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddItem]
-- Parameters
@Name Varchar(25),
@Stock Int,
@Price Float,
@SellerID Int,
-- Optional parameters
@Image Varchar(50) = null,
@Description Varchar(100) = null
as

-- Declare result variables
Declare @Result int = 0

BEGIN TRY
	-- If the seller has an item with the same name
	If Exists(Select * from Items where Name = @Name AND SellerID = @SellerID)
		BEGIN
			-- Return error code 'Row already exists'
			Select @Result = 1
		END
	-- Else...
	Else
		BEGIN
			-- Insert the item
			INSERT INTO Items("Name","Stock","Price","SellerID","Image","Description")
				values(@Name, @Stock, @Price, @SellerID, @Image, @Description)
		END
END TRY
BEGIN CATCH
	-- Set error code to 'SQL error'
	Select @Result = 100
END CATCH

-- Return the result
Select @Result as Result
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 2021-02-26 13:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[CreateUser]
-- Parameters
@PhoneNumber varchar(10),
@PIN int
as

Declare @Result int = 0
Declare @UserID int = -1

BEGIN TRY
	-- If the user already exists
	IF Exists(Select * from Users where PhoneNumber = @PhoneNumber)
		Begin
			-- Return error code 'Row already exists'
			Select @Result = 1
		End
	-- Else...
	Else
		Begin
			-- Add the user
			Insert into Users(PhoneNumber, PIN)
				values (@PhoneNumber, @PIN)
			select @UserID = UserID from Users where PhoneNumber = @PhoneNumber
		End
END TRY
BEGIN CATCH
	Select @Result = 100
END CATCH

-- Return the result
Select @Result as Result, @UserID as UserID

GO
/****** Object:  StoredProcedure [dbo].[GetMenu]    Script Date: 2021-02-26 13:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetMenu]
-- Input parameters
@SellerID int
As

BEGIN TRY
	-- Check if user exists
	If Exists(Select * from Users where UserID = @SellerID)
		BEGIN
			-- Select all itemd
			Select * from Items where SellerID = @SellerID
		END
END TRY
BEGIN CATCH
	-- Just return
	RETURN
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[LoginUser]    Script Date: 2021-02-26 13:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[LoginUser]
@PhoneNumber Varchar(10),
@PIN Int
As
-- Declare result variables
Declare @Result Int = 0
Declare @UserID int = -1

Begin Try
	-- If user with the provided phone number exists...
	If Exists(Select * from Users where Users.PhoneNumber = @PhoneNumber)
		Begin
			-- If the pin code does not match
			If NOT(Select PIN from Users where Users.PhoneNumber = @PhoneNumber) = @PIN
				BEGIN
					-- Set error code to 'Data mismatch'
					select @Result = 3					
				END
			Else
				BEGIN
					-- Set output user id to the id of the found user
					select @UserID = UserID from Users where PhoneNumber = @PhoneNumber
				End
		End
	Else
		Begin
			-- Set tatus code to 'Not found'
			select @Result = 2
		End
End Try

Begin Catch
	-- Set status to 'error'
	Select @Result = 100
End Catch

-- Return the result
Select @Result as Result, @UserID as UserID
GO
/****** Object:  StoredProcedure [dbo].[RemoveItem]    Script Date: 2021-02-26 13:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[RemoveItem]
-- Input parameters
@ItemID Int
As

-- Declare result variables
Declare @Result int = 0

-- Try to remove the specified item
BEGIN TRY

	-- If the item exist...
	If Exists(Select * from Items where ItemID = @ItemID)
		BEGIN
			-- Remove the item
			Delete from Items where ItemID = @ItemID
		END
	-- Else...
	ELSE
		BEGIN
			-- Set error code to 'Row not found'
			Select @Result = 2
		END
END TRY
-- If procedure failed
BEGIN CATCH
	-- Set error code to 'Sql Error'
	Select @Result = 100
END CATCH

-- Return result
select @Result as Result
GO
/****** Object:  StoredProcedure [dbo].[UpdateItem]    Script Date: 2021-02-26 13:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateItem]
-- Parameters
@ItemID Int       = null,
@Name Varchar(25) = null,
@Stock Int    = null,
@Price Float  = null,
@Image Varchar(50) = null,
@Description Varchar(100) = null
As

BEGIN TRY
	-- If the seller has an item with the same name
	If Exists(Select * from Items where ItemID = @ItemID)
		BEGIN
			-- Update each column based on the input value
			If @Name is not null BEGIN 
				Update Items Set "Name" = @Name where ItemID = @ItemID
				END
			If @Stock is not null BEGIN 
				Update Items Set "Stock" = @Stock where ItemID = @ItemID
			END
			If @Price is not null BEGIN 
				Update Items Set "Price" = @Price where ItemID = @ItemID
				END
			If @Image is not null BEGIN
				Update Items Set "Image" = @Image where ItemID = @ItemID
				END
			If @Description is not null BEGIN
				Update Items Set "Description" = @Description where ItemID = @ItemID
				END

			-- Return the modified item
			select * from Items where ItemID = @ItemID
		END
END TRY
BEGIN CATCH

END CATCH
-- Exit
Return
GO
USE [master]
GO
ALTER DATABASE [CashierSystem] SET  READ_WRITE 
GO
