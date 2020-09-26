USE [AssignmentDB]
GO
INSERT [dbo].[Bookings] ([Id], [UserId], [CreatedDate], [CityId], [MultiplexId], [MovieId]) VALUES (N'f0c8c85b-7a28-4b2f-b9cf-ed99cc57778c', N'5cfe1ffb-a965-43bf-9825-024703f96373', CAST(N'2020-07-26T10:36:55.8690000' AS DateTime2), N'3fd28d9e-0887-44a0-950c-6ee6a7a93924', N'46b5dcea-c6ac-495b-8ede-512fb7295ea3', N'9b85c4e5-d41f-4293-837c-8dc95ef0afc8')
INSERT [dbo].[Bookings] ([Id], [UserId], [CreatedDate], [CityId], [MultiplexId], [MovieId]) VALUES (N'8d135176-f10f-42a0-a9fb-eeec8be8af97', N'5cfe1ffb-a965-43bf-9825-024703f96373', CAST(N'2020-07-26T10:36:55.8690000' AS DateTime2), N'3fd28d9e-0887-44a0-950c-6ee6a7a93924', N'46b5dcea-c6ac-495b-8ede-512fb7295ea3', N'9b85c4e5-d41f-4293-837c-8dc95ef0afc8')
INSERT [dbo].[Bookings] ([Id], [UserId], [CreatedDate], [CityId], [MultiplexId], [MovieId]) VALUES (N'8d135176-f10f-78a0-a9fb-eeec8be8af97', N'5cfe1ffb-a965-43bf-9825-024703f96373', CAST(N'2020-07-26T10:36:55.8690000' AS DateTime2), N'3fd28d9e-0887-44a0-950c-6ee6a7a93924', N'46b5dcea-c6ac-495b-8ede-512fb7295ea3', N'9b85c4e5-d41f-4293-837c-8dc95ef0afc8')
INSERT [dbo].[Cities] ([Id], [Name], [CreatedDate]) VALUES (N'5e56bcac-f87c-4f13-8ae4-08a68a5fe729', N'Bangalore', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Cities] ([Id], [Name], [CreatedDate]) VALUES (N'3fd28d9e-0887-44a0-950c-6ee6a7a93924', N'Mumbai', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Cities] ([Id], [Name], [CreatedDate]) VALUES (N'ba660bcc-58b1-42df-90ad-ff9483b20f80', N'Delhi', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Genres] ([Id], [Name], [CreatedDate]) VALUES (N'aaf74021-2167-43ab-9b54-0992fbedcd51', N'Comedy', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Genres] ([Id], [Name], [CreatedDate]) VALUES (N'aee08adf-f572-4d9d-b6c8-2841f02ec636', N'Action', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Genres] ([Id], [Name], [CreatedDate]) VALUES (N'e74af6c6-c5f4-435d-95a5-3fe7a07738b4', N'Drama', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Languages] ([Id], [Name], [CreatedDate]) VALUES (N'9110c825-43f6-41ba-9c18-109c758e21b9', N'Kannada', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Languages] ([Id], [Name], [CreatedDate]) VALUES (N'c4119615-20e2-4914-b008-3b9ae43854b0', N'Hindi', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Languages] ([Id], [Name], [CreatedDate]) VALUES (N'3cca3c7c-6fe8-472b-aa37-773954dd7c96', N'English', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [LanguageId], [MultiplexId], [CreatedDate], [ModifiedDate]) VALUES (N'0bcaec09-19d9-4e64-8693-217012a6eaae', N'Tum Bin', N'e74af6c6-c5f4-435d-95a5-3fe7a07738b4', N'c4119615-20e2-4914-b008-3b9ae43854b0', N'46b5dcea-c6ac-495b-8ede-512fb7295ea3', CAST(N'2020-07-26T10:33:21.6850000' AS DateTime2), CAST(N'2020-07-26T10:33:21.6850000' AS DateTime2))
INSERT [dbo].[Movies] ([Id], [Name], [GenreId], [LanguageId], [MultiplexId], [CreatedDate], [ModifiedDate]) VALUES (N'9b85c4e5-d41f-4293-837c-8dc95ef0afc8', N'Tere Name', N'e74af6c6-c5f4-435d-95a5-3fe7a07738b4', N'c4119615-20e2-4914-b008-3b9ae43854b0', N'46b5dcea-c6ac-495b-8ede-512fb7295ea3', CAST(N'2020-07-26T10:33:21.6850000' AS DateTime2), CAST(N'2020-07-26T10:33:21.6850000' AS DateTime2))
INSERT [dbo].[Multiplexes] ([Id], [CityId], [Name], [NoOfShowPerDay], [TotalNumberOfSeats], [CreatedDate]) VALUES (N'3078f14d-6979-4fdf-9fba-0df98747463b', N'ba660bcc-58b1-42df-90ad-ff9483b20f80', N'PVR Rivoli', 1, 100, CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Multiplexes] ([Id], [CityId], [Name], [NoOfShowPerDay], [TotalNumberOfSeats], [CreatedDate]) VALUES (N'6ea76be0-ca2d-4e66-89f5-501cd13a110d', N'5e56bcac-f87c-4f13-8ae4-08a68a5fe729', N'Cinepolis Multiplex', 1, 100, CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Multiplexes] ([Id], [CityId], [Name], [NoOfShowPerDay], [TotalNumberOfSeats], [CreatedDate]) VALUES (N'46b5dcea-c6ac-495b-8ede-512fb7295ea3', N'3fd28d9e-0887-44a0-950c-6ee6a7a93924', N'balaji movieplex', 1, 100, CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [Name], [CreatedDate]) VALUES (N'16e3676f-bdac-48c5-a37f-3dd3a9782a9a', N'Customer', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Roles] ([Id], [Name], [CreatedDate]) VALUES (N'd9ba7798-e8cd-477e-9d08-9ea38003f104', N'Admin', CAST(N'2020-07-26T00:57:39.1620000' AS DateTime2))
INSERT [dbo].[Users] ([Id], [UserName], [EmailId], [FullName], [Password], [CreatedDate], [ModifiedDate], [LastLoggedInDate], [IsActive], [RoleId]) VALUES (N'5cfe1ffb-a965-43bf-9825-024703f96373', N'mukund@gmail.com', N'mukund@gmail.com', N'Mukund Narayan Jha', N'123456', CAST(N'2018-11-23T00:57:39.1620000' AS DateTime2), NULL, NULL, 1, N'16e3676f-bdac-48c5-a37f-3dd3a9782a9a')
INSERT [dbo].[Users] ([Id], [UserName], [EmailId], [FullName], [Password], [CreatedDate], [ModifiedDate], [LastLoggedInDate], [IsActive], [RoleId]) VALUES (N'1808fc15-0e1a-4002-8c9c-8e9e3cb94e07', N'test2@gmail.com', N'test2@gmail.com', N'Test 2', N'123456', CAST(N'2018-11-23T00:57:39.1620000' AS DateTime2), NULL, NULL, 1, N'd9ba7798-e8cd-477e-9d08-9ea38003f104')
INSERT [dbo].[Users] ([Id], [UserName], [EmailId], [FullName], [Password], [CreatedDate], [ModifiedDate], [LastLoggedInDate], [IsActive], [RoleId]) VALUES (N'39e40c7e-448b-4fe6-bb72-f46c43dc8c27', N'test3@gmail.com', N'test3@gmail.com', N'Test 3', N'123456', CAST(N'2018-11-23T00:57:39.1620000' AS DateTime2), NULL, NULL, 1, N'd9ba7798-e8cd-477e-9d08-9ea38003f104')
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [RoleId]
GO

