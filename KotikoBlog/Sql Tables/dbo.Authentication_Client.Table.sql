USE [KotikoBlog]
GO
DELETE FROM [dbo].[Authentication_Client]
GO
INSERT [dbo].[Authentication_Client] ([ID], [Secret], [Name], [ApplicationType], [Active], [RefreshTokenLifeTime], [AllowedOrigin]) VALUES (N'KotikoBlog-web', N'gYv8PiXHGjzsepCq1zPHB9PnmiPuT8E4vpAYJArLWNc=', N'KotikoBlog-web', N'0', 1, 30, N'*')
