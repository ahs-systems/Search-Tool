USE [Boo]
GO
/****** Object:  Table [dbo].[AppLists]    Script Date: 7/5/2018 1:52:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppLists](
	[AppID] [int] NOT NULL,
	[AppName] [nvarchar](150) NOT NULL,
	[AppVersion] [nvarchar](50) NOT NULL,
	[Err] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_AppLists] PRIMARY KEY CLUSTERED 
(
	[AppID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[AppLists] ([AppID], [AppName], [AppVersion], [Err]) VALUES (1, N'SearchLDAP', N'2018.03.09', N'This app is already outdated. Please use the latest one which is ''PSSTool.exe'' found on the same folder. App will now close.')
GO
INSERT [dbo].[AppLists] ([AppID], [AppName], [AppVersion], [Err]) VALUES (3, N'ItemsReport', N'2018.03.13', N'A problem on the DLL caused the program to stop working correctly. Program cannot continue.')
GO
INSERT [dbo].[AppLists] ([AppID], [AppName], [AppVersion], [Err]) VALUES (4, N'ASCEmailAudit', N'2018.05.22', N'This app is already outdated. Please use the latest one which is ''PSSTool.exe'' found on the same folder. App will now close.')
GO
INSERT [dbo].[AppLists] ([AppID], [AppName], [AppVersion], [Err]) VALUES (5, N'PSSTool', N'5', N'This is an old version. Please use the latest one. App will now close.')
GO
INSERT [dbo].[AppLists] ([AppID], [AppName], [AppVersion], [Err]) VALUES (21, N'SearchTool', N'2018.03.13', N'ERROR: You are using an old version of the app, please use the latest one.')
GO
