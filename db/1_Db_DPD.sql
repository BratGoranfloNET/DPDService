USE [DPDSibur]
GO


/****** Object:  Table [dbo].[Activities]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Realm] [tinyint] NOT NULL,
	[Date] [datetimeoffset](7) NOT NULL,
	[Type] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Signature] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blobs]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blobs](
	[Id] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[UTCCreation] [datetime2](7) NOT NULL,
	[Type] [varchar](35) NOT NULL,
	[Length] [bigint] NOT NULL,
	[Extension] [varchar](10) NOT NULL,
	[Container] [varchar](175) NOT NULL,
 CONSTRAINT [PK_Blobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdOld] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[UTCCreation] [datetime2](7) NOT NULL,
	[ImageBlobId] [uniqueidentifier] NULL,
	[Name] [nvarchar](175) NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[BirthDate] [datetime] NULL,
	[Email1] [nvarchar](175) NULL,
	[Email2] [nvarchar](175) NULL,
	[Phone1] [nvarchar](25) NULL,
	[Phone2] [nvarchar](25) NULL,
	[Notes] [nvarchar](max) NULL,
	
	[FullName] [nvarchar](600)  NULL,
	[Inn] [nvarchar](30) NULL,
	[Address] [nvarchar](300) NULL,
	[SroNumberPasspotr] [nvarchar](100) NULL,

	[Limit] [money] NULL ,
	[Profession] [nvarchar](175)  NULL,
	[ProfessionType] [nvarchar](175)  NULL,
	[ActiveFlag] [int] NULL	


 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventImages]  ******/
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
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



