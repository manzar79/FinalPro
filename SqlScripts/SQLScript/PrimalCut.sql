USE [FinalProjectDB]
GO

/****** Object:  Table [dbo].[PrimalCut]    Script Date: 8/4/2014 3:42:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PrimalCut](
	[PrimalCutId] [int] IDENTITY(1,1) NOT NULL,
	[PrimalCutName] [varchar](50) NULL,
	[AnimalId] [int] NOT NULL,
 CONSTRAINT [PK_PrimalCut] PRIMARY KEY CLUSTERED 
(
	[PrimalCutId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PrimalCut]  WITH CHECK ADD  CONSTRAINT [FK_PrimalCut_Animal1] FOREIGN KEY([AnimalId])
REFERENCES [dbo].[Animal] ([AnimalId])
GO

ALTER TABLE [dbo].[PrimalCut] CHECK CONSTRAINT [FK_PrimalCut_Animal1]
GO

