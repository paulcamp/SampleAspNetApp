IF  EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[UserDetails]') AND type in (N'U'))
BEGIN
	PRINT 'Table already exists. So, dropping it'
	DROP TABLE [dbo].[UserDetails]
END

CREATE TABLE [dbo].[UserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NULL,
	[Surname] [nvarchar](255) NULL,
	[Email] [varchar](320) NOT NULL,
	[PasswordHash] [varchar](255) NOT NULL
) ON [PRIMARY]
GO

IF (SELECT OBJECT_ID('dbo.InsertUser','P')) IS NOT NULL 
	BEGIN
		PRINT 'Procedure already exists. So, dropping it'
		DROP PROC [dbo].[InsertUser]
	END
GO

CREATE PROCEDURE [dbo].[InsertUser]
	@FirstName NVARCHAR(255),
	@Surname NVARCHAR(255),
	@Email VARCHAR(320),
	@PasswordHash VARCHAR(255)
AS
BEGIN
	INSERT INTO [dbo].[UserDetails] VALUES (@FirstName,	@Surname, @Email, @PasswordHash)
END
GO


IF (SELECT OBJECT_ID('dbo.DoesEmailAddressExist','P')) IS NOT NULL 
	BEGIN
		PRINT 'Procedure already exists. So, dropping it'
		DROP PROC [dbo].[DoesEmailAddressExist]
	END
GO

CREATE PROCEDURE [dbo].[DoesEmailAddressExist]
	@Email VARCHAR(320)
AS
BEGIN
	IF EXISTS
	(
		SELECT NULL 
		FROM [UserDetails]
		WHERE [Email] = @Email
	)
		SELECT 1
	ELSE
		SELECT 0
END
GO