/****** Object:  Table [dbo].[Locations]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[UTCCreation] [datetime2](7) NOT NULL,
	[UTCUpdate] [datetime2](7) NOT NULL,
	[ImageBlobId] [uniqueidentifier] NULL,
	[Name] [nvarchar](175) NOT NULL,
	[Type] [tinyint] NULL,
	[TimeZoneId] [nvarchar](75) NOT NULL,
	[ContactId] [int] NULL,
	[Notes] [nvarchar](max) NULL,
	[City] [nvarchar](175)  NULL,
	[Latitude] [nvarchar](175) NULL,
	[Longitude] [nvarchar](175)  NULL
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Properties] [nvarchar](max) NULL,
	[UTCCreation] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserBlobs]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBlobs](
	[UserId] [int] NOT NULL,
	[BlobId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserBlobs] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[BlobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserClaims]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Realm] [tinyint] NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NOT NULL,
	[ClaimValue] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoles] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[Role] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[UTCCreation] [datetime2](7) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[MobilePhoneConfirmed] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetimeoffset](7) NULL,
	[AccessFailedCount] [tinyint] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Realm] [tinyint] NOT NULL,
	[Name] [nvarchar](175) NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[ImageBlobId] [uniqueidentifier] NULL,
	[MobilePhone] [nvarchar](100) NULL,
	[Biography] [nvarchar](max) NULL,
	[GitHubLink] [nvarchar](200) NULL,
	[TwitterLink] [nvarchar](200) NULL,
	[LinkedInLink] [nvarchar](200) NULL,
	[FacebookLink] [nvarchar](200) NULL,
	[InstagramLink] [nvarchar](200) NULL,
	[CurrentCultureId] [nvarchar](10) NOT NULL,
	[CurrentUICultureId] [nvarchar](10) NOT NULL,
	[TimeZoneId] [nvarchar](75) NOT NULL,
	[AutoLockScreenInMinutes] [tinyint] NOT NULL,
	[StatusMessage] [nvarchar](140) NULL,
 CONSTRAINT [PK__UserEnti__3214EC070425A276] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[DataSearchView]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[DataSearchView]   
AS
(
	-- CONTACTS
	SELECT DISTINCT
		[Id],
		1 AS [Type],
		CONCAT ([Name], [Email1], [Email2], [Phone1], [Phone2], [Notes]) AS [SearchData]
	FROM
		[dbo].[Contacts]

	UNION

	-- LOCATIONS
	SELECT DISTINCT
		[Id],
		2 AS [Type],
		CONCAT ([Name], [Notes]) AS [SearchData]
	FROM
		[dbo].[Locations]

	UNION

	-- EVENTS
	SELECT DISTINCT
		E.[Id],
		3 AS [Type],
		CONCAT (E.[Name], E.[Color], E.[StartDate], E.[EndDate], E.[Description], EI.[Label], EI.[Description]) AS [SearchData]
	FROM
		[dbo].[Events] E
		LEFT JOIN [dbo].[EventImages] EI ON (EI.EventId = E.Id)

	UNION

	-- USERS
	SELECT DISTINCT
		U.[Id],
		4 AS [Type],
		CONCAT (
			U.[UserName],
			U.[Email],
			U.[Name],
			U.[Biography],
			U.[GitHubLink],
			U.[TwitterLink],
			U.[LinkedInLink],
			U.[FacebookLink],
			U.[InstagramLink],
			U.[StatusMessage],
			UC.[ClaimType],
			UC.[ClaimValue],
			UR.[Role]
		) AS [SearchData]
	FROM
		[dbo].[Users] U
		LEFT JOIN [dbo].[UserClaims] UC ON (UC.UserId = U.Id)
		LEFT JOIN [dbo].[UserRoles] UR ON (UR.UserId = U.Id)
)




GO
ALTER TABLE [dbo].[Blobs] ADD  CONSTRAINT [DF_Files_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Blobs] ADD  CONSTRAINT [DF_Files_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO
ALTER TABLE [dbo].[EventImages] ADD  CONSTRAINT [DF_EventImages_DisplayOrder]  DEFAULT ((0)) FOR [OrderIndex]
GO
ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Events_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Events_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO
ALTER TABLE [dbo].[Locations] ADD  CONSTRAINT [DF_Locations_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[Locations] ADD  CONSTRAINT [DF_Locations_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO

ALTER TABLE [dbo].[Locations] ADD  CONSTRAINT [DF_Locations_UTCUpdate]  DEFAULT (getutcdate()) FOR [UTCUpdate]
GO

ALTER TABLE [dbo].[Locations] ADD  CONSTRAINT [DF_Locations_TimeZoneId]  DEFAULT (N'UTC') FOR [TimeZoneId]
GO
ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UTCCreation]  DEFAULT (getutcdate()) FOR [UTCCreation]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_EmailConfirmed]  DEFAULT ((0)) FOR [EmailConfirmed]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_LockoutEnabled]  DEFAULT ((0)) FOR [LockoutEnabled]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_TwoFactorEnabled]  DEFAULT ((0)) FOR [TwoFactorEnabled]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_MobilePhoneConfirmed]  DEFAULT ((0)) FOR [MobilePhoneConfirmed]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_AccessFailedCount]  DEFAULT ((0)) FOR [AccessFailedCount]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CurrentCultureId]  DEFAULT (N'en-US') FOR [CurrentCultureId]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CurrentCultureId1]  DEFAULT (N'en-US') FOR [CurrentUICultureId]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_TimeZoneId]  DEFAULT (N'UTC') FOR [TimeZoneId]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_AutoLockScreenInMinutes]  DEFAULT ((0)) FOR [AutoLockScreenInMinutes]
GO
ALTER TABLE [dbo].[Activities]  WITH CHECK ADD  CONSTRAINT [FK_Activities_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Activities] CHECK CONSTRAINT [FK_Activities_Users]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_Blobs] FOREIGN KEY([ImageBlobId])
REFERENCES [dbo].[Blobs] ([Id])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_Blobs]
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
ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Blobs] FOREIGN KEY([ImageBlobId])
REFERENCES [dbo].[Blobs] ([Id])
GO
ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [FK_Locations_Blobs]
GO
ALTER TABLE [dbo].[Locations]  WITH CHECK ADD  CONSTRAINT [FK_Locations_Contacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[Locations] CHECK CONSTRAINT [FK_Locations_Contacts]
GO
ALTER TABLE [dbo].[UserBlobs]  WITH CHECK ADD  CONSTRAINT [FK_UserFiles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserBlobs] CHECK CONSTRAINT [FK_UserFiles_Users]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo_UserClaims_dbo_Users_User_Id] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_dbo_UserClaims_dbo_Users_User_Id]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo_UserRoles_dbo_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_dbo_UserRoles_dbo_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Blobs] FOREIGN KEY([ImageBlobId])
REFERENCES [dbo].[Blobs] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Blobs]
GO
/****** Object:  StoredProcedure [dbo].[ActivitiesInsert]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActivitiesInsert]

	@Realm tinyint,
	@Date datetimeoffset(7),
	@Type int,
	@UserId int,
	@Signature uniqueidentifier,

	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [Activities]
		(
			[Realm],
			[Date],
			[Type],
			[UserId],
			[Signature]
		)
		VALUES
		(
			@Realm,
			@Date,
			@Type,
			@UserId,
			@Signature
		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[ActivitiesSelect]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActivitiesSelect]

	@Id int = null,
	@UserId int = null,
	@Top int = 1000

AS
BEGIN

	SELECT TOP(@Top)
		*
	FROM 
		[Activities] A
	WHERE
		A.Id = CASE WHEN(@Id IS NULL) THEN A.Id ELSE @Id END
		AND A.UserId = CASE WHEN(@UserId IS NULL) THEN A.UserId ELSE @UserId END
	ORDER BY
		A.[Date] DESC
					
END


GO
/****** Object:  StoredProcedure [dbo].[BlobsDelete]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BlobsDelete]

	@Id uniqueidentifier = null

AS
BEGIN

	UPDATE 
		[Blobs] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id
					
END


GO
/****** Object:  StoredProcedure [dbo].[BlobsInsert]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BlobsInsert]

	@UserId int,

	@Id uniqueidentifier,
	@Type varchar(35),
	@Length bigint,
	@Extension varchar(10),
	@Container varchar(175),

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		-- INSERT BLOB

		INSERT INTO [Blobs]
		(
			[Id],
			[Type],
			[Length],
			[Extension],
			[Container]
		)
		 VALUES
		(
			@Id,
			@Type,
			@Length,
			@Extension,
			@Container
		)
	
		-- INSERT BLOB x USER RELATION
		
		INSERT INTO [UserBlobs]
		(
			[UserId],
			[BlobId]
		)
		VALUES
		(
			@UserId,
			@Id
		)
	
	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[BlobsSelect]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BlobsSelect]

	@Id uniqueidentifier = null,
	@IsDeleted bit = null

AS
BEGIN

	SELECT
		*
	FROM 
		Blobs B
	WHERE
		B.Id = CASE WHEN(@Id IS NULL) THEN B.Id ELSE @Id END
		AND B.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN B.IsDeleted ELSE @IsDeleted END
	ORDER BY
		B.Id
					
END


GO
/****** Object:  StoredProcedure [dbo].[ContactsDelete]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContactsDelete]

	@Id int = null

AS
BEGIN

	UPDATE 
		[Contacts] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id
					
END


GO
/****** Object:  StoredProcedure [dbo].[ContactsInsert]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContactsInsert]

	@ImageBlobId uniqueidentifier = null,
	@Name nvarchar(175),
	@Type tinyint,
	@Gender tinyint,
	@BirthDate datetime = null,
	@Email1 nvarchar(175) = null,
	@Email2 nvarchar(175) = null,
	@Phone1 nvarchar(25) = null,
	@Phone2 nvarchar(25) = null,
	@Notes nvarchar(max) = null,

	@IdOld int = null,
	@FullName nvarchar(600) = null,
	@Inn nvarchar(30) = null,
	@Address nvarchar(300) = null,
	@SroNumberPasspotr nvarchar(300) = null,
	
	@Limit money = null ,
	@Profession  nvarchar(175) = null,
	@ProfessionType nvarchar(175) = null,
	@ActiveFlag int = null,

	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [Contacts]
		(
			[ImageBlobId],
			[Name],
			[Type],
			[Gender],
			[BirthDate],
			[Email1],
			[Email2],
			[Phone1],
			[Phone2],
			[Notes],

			[IdOld],
			[FullName],
			[Inn],
			[Address],
			[SroNumberPasspotr],

			[Limit],
			[Profession],
			[ProfessionType],
			[ActiveFlag]

		)
		VALUES
		(
			@ImageBlobId,
			@Name,
			@Type,
			@Gender,
			@BirthDate,
			@Email1,
			@Email2,
			@Phone1,
			@Phone2,
			@Notes,

			@IdOld ,
			@FullName,
			@Inn,
			@Address,
			@SroNumberPasspotr,

			@Limit,
			@Profession,
			@ProfessionType,
			@ActiveFlag
		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[ContactsSearch]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContactsSearch]
	@Query nvarchar(100)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		C.*,
		B.*
	FROM
		[dbo].[DataSearchView] S
		INNER JOIN [dbo].[Contacts] C ON (C.Id = S.Id)
		LEFT JOIN [dbo].[Blobs] B ON (B.Id = C.ImageBlobId)
	WHERE
		C.[IsDeleted] = 0
		AND [S].[Type] = 1
		AND [S].[SearchData] LIKE '%' + @Query + '%'

END



GO
/****** Object:  StoredProcedure [dbo].[ContactsSelect]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContactsSelect]

	@Id int = null,
	@IdOld int = null,
	@IsDeleted bit = null

AS
BEGIN

	SELECT
		*
	FROM 
		Contacts C
		LEFT JOIN Blobs B ON (B.Id = C.ImageBlobId)
	WHERE
		C.Id = CASE WHEN(@Id IS NULL) THEN C.Id ELSE @Id END 
		AND C.IdOld = CASE WHEN(@IdOld IS NULL) THEN C.IdOld ELSE @IdOld END 
		AND C.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN C.IsDeleted ELSE @IsDeleted END
	ORDER BY
		C.Id
					
END


GO
/****** Object:  StoredProcedure [dbo].[ContactsUpdate]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContactsUpdate]

	@Id int,
	@ImageBlobId uniqueidentifier = null,
	@Name nvarchar(175),
	@Type tinyint,
	@Gender tinyint,
	@BirthDate datetime = null,
	@Email1 nvarchar(175) = null,
	@Email2 nvarchar(175) = null,
	@Phone1 nvarchar(25) = null,
	@Phone2 nvarchar(25) = null,
	@Notes nvarchar(max) = null,

	-- @IdOld int = null,
    @FullName nvarchar(600) = null,
	@Inn nvarchar(30) = null,
	@Address nvarchar(300) = null,
	@SroNumberPasspotr nvarchar(300) = null,
	
	@Limit money = null ,
	@Profession  nvarchar(175) = null,
	@ProfessionType nvarchar(175) = null,
	@ActiveFlag int = null,

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		-- UPDATE ENTITY

		UPDATE
			[Contacts]
		SET
			[ImageBlobId] = @ImageBlobId,
			[Name] = @Name,
			[Type] = @Type,
			[Gender] = @Gender,
			[BirthDate] = @BirthDate,
			[Email1] = @Email1,
			[Email2] = @Email2,
			[Phone1] = @Phone1,
			[Phone2] = @Phone2,
			[Notes] = @Notes,
						
			[FullName] = @FullName,
			[Inn] = @Inn,
			[Address] = @Address,
			[SroNumberPasspotr] = @SroNumberPasspotr,
			
			[Limit] = @Limit,
			[Profession] = @Profession,
			[ProfessionType] = @ProfessionType,
			[ActiveFlag] = @ActiveFlag			

		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[EventImagesCleanup]   ******/
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
			[Description]
		)
		VALUES
		(
			@Name,
			@Color,
			@StartDate,
			@EndDate,
			@LocationId,
			@Description
		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[EventsSearch]   ******/
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
			[Description] = @Description
		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[LocationsDelete]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LocationsDelete]

	@Id int = null

