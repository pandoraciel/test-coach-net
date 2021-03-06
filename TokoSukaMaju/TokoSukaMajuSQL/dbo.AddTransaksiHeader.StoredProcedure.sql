USE [Belajar]
GO
/****** Object:  StoredProcedure [dbo].[AddTransaksiHeader]    Script Date: 02/11/2021 09:56:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddTransaksiHeader]
	@PelangganId INT,
	@Total INT,
	@Result VARCHAR(14) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- set prefix transaksi kode
	declare @prefix varchar(2) = 'TR',
			@seqStr varchar(4) = '0001',
			@seq int,
			@tgl varchar(2),
			@tahun varchar(2),
			@bulan varchar(2),
			@fulldate varchar(6),
			@trKode varchar(14),
			@trKodeFinal varchar(14)

	set @fulldate = convert(varchar, getdate(), 12)
	set @tgl = right(@fulldate, 2)
	set @tahun = left(@fulldate, 2)
	set @bulan = substring(@fulldate, 3, 2)

	if(exists(select 1 from transaksi_header where convert(varchar, created_dt, 12) = convert(varchar, getdate(), 12)))
	--if(exists(select 1 from transaksi_header where created_dt = getdate()))
	begin
		--select 'exist'
		select top 1 @trKode = transaksi_id from transaksi_header order by convert(varchar, created_dt, 12) desc
		set @seq = cast(substring(@trKode, 3, 4) as int)
		set @seqStr = right('000'+CAST(@seq+1 AS VARCHAR),4)
		set @trKodeFinal = @prefix + @seqStr + '/'+ @tgl + @bulan+'/'+@tahun
		--select @trKodeFinal
	end
	else
	begin
		--select 'not exist'
		set @trKodeFinal = @prefix + @seqStr + '/'+ @tgl + @bulan+'/'+@tahun
		--select @trKodeFinal
	end

    -- Insert statements for procedure here
	INSERT INTO transaksi_header(
		transaksi_id,
		transaksi_pelanggan,
		transaksi_tanggal,
		transaksi_total,
		created_dt
	)
	VALUES
	(
		@trKodeFinal,
		@PelangganId,
		convert(varchar, getdate(), 23),
		@Total,
		GETDATE()
	)

	set @Result = @trKodeFinal
	select @Result
END
GO
