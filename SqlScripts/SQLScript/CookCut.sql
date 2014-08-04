USE [FinalProjectDB]
GO

/****** Object:  Table [dbo].[CookCut]    Script Date: 8/4/2014 9:46:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CookCut](
	[CutId] [int] NOT NULL,
	[CookId] [int] NOT NULL,
	[Good/Bad] [bit] NULL,
	[CookCutId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CookCut] PRIMARY KEY CLUSTERED 
(
	[CookCutId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CookCut]  WITH CHECK ADD  CONSTRAINT [FK_CookCut_CookType] FOREIGN KEY([CookId])
REFERENCES [dbo].[CookType] ([CookId])
GO

ALTER TABLE [dbo].[CookCut] CHECK CONSTRAINT [FK_CookCut_CookType]
GO

ALTER TABLE [dbo].[CookCut]  WITH CHECK ADD  CONSTRAINT [FK_CookCut_CutName] FOREIGN KEY([CutId])
REFERENCES [dbo].[CutName] ([CutId])
GO

ALTER TABLE [dbo].[CookCut] CHECK CONSTRAINT [FK_CookCut_CutName]
GO

