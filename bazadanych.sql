USE [master]
GO
/****** Object:  Database [MoveYourBumDatabase]    Script Date: 25.06.2023 19:40:41 ******/
CREATE DATABASE [MoveYourBumDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MoveYourBumDatabase', FILENAME = N'C:\Users\micha\MoveYourBumDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MoveYourBumDatabase_log', FILENAME = N'C:\Users\micha\MoveYourBumDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MoveYourBumDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MoveYourBumDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MoveYourBumDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MoveYourBumDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MoveYourBumDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MoveYourBumDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MoveYourBumDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MoveYourBumDatabase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MoveYourBumDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MoveYourBumDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [MoveYourBumDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MoveYourBumDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MoveYourBumDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MoveYourBumDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MoveYourBumDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MoveYourBumDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MoveYourBumDatabase] SET QUERY_STORE = OFF
GO
USE [MoveYourBumDatabase]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25.06.2023 19:40:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Day]    Script Date: 25.06.2023 19:40:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Day](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NULL,
	[Notes] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DaySchedule]    Script Date: 25.06.2023 19:40:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaySchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDay] [int] NOT NULL,
	[IdSchedule] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_DaySchedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exercise]    Script Date: 25.06.2023 19:40:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exercise](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ProperTechniqueDescription] [nvarchar](max) NULL,
	[MuscleInvolvedDescription] [nvarchar](max) NULL,
	[IdExerciseType] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Exercise] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExercisePhoto]    Script Date: 25.06.2023 19:40:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExercisePhoto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[FileUrl] [nvarchar](max) NOT NULL,
	[IdExercise] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_ExercisePhoto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseType]    Script Date: 25.06.2023 19:40:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_ExerciseType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 25.06.2023 19:40:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleExercise]    Script Date: 25.06.2023 19:40:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleExercise](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Annotation] [nvarchar](max) NULL,
	[IdSchedule] [int] NOT NULL,
	[IdExercise] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_ScheduleExercise] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleExerciseSet]    Script Date: 25.06.2023 19:40:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleExerciseSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlannedReps] [nvarchar](max) NULL,
	[ActualReps] [nvarchar](max) NULL,
	[WeightUsed] [nvarchar](max) NULL,
	[IdScheduleExercise] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[IdDaySchedule] [int] NULL,
 CONSTRAINT [PK_ScheduleExerciseSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230613202704_initial', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230618214406_M1', N'6.0.18')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230618214903_M2', N'6.0.18')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230618215510_M3', N'6.0.18')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230618233137_M4', N'6.0.18')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230619181444_M5', N'6.0.18')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230624095453_M6', N'6.0.18')
GO
SET IDENTITY_INSERT [dbo].[Day] ON 

INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (1, CAST(N'2023-06-20T00:00:00.0000000' AS DateTime2), N'dzień ttt', 0, CAST(N'2023-06-21T00:00:00.0000000' AS DateTime2), CAST(N'2023-06-21T23:43:14.1676559' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (2, CAST(N'2023-06-21T00:00:00.0000000' AS DateTime2), N'dzień nóg', 0, CAST(N'2023-06-21T23:38:27.9714793' AS DateTime2), CAST(N'2023-06-22T21:33:27.8713775' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (3, CAST(N'2023-06-22T23:43:37.6740480' AS DateTime2), N'trening fbw', 1, CAST(N'2023-06-21T23:43:37.6740480' AS DateTime2), CAST(N'2023-06-22T21:33:37.1193459' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (4, CAST(N'2023-06-26T00:00:00.0000000' AS DateTime2), N'tt', 0, CAST(N'2023-06-22T00:04:22.8359665' AS DateTime2), CAST(N'2023-06-22T00:04:22.8360378' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, CAST(N'2023-03-08T00:00:00.0000000' AS DateTime2), N'z', 0, CAST(N'2023-06-22T00:04:33.0223645' AS DateTime2), CAST(N'2023-06-22T00:04:33.0223670' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (6, CAST(N'2022-06-24T00:00:00.0000000' AS DateTime2), N'g', 0, CAST(N'2023-06-22T00:04:41.7533383' AS DateTime2), CAST(N'2023-06-22T00:04:41.7533410' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (7, CAST(N'2024-06-22T00:00:00.0000000' AS DateTime2), N'', 0, CAST(N'2023-06-22T00:04:48.5662999' AS DateTime2), CAST(N'2023-06-22T00:04:48.5663025' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (8, CAST(N'2023-06-20T00:00:00.0000000' AS DateTime2), N'lekki trening', 1, CAST(N'2023-06-22T23:37:19.4650507' AS DateTime2), CAST(N'2023-06-22T23:37:19.4651158' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (9, CAST(N'2023-06-17T00:00:00.0000000' AS DateTime2), N'dzień rąk', 0, CAST(N'2023-06-23T00:46:12.6075991' AS DateTime2), CAST(N'2023-06-23T01:03:20.3845810' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (10, CAST(N'2023-06-17T00:00:00.0000000' AS DateTime2), N'dzień nóg', 1, CAST(N'2023-06-23T01:04:40.9387488' AS DateTime2), CAST(N'2023-06-24T20:05:05.3444347' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (11, CAST(N'2023-06-24T00:00:00.0000000' AS DateTime2), N'trening rąk', 0, CAST(N'2023-06-24T20:15:16.6878143' AS DateTime2), CAST(N'2023-06-24T20:15:16.6878164' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (12, CAST(N'2023-06-24T00:00:00.0000000' AS DateTime2), N'trening rąk', 1, CAST(N'2023-06-24T20:15:38.2143653' AS DateTime2), CAST(N'2023-06-24T20:15:38.2143672' AS DateTime2))
INSERT [dbo].[Day] ([Id], [Date], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (13, CAST(N'2022-06-28T00:00:00.0000000' AS DateTime2), N'spokojny trening', 0, CAST(N'2023-06-25T19:37:02.9723529' AS DateTime2), CAST(N'2023-06-25T19:39:15.7904337' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Day] OFF
GO
SET IDENTITY_INSERT [dbo].[DaySchedule] ON 

INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (1, 3, 1, 1, CAST(N'2023-06-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-06-24T01:50:44.8889656' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (2, 3, 3, 1, CAST(N'2023-06-22T22:23:12.7572876' AS DateTime2), CAST(N'2023-06-22T22:23:12.7574586' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, 8, 1, 1, CAST(N'2023-06-22T23:40:35.2004509' AS DateTime2), CAST(N'2023-06-22T23:40:35.2084500' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (6, 8, 1, 0, CAST(N'2023-06-22T23:40:42.4758506' AS DateTime2), CAST(N'2023-06-22T23:40:42.4758562' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (7, 9, 6, 1, CAST(N'2023-06-23T00:47:33.0077854' AS DateTime2), CAST(N'2023-06-23T00:47:33.0077907' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (8, 9, 3, 1, CAST(N'2023-06-23T00:51:00.1390628' AS DateTime2), CAST(N'2023-06-23T00:51:00.1392195' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (9, 9, 3, 1, CAST(N'2023-06-23T01:04:00.2874004' AS DateTime2), CAST(N'2023-06-23T01:04:00.2874041' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (10, 9, 6, 1, CAST(N'2023-06-23T01:04:09.8654236' AS DateTime2), CAST(N'2023-06-23T01:04:09.8654292' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (11, 10, 6, 1, CAST(N'2023-06-23T01:04:49.8456291' AS DateTime2), CAST(N'2023-06-23T01:04:49.8456346' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (12, 10, 3, 1, CAST(N'2023-06-23T20:06:29.2964757' AS DateTime2), CAST(N'2023-06-23T20:31:27.7305176' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (13, 10, 1, 0, CAST(N'2023-06-23T20:06:44.0093787' AS DateTime2), CAST(N'2023-06-23T20:06:44.0093839' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (14, 8, 7, 1, CAST(N'2023-06-23T23:52:00.2819644' AS DateTime2), CAST(N'2023-06-23T23:52:00.2819696' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (15, 10, 7, 1, CAST(N'2023-06-24T01:38:00.2921195' AS DateTime2), CAST(N'2023-06-24T01:38:00.2922723' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (16, 12, 6, 1, CAST(N'2023-06-24T20:15:47.3316029' AS DateTime2), CAST(N'2023-06-24T20:15:47.3316082' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (17, 12, 3, 1, CAST(N'2023-06-24T20:16:02.1953469' AS DateTime2), CAST(N'2023-06-24T20:16:02.1953522' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (18, 13, 9, 1, CAST(N'2023-06-25T19:37:32.4661341' AS DateTime2), CAST(N'2023-06-25T19:37:32.4661376' AS DateTime2))
INSERT [dbo].[DaySchedule] ([Id], [IdDay], [IdSchedule], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (19, 13, 8, 0, CAST(N'2023-06-25T19:37:38.8199327' AS DateTime2), CAST(N'2023-06-25T19:37:38.8199382' AS DateTime2))
SET IDENTITY_INSERT [dbo].[DaySchedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Exercise] ON 

INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (1, N'Uginanie przedramion młotkowo', N'stojąc lub siedząc', N'Złap sztangielki podchwytem w pozycji stojącej, Nadgarstki ustaw w chwycie młotkowym, czyli w taki sposób, że palce są skierowane w stronę ciała. Wypnij klatkę piersiową do przodu. Weź wdech i zacznij zginanie przedramion, trzymając łokcie przez cały czas jak najbliżej ciała. W momencie maksymalnego napięcia mięśni zrób wydech i powoli kontrolując ciężar powróć do pozycji wyjściowej, czyli do momentu maksymalnego rozciągnięcia mięśni, jednocześnie robiąc wdech.', N'Główne mięśnie biorące udział w ćwiczeniu: ramienno-promieniowy', 1, 1, CAST(N'2023-06-17T00:00:00.0000000' AS DateTime2), CAST(N'2023-06-19T21:59:20.3750432' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (2, N'q', N'w', N'e', N'r', 2, 0, CAST(N'2023-06-18T00:04:26.6602332' AS DateTime2), CAST(N'2023-06-18T00:04:26.6603897' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (3, N'Wykroki', N'ze sztangą', N'Pozycja startowa jest podobna jak podczas przysiadów, czyli klatka wypięta, a łopatki ściągnięte. Podczas całego ćwiczenia zachowuj naturalną krzywiznę kręgosłupa. Weź wdech i jedną z nóg wykonaj krok do przodu. Następnie nogą wykroczną wykonaj przysiad w taki sposób, aby noga ugięła się pod kątem 90 stopni. Kolano nogi niećwiczonej powinno prawie dotykać podłoża, a jej stopa dotyka podłoża jedynie palcami. Stopa nogi wykrocznej całkowicie przylega do podłoża. Powróć do pozycji wyjściowej wypychając ciężar przez odepchnięcie od podłoża (głównie przez pięty) i robiąc jednocześnie wydech. Powtórz zaczynając tym razem od innej nogi.', N'Główne mięśnie biorące udział w ćwiczeniu: czworogłowe uda', 2, 1, CAST(N'2023-06-18T00:05:28.8788207' AS DateTime2), CAST(N'2023-06-18T13:27:12.3426174' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (4, N'qq', N'ww', N'ee', N'rr', 2, 0, CAST(N'2023-06-18T00:35:54.7087557' AS DateTime2), CAST(N'2023-06-18T00:44:52.7479613' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, N'q', N'q', N'q', N'q', 2, 0, CAST(N'2023-06-18T00:45:02.4143147' AS DateTime2), CAST(N'2023-06-18T00:45:02.4143208' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (6, N'we', N'wr', N'wt', N'wy', 21, 0, CAST(N'2023-06-18T00:45:24.5299165' AS DateTime2), CAST(N'2023-06-18T00:45:30.5267722' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (7, N'Uginanie przedramion ze sztangą', N'nachwytem na modlitewniku', N'Usiądź na siedzisku modlitewnika (być może będziesz miał możliwość wyregulowania wysokości siedziska i oparcia), łokcie i ramiona ułóż na oparciu. Złap sztangę nachwytem na szerokość barków. Weź wdech i zacznij ruch zginania przedramion. W momencie maksymalnego napięcia mięśni zrób wydech i powoli kontrolując ciężar powróć do pozycji wyjściowej, czyli do momentu maksymalnego rozciągnięcia mięśni jednocześnie robiąc wdech.', N'Główne mięśnie biorące udział w ćwiczeniu: ramienno-promieniowy', 1, 1, CAST(N'2023-06-18T00:47:08.9791410' AS DateTime2), CAST(N'2023-06-18T21:36:09.7404268' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (8, N'Uginanie przedramienia ze sztangielką', N'w oparciu o kolano', N'Usiądź na ławeczce prostej i chwyć sztangielkę podchwytem. Łokieć umieść na wewnętrznej części uda. Weź wdech i zacznij ruch zginania przedramienia. W momencie maksymalnego napięcia mięśni zrób wydech i powoli kontrolując ciężar powróć do pozycji wyjściowej, czyli do momentu maksymalnego rozciągnięcia mięśni, jednocześnie robiąc wdech.', N'Główne mięśnie biorące udział w ćwiczeniu: ramienny', 1, 1, CAST(N'2023-06-18T00:47:45.2521468' AS DateTime2), CAST(N'2023-06-18T00:47:45.2521533' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (9, N'q', N'q', N'q', N'q', 5, 0, CAST(N'2023-06-18T01:32:16.5124592' AS DateTime2), CAST(N'2023-06-18T01:32:16.5126118' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (10, N'wew', N'qeewq', N'e', N'ewq', 2, 0, CAST(N'2023-06-18T13:27:17.2893552' AS DateTime2), CAST(N'2023-06-18T13:27:17.2893606' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (11, N't', N'y', N'u', N'i', 22, 0, CAST(N'2023-06-21T22:00:04.2493252' AS DateTime2), CAST(N'2023-06-21T22:00:04.2493308' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (12, N'c', N'', N'', N'', 5, 0, CAST(N'2023-06-21T23:22:56.9806894' AS DateTime2), CAST(N'2023-06-21T23:22:56.9806948' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (13, N'Przysiady', N'przysiądź', N'nogi pod kątem prostym', N'udowe, pośladki', 2, 1, CAST(N'2023-06-23T23:50:53.3019232' AS DateTime2), CAST(N'2023-06-23T23:50:53.3020726' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (14, N'tt', N't', N't', N'tt', 23, 0, CAST(N'2023-06-24T20:13:40.1845845' AS DateTime2), CAST(N'2023-06-24T20:13:40.1845911' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (15, N'Brzuszki', N'na ławeczce lub podłodze', N'zegnij się pod katem 30 stopni', N'brzucha', 4, 1, CAST(N'2023-06-25T19:29:46.5019263' AS DateTime2), CAST(N'2023-06-25T19:34:02.9263472' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (16, N'yt', N'ytr', N'yt', N't', 4, 0, CAST(N'2023-06-25T19:30:16.9914439' AS DateTime2), CAST(N'2023-06-25T19:30:16.9914489' AS DateTime2))
INSERT [dbo].[Exercise] ([Id], [Name], [Description], [ProperTechniqueDescription], [MuscleInvolvedDescription], [IdExerciseType], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (17, N'z', N'z', N'z', N'z', 24, 0, CAST(N'2023-06-25T19:34:40.5897446' AS DateTime2), CAST(N'2023-06-25T19:34:40.5897508' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Exercise] OFF
GO
SET IDENTITY_INSERT [dbo].[ExercisePhoto] ON 

INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (1, N'Chwyć hantle chwytem zamkniętym i utrzymuj je w pozycji neutralnej, czyli palce dłoni skierowane do siebie.', N'https://i.imgur.com/2CXBa49.jpg', 1, 1, CAST(N'2023-06-18T00:00:00.0000000' AS DateTime2), CAST(N'2023-06-18T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (2, N'Wykonaj dynamiczny ruch koncentryczny, czyli ugięcie przedramion.
', N'https://i.imgur.com/PLqr29C.jpg', 1, 1, CAST(N'2023-06-18T00:00:00.0000000' AS DateTime2), CAST(N'2023-06-18T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (3, N'RarePepe', N'https://pbs.twimg.com/media/CKc4FiYWEAAAzkK.jpg', 7, 1, CAST(N'2023-06-18T20:17:14.9397884' AS DateTime2), CAST(N'2023-06-21T20:20:59.8281400' AS DateTime2))
INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (4, N'loll', N'https://pbs.twimg.com/media/CKc4FiYWEAAAzkK.jpg', 1, 0, CAST(N'2023-06-18T20:17:27.8979605' AS DateTime2), CAST(N'2023-06-18T21:44:01.6875311' AS DateTime2))
INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, N'Pepe', N'https://miro.medium.com/v2/resize:fit:1024/1*Rqh8bmPPVja-wYH7bPKTKA.jpeg', 3, 1, CAST(N'2023-06-18T21:46:42.9206053' AS DateTime2), CAST(N'2023-06-18T21:46:42.9207618' AS DateTime2))
INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (6, N'xx', N'xx', 1, 0, CAST(N'2023-06-19T21:58:48.6342953' AS DateTime2), CAST(N'2023-06-19T21:58:48.6344582' AS DateTime2))
INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (7, N't', N'tt', 11, 0, CAST(N'2023-06-21T22:00:15.2002120' AS DateTime2), CAST(N'2023-06-21T22:00:15.2002169' AS DateTime2))
INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (8, N'q', N'q', 14, 0, CAST(N'2023-06-24T20:13:48.0019166' AS DateTime2), CAST(N'2023-06-24T20:13:48.0019201' AS DateTime2))
INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (9, N'leż płasko', N'https://i.wpimg.pl/730x0/m.fitness.wp.pl/img-0692-jpg-87ecd14bd5a2aeea41f.jpg', 15, 1, CAST(N'2023-06-25T19:32:43.8508929' AS DateTime2), CAST(N'2023-06-25T19:32:43.8508967' AS DateTime2))
INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (10, N'podnieś glowę', N'https://i.wpimg.pl/730x0/m.fitness.wp.pl/img-0694-jpg-710318f412d6a2457f3.jpg', 15, 0, CAST(N'2023-06-25T19:33:12.6833085' AS DateTime2), CAST(N'2023-06-25T19:33:31.3358868' AS DateTime2))
INSERT [dbo].[ExercisePhoto] ([Id], [FileName], [FileUrl], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (11, N'podnieś głowę', N'https://i.wpimg.pl/730x0/m.fitness.wp.pl/img-0694-jpg-710318f412d6a2457f3.jpg', 15, 1, CAST(N'2023-06-25T19:33:44.7851851' AS DateTime2), CAST(N'2023-06-25T19:33:44.7851901' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ExercisePhoto] OFF
GO
SET IDENTITY_INSERT [dbo].[ExerciseType] ON 

INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (1, N'Biceps', N'Ćwiczenia na biceps', 1, CAST(N'2023-06-15T01:11:59.8711419' AS DateTime2), CAST(N'2023-06-19T21:59:11.9367824' AS DateTime2))
INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (2, N'Nogi', N'Ćwiczenia na nogi', 1, CAST(N'2023-06-15T01:17:47.0064282' AS DateTime2), CAST(N'2023-06-18T01:26:59.7885665' AS DateTime2))
INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (3, N'Plecy', N'Ćwiczenia na plecy', 1, CAST(N'2023-06-15T01:19:33.6388935' AS DateTime2), CAST(N'2023-06-15T01:19:33.6390459' AS DateTime2))
INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (4, N'Brzuch', N'Ćwiczenia na brzuch', 1, CAST(N'2023-06-15T01:26:55.2891210' AS DateTime2), CAST(N'2023-06-17T18:00:32.3426007' AS DateTime2))
INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, N'Kardio', N'Ćwiczenia na kondycje', 1, CAST(N'2023-06-15T01:27:20.3394132' AS DateTime2), CAST(N'2023-06-15T01:27:20.3394186' AS DateTime2))
INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (19, N'd', N'd', 0, CAST(N'2023-06-17T18:00:44.7790480' AS DateTime2), CAST(N'2023-06-17T18:00:44.7790535' AS DateTime2))
INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (20, N'dd', N'dd', 0, CAST(N'2023-06-17T18:00:48.0382824' AS DateTime2), CAST(N'2023-06-17T18:00:48.0382891' AS DateTime2))
INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (21, N'qq', N'qq', 0, CAST(N'2023-06-18T00:45:11.1404535' AS DateTime2), CAST(N'2023-06-18T00:45:15.2520883' AS DateTime2))
INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (22, N'tt', N'yy', 0, CAST(N'2023-06-21T21:59:56.7353670' AS DateTime2), CAST(N'2023-06-21T21:59:56.7355113' AS DateTime2))
INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (23, N'Plecy', N'ćwiczenia na plecy', 0, CAST(N'2023-06-24T20:13:29.1507822' AS DateTime2), CAST(N'2023-06-24T20:13:29.1507870' AS DateTime2))
INSERT [dbo].[ExerciseType] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (24, N'łydki', N'rr', 0, CAST(N'2023-06-25T19:34:31.3967257' AS DateTime2), CAST(N'2023-06-25T19:34:31.3967309' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ExerciseType] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (1, N'Trening dla początkujących', N'Trening całego ciała', 1, CAST(N'2023-06-19T22:05:38.9999435' AS DateTime2), CAST(N'2023-06-21T18:55:08.7979238' AS DateTime2))
INSERT [dbo].[Schedule] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (2, N'xx', N'xx', 0, CAST(N'2023-06-19T22:06:00.8937156' AS DateTime2), CAST(N'2023-06-19T22:06:00.8937207' AS DateTime2))
INSERT [dbo].[Schedule] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (3, N'Trening siłowy', N'górne partie', 1, CAST(N'2023-06-20T19:48:50.1957291' AS DateTime2), CAST(N'2023-06-20T22:10:40.3511794' AS DateTime2))
INSERT [dbo].[Schedule] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (4, N'xx', N'x', 0, CAST(N'2023-06-21T18:55:31.8913537' AS DateTime2), CAST(N'2023-06-21T19:00:44.4156053' AS DateTime2))
INSERT [dbo].[Schedule] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, N'c', N'c', 0, CAST(N'2023-06-21T23:22:37.9327015' AS DateTime2), CAST(N'2023-06-21T23:22:37.9328505' AS DateTime2))
INSERT [dbo].[Schedule] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (6, N'Trening górnych partii', N'Ręce i klatka oraz plecy', 1, CAST(N'2023-06-23T00:46:46.4610489' AS DateTime2), CAST(N'2023-06-23T00:46:46.4610537' AS DateTime2))
INSERT [dbo].[Schedule] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (7, N'Nogi', N'dzień nóg', 1, CAST(N'2023-06-23T23:51:12.6357798' AS DateTime2), CAST(N'2023-06-23T23:51:12.6357847' AS DateTime2))
INSERT [dbo].[Schedule] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (8, N'Kardio', N'biegi', 1, CAST(N'2023-06-24T20:14:22.0360465' AS DateTime2), CAST(N'2023-06-24T20:14:22.0360517' AS DateTime2))
INSERT [dbo].[Schedule] ([Id], [Name], [Description], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (9, N'trening poniedziałkowy', N'fbw', 1, CAST(N'2023-06-25T19:35:36.6642946' AS DateTime2), CAST(N'2023-06-25T19:36:35.9033176' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[ScheduleExercise] ON 

INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (4, N'na stojąco', 1, 1, 1, CAST(N'2023-06-20T00:23:49.0672114' AS DateTime2), CAST(N'2023-06-20T22:59:51.7695561' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, N'proste plecy!', 1, 3, 1, CAST(N'2023-06-19T22:35:10.4090000' AS DateTime2), CAST(N'2023-06-19T22:35:10.4090000' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (6, N'powoli', 1, 7, 1, CAST(N'2023-06-20T00:23:49.0672114' AS DateTime2), CAST(N'2023-06-20T22:59:51.7695561' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (11, N'proste plecy', 3, 3, 1, CAST(N'2023-06-21T18:54:12.6622162' AS DateTime2), CAST(N'2023-06-21T18:54:12.6624470' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (12, N'powoli', 3, 8, 1, CAST(N'2023-06-21T19:08:02.2197756' AS DateTime2), CAST(N'2023-06-21T19:08:02.2199936' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (13, N'ok', 4, 7, 1, CAST(N'2023-06-21T19:08:24.0987476' AS DateTime2), CAST(N'2023-06-21T19:08:24.0987539' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (14, N'xd', 4, 3, 0, CAST(N'2023-06-21T19:08:36.0870104' AS DateTime2), CAST(N'2023-06-21T20:19:15.2713681' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (15, N't', 3, 7, 0, CAST(N'2023-06-21T20:20:01.1524091' AS DateTime2), CAST(N'2023-06-21T20:20:01.1524143' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (16, N'yy', 3, 8, 0, CAST(N'2023-06-21T20:20:09.5248671' AS DateTime2), CAST(N'2023-06-21T20:20:09.5248724' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (17, N'powoli', 6, 1, 1, CAST(N'2023-06-23T00:47:05.0691395' AS DateTime2), CAST(N'2023-06-23T00:47:05.0691479' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (18, NULL, 6, 8, 1, CAST(N'2023-06-23T00:47:09.2983416' AS DateTime2), CAST(N'2023-06-23T00:47:09.2983465' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (19, N'bez ciężaru', 7, 13, 1, CAST(N'2023-06-23T23:51:28.2748979' AS DateTime2), CAST(N'2023-06-23T23:51:28.2749017' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (20, N'nisko', 8, 13, 0, CAST(N'2023-06-24T20:14:33.5965530' AS DateTime2), CAST(N'2023-06-24T20:14:33.5965568' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (21, N'nisko', 8, 13, 1, CAST(N'2023-06-24T20:14:53.0824505' AS DateTime2), CAST(N'2023-06-24T20:14:53.0824556' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (22, N'tt', 9, 17, 0, CAST(N'2023-06-25T19:35:52.7898678' AS DateTime2), CAST(N'2023-06-25T19:35:52.7898713' AS DateTime2))
INSERT [dbo].[ScheduleExercise] ([Id], [Annotation], [IdSchedule], [IdExercise], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (23, N'yy', 9, 15, 1, CAST(N'2023-06-25T19:36:00.1420168' AS DateTime2), CAST(N'2023-06-25T19:36:00.1420221' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ScheduleExercise] OFF
GO
SET IDENTITY_INSERT [dbo].[ScheduleExerciseSet] ON 

INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (1, N'12', N'10', N'20', 19, 1, CAST(N'2023-06-24T18:38:42.2996170' AS DateTime2), CAST(N'2023-06-24T20:10:39.2370006' AS DateTime2), 15)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (2, N'11', N'8', N'20', 19, 1, CAST(N'2023-06-24T18:49:38.4408547' AS DateTime2), CAST(N'2023-06-24T20:11:02.7263105' AS DateTime2), 15)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (3, N'12', N'12', N'15', 4, 1, CAST(N'2023-06-24T19:17:25.4402921' AS DateTime2), CAST(N'2023-06-24T19:17:25.4404415' AS DateTime2), 1)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (4, N'12', N'10', N'15', 4, 1, CAST(N'2023-06-24T19:17:32.4781474' AS DateTime2), CAST(N'2023-06-24T20:12:59.7162099' AS DateTime2), 1)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (5, N'10', N'11', N'15', 4, 1, CAST(N'2023-06-24T19:17:40.0489541' AS DateTime2), CAST(N'2023-06-24T20:13:03.7639561' AS DateTime2), 1)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (6, N'10', N'10', N'12', 5, 1, CAST(N'2023-06-24T19:18:08.2980901' AS DateTime2), CAST(N'2023-06-24T19:18:08.2980956' AS DateTime2), 1)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (7, N'10', N'9', N'12', 5, 0, CAST(N'2023-06-24T19:18:14.5275381' AS DateTime2), CAST(N'2023-06-24T19:18:14.5275462' AS DateTime2), 1)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (8, N'12', N'12', N'20', 6, 1, CAST(N'2023-06-24T19:18:33.3647640' AS DateTime2), CAST(N'2023-06-24T19:18:33.3647695' AS DateTime2), 1)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (9, N'12', N'10', N'20', 6, 1, CAST(N'2023-06-24T19:18:38.9737695' AS DateTime2), CAST(N'2023-06-24T19:18:38.9737753' AS DateTime2), 1)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (10, N'10', N'8', N'20', 6, 1, CAST(N'2023-06-24T19:18:52.0618803' AS DateTime2), CAST(N'2023-06-24T19:18:52.0618858' AS DateTime2), 1)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (11, N'10', N'8', N'20', 19, 0, CAST(N'2023-06-24T20:11:12.7024141' AS DateTime2), CAST(N'2023-06-24T20:11:12.7024191' AS DateTime2), 15)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (12, N'10', N'0', N'15', 4, 1, CAST(N'2023-06-24T20:12:51.7226102' AS DateTime2), CAST(N'2023-06-24T20:12:51.7226168' AS DateTime2), 1)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (13, N'10', N'10', N'20', 17, 1, CAST(N'2023-06-24T20:16:39.8080397' AS DateTime2), CAST(N'2023-06-24T20:17:11.9735832' AS DateTime2), 16)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (14, N'10', N'8', N'20', 17, 1, CAST(N'2023-06-24T20:16:46.6952391' AS DateTime2), CAST(N'2023-06-24T20:17:18.8523794' AS DateTime2), 16)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (15, N'8', N'8', N'15', 17, 0, CAST(N'2023-06-24T20:16:52.0474215' AS DateTime2), CAST(N'2023-06-24T20:17:23.9064944' AS DateTime2), 16)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (16, N'100', N'100', N'6', 17, 1, CAST(N'2023-06-25T00:24:23.9500962' AS DateTime2), CAST(N'2023-06-25T00:24:34.4136522' AS DateTime2), 11)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (17, N'1', N'20', N'70', 18, 1, CAST(N'2023-06-25T00:25:53.0341317' AS DateTime2), CAST(N'2023-06-25T00:25:53.0342833' AS DateTime2), 11)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (18, N'15', N'10', N'15', 23, 0, CAST(N'2023-06-25T19:38:04.9305431' AS DateTime2), CAST(N'2023-06-25T19:38:57.4333039' AS DateTime2), 18)
INSERT [dbo].[ScheduleExerciseSet] ([Id], [PlannedReps], [ActualReps], [WeightUsed], [IdScheduleExercise], [IsActive], [CreatedDate], [ModifiedDate], [IdDaySchedule]) VALUES (19, N'10', N'0', N'10', 23, 0, CAST(N'2023-06-25T19:38:10.6379367' AS DateTime2), CAST(N'2023-06-25T19:38:10.6379430' AS DateTime2), 18)
SET IDENTITY_INSERT [dbo].[ScheduleExerciseSet] OFF
GO
/****** Object:  Index [IX_DaySchedule_IdDay]    Script Date: 25.06.2023 19:40:41 ******/
CREATE NONCLUSTERED INDEX [IX_DaySchedule_IdDay] ON [dbo].[DaySchedule]
(
	[IdDay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DaySchedule_IdSchedule]    Script Date: 25.06.2023 19:40:41 ******/
CREATE NONCLUSTERED INDEX [IX_DaySchedule_IdSchedule] ON [dbo].[DaySchedule]
(
	[IdSchedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Exercise_IdExerciseType]    Script Date: 25.06.2023 19:40:41 ******/
CREATE NONCLUSTERED INDEX [IX_Exercise_IdExerciseType] ON [dbo].[Exercise]
(
	[IdExerciseType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExercisePhoto_IdExercise]    Script Date: 25.06.2023 19:40:41 ******/
CREATE NONCLUSTERED INDEX [IX_ExercisePhoto_IdExercise] ON [dbo].[ExercisePhoto]
(
	[IdExercise] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ScheduleExercise_IdExercise]    Script Date: 25.06.2023 19:40:41 ******/
CREATE NONCLUSTERED INDEX [IX_ScheduleExercise_IdExercise] ON [dbo].[ScheduleExercise]
(
	[IdExercise] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ScheduleExercise_IdSchedule]    Script Date: 25.06.2023 19:40:41 ******/
CREATE NONCLUSTERED INDEX [IX_ScheduleExercise_IdSchedule] ON [dbo].[ScheduleExercise]
(
	[IdSchedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ScheduleExerciseSet_IdDaySchedule]    Script Date: 25.06.2023 19:40:41 ******/
CREATE NONCLUSTERED INDEX [IX_ScheduleExerciseSet_IdDaySchedule] ON [dbo].[ScheduleExerciseSet]
(
	[IdDaySchedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ScheduleExerciseSet_IdScheduleExercise]    Script Date: 25.06.2023 19:40:41 ******/
CREATE NONCLUSTERED INDEX [IX_ScheduleExerciseSet_IdScheduleExercise] ON [dbo].[ScheduleExerciseSet]
(
	[IdScheduleExercise] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Exercise] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[DaySchedule]  WITH CHECK ADD  CONSTRAINT [FK_DaySchedule_Day_IdDay] FOREIGN KEY([IdDay])
REFERENCES [dbo].[Day] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DaySchedule] CHECK CONSTRAINT [FK_DaySchedule_Day_IdDay]
GO
ALTER TABLE [dbo].[DaySchedule]  WITH CHECK ADD  CONSTRAINT [FK_DaySchedule_Schedule_IdSchedule] FOREIGN KEY([IdSchedule])
REFERENCES [dbo].[Schedule] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DaySchedule] CHECK CONSTRAINT [FK_DaySchedule_Schedule_IdSchedule]
GO
ALTER TABLE [dbo].[Exercise]  WITH CHECK ADD  CONSTRAINT [FK_Exercise_ExerciseType_IdExerciseType] FOREIGN KEY([IdExerciseType])
REFERENCES [dbo].[ExerciseType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exercise] CHECK CONSTRAINT [FK_Exercise_ExerciseType_IdExerciseType]
GO
ALTER TABLE [dbo].[ExercisePhoto]  WITH CHECK ADD  CONSTRAINT [FK_ExercisePhoto_Exercise_IdExercise] FOREIGN KEY([IdExercise])
REFERENCES [dbo].[Exercise] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExercisePhoto] CHECK CONSTRAINT [FK_ExercisePhoto_Exercise_IdExercise]
GO
ALTER TABLE [dbo].[ScheduleExercise]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleExercise_Exercise_IdExercise] FOREIGN KEY([IdExercise])
REFERENCES [dbo].[Exercise] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScheduleExercise] CHECK CONSTRAINT [FK_ScheduleExercise_Exercise_IdExercise]
GO
ALTER TABLE [dbo].[ScheduleExercise]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleExercise_Schedule_IdSchedule] FOREIGN KEY([IdSchedule])
REFERENCES [dbo].[Schedule] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScheduleExercise] CHECK CONSTRAINT [FK_ScheduleExercise_Schedule_IdSchedule]
GO
ALTER TABLE [dbo].[ScheduleExerciseSet]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleExerciseSet_DaySchedule_IdDaySchedule] FOREIGN KEY([IdDaySchedule])
REFERENCES [dbo].[DaySchedule] ([Id])
GO
ALTER TABLE [dbo].[ScheduleExerciseSet] CHECK CONSTRAINT [FK_ScheduleExerciseSet_DaySchedule_IdDaySchedule]
GO
ALTER TABLE [dbo].[ScheduleExerciseSet]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleExerciseSet_ScheduleExercise_IdScheduleExercise] FOREIGN KEY([IdScheduleExercise])
REFERENCES [dbo].[ScheduleExercise] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ScheduleExerciseSet] CHECK CONSTRAINT [FK_ScheduleExerciseSet_ScheduleExercise_IdScheduleExercise]
GO
USE [master]
GO
ALTER DATABASE [MoveYourBumDatabase] SET  READ_WRITE 
GO
