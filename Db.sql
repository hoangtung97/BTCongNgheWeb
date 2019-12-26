USE [master]
GO
/****** Object:  Database [ChatWebsite]    Script Date: 26-Dec-19 1:43:49 PM ******/
CREATE DATABASE [ChatWebsite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChatWebsite', FILENAME = N'F:\4th Year Projects\Web Technology\WebApp\BTCongngheWeb\ChatWebsite.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChatWebsite_log', FILENAME = N'F:\4th Year Projects\Web Technology\WebApp\BTCongngheWeb\ChatWebsite_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ChatWebsite] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChatWebsite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChatWebsite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChatWebsite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChatWebsite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChatWebsite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChatWebsite] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChatWebsite] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChatWebsite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChatWebsite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChatWebsite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChatWebsite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChatWebsite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChatWebsite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChatWebsite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChatWebsite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChatWebsite] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChatWebsite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChatWebsite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChatWebsite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChatWebsite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChatWebsite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChatWebsite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChatWebsite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChatWebsite] SET RECOVERY FULL 
GO
ALTER DATABASE [ChatWebsite] SET  MULTI_USER 
GO
ALTER DATABASE [ChatWebsite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChatWebsite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChatWebsite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChatWebsite] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChatWebsite] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ChatWebsite', N'ON'
GO
ALTER DATABASE [ChatWebsite] SET QUERY_STORE = OFF
GO
USE [ChatWebsite]
GO
/****** Object:  Table [dbo].[ChatRoom]    Script Date: 26-Dec-19 1:43:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatRoom](
	[RoomID] [int] NOT NULL,
	[RoomName] [nvarchar](50) NULL,
	[RoomAdmin] [int] NULL,
	[RoomPW] [char](16) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conversations]    Script Date: 26-Dec-19 1:43:50 PM ******/
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
/****** Object:  Table [dbo].[Room_Users]    Script Date: 26-Dec-19 1:43:50 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 26-Dec-19 1:43:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[Password_] [char](16) NOT NULL,
	[Avatar] [varbinary](max) NULL,
	[Sex] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ChatRoom] ([RoomID], [RoomName], [RoomAdmin], [RoomPW]) VALUES (1, N'BullShiters', 1, NULL)
INSERT [dbo].[ChatRoom] ([RoomID], [RoomName], [RoomAdmin], [RoomPW]) VALUES (2, N'Phiuk Yu', 1, NULL)
INSERT [dbo].[ChatRoom] ([RoomID], [RoomName], [RoomAdmin], [RoomPW]) VALUES (3, N'DumbShiet', 1, NULL)
INSERT [dbo].[ChatRoom] ([RoomID], [RoomName], [RoomAdmin], [RoomPW]) VALUES (4, N'LMAO', 1, N'123             ')
INSERT [dbo].[ChatRoom] ([RoomID], [RoomName], [RoomAdmin], [RoomPW]) VALUES (5, N'PhanNgu', 2, N'123             ')
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
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (1, N'hieu', N'MinhHieu', N'123             ', NULL, N'Nam', CAST(N'1998-10-20' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (2, N'phan', N'PhanLon', N'123             ', NULL, N'Nam', CAST(N'1998-05-20' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (3, N'tung', N'TungNguLol', N'123             ', NULL, N'Nam', CAST(N'1998-04-25' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (4, N'minh', N'TrieuMinh', N'123             ', NULL, N'Nam', CAST(N'1998-06-12' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (5, N'mars', N'Mars', N'123             ', NULL, N'Nam', CAST(N'2000-03-25' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (6, N'cm', N'CrystalMaiden', N'123             ', NULL, N'Nữ', CAST(N'2003-06-14' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (7, N'drow', N'Traxex ', N'123             ', NULL, N'Khác', CAST(N'1995-12-01' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (8, N'phanngu', N'Phan Ngu', N'123             ', NULL, N'Nữ', CAST(N'2019-12-04' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (9, N'juggy', N'Juggernaut', N'123             ', NULL, N'Không xác định', CAST(N'1951-11-16' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (10, N'sven', N'Rogue Knight', N'123             ', NULL, N'Nam', CAST(N'2019-12-02' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (11, N'axe', N'Axe', N'123             ', NULL, N'Nam', CAST(N'2017-06-14' AS Date))
INSERT [dbo].[Users] ([UserID], [Username], [DisplayName], [Password_], [Avatar], [Sex], [DateOfBirth]) VALUES (12, N'lina', N'Lina', N'123             ', NULL, N'Nữ', CAST(N'2009-07-16' AS Date))
ALTER TABLE [dbo].[ChatRoom]  WITH CHECK ADD  CONSTRAINT [FK__ChatRoom__RoomAd__3A4CA8FD] FOREIGN KEY([RoomAdmin])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[ChatRoom] CHECK CONSTRAINT [FK__ChatRoom__RoomAd__3A4CA8FD]
GO
ALTER TABLE [dbo].[Conversations]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[ChatRoom] ([RoomID])
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
/****** Object:  StoredProcedure [dbo].[Log_In]    Script Date: 26-Dec-19 1:43:54 PM ******/
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
