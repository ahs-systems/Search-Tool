USE [Boo]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 7/5/2018 1:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[username] [nvarchar](100) NOT NULL,
	[zone] [nvarchar](10) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[status] [bit] NULL
) ON [PRIMARY]

GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'DarwinDizon', N'CAL       ', N'Darwin', N'Dizon', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'SCOTTHASTINGS', N'CAL       ', N'Scott', N'Hastings', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'ROTCHELOSANTOS', N'CAL       ', N'Rotchelo', N'Santos', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'ADELACRUZ02', N'CAL       ', N'Ana Lisa', N'Dela Cruz', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'LOURDESSHAHPORI', N'CAL       ', N'Lourdes', N'Shahpori', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'BSANTOS', N'CAL       ', N'Bernadette', N'Santos', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'MIKAELMANAGAT', N'CAL       ', N'Mikael', N'Managat', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'YEGORNIKITIN', N'CAL       ', N'Yegor', N'Nikitin', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'BOlson02', N'CAL       ', N'Braden', N'Olson', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'LTA', N'CAL       ', N'Linh', N'Ta', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'NSALAMAT', N'CAL       ', N'Nino Caesario', N'Salamat', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'JTOMA', N'CAL       ', N'Julie Ann', N'Toma', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'JAMIETAM', N'CAL       ', N'Jamie', N'Tam', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'ANGIEKER', N'EDM       ', N'Angie', N'Kernaghan', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'ARLETTEMILLER', N'EDM       ', N'Arlette', N'Miller', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'DEEPTICHOPRA', N'EDM       ', N'Deepti', N'Chopra', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'NICHOLASJEWELL', N'EDM       ', N'Nicholas', N'Jewell', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'RDNSSCBJ', N'EDM       ', N'Rick', N'Leyland', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'JOSEFAGBULOS', N'EDM       ', N'Josef', N'Agbulos', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'TYRELSCHULTZ', N'EDM       ', N'Tyrel', N'Schultz', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'TREVORBIDYK', N'NCS       ', N'Trevor', N'Bidyk', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'RDFIPCH', N'NCS       ', N'Dale', N'Sydora', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'NSORUSZ', N'NCS       ', N'Jacqui', N'Bourque', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'RDNSSCAZ', N'NCS       ', N'Michelle', N'Penhale', 1)
GO
INSERT [dbo].[AppUsers] ([username], [zone], [FirstName], [LastName], [status]) VALUES (N'DFIPCG', N'NCS       ', N'Wendy', N'Scott', 1)
GO
