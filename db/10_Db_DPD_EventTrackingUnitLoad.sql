USE [DPDSibur]
GO

/****** Object:  Table [dbo].[EventTrackingUnitLoad]  ******/
IF (OBJECT_ID('[dbo].[EventTrackingUnitLoad]') IS NOT NULL)
 DROP TABLE [dbo].[EventTrackingUnitLoad]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventTrackingUnitLoad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,		
	[UTCCreation] [datetime2](7) NOT NULL,	
	[UTCUpdate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](300) NULL,	
	
	[EventTrackingParameterId] [int] NOT NULL,
		
	[article] [nvarchar](300) NULL,
	[descript] [nvarchar](300) NULL,
	[declared_value] [nvarchar](300) NULL,
	[parcel_num] [nvarchar](300) NULL,
	[npp_amount]  [nvarchar](300) NULL,
	[vat_percent]  [int] NULL,
	[vat_percentSpecified] [bit] NULL,
	[without_vat] [bit] NULL,
	[without_vatSpecified] [bit] NULL,
	[countField] [int] NULL,
	[state_nameField] [nvarchar](300) NULL

	
 CONSTRAINT [PK_EventTrackingUnitLoad] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





ALTER TABLE [dbo].[EventTrackingUnitLoad] ADD  CONSTRAINT [DF_EventTrackingUnitLoad_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


ALTER TABLE [dbo].[EventTrackingUnitLoad] ADD  CONSTRAINT [DF_EventTrackingUnitLoad_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[EventTrackingUnitLoad] ADD  CONSTRAINT [DF_EventTrackingUnitLoad_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO







--ALTER TABLE [dbo].[EventTrackingUnitLoad]  WITH CHECK ADD  CONSTRAINT [FK_EventTrackingUnitLoad_EventTrackingUnitLoad] FOREIGN KEY([ParentId])
--REFERENCES [dbo].[EventTrackingUnitLoad] ([Id])
--GO

--ALTER TABLE [dbo].[EventTrackingUnitLoad] CHECK CONSTRAINT [FK_EventTrackingUnitLoad_EventTrackingUnitLoad]
--GO



/****** Object:  StoredProcedure [dbo].[EventTrackingUnitLoadInsert]   ******/
IF (OBJECT_ID('[dbo].[EventTrackingUnitLoadInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingUnitLoadInsert]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EventTrackingUnitLoadInsert]

	
	@Name nvarchar(300) = null,		
	@EventTrackingParameterId  int,		
	@article nvarchar(300),
	@descript nvarchar(300),
	@declared_value nvarchar(300),
	@parcel_num nvarchar(300),
	@npp_amount nvarchar(300),
	@vat_percent int,
	@vat_percentSpecified bit,
	@without_vat bit,
	@without_vatSpecified bit,
	@countField int,
	@state_nameField nvarchar(300),
	
	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [EventTrackingUnitLoad]
		(
	
		[Name],					
		[EventTrackingParameterId],		
		[article],
		[descript],
		[declared_value],
		[parcel_num],
		[npp_amount],
		[vat_percent],
		[vat_percentSpecified],
		[without_vat],
		[without_vatSpecified],
		[countField],
		[state_nameField]

		)
		VALUES
		(
					
		@Name,					
		@EventTrackingParameterId,		
		@article,
		@descript,
		@declared_value,
		@parcel_num,
		@npp_amount,
		@vat_percent,
		@vat_percentSpecified,
		@without_vat,
		@without_vatSpecified,
		@countField,
		@state_nameField

		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO


/****** Object:  StoredProcedure [dbo].[EventTrackingUnitLoadSelect]  ******/

IF (OBJECT_ID('[dbo].[EventTrackingUnitLoadSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingUnitLoadSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingUnitLoadSelect]

	@Id int = null,	
	@IsDeleted bit = null		

AS
BEGIN

	SELECT
		*
	FROM 
		EventTrackingUnitLoad C
		--LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)		
		
	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END		
		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END
	ORDER BY
		C.Id DESC					
END
GO









/******  StoredProcedure [dbo].[EventTrackingUnitLoadUpdate]  ******/
IF (OBJECT_ID('[dbo].[EventTrackingUnitLoadUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingUnitLoadUpdate]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EventTrackingUnitLoadUpdate]

	@Id int,	
	@Name nvarchar(300) = null,		
	@EventTrackingParameterId  int,		
	@article nvarchar(300),
	@descript nvarchar(300),
	@declared_value nvarchar(300),
	@parcel_num nvarchar(300),
	@npp_amount nvarchar(300),
	@vat_percent int,
	@vat_percentSpecified bit,
	@without_vat bit,
	@without_vatSpecified bit,
	@countField int,
	@state_nameField nvarchar(300),

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		UPDATE
			[EventTrackingUnitLoad]
		SET

	
    [Name]	 = @Name,		
	[EventTrackingParameterId] = @EventTrackingParameterId,		
	[article] = @article,
	[descript] = @descript,
	[declared_value] = @declared_value,
	[parcel_num] = @parcel_num,
	[npp_amount] = @npp_amount,
	[vat_percent] = @vat_percent,
	[vat_percentSpecified] = @vat_percentSpecified,
	[without_vat] = @without_vat,
	[without_vatSpecified] =  @without_vatSpecified,
	[countField] = @countField,
	[state_nameField] = @state_nameField


		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO



/******  StoredProcedure [dbo].[EventTrackingUnitLoadDelete]   ******/
IF (OBJECT_ID('[dbo].[EventTrackingUnitLoadDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingUnitLoadDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingUnitLoadDelete]
	@Id int = null
AS
BEGIN
	UPDATE 
		[EventTrackingUnitLoad] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id					
END
GO




IF (OBJECT_ID('[dbo].[EventTrackingUnitLoadDeleteAll]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTrackingUnitLoadDeleteAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTrackingUnitLoadDeleteAll]
	
AS
BEGIN
	DELETE FROM [EventTrackingUnitLoad] 
					
END
GO
