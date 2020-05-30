USE [DPDSibur]
GO

/****** Object:  Table [dbo].[StateUnited]  ******/
IF (OBJECT_ID('[dbo].[StateUnited]') IS NOT NULL)
 DROP TABLE [dbo].[StateUnited]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StateUnited](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,		
	[UTCCreation] [datetime2](7) NOT NULL,	
	[UTCUpdate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](300) NULL,	
	[Count] [int],
		
    [StateUnitedParcelsId] [int] NULL,
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

	[EventName] [nvarchar](300) NULL,       
	
	[DeliveryAddress] [nvarchar](300) NULL,  
	[DeliveryCity] [nvarchar](300) NULL,     
	[DeliveryVariant] [nvarchar](300) NULL,  
	[DeliveryPointCode] [nvarchar](300) NULL,
	[DeliveryInterval] [nvarchar](300) NULL, 
	
	[PickupAddress] [nvarchar](300) NULL,    
	[PickupCity] [nvarchar](300) NULL,       
	[PointCity] [nvarchar](300) NULL,        
	[Consignee2] [nvarchar](300) NULL,        
	[Consignor] [nvarchar](300) NULL ,
	
	[EventReason] [nvarchar](300) NULL ,
	[ProblemName] [nvarchar](300) NULL ,
	[ReasonName] [nvarchar](300) NULL ,
	[RejectionReason] [nvarchar](300) NULL ,
	[OrderType] [nvarchar](300) NULL ,
	[MomentLocZone] [nvarchar](300) NULL 
	
	
 CONSTRAINT [PK_StateUnited] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





ALTER TABLE [dbo].[StateUnited] ADD  CONSTRAINT [DF_StateUnited_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


ALTER TABLE [dbo].[StateUnited] ADD  CONSTRAINT [DF_StateUnited_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[StateUnited] ADD  CONSTRAINT [DF_StateUnited_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO







--ALTER TABLE [dbo].[StateUnited]  WITH CHECK ADD  CONSTRAINT [FK_StateUnited_StateUnited] FOREIGN KEY([ParentId])
--REFERENCES [dbo].[StateUnited] ([Id])
--GO

--ALTER TABLE [dbo].[StateUnited] CHECK CONSTRAINT [FK_StateUnited_StateUnited]
--GO



/****** Object:  StoredProcedure [dbo].[StateUnitedInsert]   ******/
IF (OBJECT_ID('[dbo].[StateUnitedInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateUnitedInsert]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StateUnitedInsert]

	
	@Name nvarchar(300) = null,	
	@Count int,
	@StateUnitedParcelsId int ,
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
	
	@EventName nvarchar(300),        
	
	@DeliveryAddress nvarchar(300),  
	@DeliveryCity nvarchar(300),     
	@DeliveryVariant nvarchar(300),  
	@DeliveryPointCode nvarchar(300),
	@DeliveryInterval nvarchar(300), 
	
	@PickupAddress nvarchar(300),    
	@PickupCity nvarchar(300),       
	@PointCity  nvarchar(300),       
	@Consignee2 nvarchar(300),        
	@Consignor nvarchar(300),        

	@EventReason nvarchar(300),
	@ProblemName nvarchar(300),
	@ReasonName nvarchar(300),
	@RejectionReason nvarchar(300),
	@OrderType nvarchar(300),
	@MomentLocZone nvarchar(300),
	
	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [StateUnited]
		(
	
	
		
	[Name],	
	[Count],	
	[StateUnitedParcelsId],
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
    [consignee],
	
	[EventName],        
	
	[DeliveryAddress],  
	[DeliveryCity],     
	[DeliveryVariant],  
	[DeliveryPointCode],
	[DeliveryInterval], 
	
	[PickupAddress],    
	[PickupCity],       
	[PointCity],        
	[Consignee2],        
	[Consignor],
	
	[EventReason],    
	[ProblemName],    
	[ReasonName],     
	[RejectionReason],
	[OrderType],      
	[MomentLocZone]         
			

		)
		VALUES
		(


	@Name ,	
	@Count,
	@StateUnitedParcelsId ,
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
    @consignee,

	@EventName,        
	
	@DeliveryAddress ,  
	@DeliveryCity,     
	@DeliveryVariant,  
	@DeliveryPointCode,
	@DeliveryInterval, 
	
	@PickupAddress,    
	@PickupCity,       
	@PointCity,       
	@Consignee2 ,        
	@Consignor ,

	@EventReason,    
	@ProblemName,    
	@ReasonName,     
	@RejectionReason,
	@OrderType,      
	@MomentLocZone

	)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO


/****** Object:  StoredProcedure [dbo].[StateUnitedSelect]  ******/

IF (OBJECT_ID('[dbo].[StateUnitedSelect]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateUnitedSelect]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateUnitedSelect]

	@Id int = null,	
	@IsDeleted bit = null,
	@DPDParam nvarchar(300) = null		

AS
BEGIN

	SELECT
		*
	FROM 
		StateUnited S
		--LEFT JOIN Blobs B ON (B.Id = S.ImageBlobId)		
		
	WHERE
		S.Id = CASE WHEN(@Id IS NULL) THEN S.Id ELSE @Id END		
		AND S.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN S.IsDeleted ELSE @IsDeleted END
		AND S.dpdOrderNr = CASE WHEN(@DPDParam IS NULL) THEN S.dpdOrderNr ELSE @DPDParam END		
	ORDER BY
		S.Id DESC					
END
GO









/******  StoredProcedure [dbo].[StateUnitedUpdate]  ******/
IF (OBJECT_ID('[dbo].[StateUnitedUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateUnitedUpdate]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[StateUnitedUpdate]

	@Id int,
	@Name nvarchar(300) = null,	
	@Count int,
	
	@StateUnitedParcelsId int ,
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
	
	@EventName nvarchar(300),        
	
	@DeliveryAddress nvarchar(300),  
	@DeliveryCity nvarchar(300),     
	@DeliveryVariant nvarchar(300),  
	@DeliveryPointCode nvarchar(300),
	@DeliveryInterval nvarchar(300), 
	
	@PickupAddress nvarchar(300),    
	@PickupCity nvarchar(300),       
	@PointCity  nvarchar(300),       
	@Consignee2 nvarchar(300),        
	@Consignor nvarchar(300),        

	@EventReason nvarchar(300),
	@ProblemName nvarchar(300),
	@ReasonName nvarchar(300),
	@RejectionReason nvarchar(300),
	@OrderType nvarchar(300),
	@MomentLocZone nvarchar(300),


	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		UPDATE
			[StateUnited]
		SET

	
    [Name]	 = @Name,	
	[Count]  = @Count,
	[StateUnitedParcelsId] = StateUnitedParcelsId,
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
    [consignee]  = @consignee,

	[EventName]   =  @EventName,        
	
	[DeliveryAddress]  = @DeliveryAddress,  
	[DeliveryCity]    =  @DeliveryCity,     
	[DeliveryVariant]  = @DeliveryVariant,  
	[DeliveryPointCode]	= @DeliveryPointCode,
	[DeliveryInterval] =  @DeliveryInterval, 
	
	[PickupAddress]   = @PickupAddress,    
	[PickupCity]     =  @PickupCity,       
	[PointCity]      = @PointCity,        
	[Consignee2]     =  @Consignee2,        
	[Consignor]      =  @Consignor,
	
	[EventReason]  =  @EventReason, 
	[ProblemName]  = @ProblemName, 
	[ReasonName]  = @ReasonName,    
	[RejectionReason] = @RejectionReason,
	[OrderType]  =    @OrderType, 
	[MomentLocZone]  = @MomentLocZone 
	        

	


		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO



/******  StoredProcedure [dbo].[StateUnitedDelete]   ******/
IF (OBJECT_ID('[dbo].[StateUnitedDelete]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateUnitedDelete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateUnitedDelete]
	@Id int = null
AS
BEGIN
	UPDATE 
		[StateUnited] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id					
END
GO





IF (OBJECT_ID('[dbo].[StateUnitedDeleteAll]') IS NOT NULL)
 DROP PROCEDURE [dbo].[StateUnitedDeleteAll]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateUnitedDeleteAll]
	
AS
BEGIN

	DELETE FROM  [StateUnited] 
					
END
GO
