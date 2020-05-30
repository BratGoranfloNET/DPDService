USE [DPDSibur]
GO

/****** Object:  Table [dbo].[Tag]   ******/

IF (OBJECT_ID('[dbo].[Tag]') IS NOT NULL)
 DROP TABLE [dbo].[Tag]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,	
	[UTCCreation] [datetime2](7) NOT NULL,
	[UTCUpdate]   [datetime2](7) NOT NULL,		
	[Name] [nvarchar](300) NOT NULL	
	
	
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




ALTER TABLE [dbo].[Tag] ADD  CONSTRAINT [DF_Tag_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[Tag] ADD  CONSTRAINT [DF_Tag_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[Tag] ADD  CONSTRAINT [DF_Tag_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO




--ALTER TABLE [dbo].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_Position] FOREIGN KEY([PositionId])
--REFERENCES [dbo].[Position] ([Id])
--GO
--ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_Position]
--GO






/****** Object:  StoredProcedure [dbo].[TagInsert]  ******/
IF (OBJECT_ID('[dbo].[TagInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[TagInsert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TagInsert]

				
		@Name nvarchar(300),
			

		-- Output
		@EntityId int output,
		@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [Tag]
		(			
		
		[Name]		
			
		)
		VALUES
		(

		@Name
					
		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  	
END
GO


/****** Object:  StoredProcedure [dbo].[TagSelect]  ******/

IF (OBJECT_ID('[dbo].[TagSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[TagSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TagSelect]

	@Id int = null,	
	@IsDeleted bit = null	
	

AS
BEGIN

	SELECT
		*
	FROM 
		Tag E
		--LEFT JOIN Blobs B ON (B.Id = E.ImageBlobId)
		--LEFT JOIN Position P ON (P.Id = E.PositionId)
		
	WHERE
		E.Id = CASE WHEN(@Id IS NULL) THEN E.Id ELSE @Id END		
		AND E.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN E.IsDeleted ELSE @IsDeleted END
	ORDER BY
		E.Id DESC					
END
GO



/****** Object:  StoredProcedure [dbo].[TagUpdate]   ******/
IF (OBJECT_ID('[dbo].[TagUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[TagUpdate]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TagUpdate]

		@Id int,
		@Name nvarchar(300),	
		

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		-- UPDATE ENTITY

		UPDATE
			[Tag]
		SET
		
		[Name]    = @Name		

		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END

GO




/****** Object:  StoredProcedure [dbo].[TagDelete]     ******/
IF (OBJECT_ID('[dbo].[TagDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[TagDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TagDelete]

	@Id int = null

AS
BEGIN

	
	UPDATE 
		[Tag] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id
					
END

GO