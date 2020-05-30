USE [DPDSibur]
GO



/****** Object:  Table [dbo].[EventImages]  ******/
IF (OBJECT_ID('[dbo].[EventImages]') IS NOT NULL)
 DROP TABLE [dbo].[EventImages]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventImages](
	[EventId] [int] NOT NULL,
	[ImageBlobId] [uniqueidentifier] NOT NULL,
	[OrderIndex] [int] NOT NULL,
	[Label] [nvarchar](75) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_EventImages] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[ImageBlobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



/****** Object:  Table [dbo].[Events]  ******/
IF (OBJECT_ID('[dbo].[Events]') IS NOT NULL)
 DROP TABLE [dbo].[Events]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[UTCCreation] [datetime2](7) NOT NULL,
	[Name] [nvarchar](175) NOT NULL,
	[Color] [varchar](25) NOT NULL,
	[StartDate] [datetimeoffset](7) NOT NULL,
	[EndDate] [datetimeoffset](7) NULL,
	[LocationId] [int] NULL,
	[Description] [nvarchar](max) NULL,
	--[ProductionId] [int] NULL,
	[EventTypeId] [int] NULL,
	[Fio] [nvarchar](175) NULL,
	[StateUnitedId] [int] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO






ALTER TABLE [dbo].[EventImages] ADD  CONSTRAINT [DF_EventImages_DisplayOrder]  DEFAULT ((0)) FOR [OrderIndex]
GO
ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Events_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Events_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO



ALTER TABLE [dbo].[EventImages]  WITH CHECK ADD  CONSTRAINT [FK_EventImages_Blobs] FOREIGN KEY([ImageBlobId])
REFERENCES [dbo].[Blobs] ([Id])
GO
ALTER TABLE [dbo].[EventImages] CHECK CONSTRAINT [FK_EventImages_Blobs]
GO
ALTER TABLE [dbo].[EventImages]  WITH CHECK ADD  CONSTRAINT [FK_EventImages_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([Id])
GO
ALTER TABLE [dbo].[EventImages] CHECK CONSTRAINT [FK_EventImages_Events]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Locations] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Locations]
GO















