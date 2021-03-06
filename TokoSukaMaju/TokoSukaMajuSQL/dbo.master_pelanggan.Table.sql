USE [Belajar]
GO
/****** Object:  Table [dbo].[master_pelanggan]    Script Date: 02/11/2021 09:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[master_pelanggan](
	[pelanggan_id] [int] IDENTITY(1,1) NOT NULL,
	[pelanggan_nama] [varchar](32) NULL,
	[pelanggan_alamat] [varchar](50) NULL,
	[pelanggan_telp] [varchar](12) NULL,
	[created_dt] [datetime] NULL,
	[updated_dt] [datetime] NULL,
 CONSTRAINT [PK_master_pelanggan] PRIMARY KEY CLUSTERED 
(
	[pelanggan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
