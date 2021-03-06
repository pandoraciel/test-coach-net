USE [Belajar]
GO
/****** Object:  Table [dbo].[master_produk]    Script Date: 02/11/2021 09:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[master_produk](
	[produk_id] [int] IDENTITY(1,1) NOT NULL,
	[produk_nama] [varchar](32) NULL,
	[produk_harga] [int] NULL,
	[produk_deskripsi] [varchar](50) NULL,
	[created_dt] [datetime] NULL,
	[updated_dt] [datetime] NULL,
 CONSTRAINT [PK_master_produk] PRIMARY KEY CLUSTERED 
(
	[produk_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
