USE [Test]
GO
/****** Object:  Table [dbo].[IMAGEN_USUARIO]    Script Date: 4/03/2023 13:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMAGEN_USUARIO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Imagen] [varbinary](max) NULL,
	[ImagenString] [varchar](max) NULL,
 CONSTRAINT [PK__IMAGEN_U__3214EC07E4C8B73B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