AS
BEGIN

	UPDATE 
		[Locations] 
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id
					
END


GO
/****** Object:  StoredProcedure [dbo].[LocationsInsert]    ******/
IF (OBJECT_ID('[dbo].[LocationsInsert]') IS NOT NULL)
 DROP PROCEDURE [dbo].[LocationsInsert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LocationsInsert]

	@ImageBlobId uniqueidentifier = null,
	@Name nvarchar(175),
	@Type tinyint = null,
	@TimeZoneId nvarchar(75),
	@ContactId int = null,
	@Notes nvarchar(max) = null,
	@City nvarchar(175) = null,
	@Latitude nvarchar(175) = null,
	@Longitude nvarchar(175) = null,


	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [Locations]
		(
			[ImageBlobId],
			[Name],
			[Type],
			[TimeZoneId],
			[ContactId],
			[Notes],
			[City],
			[Latitude],
			[Longitude] 
		)
		VALUES
		(
			@ImageBlobId,
			@Name,
			@Type,
			@TimeZoneId,
			@ContactId,
			@Notes,
			@City,
			@Latitude, 
			@Longitude 
		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[LocationsSearch]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LocationsSearch]
	@Query nvarchar(100)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		L.*,
		B.*,
		C.*
	FROM
		[dbo].[DataSearchView] S
		INNER JOIN [dbo].[Locations] L ON (L.Id = S.Id)
		LEFT JOIN [dbo].[Blobs] B ON (B.Id = L.ImageBlobId)
		LEFT JOIN [dbo].[Contacts] C ON (C.Id = L.ContactId)		
	WHERE
		L.[IsDeleted] = 0
		AND [S].[Type] = 2
		AND [S].[SearchData] LIKE '%' + @Query + '%'

