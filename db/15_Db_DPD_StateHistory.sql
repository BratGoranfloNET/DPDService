USE [DPDSibur]
GO

/****** Object:  Table [dbo].[StateHistory]  ******/
IF (OBJECT_ID('[dbo].[StateHistory]') IS NOT NULL)
 DROP TABLE [dbo].[StateHistory]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StateHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,		
	[UTCCreation] [datetime2](7) NOT NULL,	
	[UTCUpdate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](300) NULL,	
   
    
    [dpdOrderNr] [nvarchar](300) NULL,
    [dpdParcelNr] [nvarchar](300) NULL,    
    [newState] [nvarchar](300) NULL,
    [transitionTime] [datetime2](7) NULL,

    [terminalCode] [nvarchar](300) NULL,
    [terminalCity] [nvarchar](300) NULL,
    [incidentCode] [nvarchar](300) NULL,
    [incidentName] [nvarchar](300) NULL,
    [consignee] [nvarchar](300) NULL,
	
	
 CONSTRAINT [PK_StateHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





ALTER TABLE [dbo].[StateHistory] ADD  CONSTRAINT [DF_StateHistory_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


ALTER TABLE [dbo].[StateHistory] ADD  CONSTRAINT [DF_StateHistory_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[StateHistory] ADD  CONSTRAINT [DF_StateHistory_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO







--ALTER TABLE [dbo].[StateHistory]  WITH CHECK ADD  CONSTRAINT [FK_StateHistory_StateHistory] FOREIGN KEY([ParentId])
--REFERENCES [dbo].[StateHistory] ([Id])
--GO

--ALTER TABLE [dbo].[StateHistory] CHECK CONSTRAINT [FK_StateHistory_StateHistory]
--GO



/****** Object:  StoredProcedure [dbo].[StateHistoryInsert]   ******/
IF (OBJECT_ID('[dbo].[StateHistoryInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateHistoryInsert]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StateHistoryInsert]

	
	@Name nvarchar(300) = null,	
	
    @dpdOrderNr nvarchar(300),
    @dpdParcelNr nvarchar(300),    
    @newState nvarchar(300),
    @transitionTime datetime2(7),
    @terminalCode nvarchar(300),
    @terminalCity nvarchar(300),
    @incidentCode nvarchar(300),
    @incidentName nvarchar(300),
    @consignee nvarchar(300),
	
	
	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [StateHistory]
		(
	
	
		
	[Name],	
	
    [dpdOrderNr],
    [dpdParcelNr],    
    [newState] ,
    [transitionTime] ,
    [terminalCode],
    [terminalCity] ,
    [incidentCode],
    [incidentName] ,
    [consignee] 
			

		)
		VALUES
		(


	@Name ,		
    @dpdOrderNr,
    @dpdParcelNr,    
    @newState,
    @transitionTime,
    @terminalCode,
    @terminalCity,
    @incidentCode,
    @incidentName,
    @consignee
		

		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO


/****** Object:  StoredProcedure [dbo].[StateHistorySelect]  ******/

IF (OBJECT_ID('[dbo].[StateHistorySelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateHistorySelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateHistorySelect]

	@Id int = null,	
	@IsDeleted bit = null,
	@DPDParam nvarchar(300) = null			

AS
BEGIN

	SELECT
		*
	FROM 
		StateHistory C
		--LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)		
		
	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END		
		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END
		AND C.dpdOrderNr = CASE WHEN(@DPDParam IS NULL) THEN C.dpdOrderNr ELSE @DPDParam END
	ORDER BY
		C.Id DESC					
END
GO









/******  StoredProcedure [dbo].[StateHistoryUpdate]  ******/
IF (OBJECT_ID('[dbo].[StateHistoryUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateHistoryUpdate]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StateHistoryUpdate]

	@Id int,
	@Name nvarchar(300) = null,	
	
	
    @dpdOrderNr nvarchar(300),
    @dpdParcelNr nvarchar(300),   
    @newState nvarchar(300),
    @transitionTime datetime2(7),
    @terminalCode nvarchar(300),
    @terminalCity nvarchar(300),
    @incidentCode nvarchar(300),
    @incidentName nvarchar(300),
    @consignee nvarchar(300),
	

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		UPDATE
			[StateHistory]
		SET

	
    [Name]	 = @Name,	
    [dpdOrderNr]  = @dpdOrderNr,
    [dpdParcelNr]  = @dpdParcelNr,    
    [newState]  = @newState,
    [transitionTime]  = @transitionTime,
    [terminalCode]  = @terminalCode,
    [terminalCity]  = @terminalCity,
    [incidentCode]  = @incidentCode,
    [incidentName]  = @incidentName,
    [consignee]  = @consignee	


		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO



/******  StoredProcedure [dbo].[StateHistoryDelete]   ******/
IF (OBJECT_ID('[dbo].[StateHistoryDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateHistoryDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateHistoryDelete]
	@Id int = null
AS
BEGIN
	UPDATE 
		[StateHistory] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id					
END
GO





IF (OBJECT_ID('[dbo].[StateHistoryDeleteAll]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateHistoryDeleteAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateHistoryDeleteAll]
	
AS
BEGIN

	DELETE FROM  [StateHistory] 
					
END
GO
