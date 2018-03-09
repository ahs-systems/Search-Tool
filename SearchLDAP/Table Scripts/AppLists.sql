USE [Boo]
GO

/****** Object:  Table [dbo].[AppLists]    Script Date: 3/9/2018 12:32:39 PM ******/
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

