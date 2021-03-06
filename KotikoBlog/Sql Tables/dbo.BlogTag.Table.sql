USE [KotikoBlog]
GO
DELETE FROM [dbo].[BlogTag]
GO
SET IDENTITY_INSERT [dbo].[BlogTag] ON 

INSERT [dbo].[BlogTag] ([ID], [Name], [UrlSlug], [Description]) VALUES (1, N'CSharp', N'csharp', NULL)
INSERT [dbo].[BlogTag] ([ID], [Name], [UrlSlug], [Description]) VALUES (2, N'ASP', N'asp', NULL)
INSERT [dbo].[BlogTag] ([ID], [Name], [UrlSlug], [Description]) VALUES (3, N'ASP.NET', N'asp_net', NULL)
INSERT [dbo].[BlogTag] ([ID], [Name], [UrlSlug], [Description]) VALUES (4, N'JavaScript', N'javascript', NULL)
INSERT [dbo].[BlogTag] ([ID], [Name], [UrlSlug], [Description]) VALUES (5, N'Silverlight', N'silverlight', NULL)
INSERT [dbo].[BlogTag] ([ID], [Name], [UrlSlug], [Description]) VALUES (6, N'Html', N'html', NULL)
INSERT [dbo].[BlogTag] ([ID], [Name], [UrlSlug], [Description]) VALUES (7, N'Css', N'css', NULL)
SET IDENTITY_INSERT [dbo].[BlogTag] OFF
