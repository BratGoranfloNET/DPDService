USE [DPDSibur]
GO

/****** Object:  Table [dbo].[EventType]   ******/

IF (OBJECT_ID('[dbo].[EventType]') IS NOT NULL)
 DROP TABLE [dbo].[EventType]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[EventType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,	
	[UTCCreation] [datetime2](7) NOT NULL,
	[UTCUpdate]   [datetime2](7) NOT NULL,		
	[Name] [nvarchar](300) NOT NULL
	
	
	
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




ALTER TABLE [dbo].[EventType] ADD  CONSTRAINT [DF_EventType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[EventType] ADD  CONSTRAINT [DF_EventType_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[EventType] ADD  CONSTRAINT [DF_EventType_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO




--ALTER TABLE [dbo].[EventType]  WITH CHECK ADD  CONSTRAINT [FK_EventType_Position] FOREIGN KEY([PositionId])
--REFERENCES [dbo].[Position] ([Id])
--GO
--ALTER TABLE [dbo].[EventType] CHECK CONSTRAINT [FK_EventType_Position]
--GO






/****** Object:  StoredProcedure [dbo].[EventTypeInsert]  ******/
IF (OBJECT_ID('[dbo].[EventTypeInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTypeInsert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTypeInsert]

				
		@Name nvarchar(300),			

		-- Output
		@EntityId int output,
		@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [EventType]
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


/****** Object:  StoredProcedure [dbo].[EventTypeSelect]  ******/

IF (OBJECT_ID('[dbo].[EventTypeSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTypeSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTypeSelect]

	@Id int = null,	
	@IsDeleted bit = null	
	

AS
BEGIN

	SELECT
		*
	FROM 
		EventType E
		--LEFT JOIN Blobs B ON (B.Id = E.ImageBlobId)
		--LEFT JOIN Position P ON (P.Id = E.PositionId)
		
	WHERE
		E.Id = CASE WHEN(@Id IS NULL) THEN E.Id ELSE @Id END		
		AND E.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN E.IsDeleted ELSE @IsDeleted END
	ORDER BY
		E.Id DESC					
END
GO



/****** Object:  StoredProcedure [dbo].[EventTypeUpdate]   ******/
IF (OBJECT_ID('[dbo].[EventTypeUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTypeUpdate]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTypeUpdate]

		@Id int,
		@Name nvarchar(300),		
		

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		-- UPDATE ENTITY

		UPDATE
			[EventType]
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




/****** Object:  StoredProcedure [dbo].[EventTypeDelete]     ******/
IF (OBJECT_ID('[dbo].[EventTypeDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[EventTypeDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EventTypeDelete]

	@Id int = null

AS
BEGIN

	
	UPDATE 
		[EventType] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id
					
END

GO