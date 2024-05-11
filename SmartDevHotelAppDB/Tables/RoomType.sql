﻿
CREATE TABLE [SMARTDEV_HOTEL_APP].[RoomType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](2000) NULL,
	[Price] [money] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [SMARTDEV_HOTEL_APP].[RoomType] ADD  CONSTRAINT [DF_RoomType_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO

