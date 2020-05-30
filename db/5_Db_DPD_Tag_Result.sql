USE [DPDSibur]
GO


/****** Object:  Table [dbo].[TagResult]   ******/

IF (OBJECT_ID('[dbo].[TagResult]') IS NOT NULL)
 DROP TABLE [dbo].[TagResult]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TagResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,	
	[UTCCreation] [datetime2](7) NOT NULL,
	[UTCUpdate]   [datetime2](7) NOT NULL,
	[TagId] int  NULL, 
	[ArticleId] int  NULL,
	
 CONSTRAINT [PK_TagResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

ALTER TABLE [dbo].[TagResult] ADD  CONSTRAINT [DF_TagResult_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TagResult] ADD  CONSTRAINT [DF_TagResult_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO
ALTER TABLE [dbo].[TagResult] ADD  CONSTRAINT [DF_TagResult_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO



ALTER TABLE [dbo].[TagResult]  WITH CHECK ADD  CONSTRAINT [FK_TagResult_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO

--ALTER TABLE [dbo].[TagResult] CHECK CONSTRAINT [FK_TagResult_Department]
--GO


ALTER TABLE [dbo].[TagResult]  WITH CHECK ADD  CONSTRAINT [FK_TagResult_Articles] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([Id])
GO



/****** Object:  StoredProcedure [dbo].[TagResultInsert]  ******/
IF (OBJECT_ID('[dbo].[TagResultInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[TagResultInsert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TagResultInsert]

				
		@TagId int = null,	
		@ArticleId int = null,		

		-- Output
		@EntityId int output,
		@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [TagResult]
		(			
		
		[TagId],
		[ArticleId]			
			
		)
		VALUES
		(

		@TagId,
		@ArticleId				
			
		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  	
END
GO


/****** Object:  StoredProcedure [dbo].[TagResultSelect]  ******/

IF (OBJECT_ID('[dbo].[TagResultSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[TagResultSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TagResultSelect]

	@Id int = null,	
	@ArticleId int = null,
	@IsDeleted bit = null	
	

AS
BEGIN

	SELECT
		*
	FROM 
		TagResult P
		--LEFT JOIN Blobs B ON (B.Id = P.ImageBlobId)
		--LEFT JOIN Department M ON (M.Id = P.ArticleId)
		
	WHERE
		P.Id = CASE WHEN(@Id IS NULL) THEN P.Id ELSE @Id END
		AND P.ArticleId = CASE WHEN(@ArticleId IS NULL) THEN P.ArticleId ELSE @ArticleId END		
		AND P.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN P.IsDeleted ELSE @IsDeleted END
	ORDER BY
		P.Id DESC					
END
GO



/****** Object:  StoredProcedure [dbo].[TagResultUpdate]   ******/
IF (OBJECT_ID('[dbo].[TagResultUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[TagResultUpdate]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TagResultUpdate]

		@Id int,	
		@TagId int,
		@ArticleId int,							

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		-- UPDATE ENTITY

		UPDATE
			[TagResult]
		SET
									
		[TagId] = @TagId,
		[ArticleId] = @ArticleId					
		
		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END

GO




/****** Object:  StoredProcedure [dbo].[TagResultDelete]     ******/
IF (OBJECT_ID('[dbo].[TagResultDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[TagResultDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TagResultDelete]

	@Id int = null

AS
BEGIN

	
	UPDATE 
		[TagResult] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id
					
END

GO