/****** Object:  StoredProcedure [dbo].[EventImagesCleanup]   ******/
IF (OBJECT_ID('[dbo].[EventImagesCleanup]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventImagesCleanup]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventImagesCleanup]

	@EventId int

AS
BEGIN

	DELETE FROM
		[EventImages]
	WHERE
		EventId = @EventId
					
END


GO
/****** Object:  StoredProcedure [dbo].[EventImagesInsert]   ******/
IF (OBJECT_ID('[dbo].[EventImagesInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventImagesInsert]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventImagesInsert]

	@EventId int,
	@ImageBlobId uniqueidentifier,
	@OrderIndex int,
	@Label nvarchar(75),
	@Description nvarchar(max),

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		-- INSERT ENTITY

		INSERT INTO [EventImages]
		(
			[EventId],
			[ImageBlobId],
			[OrderIndex],
			[Label],
			[Description]
		) 
		VALUES
		(
			@EventId, 
			@ImageBlobId,
			@OrderIndex,
			@Label,
			@Description
		)

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE();
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[EventsDelete]   ******/
IF (OBJECT_ID('[dbo].[EventsDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventsDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventsDelete]

	@Id int = null

AS
BEGIN

	UPDATE 
		[Events] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id
					
END


GO
/****** Object:  StoredProcedure [dbo].[EventsInsert]   ******/
IF (OBJECT_ID('[dbo].[EventsInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventsInsert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventsInsert]

	@Name nvarchar(175),
	@Color varchar(25),
	@StartDate datetimeoffset(7),
	@EndDate datetimeoffset(7) = null,
	@LocationId int = null,
	@Description nvarchar(max) = null,
	-- @ProductionId int = null,
	@EventTypeId int = null,
	@Fio nvarchar(175),
	@StateUnitedId int = null,
	

	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [Events]
		(
			[Name],
			[Color],
			[StartDate],
			[EndDate],
			[LocationId],
			[Description],
			--[ProductionId],
			[EventTypeId],
			[Fio],
			[StateUnitedId]
		)
		VALUES
		(
			@Name,
			@Color,
			@StartDate,
			@EndDate,
			@LocationId,
			@Description,
			-- @ProductionId,
			@EventTypeId,
			@Fio,
			@StateUnitedId
		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[EventsSearch]   ******/
IF (OBJECT_ID('[dbo].[EventsSearch]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventsSearch]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventsSearch]

	@Query nvarchar(100)

AS
BEGIN

	-- Returns a multi result set with the events related data

	DECLARE @EventIds TABLE (EventId int)

	INSERT INTO @EventIds
		SELECT
			S.Id
		FROM 
			[dbo].[DataSearchView] S
			INNER JOIN [dbo].[Events] E ON (E.Id = S.Id)
		WHERE 
			E.[IsDeleted] = 0
			AND [S].[Type] = 3
			AND [S].[SearchData] LIKE '%' + @Query + '%'

	-- Events query
	SELECT
		*
	FROM
		[Events] E
		LEFT JOIN [Locations] L ON (L.Id = E.LocationId)
	WHERE
		E.Id IN (SELECT EventId FROM @EventIds)
	ORDER BY
		E.Id

	-- Event Images query
	SELECT
		B.*,
		EI.EventId,
		EI.[Label],
		EI.[Description]
	FROM 
		[Blobs] B 
		INNER JOIN [EventImages] EI ON (B.Id = EI.ImageBlobId)
	WHERE 
		EI.[EventId] IN (SELECT EventId FROM @EventIds)
	ORDER BY 
		EI.EventId
					
END


GO


/****** Object:  StoredProcedure [dbo].[EventsSelect]   ******/
IF (OBJECT_ID('[dbo].[EventsSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventsSelect]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventsSelect]

	@Id int = null,
	@IsDeleted bit = null

AS
BEGIN

	-- Returns a multi result set with the events related data

	DECLARE @EventIds TABLE (EventId int)

	INSERT INTO @EventIds
		SELECT
			Id
		FROM 
			[Events] E
		WHERE 
			E.Id = CASE WHEN(@Id IS NULL) THEN E.Id ELSE @Id END
			AND E.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN E.IsDeleted ELSE @IsDeleted END

	-- Events query
	SELECT
		*
	FROM
		[Events] E
		LEFT JOIN [Locations] L ON (L.Id = E.LocationId)
		-- LEFT JOIN [Production] P ON (P.Id = E.ProductionId)
		LEFT JOIN [EventType] T ON (T.Id = E.EventTypeId)
	WHERE
		E.Id IN (SELECT EventId FROM @EventIds)
	ORDER BY
		E.Id

	-- Event Images query
	SELECT
		B.*,
		EI.EventId,
		EI.[Label],
		EI.[Description]
	FROM 
		[Blobs] B 
		INNER JOIN [EventImages] EI ON (B.Id = EI.ImageBlobId)
	WHERE 
		EI.[EventId] IN (SELECT EventId FROM @EventIds)
	ORDER BY 
		EI.OrderIndex
	
					
END


GO
/****** Object:  StoredProcedure [dbo].[EventsUpdate]  ******/
IF (OBJECT_ID('[dbo].[EventsUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventsUpdate]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventsUpdate]

	@Id int,
	@Name nvarchar(175),
	@Color varchar(25),
	@StartDate datetimeoffset(7),
	@EndDate datetimeoffset(7) = null,
	@LocationId int = null,
	@Description nvarchar(max) = null,
	-- @ProductionId int = null,
	@EventTypeId int = null,
	@Fio nvarchar(175),
	@StateUnitedId int = null,

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		UPDATE
			[Events]
		SET
			[Name] = @Name,
			[Color] = @Color,
			[StartDate] = @StartDate,
			[EndDate] = @EndDate,
			[LocationId] = @LocationId,
			[Description] = @Description,
			-- [ProductionId]  = @ProductionId,
			[EventTypeId] = @EventTypeId,
			[Fio] = @Fio,
			[StateUnitedId] = @StateUnitedId
		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO