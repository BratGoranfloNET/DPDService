USE [DPDSibur]
GO

/****** Object:  Table [dbo].[StateParcelsUnited]  ******/
IF (OBJECT_ID('[dbo].[StateParcelsUnited]') IS NOT NULL)
 DROP TABLE [dbo].[StateParcelsUnited]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StateParcelsUnited](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,		
	[UTCCreation] [datetime2](7) NOT NULL,	
	[UTCUpdate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](300) NULL,	
	[docId] [bigint] NULL,
    [docDate] [datetime2](7)  NULL,
    [clientNumber] [bigint] NULL,
    [resultComplete] [bit] NULL
		
	
	
 CONSTRAINT [PK_StateParcelsUnited] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





ALTER TABLE [dbo].[StateParcelsUnited] ADD  CONSTRAINT [DF_StateParcelsUnited_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


ALTER TABLE [dbo].[StateParcelsUnited] ADD  CONSTRAINT [DF_StateParcelsUnited_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[StateParcelsUnited] ADD  CONSTRAINT [DF_StateParcelsUnited_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO







--ALTER TABLE [dbo].[StateParcelsUnited]  WITH CHECK ADD  CONSTRAINT [FK_StateParcelsUnited_StateParcelsUnited] FOREIGN KEY([ParentId])
--REFERENCES [dbo].[StateParcelsUnited] ([Id])
--GO

--ALTER TABLE [dbo].[StateParcelsUnited] CHECK CONSTRAINT [FK_StateParcelsUnited_StateParcelsUnited]
--GO



/****** Object:  StoredProcedure [dbo].[StateParcelsUnitedInsert]   ******/
IF (OBJECT_ID('[dbo].[StateParcelsUnitedInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateParcelsUnitedInsert]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StateParcelsUnitedInsert]

	
	@Name nvarchar(300) = null,		
	@docId bigint,
    @docDate  datetime2(7),
    @clientNumber bigint,
    @resultComplete bit,
	
	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [StateParcelsUnited]
		(
	
		[Name],		
		[docId],
		[docDate],
		[clientNumber],
		[resultComplete]		

		)
		VALUES
		(

		@Name,	
		@docId,
		@docDate,
		@clientNumber,
		@resultComplete	

		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO


/****** Object:  StoredProcedure [dbo].[StateParcelsUnitedSelect]  ******/

IF (OBJECT_ID('[dbo].[StateParcelsUnitedSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateParcelsUnitedSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateParcelsUnitedSelect]

	@Id int = null,	
	@IsDeleted bit = null		

AS
BEGIN

	SELECT
		*
	FROM 
		StateParcelsUnited C
		--LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)		
		
	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END		
		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END
	ORDER BY
		C.Id DESC					
END
GO









/******  StoredProcedure [dbo].[StateParcelsUnitedUpdate]  ******/
IF (OBJECT_ID('[dbo].[StateParcelsUnitedUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateParcelsUnitedUpdate]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StateParcelsUnitedUpdate]

	@Id int,
	@Name nvarchar(300) = null,		
	@docId bigint,
	@docDate datetime2(7),
	@clientNumber bigint,
	@resultComplete bit, 

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		UPDATE
			[StateParcelsUnited]
		SET

	
    [Name]	 = @Name,		
	[docId] = @docId,
	[docDate] = @docDate,
	[clientNumber] = @clientNumber,
	[resultComplete] = @resultComplete	


		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO



/******  StoredProcedure [dbo].[StateParcelsUnitedDelete]   ******/
IF (OBJECT_ID('[dbo].[StateParcelsUnitedDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateParcelsUnitedDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateParcelsUnitedDelete]
	@Id int = null
AS
BEGIN
	UPDATE 
		[StateParcelsUnited] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id					
END
GO




IF (OBJECT_ID('[dbo].[StateParcelsUnitedDeleteAll]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateParcelsUnitedDeleteAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateParcelsUnitedDeleteAll]
	@Id int = null
AS
BEGIN
	DELETE FROM [StateParcelsUnited] 
					
END
GO
