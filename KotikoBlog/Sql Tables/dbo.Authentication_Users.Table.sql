USE [KotikoBlog]
GO
DELETE FROM [dbo].[Authentication_Users]
GO
SET IDENTITY_INSERT [dbo].[Authentication_Users] ON 

INSERT [dbo].[Authentication_Users] ([ID], [Nombre], [Password], [Email], [LockedCode], [Created], [Deleted], [Modified]) VALUES (1, N'Asier', N'lOhdkCGka7jfUQMBDaXW0V5kZcxXho33HHywaRssh+w=', N'asier.salguero@gmail.com', N'0073', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Authentication_Users] OFF
