USE [FinalProjectDB]
GO

/****** Object:  Table [dbo].[AltName]    Script Date: 8/4/2014 9:45:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AltName](
	[AltNameId] [int] IDENTITY(1,1) NOT NULL,
	[CutId] [int] NOT NULL,
	[AltName] [varchar](50) NULL,
 CONSTRAINT [PK_AltName] PRIMARY KEY CLUSTERED 
(
	[AltNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AltName]  WITH CHECK ADD  CONSTRAINT [FK_AltName_CutName] FOREIGN KEY([CutId])
REFERENCES [dbo].[CutName] ([CutId])
GO

ALTER TABLE [dbo].[AltName] CHECK CONSTRAINT [FK_AltName_CutName]
GO