END



GO
/****** Object:  StoredProcedure [dbo].[LocationsSelect]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LocationsSelect]

	@Id int = null,
	@IsDeleted bit = null

AS
BEGIN

	SELECT
		*
	FROM 
		Locations L
		LEFT JOIN Blobs B ON (B.Id = L.ImageBlobId)
		LEFT JOIN Contacts C ON (C.Id = L.ContactId)
	WHERE
		L.Id = CASE WHEN(@Id IS NULL) THEN L.Id ELSE @Id END
		AND L.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN L.IsDeleted ELSE @IsDeleted END
	ORDER BY
		L.Id
					
END


GO
/****** Object:  StoredProcedure [dbo].[LocationsUpdate]    ******/
IF (OBJECT_ID('[dbo].[LocationsUpdate]') IS NOT NULL)
 DROP PROCEDURE [dbo].[LocationsUpdate]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LocationsUpdate]

	@Id int,
	@ImageBlobId uniqueidentifier = null,
	@Name nvarchar(175),
	@Type tinyint = null,
	@TimeZoneId nvarchar(75),
	@ContactId int = null,
	@Notes nvarchar(max) = null,
	@City nvarchar(175) = null,
	@Latitude nvarchar(175) = null, 
	@Longitude nvarchar(175) = null, 

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		-- UPDATE ENTITY

		UPDATE
			[Locations]
		SET
			[ImageBlobId] = @ImageBlobId,
			[Name] = @Name,
			[Type] = @Type,
			[TimeZoneId] = @TimeZoneId,
			[ContactId] = @ContactId,
			[Notes] = @Notes,
			[City] = @City,
			[Latitude] = @Latitude, 
			[Longitude] = @Longitude

		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[LogsInsert]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LogsInsert]

	@Type nvarchar(50),
	@Message nvarchar(max),
	@Properties nvarchar(max)
	
