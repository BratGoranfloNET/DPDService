USE [DPDSibur]
GO

/****** Object:  Table [dbo].[StateParcels]  ******/
IF (OBJECT_ID('[dbo].[StateParcels]') IS NOT NULL)
 DROP TABLE [dbo].[StateParcels]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StateParcels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,		
	[UTCCreation] [datetime2](7) NOT NULL,	
	[UTCUpdate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](300) NULL,	
	[docId] [bigint] NULL,
    [docDate] [datetime2](7)  NULL,
    [clientNumber] [bigint] NULL,
    [resultComplete] [bit] NULL
		
	
	
 CONSTRAINT [PK_StateParcels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





ALTER TABLE [dbo].[StateParcels] ADD  CONSTRAINT [DF_StateParcels_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


ALTER TABLE [dbo].[StateParcels] ADD  CONSTRAINT [DF_StateParcels_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[StateParcels] ADD  CONSTRAINT [DF_StateParcels_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO







--ALTER TABLE [dbo].[StateParcels]  WITH CHECK ADD  CONSTRAINT [FK_StateParcels_StateParcels] FOREIGN KEY([ParentId])
--REFERENCES [dbo].[StateParcels] ([Id])
--GO

--ALTER TABLE [dbo].[StateParcels] CHECK CONSTRAINT [FK_StateParcels_StateParcels]
--GO



/****** Object:  StoredProcedure [dbo].[StateParcelsInsert]   ******/
IF (OBJECT_ID('[dbo].[StateParcelsInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateParcelsInsert]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StateParcelsInsert]

	
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

		INSERT INTO [StateParcels]
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


/****** Object:  StoredProcedure [dbo].[StateParcelsSelect]  ******/

IF (OBJECT_ID('[dbo].[StateParcelsSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateParcelsSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateParcelsSelect]

	@Id int = null,	
	@IsDeleted bit = null		

AS
BEGIN

	SELECT
		*
	FROM 
		StateParcels C
		--LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)		
		
	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END		
		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END
	ORDER BY
		C.Id DESC					
END
GO









/******  StoredProcedure [dbo].[StateParcelsUpdate]  ******/
IF (OBJECT_ID('[dbo].[StateParcelsUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateParcelsUpdate]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StateParcelsUpdate]

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
			[StateParcels]
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



/******  StoredProcedure [dbo].[StateParcelsDelete]   ******/
IF (OBJECT_ID('[dbo].[StateParcelsDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateParcelsDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateParcelsDelete]
	@Id int = null
AS
BEGIN
	UPDATE 
		[StateParcels] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id					
END
GO




IF (OBJECT_ID('[dbo].[StateParcelsDeleteAll]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateParcelsDeleteAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateParcelsDeleteAll]
	@Id int = null
AS
BEGIN
	DELETE FROM [StateParcels] 
					
END
GO
