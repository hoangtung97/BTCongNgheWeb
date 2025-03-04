USE [master]
GO
/****** Object:  Database [ChatWebsite]    Script Date: 12/27/2019 10:00:30 AM ******/
CREATE DATABASE [ChatWebsite]
 
USE [ChatWebsite]
GO
/****** Object:  Table [dbo].[ChatRoom]    Script Date: 12/27/2019 10:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatRoom](
	[RoomID] [int] NOT NULL,
	[RoomName] [nvarchar](50) NULL,
	[RoomAdmin] [int] NULL,
	[RoomPW] [char](32) NULL,
 CONSTRAINT [PK__ChatRoom__328639196F73F1F0] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conversations]    Script Date: 12/27/2019 10:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conversations](
	[RoomID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[_Time] [datetime] NOT NULL,
	[Content] [nvarchar](200) NULL,
 CONSTRAINT [Conv_PK] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC,
	[UserID] ASC,
	[_Time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room_Users]    Script Date: 12/27/2019 10:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room_Users](
	[RoomID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Socket] [char](50) NULL,
	[AdminRight] [bit] NULL,
 CONSTRAINT [Room_Users_PK] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/27/2019 10:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[Password_] [char](32) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Sex] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
 CONSTRAINT [PK__Users__1788CCACCF850414] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (1, N'ass', N'asssd', N'd                               ', NULL, NULL, NULL)
ALTER TABLE [dbo].[ChatRoom]  WITH CHECK ADD  CONSTRAINT [FK__ChatRoom__RoomAd__3A4CA8FD] FOREIGN KEY([RoomAdmin])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ChatRoom] CHECK CONSTRAINT [FK__ChatRoom__RoomAd__3A4CA8FD]
GO
ALTER TABLE [dbo].[Conversations]  WITH CHECK ADD  CONSTRAINT [FK__Conversat__RoomI__3E52440B] FOREIGN KEY([RoomID])
REFERENCES [dbo].[ChatRoom] ([RoomID])
GO
ALTER TABLE [dbo].[Conversations] CHECK CONSTRAINT [FK__Conversat__RoomI__3E52440B]
GO
ALTER TABLE [dbo].[Conversations]  WITH CHECK ADD  CONSTRAINT [FK__Conversat__UserI__2739D489] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Conversations] CHECK CONSTRAINT [FK__Conversat__UserI__2739D489]
GO
ALTER TABLE [dbo].[Room_Users]  WITH CHECK ADD  CONSTRAINT [FK__Room_User__RoomI__06CD04F7] FOREIGN KEY([RoomID])
REFERENCES [dbo].[ChatRoom] ([RoomID])
GO
ALTER TABLE [dbo].[Room_Users] CHECK CONSTRAINT [FK__Room_User__RoomI__06CD04F7]
GO
ALTER TABLE [dbo].[Room_Users]  WITH CHECK ADD  CONSTRAINT [FK__Room_User__UserI__07C12930] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Room_Users] CHECK CONSTRAINT [FK__Room_User__UserI__07C12930]
GO
/****** Object:  StoredProcedure [dbo].[Log_In]    Script Date: 12/27/2019 10:00:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Log_In]( @username nvarchar(50), @password char(32) )
as
begin
	set nocount on;
	declare @userid int

	select @userid = UserID from dbo.Users
	where Username = @username and Password_ = @password

	if @userid is not null
	begin
		select @userID[UserID] 
	end
	else
	begin
		select -1
	end
end
GO
USE [master]
GO
ALTER DATABASE [ChatWebsite] SET  READ_WRITE 
GO
