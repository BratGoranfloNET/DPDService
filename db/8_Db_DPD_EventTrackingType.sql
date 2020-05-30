USE [DPDSibur]
GO

/****** Object:  Table [dbo].[EventTrackingType]  ******/
IF (OBJECT_ID('[dbo].[EventTrackingType]') IS NOT NULL)
 DROP TABLE [dbo].[EventTrackingType]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventTrackingType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,		
	[UTCCreation] [datetime2](7) NOT NULL,	
	[UTCUpdate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](300) NULL,
		
	[EventTrackingId] [int]  NOT NULL,  

    [clientOrderNr] [nvarchar](300) NULL,
    [clientCodeInternal] [nvarchar](300) NULL,
    [clientParcelNr] [nvarchar](300) NULL,
    [dpdOrderNr] [nvarchar](300) NULL,
    [dpdParcelNr] [nvarchar](300) NULL,
    [eventNumber] [nvarchar](300) NULL,
    [eventCode] [nvarchar](300) NULL,
    [eventName] [nvarchar](300) NULL,
    [reasonCode] [nvarchar](300) NULL,
    [reasonName] [nvarchar](300) NULL,
    [eventDate] [nvarchar](300) NULL

	
 CONSTRAINT [PK_EventTrackingType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





ALTER TABLE [dbo].[EventTrackingType] ADD  CONSTRAINT [DF_EventTrackingType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


ALTER TABLE [dbo].[EventTrackingType] ADD  CONSTRAINT [DF_EventTrackingType_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[EventTrackingType] ADD  CONSTRAINT [DF_EventTrackingType_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO







--ALTER TABLE [dbo].[EventTrackingType]  WITH CHECK ADD  CONSTRAINT [FK_EventTrackingType_EventTrackingType] FOREIGN KEY([ParentId])
--REFERENCES [dbo].[EventTrackingType] ([Id])
--GO

--ALTER TABLE [dbo].[EventTrackingType] CHECK CONSTRAINT [FK_EventTrackingType_EventTrackingType]
--GO



/****** Object:  StoredProcedure [dbo].[EventTrackingTypeInsert]   ******/
IF (OBJECT_ID('[dbo].[EventTrackingTypeInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingTypeInsert]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EventTrackingTypeInsert]

	
	@Name nvarchar(300) = null,
	@EventTrackingId int,  

    @clientOrderNr nvarchar(300),
    @clientCodeInternal nvarchar(300),
    @clientParcelNr nvarchar(300),
    @dpdOrderNr nvarchar(300),
    @dpdParcelNr nvarchar(300),
    @eventNumber nvarchar(300),
    @eventCode nvarchar(300),
    @eventName nvarchar(300),
    @reasonCode nvarchar(300),
    @reasonName nvarchar(300),
    @eventDate nvarchar(300),

	
	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [EventTrackingType]
		(
	
		[Name] ,
		[EventTrackingId],  
		
		[clientOrderNr] ,
		[clientCodeInternal] ,
		[clientParcelNr],
		[dpdOrderNr],
		[dpdParcelNr],
		[eventNumber] ,
		[eventCode] ,
		[eventName] ,
		[reasonCode] ,
		[reasonName] ,
		[eventDate]

		)
		VALUES
		(
		
		@Name,
		@EventTrackingId,  		
		@clientOrderNr,
		@clientCodeInternal,
		@clientParcelNr,
		@dpdOrderNr,
		@dpdParcelNr,
		@eventNumber,
		@eventCode,
		@eventName,
		@reasonCode,
		@reasonName,
		@eventDate

		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO


/****** Object:  StoredProcedure [dbo].[EventTrackingTypeSelect]  ******/

IF (OBJECT_ID('[dbo].[EventTrackingTypeSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingTypeSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingTypeSelect]

	@Id int = null,	
	@IsDeleted bit = null		

AS
BEGIN

	SELECT
		*
	FROM 
		EventTrackingType C
		--LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)		
		
	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END		
		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END
	ORDER BY
		C.Id DESC					
END
GO




/******  StoredProcedure [dbo].[EventTrackingTypeUpdate]  ******/
IF (OBJECT_ID('[dbo].[EventTrackingTypeUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingTypeUpdate]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EventTrackingTypeUpdate]

	@Id int,
	@Name nvarchar(300) = null,		
	@EventTrackingId nvarchar(300),
    @clientOrderNr nvarchar(300),
    @clientCodeInternal nvarchar(300),
    @clientParcelNr nvarchar(300),
    @dpdOrderNr nvarchar(300),
    @dpdParcelNr nvarchar(300),
    @eventNumber nvarchar(300),
    @eventCode nvarchar(300),
    @eventName nvarchar(300),
    @reasonCode nvarchar(300),
    @reasonName nvarchar(300),
    @eventDate nvarchar(300),

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		UPDATE
			[EventTrackingType]
		SET

	
    [Name]	 = @Name,	
	[EventTrackingId] = @EventTrackingId,
    [clientOrderNr] = @clientOrderNr,
    [clientCodeInternal] = @clientCodeInternal,
    [clientParcelNr] = @clientParcelNr,
    [dpdOrderNr] = @dpdOrderNr,
    [dpdParcelNr] = @dpdParcelNr,
	[eventNumber] = @eventNumber,  
	[eventCode] = @eventCode,
    [eventName] = @eventName, 
    [reasonCode] = @reasonCode,
    [reasonName] = @reasonName,
    [eventDate] = @eventDate
	
	WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO



/******  StoredProcedure [dbo].[EventTrackingTypeDelete]   ******/
IF (OBJECT_ID('[dbo].[EventTrackingTypeDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingTypeDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingTypeDelete]
	@Id int = null
AS
BEGIN
	UPDATE 
		[EventTrackingType] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id					
END
GO



IF (OBJECT_ID('[dbo].[EventTrackingTypeDeleteAll]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingTypeDeleteAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingTypeDeleteAll]
	
AS
BEGIN  

	DECLARE @local_time DATETIME;
	DECLARE @gmt_time DATETIME;
	DECLARE @last_week DATETIME;

	SET @local_time = GETDATE();
	SET @gmt_time = GETUTCDATE();
	SET @last_week = DATEADD(DAY,-7,@gmt_time)
	

	DELETE FROM
	 EventTrackingType  
	 WHERE UTCCreation <=  @last_week
				
END
GO