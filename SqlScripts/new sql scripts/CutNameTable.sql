USE [FinalProjectDB]
GO

/****** Object:  Table [dbo].[CutName]    Script Date: 08/11/2014 09:43:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CutName](
	[CutId] [int] IDENTITY(1,1) NOT NULL,
	[CutName] [varchar](50) NULL,
	[PrimalCutId] [int] NOT NULL,
	[Notes] [text] NULL,
 CONSTRAINT [PK_CutName] PRIMARY KEY CLUSTERED 
(
	[CutId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CutName]  WITH CHECK ADD  CONSTRAINT [FK_CutName_PrimalCut] FOREIGN KEY([PrimalCutId])
REFERENCES [dbo].[PrimalCut] ([PrimalCutId])
GO

ALTER TABLE [dbo].[CutName] CHECK CONSTRAINT [FK_CutName_PrimalCut]
GO

