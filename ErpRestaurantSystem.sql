USE [master]
GO
/****** Object:  Database [ErpRestaurantSystem]    Script Date: 07.06.2023 0:44:05 ******/
CREATE DATABASE [ErpRestaurantSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Restaurant_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Restaurant_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Restaurant_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Restaurant_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ErpRestaurantSystem] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ErpRestaurantSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ErpRestaurantSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ErpRestaurantSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ErpRestaurantSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ErpRestaurantSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ErpRestaurantSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [ErpRestaurantSystem] SET  MULTI_USER 
GO
ALTER DATABASE [ErpRestaurantSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ErpRestaurantSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ErpRestaurantSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ErpRestaurantSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ErpRestaurantSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ErpRestaurantSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ErpRestaurantSystem', N'ON'
GO
ALTER DATABASE [ErpRestaurantSystem] SET QUERY_STORE = OFF
GO
USE [ErpRestaurantSystem]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 07.06.2023 0:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id_category] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[ordinem] [int] NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[id_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category_list]    Script Date: 07.06.2023 0:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category_list](
	[id_category_list] [int] IDENTITY(1,1) NOT NULL,
	[id_menu] [int] NOT NULL,
	[id_category] [int] NOT NULL,
 CONSTRAINT [PK_category_list] PRIMARY KEY CLUSTERED 
(
	[id_category_list] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 07.06.2023 0:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[surname] [nvarchar](255) NULL,
	[patronymic] [nvarchar](255) NULL,
	[role] [nvarchar](50) NULL,
	[pin_code] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 07.06.2023 0:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[id_menu] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[available] [bit] NOT NULL,
	[ordinem] [int] NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[id_menu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_list]    Script Date: 07.06.2023 0:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_list](
	[id_order_list] [int] IDENTITY(1,1) NOT NULL,
	[id_orders] [int] NOT NULL,
	[id_menu] [int] NOT NULL,
	[count] [int] NULL,
 CONSTRAINT [PK_order_list] PRIMARY KEY CLUSTERED 
(
	[id_order_list] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 07.06.2023 0:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[id_orders] [int] IDENTITY(1,1) NOT NULL,
	[time] [datetime] NULL,
	[closed] [bit] NULL,
	[name] [varchar](200) NULL,
	[sum] [decimal](18, 2) NULL,
	[employee_id] [int] NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[id_orders] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recipes]    Script Date: 07.06.2023 0:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recipes](
	[id_recipes] [int] IDENTITY(1,1) NOT NULL,
	[id_menu] [int] NOT NULL,
	[id_stocks] [int] NOT NULL,
	[quantity] [float] NOT NULL,
 CONSTRAINT [PK_recipes] PRIMARY KEY CLUSTERED 
(
	[id_recipes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salaries]    Script Date: 07.06.2023 0:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salaries](
	[salaryId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NULL,
	[startdate] [date] NULL,
	[enddate] [date] NULL,
	[hoursworked] [float] NULL,
	[hourlyrate] [decimal](10, 2) NULL,
	[bonus] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[salaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stocks]    Script Date: 07.06.2023 0:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stocks](
	[id_stocks] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[count] [float] NULL,
	[threshold] [float] NULL,
	[price_per_unit] [float] NULL,
 CONSTRAINT [PK_stocks] PRIMARY KEY CLUSTERED 
(
	[id_stocks] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[work_schedule]    Script Date: 07.06.2023 0:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[work_schedule](
	[schedule_id] [int] IDENTITY(1,1) NOT NULL,
	[employee_id] [int] NULL,
	[start_time] [datetime] NULL,
	[end_time] [datetime] NULL,
	[is_vacation] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[schedule_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([id_category], [name], [ordinem]) VALUES (1009, N'Горячие блюда', 1011)
INSERT [dbo].[categories] ([id_category], [name], [ordinem]) VALUES (1010, N'Закуски', 1009)
INSERT [dbo].[categories] ([id_category], [name], [ordinem]) VALUES (1011, N'Напитки', 1010)
INSERT [dbo].[categories] ([id_category], [name], [ordinem]) VALUES (1012, N'Десерты', 1012)
INSERT [dbo].[categories] ([id_category], [name], [ordinem]) VALUES (1013, N'Салаты', 1013)
SET IDENTITY_INSERT [dbo].[categories] OFF
GO
SET IDENTITY_INSERT [dbo].[category_list] ON 

INSERT [dbo].[category_list] ([id_category_list], [id_menu], [id_category]) VALUES (43, 10, 1009)
INSERT [dbo].[category_list] ([id_category_list], [id_menu], [id_category]) VALUES (82, 9, 1011)
INSERT [dbo].[category_list] ([id_category_list], [id_menu], [id_category]) VALUES (88, 15, 1009)
INSERT [dbo].[category_list] ([id_category_list], [id_menu], [id_category]) VALUES (91, 11, 1010)
INSERT [dbo].[category_list] ([id_category_list], [id_menu], [id_category]) VALUES (97, 29, 1009)
INSERT [dbo].[category_list] ([id_category_list], [id_menu], [id_category]) VALUES (98, 30, 1010)
INSERT [dbo].[category_list] ([id_category_list], [id_menu], [id_category]) VALUES (99, 28, 1009)
INSERT [dbo].[category_list] ([id_category_list], [id_menu], [id_category]) VALUES (100, 12, 1012)
INSERT [dbo].[category_list] ([id_category_list], [id_menu], [id_category]) VALUES (101, 14, 1009)
SET IDENTITY_INSERT [dbo].[category_list] OFF
GO
SET IDENTITY_INSERT [dbo].[employees] ON 

INSERT [dbo].[employees] ([employee_id], [name], [surname], [patronymic], [role], [pin_code]) VALUES (1, N'Эмиль', N'Талипов', N'Эльвирович', N'it', 1234)
INSERT [dbo].[employees] ([employee_id], [name], [surname], [patronymic], [role], [pin_code]) VALUES (2, N'Петр', N'Петров', N'Петрович', N'waiter', 2345)
INSERT [dbo].[employees] ([employee_id], [name], [surname], [patronymic], [role], [pin_code]) VALUES (3, N'Ольга', N'Сидорова', N'Алексеевна', N'accountant', 3456)
INSERT [dbo].[employees] ([employee_id], [name], [surname], [patronymic], [role], [pin_code]) VALUES (4, N'Анна', N'Каренина', N'Андреевна', N'waiter', 1111)
INSERT [dbo].[employees] ([employee_id], [name], [surname], [patronymic], [role], [pin_code]) VALUES (5, N'Надежда', N'Пенкина', N'Владиславовна', N'waiter', 4444)
SET IDENTITY_INSERT [dbo].[employees] OFF
GO
SET IDENTITY_INSERT [dbo].[menu] ON 

INSERT [dbo].[menu] ([id_menu], [name], [price], [available], [ordinem]) VALUES (9, N'Клюквенный чай', CAST(600.00 AS Decimal(18, 2)), 1, 9)
INSERT [dbo].[menu] ([id_menu], [name], [price], [available], [ordinem]) VALUES (10, N'Паста', CAST(800.00 AS Decimal(18, 2)), 1, 10)
INSERT [dbo].[menu] ([id_menu], [name], [price], [available], [ordinem]) VALUES (11, N'Хлебные палочки', CAST(300.00 AS Decimal(18, 2)), 1, 11)
INSERT [dbo].[menu] ([id_menu], [name], [price], [available], [ordinem]) VALUES (12, N'Тирамису', CAST(1000.00 AS Decimal(18, 2)), 1, 12)
INSERT [dbo].[menu] ([id_menu], [name], [price], [available], [ordinem]) VALUES (14, N'Котлета куриная', CAST(800.00 AS Decimal(18, 2)), 1, 14)
INSERT [dbo].[menu] ([id_menu], [name], [price], [available], [ordinem]) VALUES (15, N'Пулоты из фазана', CAST(6000.00 AS Decimal(18, 2)), 0, 15)
INSERT [dbo].[menu] ([id_menu], [name], [price], [available], [ordinem]) VALUES (28, N'Стейк "Черный ангус" с пюре и овощами', CAST(4500.00 AS Decimal(18, 2)), 1, 28)
INSERT [dbo].[menu] ([id_menu], [name], [price], [available], [ordinem]) VALUES (29, N'Лазанья с морепродуктами', CAST(3000.00 AS Decimal(18, 2)), 1, 29)
INSERT [dbo].[menu] ([id_menu], [name], [price], [available], [ordinem]) VALUES (30, N'Оссобуко с ризотто', CAST(1900.00 AS Decimal(18, 2)), 1, 30)
SET IDENTITY_INSERT [dbo].[menu] OFF
GO
SET IDENTITY_INSERT [dbo].[order_list] ON 

INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (36, 41, 9, 10)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (37, 42, 9, 3)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (38, 43, 9, 6)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (39, 43, 10, 5)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (40, 43, 11, 4)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (47, 50, 10, 5)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (48, 50, 11, 10)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (49, 54, 10, 3)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (50, 54, 9, 2)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (51, 54, 11, 3)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (52, 55, 9, 4)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (53, 55, 10, 7)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (54, 55, 11, 5)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (55, 57, 10, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (56, 57, 9, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (57, 57, 11, 3)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (58, 56, 9, 4)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (59, 56, 10, 5)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (60, 56, 11, 6)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (64, 70, 11, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (65, 70, 9, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (66, 70, 12, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (67, 70, 10, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (72, 55, 14, 2)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (73, 55, 12, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (74, 59, 11, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (78, 87, 10, 2)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (81, 56, 14, 3)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (83, 68, 14, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (84, 68, 12, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (85, 68, 11, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (87, 88, 9, 15)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (103, 56, 9, 5)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (104, 64, 10, 2)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (106, 63, 11, 2)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (107, 63, 14, 4)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (108, 63, 29, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (109, 63, 10, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (110, 63, 28, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (111, 62, 12, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (112, 62, 11, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (113, 62, 10, 5)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (114, 62, 9, 3)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (115, 61, 11, 3)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (116, 61, 10, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (117, 61, 9, 2)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (118, 60, 28, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (119, 60, 12, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (120, 60, 10, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (121, 60, 9, 1)
INSERT [dbo].[order_list] ([id_order_list], [id_orders], [id_menu], [count]) VALUES (122, 59, 30, 1)
SET IDENTITY_INSERT [dbo].[order_list] OFF
GO
SET IDENTITY_INSERT [dbo].[orders] ON 

INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (41, CAST(N'2019-05-07T20:22:40.797' AS DateTime), 1, N'Чай', CAST(300.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (42, CAST(N'2019-05-07T20:53:34.777' AS DateTime), 1, N'3', CAST(90.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (43, CAST(N'2019-05-07T21:02:05.983' AS DateTime), 1, N'3', CAST(2180.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (50, CAST(N'2019-05-13T02:21:01.813' AS DateTime), 1, N'50', CAST(2000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (54, CAST(N'2023-05-16T16:35:22.867' AS DateTime), 1, N'54', CAST(1260.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (55, CAST(N'2023-05-16T16:41:04.937' AS DateTime), 1, N'55', CAST(3440.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (56, CAST(N'2023-05-16T16:41:05.393' AS DateTime), 1, N'56', CAST(8650.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (57, CAST(N'2023-05-16T16:41:11.497' AS DateTime), 1, N'57', CAST(430.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (59, CAST(N'2023-05-17T21:29:46.193' AS DateTime), 0, N'59', CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (60, CAST(N'2023-05-17T21:29:51.233' AS DateTime), 0, N'60', CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (61, CAST(N'2023-05-17T21:29:54.813' AS DateTime), 0, N'61', CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (62, CAST(N'2023-05-17T21:29:57.413' AS DateTime), 0, N'62', CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (63, CAST(N'2023-05-17T21:30:01.920' AS DateTime), 0, N'63', CAST(0.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (64, CAST(N'2023-05-17T21:30:04.090' AS DateTime), 1, N'64', CAST(1600.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (68, CAST(N'2023-05-17T23:44:00.517' AS DateTime), 1, N'68', CAST(1050.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (70, CAST(N'2023-05-18T16:00:47.940' AS DateTime), 1, N'70', CAST(550.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (87, CAST(N'2023-05-30T12:56:30.003' AS DateTime), 1, N'87', CAST(800.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[orders] ([id_orders], [time], [closed], [name], [sum], [employee_id]) VALUES (88, CAST(N'2023-05-31T03:05:41.033' AS DateTime), 1, N'88', CAST(4500.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[orders] OFF
GO
SET IDENTITY_INSERT [dbo].[recipes] ON 

INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (85, 10, 3, 0.5)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (87, 10, 5, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (106, 9, 6, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (107, 9, 15, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (112, 15, 16, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (119, 11, 3, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (129, 29, 19, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (130, 29, 23, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (131, 29, 21, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (132, 29, 22, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (133, 30, 24, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (134, 28, 17, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (135, 28, 18, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (136, 12, 3, 1)
INSERT [dbo].[recipes] ([id_recipes], [id_menu], [id_stocks], [quantity]) VALUES (137, 14, 7, 1)
SET IDENTITY_INSERT [dbo].[recipes] OFF
GO
SET IDENTITY_INSERT [dbo].[salaries] ON 

INSERT [dbo].[salaries] ([salaryId], [employeeId], [startdate], [enddate], [hoursworked], [hourlyrate], [bonus]) VALUES (1, 1, CAST(N'2023-01-01' AS Date), CAST(N'2023-01-31' AS Date), 160.5, CAST(500.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)))
INSERT [dbo].[salaries] ([salaryId], [employeeId], [startdate], [enddate], [hoursworked], [hourlyrate], [bonus]) VALUES (2, 2, CAST(N'2023-02-01' AS Date), CAST(N'2023-02-28' AS Date), 175, CAST(20.00 AS Decimal(10, 2)), CAST(2500.00 AS Decimal(10, 2)))
INSERT [dbo].[salaries] ([salaryId], [employeeId], [startdate], [enddate], [hoursworked], [hourlyrate], [bonus]) VALUES (3, 3, CAST(N'2023-03-01' AS Date), CAST(N'2023-03-31' AS Date), 155, CAST(25.00 AS Decimal(10, 2)), CAST(500.00 AS Decimal(10, 2)))
INSERT [dbo].[salaries] ([salaryId], [employeeId], [startdate], [enddate], [hoursworked], [hourlyrate], [bonus]) VALUES (4, 4, CAST(N'2023-04-01' AS Date), CAST(N'2023-04-30' AS Date), 145, CAST(17.00 AS Decimal(10, 2)), CAST(3000.00 AS Decimal(10, 2)))
INSERT [dbo].[salaries] ([salaryId], [employeeId], [startdate], [enddate], [hoursworked], [hourlyrate], [bonus]) VALUES (6, 5, CAST(N'2023-04-01' AS Date), CAST(N'2023-04-30' AS Date), 150, CAST(500.00 AS Decimal(10, 2)), CAST(5000.00 AS Decimal(10, 2)))
INSERT [dbo].[salaries] ([salaryId], [employeeId], [startdate], [enddate], [hoursworked], [hourlyrate], [bonus]) VALUES (11, 1, CAST(N'2023-06-05' AS Date), CAST(N'2023-06-05' AS Date), 150, CAST(300.00 AS Decimal(10, 2)), NULL)
SET IDENTITY_INSERT [dbo].[salaries] OFF
GO
SET IDENTITY_INSERT [dbo].[stocks] ON 

INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (3, N'Мука', 990, 300, 100)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (5, N'Говядина', 172.2000002861023, 50, 350)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (6, N'Чай', 4910, 300, 130)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (7, N'Фарш куриный', 54, 10, 300)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (8, N'Огурцы', 100, 100, 150)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (14, N'Томат', 100, 10, 100)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (15, N'Клюква', 50, 60, 50)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (16, N'Вырезка из фазана', 10, 5, 5000)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (17, N'Черный ангус', 10000, 1000, 200)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (18, N'Картофель', 300000, 5000, 50)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (19, N'Лазанья', 10000, 1000, 70)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (20, N'Лазанья', 10000, 1000, 300)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (21, N'Кальмары', 5000, 100, 300)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (22, N'Мидии', 10000, 1000, 200)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (23, N'Сырный соус', 6000, 1000, 100)
INSERT [dbo].[stocks] ([id_stocks], [name], [count], [threshold], [price_per_unit]) VALUES (24, N'Оссобуко', 5000, 2500, 100)
SET IDENTITY_INSERT [dbo].[stocks] OFF
GO
SET IDENTITY_INSERT [dbo].[work_schedule] ON 

INSERT [dbo].[work_schedule] ([schedule_id], [employee_id], [start_time], [end_time], [is_vacation]) VALUES (2, 1, CAST(N'2023-05-24T09:00:00.000' AS DateTime), CAST(N'2023-05-24T17:00:00.000' AS DateTime), 0)
INSERT [dbo].[work_schedule] ([schedule_id], [employee_id], [start_time], [end_time], [is_vacation]) VALUES (3, 2, CAST(N'2023-05-25T08:30:00.000' AS DateTime), CAST(N'2023-05-25T16:30:00.000' AS DateTime), 0)
INSERT [dbo].[work_schedule] ([schedule_id], [employee_id], [start_time], [end_time], [is_vacation]) VALUES (4, 3, CAST(N'2023-05-26T10:00:00.000' AS DateTime), CAST(N'2023-05-26T18:00:00.000' AS DateTime), 0)
INSERT [dbo].[work_schedule] ([schedule_id], [employee_id], [start_time], [end_time], [is_vacation]) VALUES (7, 4, CAST(N'2023-05-25T09:00:08.000' AS DateTime), CAST(N'2023-05-27T21:00:08.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[work_schedule] OFF
GO
ALTER TABLE [dbo].[menu] ADD  CONSTRAINT [DF_menu_available]  DEFAULT ((1)) FOR [available]
GO
ALTER TABLE [dbo].[orders] ADD  CONSTRAINT [DF_orders_sum]  DEFAULT ((0)) FOR [sum]
GO
ALTER TABLE [dbo].[stocks] ADD  CONSTRAINT [DF_stocks_count]  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[category_list]  WITH CHECK ADD  CONSTRAINT [FK_category_list_categories] FOREIGN KEY([id_category])
REFERENCES [dbo].[categories] ([id_category])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[category_list] CHECK CONSTRAINT [FK_category_list_categories]
GO
ALTER TABLE [dbo].[category_list]  WITH CHECK ADD  CONSTRAINT [FK_category_list_menu] FOREIGN KEY([id_menu])
REFERENCES [dbo].[menu] ([id_menu])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[category_list] CHECK CONSTRAINT [FK_category_list_menu]
GO
ALTER TABLE [dbo].[order_list]  WITH CHECK ADD  CONSTRAINT [FK_order_list_menu] FOREIGN KEY([id_menu])
REFERENCES [dbo].[menu] ([id_menu])
GO
ALTER TABLE [dbo].[order_list] CHECK CONSTRAINT [FK_order_list_menu]
GO
ALTER TABLE [dbo].[order_list]  WITH CHECK ADD  CONSTRAINT [FK_order_list_orders] FOREIGN KEY([id_orders])
REFERENCES [dbo].[orders] ([id_orders])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[order_list] CHECK CONSTRAINT [FK_order_list_orders]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_employees] FOREIGN KEY([employee_id])
REFERENCES [dbo].[employees] ([employee_id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_employees]
GO
ALTER TABLE [dbo].[recipes]  WITH CHECK ADD  CONSTRAINT [FK_recipes_menu] FOREIGN KEY([id_menu])
REFERENCES [dbo].[menu] ([id_menu])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[recipes] CHECK CONSTRAINT [FK_recipes_menu]
GO
ALTER TABLE [dbo].[recipes]  WITH CHECK ADD  CONSTRAINT [FK_recipes_stocks] FOREIGN KEY([id_stocks])
REFERENCES [dbo].[stocks] ([id_stocks])
GO
ALTER TABLE [dbo].[recipes] CHECK CONSTRAINT [FK_recipes_stocks]
GO
ALTER TABLE [dbo].[salaries]  WITH CHECK ADD FOREIGN KEY([employeeId])
REFERENCES [dbo].[employees] ([employee_id])
GO
ALTER TABLE [dbo].[work_schedule]  WITH CHECK ADD FOREIGN KEY([employee_id])
REFERENCES [dbo].[employees] ([employee_id])
GO
USE [master]
GO
ALTER DATABASE [ErpRestaurantSystem] SET  READ_WRITE 
GO
