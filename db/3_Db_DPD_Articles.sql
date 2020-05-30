USE [DPDSibur]
GO

/****** Object:  Table [dbo].[Articles]   ******/
IF (OBJECT_ID('[dbo].[Articles]') IS NOT NULL)
 DROP TABLE [dbo].[Articles]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,	
	[UTCCreation] [datetime2](7) NOT NULL,
	[UTCUpdate]   [datetime2](7) NOT NULL,
	--[AddedBy] [nvarchar](256)  NULL,
	[CategoryId] [int]  NULL,
	[Title] [nvarchar](256) NOT NULL,
	--[Path] [nvarchar](256)  NULL,
	[Abstract] [nvarchar](4000) NULL,
	[Body] [ntext] NOT NULL,	
	--[ReleaseDate] [datetime]  NULL,
	--[ExpireDate] [datetime] NULL,
	--[Approved] [bit] NOT NULL CONSTRAINT [DF_Articles_Approved]  DEFAULT ((1)),	
	--[CommentsEnabled] [bit] NOT NULL CONSTRAINT [DF_Articles_CommentsEnabled]  DEFAULT ((1)),
	--[OnlyForMembers] [bit] NOT NULL CONSTRAINT [DF_Articles_OnlyForMembers]  DEFAULT ((0)),
	--[ViewCount] [int] NOT NULL CONSTRAINT [DF_Articles_ViewCount]  DEFAULT ((0)),
	--[Votes] [int] NOT NULL CONSTRAINT [DF_Articles_Votes]  DEFAULT ((0)),
	--[TotalRating] [int] NOT NULL CONSTRAINT [DF_Articles_TotalRating]  DEFAULT ((0)),
	[ImageBlobId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_Articles_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_Articles_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO

--ALTER TABLE [dbo].[Articles]  WITH NOCHECK ADD  CONSTRAINT [FK_Articles_Categories] FOREIGN KEY([CategoryId])
--REFERENCES [dbo].[Categories] ([Id])
--ON UPDATE CASCADE
--ON DELETE CASCADE
--GO


--ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Categories]
--GO


ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Blobs] FOREIGN KEY([ImageBlobId])
REFERENCES [dbo].[Blobs] ([Id])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Blobs]
GO



ALTER TABLE [dbo].[Articles] ADD  CONSTRAINT [DF_Articles_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO




/****** Object:  StoredProcedure [dbo].[ArticleInsert]  ******/
IF (OBJECT_ID('[dbo].[ArticleInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[ArticleInsert]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ArticleInsert]
	
	--@AddedBy nvarchar(256),
	@CategoryId int = null,	
    @Title nvarchar(256) = null,
    --@Path nvarchar(256)= null,
    @Abstract nvarchar(4000)= null,
    @Body ntext,   
    --@ReleaseDate datetime = null,
    --@ExpireDate datetime = null,
    --@Approved bit ,   
	--@CommentsEnabled bit,
    --@OnlyForMembers bit, 
    --@ViewCount int,
    --@Votes int,
    --@TotalRating int,
	@ImageBlobId uniqueidentifier = null,


	
	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [Articles]
		(	
	--[AddedBy],
	[CategoryId],
    [Title],
    --[Path],
    [Abstract],
    [Body],    
    --[ReleaseDate],
   -- [ExpireDate],
    --[Approved],    
	--[CommentsEnabled],
    --[OnlyForMembers],
    --[ViewCount],
    --[Votes],
    --[TotalRating],
	[ImageBlobId]

		)
		VALUES
		(	
	
	--@AddedBy,
	@CategoryId,	
    @Title,
   -- @Path,
    @Abstract,
    @Body,    
    --@ReleaseDate,
   -- @ExpireDate,
    --@Approved,
	--@CommentsEnabled,
    --@OnlyForMembers,    
    --@ViewCount,
    --@Votes,
    --@TotalRating,
	@ImageBlobId

		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END

GO







/****** Object:  StoredProcedure [dbo].[ArticleSelect]    ******/
IF (OBJECT_ID('[dbo].[ArticleSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[ArticleSelect]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ArticleSelect]

	@Id int = null,
	@IsDeleted bit = null,
	@CategoryId int = null
	--@NowDate datetime = null,
	--@CheckForApproved bit = null

AS

BEGIN

	SELECT
		*
	FROM 
		Articles A
		LEFT JOIN Blobs B ON (B.Id = A.ImageBlobId)
		LEFT JOIN Categories C ON (C.Id = A.CategoryId)
	WHERE
		A.Id = CASE WHEN(@Id IS NULL) THEN A.Id ELSE @Id END
		AND A.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN A.IsDeleted ELSE @IsDeleted END


		AND A.CategoryId =  CASE WHEN(@CategoryId IS NULL) THEN A.CategoryId ELSE @CategoryId  END   
		--AND A.ReleaseDate <= CASE WHEN(@NowDate IS NULL) THEN A.ReleaseDate ELSE @NowDate  END  
		--AND A.ExpireDate  >= CASE WHEN(@NowDate IS NULL) THEN A.ExpireDate ELSE @NowDate  END 
		--AND A.Approved =  CASE WHEN(@CheckForApproved IS NULL) THEN A.Approved ELSE 1 END



	ORDER BY
		A.Id
					
END
GO



/****** Object:  StoredProcedure [dbo].[ArticleUpdate]    ******/
IF (OBJECT_ID('[dbo].[ArticleUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[ArticleUpdate]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ArticleUpdate]

	@Id int,
	@Title nvarchar(256),
	--@Path nvarchar(256) = null,
	@CategoryId int = null,	    
    @Abstract nvarchar(4000),
    @Body ntext,   
    --@ReleaseDate datetime = null,
   -- @ExpireDate datetime = null,
    --@Approved bit = null,
	--@CommentsEnabled bit = null,
    --@OnlyForMembers bit = null,
    @ImageBlobId uniqueidentifier = null,
    	

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		-- UPDATE ENTITY

		UPDATE
			[Articles]
		SET
			[Title] = @Title,
			--[Path] = @Path,			
			[CategoryId] = @CategoryId,  
			[Abstract]  = @Abstract,
			[Body] = @Body,			
			--[ReleaseDate]  = @ReleaseDate,
			--[ExpireDate] =  @ExpireDate,
			--[Approved]  = @Approved,
			--[CommentsEnabled]  = @CommentsEnabled,
			--[OnlyForMembers] = @OnlyForMembers,
			[ImageBlobId] = @ImageBlobId
			
			
		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END

GO





/****** StoredProcedure [dbo].[ArticleDelete] ******/
IF (OBJECT_ID('[dbo].[ArticleDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[ArticleDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ArticleDelete]

	@Id int = null

AS
BEGIN

	UPDATE 
		[Articles] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id
					
END


GO
