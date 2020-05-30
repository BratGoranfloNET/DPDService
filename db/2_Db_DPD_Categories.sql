USE [DPDSibur]
GO

/****** Object:  Table [dbo].[Categories]  ******/
IF (OBJECT_ID('[dbo].[Categories]') IS NOT NULL)
 DROP TABLE [dbo].[Categories]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[ParentId] [int] NULL,
	[Level] [int] NULL,
	[UTCCreation] [datetime2](7) NOT NULL,	
	[UTCUpdate] [datetime2](7) NOT NULL,	
	[AddedBy] [nvarchar](256) NOT NULL,
	[Title] [nvarchar](256) NOT NULL,
	[Importance] [int] NOT NULL,
	[Description] [nvarchar](4000) NULL,
	[ImageBlobId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_Importance]  DEFAULT ((0)) FOR [Importance]
GO

ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO







ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Categories] ([Id])
GO

ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO





/****** Object:  StoredProcedure [dbo].[CategoryInsert]   ******/
IF (OBJECT_ID('[dbo].[CategoryInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[CategoryInsert]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CategoryInsert]

	@ParentId int,
	@Level int,	
	@AddedBy nvarchar(256),
	@Title nvarchar(256),	
	@Importance int = 0,
	@Description nvarchar(4000),
	@ImageBlobId uniqueidentifier = null,
	
	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [Categories]
		(
	[ParentId],
	[Level],	
	[AddedBy],
	[Title],	
	[Importance],
	[Description],
	[ImageBlobId]
		)
		VALUES
		(
	@ParentId,
	@Level,	
	@AddedBy,
	@Title,	
	@Importance,
	@Description,
	@ImageBlobId

		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO


/****** Object:  StoredProcedure [dbo].[CategorySelect]  ******/

IF (OBJECT_ID('[dbo].[CategorySelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[CategorySelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategorySelect]

	@Id int = null,	
	@IsDeleted bit = null		

AS
BEGIN

	SELECT
		*
	FROM 
		Categories C
		LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)		
		
	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END		
		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END
	ORDER BY
		C.Id DESC					
END
GO





/******  StoredProcedure [dbo].[CategoryParentsOnlySelect]   ******/
IF (OBJECT_ID('[dbo].[CategoryParentsOnlySelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[CategoryParentsOnlySelect]
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoryParentsOnlySelect]

	@Id int = null,
	@IsDeleted bit = null,
	@IsParent bit = null

AS
BEGIN

	SELECT
		*
	FROM 
		Categories C
		LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)
		--LEFT JOIN Contacts C ON (C.Id = L.ContactId)

	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END

		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END		

		AND  C.ParentId   IS NULL

	ORDER BY
		C.Id
					
END

GO


/****** StoredProcedure [dbo].[CategoryChildesOnlySelect]  ******/
IF (OBJECT_ID('[dbo].[CategoryChildesOnlySelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[CategoryChildesOnlySelect]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoryChildesOnlySelect]

	@Id int = null,
	@IsDeleted bit = null,
	@IsChild bit = null

AS
BEGIN

	SELECT
		*
	FROM 
		Categories C
		LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)
		--LEFT JOIN Contacts C ON (C.Id = L.ContactId)

	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END

		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END		

		AND  C.ParentId   IS NOT NULL

	ORDER BY
		C.Id
					
END

GO



/******  StoredProcedure [dbo].[CategoryUpdate]  ******/
IF (OBJECT_ID('[dbo].[CategoryUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[CategoryUpdate]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CategoryUpdate]

	@Id int,	
	@ParentId int,	
	@Level int,
	@Title nvarchar(256),	
	@Importance int = 0,
	@Description nvarchar(4000),
	@ImageBlobId uniqueidentifier = null,

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		UPDATE
			[Categoriess]
		SET

	[ParentId] = @ParentId,
	[Level] = @Level,
	[Title] = @Title,	
	[Importance] = @Importance,
	[Description] = @Description,
	[ImageBlobId] = @ImageBlobId 


		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO



/******  StoredProcedure [dbo].[CategoryDelete]   ******/
IF (OBJECT_ID('[dbo].[CategoryDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[CategoryDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CategoryDelete]
	@Id int = null
AS
BEGIN
	UPDATE 
		[Categories] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id					
END
GO
