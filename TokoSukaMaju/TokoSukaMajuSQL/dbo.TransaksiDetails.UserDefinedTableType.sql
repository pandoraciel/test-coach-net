USE [Belajar]
GO
/****** Object:  UserDefinedTableType [dbo].[TransaksiDetails]    Script Date: 02/11/2021 09:56:23 ******/
CREATE TYPE [dbo].[TransaksiDetails] AS TABLE(
	[transaksi_header_id] [varchar](14) NULL,
	[transaksi_detail_id] [int] NULL,
	[transaksi_detail_produk] [int] NULL,
	[transaksi_detail_jumlah] [int] NULL,
	[transaksi_detail_total] [int] NULL
)
GO