AS
BEGIN

	-- INSERT LOG

	INSERT INTO [Logs]
	(
		[Type],
		[Message],
		[Properties]
	)
		VALUES
	(
		@Type,
		@Message,
		@Properties
	)
	
END


GO
/****** Object:  StoredProcedure [dbo].[LogsSelect]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LogsSelect]

	@Id int = null,
	@Top int = 1000

AS
BEGIN

	SELECT TOP(@Top)
		*
	FROM 
		[Logs] L
	WHERE
		L.Id = CASE WHEN(@Id IS NULL) THEN L.Id ELSE @Id END
	ORDER BY
		[UTCCreation] DESC
					
END


GO
/****** Object:  StoredProcedure [dbo].[UserClaimsCleanup]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserClaimsCleanup]

	@UserId int

AS
BEGIN

	DELETE FROM
		[UserClaims]
	WHERE
		UserId = @UserId
					
END


GO
/****** Object:  StoredProcedure [dbo].[UserClaimsInsert]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserClaimsInsert]

	@Realm tinyint,
	@UserId int,
	@ClaimType nvarchar(max),
	@ClaimValue nvarchar(max),

	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [UserClaims] 
		(
			Realm,
			UserId, 
			ClaimType, 
			ClaimValue
		) 
		VALUES
		(
			@Realm,
			@UserId, 
			@ClaimType, 
			@ClaimValue
		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE();
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[UserRolesCleanup]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserRolesCleanup]

	@UserId int

AS
BEGIN

	DELETE FROM
		[UserRoles]
	WHERE
		UserId = @UserId
					
END


GO
/****** Object:  StoredProcedure [dbo].[UserRolesInsert]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserRolesInsert]

	@UserId int,
	@Role nvarchar(128),

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		-- INSERT ENTITY

		INSERT INTO [UserRoles] 
		(
			UserId, 
			[Role]
		) 
		VALUES
		(
			@UserId, 
			@Role
		)

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE();
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[UsersDelete]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsersDelete]

	@Id int = null

AS
BEGIN

	UPDATE 
		[Users]
	SET 
		IsDeleted = 1
	WHERE
		[Id] = @Id
					
END


GO
/****** Object:  StoredProcedure [dbo].[UsersInsert]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsersInsert]

	@LockoutEnabled bit,
	@PasswordHash nvarchar(max) = null,
	@SecurityStamp nvarchar(max) = null,
	@UserName nvarchar(20),
	@Email nvarchar(255),
	@Realm tinyint,
	@Name nvarchar(175),
	@Gender tinyint,
	@ImageBlobId uniqueidentifier = null,
	@Biography nvarchar(max) = null,

	@CurrentCultureId nvarchar(10) = null,
	@CurrentUICultureId nvarchar(10) = null,
	@TimeZoneId nvarchar(75) = null,

	-- Output
	@EntityId int output,
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY
		
		SET @EntityId = 0

		-- INSERT ENTITY

		INSERT INTO [Users]
		(
			[LockoutEnabled],
			[PasswordHash],
			[SecurityStamp],
			[UserName],
			[Email],
			[Realm],
			[Name],
			[Gender],
			[ImageBlobId],
			[Biography],
			[CurrentCultureId],
			[CurrentUICultureId],
			[TimeZoneId]
		)
		VALUES
		(
			@LockoutEnabled,
			@PasswordHash,
			@SecurityStamp,
			@UserName,
			@Email,
			@Realm,
			@Name,
			@Gender,
			@ImageBlobId,
			@Biography,
			@CurrentCultureId,
			@CurrentUICultureId,
			@TimeZoneId
		)

		SET @EntityId = SCOPE_IDENTITY()

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[UsersSearch]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsersSearch]

	@Query nvarchar(100)

AS
BEGIN

	SET NOCOUNT ON;

	-- Returns a multi result set with the users related data

	DECLARE @UserIds TABLE (UserId int)

	INSERT INTO @UserIds
		SELECT
			S.Id
		FROM 
			[dbo].[DataSearchView] S
			INNER JOIN [dbo].[Users] U ON (U.Id = S.Id)
		WHERE 
			U.[IsDeleted] = 0
			AND [S].[Type] = 4
			AND [S].[SearchData] LIKE '%' + @Query + '%'

	-- Users
	SELECT
		*
	FROM
		[Users] U
		LEFT JOIN [Blobs] B ON (B.Id = U.ImageBlobId)
	WHERE
		U.Id IN (SELECT UserId FROM @UserIds)
	ORDER BY
		U.Id

	-- Claims
	SELECT
		*
	FROM
		[UserClaims] UC
	WHERE
		UC.UserId IN (SELECT UserId FROM @UserIds)

	-- Roles
	SELECT
		UR.*
	FROM
		[UserRoles] UR
	WHERE
		UR.UserId IN (SELECT UserId FROM @UserIds)

END



GO
/****** Object:  StoredProcedure [dbo].[UsersSelect]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsersSelect]

	@Id int = null,
	@Email nvarchar(255) = null,
	@UserName nvarchar(20) = null,
	@IsDeleted bit = null

AS
BEGIN

	-- Returns a multi result set with the users related data

	DECLARE @UserIds TABLE (UserId int)

	INSERT INTO @UserIds
		SELECT
			Id
		FROM 
			[Users] U
		WHERE 
			U.Id = CASE WHEN(@Id IS NULL) THEN U.Id ELSE @Id END
			AND U.Email = CASE WHEN(@Email IS NULL) THEN U.Email ELSE @Email END
			AND U.UserName = CASE WHEN(@UserName IS NULL) THEN U.UserName ELSE @UserName END
			AND U.IsDeleted = CASE WHEN(@IsDeleted IS NULL) THEN U.IsDeleted ELSE @IsDeleted END

	-- Users
	SELECT
		*
	FROM
		[Users] U
		LEFT JOIN [Blobs] B ON (B.Id = U.ImageBlobId)
	WHERE
		U.Id IN (SELECT UserId FROM @UserIds)
	ORDER BY
		U.Id

	-- Claims
	SELECT
		*
	FROM
		[UserClaims] UC
	WHERE
		UC.UserId IN (SELECT UserId FROM @UserIds)

	-- Roles
	SELECT
		UR.*
	FROM
		[UserRoles] UR
	WHERE
		UR.UserId IN (SELECT UserId FROM @UserIds)
					
END


GO
/****** Object:  StoredProcedure [dbo].[UsersUpdateIdentity]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsersUpdateIdentity]

	@Id int,
	@IsDeleted bit,
	@EmailConfirmed bit,
	@LockoutEnabled bit,
	@TwoFactorEnabled bit,
	@MobilePhoneConfirmed bit,
	@LockoutEndDateUtc datetimeoffset(7) = null,
	@AccessFailedCount tinyint,
	@PasswordHash nvarchar(max) = null,
	@SecurityStamp nvarchar(max) = null,
	@UserName nvarchar(20),
	@Email nvarchar(255),
	@Realm tinyint,
	@Name nvarchar(175),
	@Gender tinyint,
	@ImageBlobId uniqueidentifier = null,
	@MobilePhone nvarchar(100) = null,
	@Biography nvarchar(max) = null,
	@GitHubLink nvarchar(200) = null,
	@TwitterLink nvarchar(200) = null,
	@LinkedInLink nvarchar(200) = null,
	@FacebookLink nvarchar(200) = null,
	@InstagramLink nvarchar(200) = null,
	@CurrentCultureId nvarchar(10),
	@CurrentUICultureId nvarchar(10),
	@TimeZoneId nvarchar(75),
	@AutoLockScreenInMinutes tinyint,
	@StatusMessage nvarchar(140) = null,

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		UPDATE
			[Users]
		SET
			[IsDeleted] = @IsDeleted,
			[EmailConfirmed] = @EmailConfirmed,
			[LockoutEnabled] = @LockoutEnabled,
			[TwoFactorEnabled] = @TwoFactorEnabled,
			[MobilePhoneConfirmed] = @MobilePhoneConfirmed,
			[LockoutEndDateUtc] = @LockoutEndDateUtc,
			[AccessFailedCount] = @AccessFailedCount,
			[PasswordHash] = @PasswordHash,
			[SecurityStamp] = @SecurityStamp,
			[UserName] = @UserName,
			[Email] = @Email,
			[Realm] = @Realm,
			[Name] = @Name,
			[Gender] = @Gender,
			[ImageBlobId] = @ImageBlobId,
			[MobilePhone] = @MobilePhone,
			[Biography] = @Biography,
			[GitHubLink] = @GitHubLink,
			[TwitterLink] = @TwitterLink,
			[LinkedInLink] = @LinkedInLink,
			[FacebookLink] = @FacebookLink,
			[InstagramLink] = InstagramLink,
			[CurrentCultureId] = @CurrentCultureId,
			[CurrentUICultureId] = @CurrentUICultureId,
			[TimeZoneId] = @TimeZoneId,
			[AutoLockScreenInMinutes] = @AutoLockScreenInMinutes,
			[StatusMessage] = @StatusMessage
		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END


GO
/****** Object:  StoredProcedure [dbo].[UsersUpdateProfile]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsersUpdateProfile]

	@Id int,
	@Name nvarchar(175),
	@Email nvarchar(255),
	@Gender tinyint,
	@UserName nvarchar(20),
	@ImageBlobId uniqueidentifier = null,
	@Biography nvarchar(max) = null,
	@GitHubLink nvarchar(200) = null,
	@TwitterLink nvarchar(200) = null,
	@LinkedInLink nvarchar(200) = null,
	@FacebookLink nvarchar(200) = null,
	@InstagramLink nvarchar(200) = null,

	@CurrentCultureId nvarchar(10),
	@CurrentUICultureId nvarchar(10),
	@TimeZoneId nvarchar(75),
	
	@AutoLockScreenInMinutes tinyint,

	@StatusMessage nvarchar(140) = null,

	-- Output
	@ErrorMessage nvarchar(1000) output
	
AS
BEGIN

	BEGIN TRY

		-- UPDATE ENTITY

		UPDATE
			[Users]
		SET
			[Name] = @Name,
			[Email] = @Email,
			[Gender] = @Gender,
			[UserName] = @UserName,
			[ImageBlobId] = @ImageBlobId,
			[Biography] = @Biography,
			[GitHubLink] = @GitHubLink,
			[TwitterLink] = @TwitterLink,
			[LinkedInLink] = @LinkedInLink,
			[FacebookLink] = @FacebookLink,
			[InstagramLink] = @InstagramLink,

			[CurrentCultureId] = @CurrentCultureId,
			[CurrentUICultureId] = @CurrentUICultureId,
			[TimeZoneId] = @TimeZoneId,

			[AutoLockScreenInMinutes] = @AutoLockScreenInMinutes,

			[StatusMessage] = @StatusMessage

		WHERE
			Id = @Id

	END TRY
	BEGIN CATCH
	  
	  SET @ErrorMessage = ERROR_MESSAGE()
	  
	END CATCH  
	
END

GO




-----------------------





INSERT INTO [Users]
(
	[LockoutEnabled],
	[PasswordHash],
	[SecurityStamp],
	[UserName],
	[Email],
	[Realm],
	[Name],
	[Gender],
	[ImageBlobId],
	[Biography]
)
	VALUES
(
	0,
	'AINCgbCLUSYjSnDrVGtCJCNphNWOAtcGScdSIOXYpGoezJoyFBEuZ7cTq3jpdVCEwg==', /*password*/
	'79df49ad-983c-4680-8cd7-15c2058fd8e3',
	'admin',
	'admin@sibur.ru',
	0,
	'Sibur Admin',
	0,
	null,
	'This is the demonstration user biography.'
)
GO

INSERT INTO UserRoles ([UserId], [Role]) Values (SCOPE_IDENTITY(), 'Admin')
GO











