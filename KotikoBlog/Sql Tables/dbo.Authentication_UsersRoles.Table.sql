USE [KotikoBlog]
GO
DELETE FROM [dbo].[Authentication_UsersRoles]
GO
INSERT [dbo].[Authentication_UsersRoles] ([IdUser], [IdRole]) VALUES (1, 1)
