USE [Belajar]
GO
/****** Object:  Table [dbo].[transaksi_header]    Script Date: 02/11/2021 09:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transaksi_header](
	[transaksi_id] [varchar](14) NOT NULL,
	[transaksi_pelanggan] [int] NULL,
	[transaksi_tanggal] [date] NULL,
	[transaksi_total] [int] NULL,
	[created_dt] [datetime] NULL,
	[updated_dt] [datetime] NULL,
 CONSTRAINT [PK_transaksi_header] PRIMARY KEY CLUSTERED 
(
	[transaksi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[transaksi_header]  WITH CHECK ADD  CONSTRAINT [FK_transaksi_header_master_pelanggan] FOREIGN KEY([transaksi_pelanggan])
REFERENCES [dbo].[master_pelanggan] ([pelanggan_id])
GO
ALTER TABLE [dbo].[transaksi_header] CHECK CONSTRAINT [FK_transaksi_header_master_pelanggan]
GO
