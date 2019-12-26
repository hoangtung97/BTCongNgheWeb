USE [master]
GO
/****** Object:  Database [ChatWebsite]    Script Date: 12/26/2019 9:42:47 PM ******/
CREATE DATABASE [ChatWebsite]
 CONTAINMENT = NONE

USE [ChatWebsite]
GO
/****** Object:  Table [dbo].[ChatRoom]    Script Date: 12/26/2019 9:42:48 PM ******/
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
/****** Object:  Table [dbo].[Conversations]    Script Date: 12/26/2019 9:42:48 PM ******/
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
/****** Object:  Table [dbo].[Room_Users]    Script Date: 12/26/2019 9:42:48 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 12/26/2019 9:42:48 PM ******/
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
INSERT [dbo].[ChatRoom] ([RoomID], [RoomName], [RoomAdmin], [RoomPW]) VALUES (1, N'BullShiters', 1, NULL)
INSERT [dbo].[ChatRoom] ([RoomID], [RoomName], [RoomAdmin], [RoomPW]) VALUES (2, N'Phiuk Yu', 1, NULL)
INSERT [dbo].[ChatRoom] ([RoomID], [RoomName], [RoomAdmin], [RoomPW]) VALUES (3, N'DumbShiet', 1, NULL)
INSERT [dbo].[ChatRoom] ([RoomID], [RoomName], [RoomAdmin], [RoomPW]) VALUES (4, N'LMAO', 1, N'123                             ')
INSERT [dbo].[ChatRoom] ([RoomID], [RoomName], [RoomAdmin], [RoomPW]) VALUES (5, N'PhanNgu', 2, N'123                             ')
INSERT [dbo].[Conversations] ([RoomID], [UserID], [_Time], [Content]) VALUES (1, 1, CAST(N'2019-12-18T08:40:35.307' AS DateTime), N'gsrgrgrgedr
')
INSERT [dbo].[Conversations] ([RoomID], [UserID], [_Time], [Content]) VALUES (2, 1, CAST(N'2019-12-18T14:48:21.880' AS DateTime), N'gwsuhgirugh')
INSERT [dbo].[Conversations] ([RoomID], [UserID], [_Time], [Content]) VALUES (2, 1, CAST(N'2019-12-18T14:48:29.000' AS DateTime), N'hedrhret')
INSERT [dbo].[Conversations] ([RoomID], [UserID], [_Time], [Content]) VALUES (3, 2, CAST(N'2019-12-19T14:28:09.880' AS DateTime), N'cakkkkk')
INSERT [dbo].[Conversations] ([RoomID], [UserID], [_Time], [Content]) VALUES (4, 2, CAST(N'2019-12-19T22:48:56.080' AS DateTime), N'cakcakcakcka')
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (1, 1, NULL, 1)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (1, 2, NULL, 0)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (1, 5, NULL, 0)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (2, 1, NULL, 1)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (2, 3, NULL, 0)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (2, 4, NULL, 0)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (3, 1, NULL, 1)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (3, 3, NULL, 0)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (3, 4, NULL, 0)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (4, 1, NULL, 1)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (4, 2, NULL, 0)
INSERT [dbo].[Room_Users] ([RoomID], [UserID], [Socket], [AdminRight]) VALUES (5, 2, NULL, 1)
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (1, N'hieu', N'MinhHieu', N'123                             ', N'https://previews.123rf.com/images/nikiteev/nikiteev1810/nikiteev181000032/110071024-vector-single-cartoon-illustration-the-letter-h.jpg', N'Nam', CAST(N'1998-10-20' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (2, N'phan', N'PhanLon', N'123                             ', N'https://previews.123rf.com/images/nikiteev/nikiteev1810/nikiteev181000057/110071440-vector-single-cartoon-illustration-the-letter-p.jpg', N'Nam', CAST(N'1998-05-20' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (3, N'tung', N'TungNguLol', N'123                             ', N'https://st4.depositphotos.com/2485347/21852/v/1600/depositphotos_218525338-stock-illustration-single-cartoon-ice-blue-letter.jpg', N'Nam', CAST(N'1998-04-25' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (4, N'minh', N'TrieuMinh', N'123                             ', N'https://previews.123rf.com/images/nikiteev/nikiteev1810/nikiteev181000009/110070842-vector-single-cartoon-illustration-ice-blue-letter-m.jpg', N'Nam', CAST(N'1998-06-12' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (5, N'mars', N'Mars', N'123                             ', N'https://i.stack.imgur.com/l60Hf.png', N'Nam', CAST(N'2000-03-25' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (6, N'cm', N'CrystalMaiden', N'123                             ', N'https://i.stack.imgur.com/l60Hf.png', N'Nữ', CAST(N'2003-06-14' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (7, N'drow', N'Traxex ', N'123                             ', N'https://i.stack.imgur.com/l60Hf.png', N'Khác', CAST(N'1995-12-01' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (8, N'phanngu', N'Phan Ngu', N'123                             ', N'https://i.stack.imgur.com/l60Hf.png', N'Nữ', CAST(N'2019-12-04' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (9, N'juggy', N'Juggernaut', N'123                             ', N'https://i.stack.imgur.com/l60Hf.png', N'Không xác định', CAST(N'1951-11-16' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (10, N'sven', N'Rogue Knight', N'123                             ', N'https://i.stack.imgur.com/l60Hf.png', N'Nam', CAST(N'2019-12-02' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (11, N'axe', N'Axe', N'123                             ', N'https://i.stack.imgur.com/l60Hf.png', N'Nam', CAST(N'2017-06-14' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (12, N'lina', N'Lina', N'123                             ', N'https://i.stack.imgur.com/l60Hf.png', N'Nữ', CAST(N'2009-07-16' AS Date))
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
/****** Object:  StoredProcedure [dbo].[Log_In]    Script Date: 12/26/2019 9:42:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Log_In]( @username nvarchar(50), @password char(16) )
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
