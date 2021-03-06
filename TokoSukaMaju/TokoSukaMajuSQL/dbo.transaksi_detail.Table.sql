USE [Belajar]
GO
/****** Object:  Table [dbo].[transaksi_detail]    Script Date: 02/11/2021 09:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transaksi_detail](
	[transaksi_header_id] [varchar](14) NOT NULL,
	[transaksi_detail_id] [int] NOT NULL,
	[transaksi_detail_produk] [int] NULL,
	[transaksi_detail_jumlah] [int] NULL,
	[transaksi_detail_total] [int] NULL,
	[created_dt] [datetime] NULL,
	[update_dt] [datetime] NULL,
 CONSTRAINT [PK_transaksi_detail] PRIMARY KEY CLUSTERED 
(
	[transaksi_header_id] ASC,
	[transaksi_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[transaksi_detail]  WITH CHECK ADD  CONSTRAINT [FK_transaksi_detail_transaksi_detail] FOREIGN KEY([transaksi_detail_produk])
REFERENCES [dbo].[master_produk] ([produk_id])
GO
ALTER TABLE [dbo].[transaksi_detail] CHECK CONSTRAINT [FK_transaksi_detail_transaksi_detail]
GO
ALTER TABLE [dbo].[transaksi_detail]  WITH CHECK ADD  CONSTRAINT [FK_transaksi_detail_transaksi_header] FOREIGN KEY([transaksi_header_id])
REFERENCES [dbo].[transaksi_header] ([transaksi_id])
GO
ALTER TABLE [dbo].[transaksi_detail] CHECK CONSTRAINT [FK_transaksi_detail_transaksi_header]
GO
