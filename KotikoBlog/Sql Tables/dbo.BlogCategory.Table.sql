USE [KotikoBlog]
GO
DELETE FROM [dbo].[BlogCategory]
GO
SET IDENTITY_INSERT [dbo].[BlogCategory] ON 

INSERT [dbo].[BlogCategory] ([ID], [Name], [UrlSlug], [Description]) VALUES (1, N'Programming', N'programming', NULL)
INSERT [dbo].[BlogCategory] ([ID], [Name], [UrlSlug], [Description]) VALUES (2, N'Humor', N'humor', NULL)
INSERT [dbo].[BlogCategory] ([ID], [Name], [UrlSlug], [Description]) VALUES (3, N'Design', N'design', NULL)
SET IDENTITY_INSERT [dbo].[BlogCategory] OFF
