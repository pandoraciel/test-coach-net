USE [Belajar]
GO
/****** Object:  StoredProcedure [dbo].[AddTransaksiDetail]    Script Date: 02/11/2021 09:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddTransaksiDetail]
	@TransaksiDetail TransaksiDetails READONLY,
	@Result INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO transaksi_detail(
	transaksi_header_id, 
	transaksi_detail_id, 
	transaksi_detail_produk, 
	transaksi_detail_total, 
	transaksi_detail_jumlah, 
	created_dt)
	SELECT transaksi_header_id, 
	transaksi_detail_id, 
	transaksi_detail_produk, 
	transaksi_detail_total, 
	transaksi_detail_jumlah,
	getdate()
	FROM @TransaksiDetail

	SELECT @Result = COUNT(*) FROM @TransaksiDetail
	SELECT @Result
END
GO
