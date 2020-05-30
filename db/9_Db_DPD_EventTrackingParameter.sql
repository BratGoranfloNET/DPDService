USE [DPDSibur]
GO

/****** Object:  Table [dbo].[EventTrackingParameter]  ******/
IF (OBJECT_ID('[dbo].[EventTrackingParameter]') IS NOT NULL)
 DROP TABLE [dbo].[EventTrackingParameter]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventTrackingParameter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,		
	[UTCCreation] [datetime2](7) NOT NULL,	
	[UTCUpdate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](300) NULL,		

	[EventTrackingTypeId] [int] NOT NULL,	

    [paramName] [nvarchar](300) NULL,
    [valueString] [nvarchar](300) NULL,
    [valueDecimal] [decimal] NULL,
    [valueDecimalSpecified] [bit]  NULL,
    [valueDateTime]  [datetime2](7) NULL,	
    [valueDateTimeSpecified] [bit] NULL,
    [type]  [nvarchar](300) NULL
	
	
 CONSTRAINT [PK_EventTrackingParameter] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





ALTER TABLE [dbo].[EventTrackingParameter] ADD  CONSTRAINT [DF_EventTrackingParameter_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


ALTER TABLE [dbo].[EventTrackingParameter] ADD  CONSTRAINT [DF_EventTrackingParameter_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[EventTrackingParameter] ADD  CONSTRAINT [DF_EventTrackingParameter_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO




--ALTER TABLE [dbo].[EventTrackingParameter]  WITH CHECK ADD  CONSTRAINT [FK_EventTrackingParameter_EventTrackingParameter] FOREIGN KEY([ParentId])
--REFERENCES [dbo].[EventTrackingParameter] ([Id])
--GO

--ALTER TABLE [dbo].[EventTrackingParameter] CHECK CONSTRAINT [FK_EventTrackingParameter_EventTrackingParameter]
--GO



/****** Object:  StoredProcedure [dbo].[EventTrackingParameterInsert]   ******/
IF (OBJECT_ID('[dbo].[EventTrackingParameterInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingParameterInsert]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EventTrackingParameterInsert]

	
	@Name nvarchar(300) = null,	
	@EventTrackingTypeId int,	
    @paramName nvarchar(300),
    @valueString nvarchar(300),
    @valueDecimal decimal,
    @valueDecimalSpecified bit,
    @valueDateTime datetime2(7),	
    @valueDateTimeSpecified  bit,
    @type nvarchar(300),
	
	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [EventTrackingParameter]
		(
	
		[Name],		
		[EventTrackingTypeId],	
		[paramName],
		[valueString],
		[valueDecimal],
		[valueDecimalSpecified],
		[valueDateTime],	
		[valueDateTimeSpecified],
		[type]

		)
		VALUES
		(

		@Name,			
		@EventTrackingTypeId,	
		@paramName,
		@valueString,
		@valueDecimal,
		@valueDecimalSpecified,
		@valueDateTime,	
		@valueDateTimeSpecified,
		@type

		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO


/****** Object:  StoredProcedure [dbo].[EventTrackingParameterSelect]  ******/

IF (OBJECT_ID('[dbo].[EventTrackingParameterSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingParameterSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingParameterSelect]

	@Id int = null,	
	@IsDeleted bit = null		

AS
BEGIN

	SELECT
		*
	FROM 
		EventTrackingParameter C
		--LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)		
		
	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END		
		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END
	ORDER BY
		C.Id DESC					
END
GO









/******  StoredProcedure [dbo].[EventTrackingParameterUpdate]  ******/
IF (OBJECT_ID('[dbo].[EventTrackingParameterUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingParameterUpdate]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EventTrackingParameterUpdate]

	@Id int,	
	
	@Name nvarchar(300) = null,	
	@EventTrackingTypeId int,	
    @paramName nvarchar(300),
    @valueString nvarchar(300),
    @valueDecimal decimal,
    @valueDecimalSpecified bit,
    @valueDateTime datetime2(7),	
    @valueDateTimeSpecified  bit,
    @type nvarchar(300),

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		UPDATE
			[EventTrackingParameter]
		SET
	
			[Name] = @Name,		
			[EventTrackingTypeId] = @EventTrackingTypeId,	
			[paramName] = @paramName,
			[valueString] = @valueString,
			[valueDecimal] = @valueDecimal,
			[valueDecimalSpecified] = @valueDecimalSpecified ,
			[valueDateTime]  = @valueDateTime,	
			[valueDateTimeSpecified] = @valueDateTimeSpecified,
			[type] = @type	
	

		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO



/******  StoredProcedure [dbo].[EventTrackingParameterDelete]   ******/
IF (OBJECT_ID('[dbo].[EventTrackingParameterDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingParameterDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingParameterDelete]
	@Id int = null
AS
BEGIN
	UPDATE 
		[EventTrackingParameter] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id					
END
GO




IF (OBJECT_ID('[dbo].[EventTrackingParameterDeleteAll]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingParameterDeleteAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingParameterDeleteAll]
	
AS
BEGIN

	DECLARE @local_time DATETIME;
	DECLARE @gmt_time DATETIME;
	DECLARE @last_week DATETIME;

	SET @local_time = GETDATE();
	SET @gmt_time   = GETUTCDATE();
	SET @last_week  = DATEADD(DAY,-7,@gmt_time)
	
	DELETE FROM
	 EventTrackingParameter  
	 WHERE UTCCreation <=  @last_week
	
END
GO




