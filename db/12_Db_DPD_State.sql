USE [DPDSibur]
GO

/****** Object:  Table [dbo].[State]  ******/
IF (OBJECT_ID('[dbo].[State]') IS NOT NULL)
 DROP TABLE [dbo].[State]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,		
	[UTCCreation] [datetime2](7) NOT NULL,	
	[UTCUpdate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](300) NULL,	
		
    [StateParcelsId] [int] NULL,
    [clientOrderNr] [nvarchar](300) NULL,
    [clientParcelNr] [nvarchar](300) NULL,
    [dpdOrderNr] [nvarchar](300) NULL,
    [dpdParcelNr] [nvarchar](300) NULL,
    [pickupDate] [datetime2](7)  NULL,
    [dpdOrderReNr] [nvarchar](300) NULL,
    [dpdParcelReNr] [nvarchar](300) NULL,
    [isReturn] [bit] NULL,
    [isReturnSpecified] [bit] NULL,
    [planDeliveryDate] [datetime2](7)  NULL,
    [planDeliveryDateSpecified] [bit] NULL,
    [newState] [nvarchar](300) NULL,
    [transitionTime] [datetime2](7)  NULL,
    [terminalCode] [nvarchar](300) NULL,
    [terminalCity] [nvarchar](300) NULL,
    [incidentCode] [nvarchar](300) NULL,
    [incidentName] [nvarchar](300) NULL,
    [consignee] [nvarchar](300) NULL,
	
	
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO







--ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_State] FOREIGN KEY([ParentId])
--REFERENCES [dbo].[State] ([Id])
--GO

--ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_State]
--GO



/****** Object:  StoredProcedure [dbo].[StateInsert]   ******/
IF (OBJECT_ID('[dbo].[StateInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateInsert]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StateInsert]

	
	@Name nvarchar(300) = null,	
	@StateParcelsId int ,
    @clientOrderNr nvarchar(300),
    @clientParcelNr nvarchar(300),
    @dpdOrderNr nvarchar(300),
    @dpdParcelNr nvarchar(300),
    @pickupDate datetime2(7),
    @dpdOrderReNr nvarchar(300),
    @dpdParcelReNr nvarchar(300),
    @isReturn bit,
    @isReturnSpecified bit,
    @planDeliveryDate datetime2(7),
    @planDeliveryDateSpecified bit,
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

		INSERT INTO [State]
		(
	
	
		
	[Name],	
	[StateParcelsId],
    [clientOrderNr] ,
    [clientParcelNr],
    [dpdOrderNr],
    [dpdParcelNr],
    [pickupDate] ,
    [dpdOrderReNr] ,
    [dpdParcelReNr] ,
    [isReturn],
    [isReturnSpecified] ,
    [planDeliveryDate] ,
    [planDeliveryDateSpecified],
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
	@StateParcelsId ,
    @clientOrderNr ,
    @clientParcelNr ,
    @dpdOrderNr,
    @dpdParcelNr,
    @pickupDate,
    @dpdOrderReNr,
    @dpdParcelReNr,
    @isReturn,
    @isReturnSpecified,
    @planDeliveryDate,
    @planDeliveryDateSpecified,
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


/****** Object:  StoredProcedure [dbo].[StateSelect]  ******/

IF (OBJECT_ID('[dbo].[StateSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateSelect]

	@Id int = null,	
	@IsDeleted bit = null		

AS
BEGIN

	SELECT
		*
	FROM 
		State C
		--LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)		
		
	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END		
		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END
	ORDER BY
		C.Id DESC					
END
GO









/******  StoredProcedure [dbo].[StateUpdate]  ******/
IF (OBJECT_ID('[dbo].[StateUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateUpdate]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StateUpdate]

	@Id int,
	@Name nvarchar(300) = null,	
	
	@StateParcelsId int ,
    @clientOrderNr nvarchar(300),
    @clientParcelNr nvarchar(300),
    @dpdOrderNr nvarchar(300),
    @dpdParcelNr nvarchar(300),
    @pickupDate datetime2(7),
    @dpdOrderReNr nvarchar(300),
    @dpdParcelReNr nvarchar(300),
    @isReturn bit,
    @isReturnSpecified bit,
    @planDeliveryDate datetime2(7),
    @planDeliveryDateSpecified bit,
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
			[State]
		SET

	
    [Name]	 = @Name,	
	[StateParcelsId] = StateParcelsId,
    [clientOrderNr]  = @clientOrderNr,
    [clientParcelNr]  = @clientParcelNr,
    [dpdOrderNr]  = @dpdOrderNr,
    [dpdParcelNr]  = @dpdParcelNr,
    [pickupDate]  = @pickupDate,
    [dpdOrderReNr]  = @dpdOrderReNr,
    [dpdParcelReNr]  = @dpdParcelReNr,
    [isReturn]  = @isReturn,
    [isReturnSpecified]  = @isReturnSpecified,
    [planDeliveryDate]  = @planDeliveryDate,
    [planDeliveryDateSpecified]  = @planDeliveryDateSpecified,
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



/******  StoredProcedure [dbo].[StateDelete]   ******/
IF (OBJECT_ID('[dbo].[StateDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateDelete]
	@Id int = null
AS
BEGIN
	UPDATE 
		[State] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id					
END
GO





IF (OBJECT_ID('[dbo].[StateDeleteAll]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateDeleteAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateDeleteAll]
	
AS
BEGIN
		
		
	DECLARE @local_time DATETIME;
	DECLARE @gmt_time DATETIME;
	DECLARE @last_week DATETIME;

	SET @local_time = GETDATE();
	SET @gmt_time = GETUTCDATE();
	SET @last_week = DATEADD(DAY,-7,@gmt_time)
	

	DELETE FROM
	 State  
	 WHERE UTCCreation <=  @last_week
		
		
		
					
END
GO
