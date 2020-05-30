USE [DPDSibur]
GO

/****** Object:  Table [dbo].[EventTracking]  ******/
IF (OBJECT_ID('[dbo].[EventTracking]') IS NOT NULL)
 DROP TABLE [dbo].[EventTracking]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventTracking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,		
	[UTCCreation] [datetime2](7) NOT NULL,	
	[UTCUpdate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](300) NULL,		
	[docId] [bigint] NULL,
	[docDate] [datetime2](7)  NULL,
	[clientNumber] [bigint] NULL,
	[resultComplete] [bit] NULL	
	
 CONSTRAINT [PK_EventTracking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




ALTER TABLE [dbo].[EventTracking] ADD  CONSTRAINT [DF_EventTracking_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


ALTER TABLE [dbo].[EventTracking] ADD  CONSTRAINT [DF_EventTracking_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[EventTracking] ADD  CONSTRAINT [DF_EventTracking_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO







--ALTER TABLE [dbo].[EventTracking]  WITH CHECK ADD  CONSTRAINT [FK_EventTracking_EventTracking] FOREIGN KEY([ParentId])
--REFERENCES [dbo].[EventTracking] ([Id])
--GO

--ALTER TABLE [dbo].[EventTracking] CHECK CONSTRAINT [FK_EventTracking_EventTracking]
--GO



/****** Object:  StoredProcedure [dbo].[EventTrackingInsert]   ******/
IF (OBJECT_ID('[dbo].[EventTrackingInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingInsert]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EventTrackingInsert]

	
	@Name nvarchar(300) = null,		
	@docId bigint,
	@docDate datetime2,
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

		INSERT INTO [EventTracking]
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
		@docId ,
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


/****** Object:  StoredProcedure [dbo].[EventTrackingSelect]  ******/

IF (OBJECT_ID('[dbo].[EventTrackingSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingSelect]

	@Id int = null,	
	@IsDeleted bit = null		

AS
BEGIN

	SELECT
		*
	FROM 
		EventTracking C
		--LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)		
		
	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END		
		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END
	ORDER BY
		C.Id DESC					
END
GO









/******  StoredProcedure [dbo].[EventTrackingUpdate]  ******/
IF (OBJECT_ID('[dbo].[EventTrackingUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingUpdate]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EventTrackingUpdate]

	@Id int,
	@Name nvarchar(300) = null,		
	@docId bigint,
	@docDate datetime2,
	@clientNumber bigint,
	@resultComplete bit, 	

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		UPDATE
			[EventTracking]
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



/******  StoredProcedure [dbo].[EventTrackingDelete]   ******/
IF (OBJECT_ID('[dbo].[EventTrackingDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingDelete]
	@Id int = null
AS
BEGIN
	UPDATE 
		[EventTracking] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id					
END
GO



IF (OBJECT_ID('[dbo].[EventTrackingDeleteAll]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingDeleteAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingDeleteAll]
	--@Id int = null
AS
BEGIN
	DELETE FROM	[EventTracking] 
	
	--WHERE
	--	[Id] = @Id					
END
GO
