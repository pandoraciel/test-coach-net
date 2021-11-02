using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TokoSukaMaju.Models;

namespace TokoSukaMaju.Repository
{
    public class TransaksiRepo
    {
        readonly IDbConnection con;
        public TransaksiRepo()
        {
            var constr = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
            con = new SqlConnection(constr);
        }

        public List<TransaksiHeader> GetTransaksis()
        {
            var query = @"select a.transaksi_id as Id, 
                        convert(varchar, a.transaksi_tanggal, 106) as TanggalStr,
                        a.transaksi_total as Total,
                        b.pelanggan_id,
                        b.pelanggan_nama as Nama
                        from transaksi_header a 
                        inner join master_pelanggan b on a.transaksi_pelanggan = b.pelanggan_id
                        order by a.created_dt desc";
            con.Open();
            var result = con.Query<TransaksiHeader, Pelanggan, TransaksiHeader>(query, (header, pelanggan) =>
            {
                header.Pelanggan = pelanggan;
                return header;
            },
            splitOn: "pelanggan_id").Distinct().ToList();
            con.Close();

            return result;
        }

        public int AddTransaksi(TransaksiHeader transaksi)
        {
            con.Open();
            var parameterH = new DynamicParameters();
            parameterH.Add("@PelangganId", transaksi.PelangganId);
            parameterH.Add("@Total", transaksi.Total);
            parameterH.Add("@Result", null ,dbType: DbType.String, direction: ParameterDirection.Output, 14);
            
            var transaksiKode = con.ExecuteScalar<string>("AddTransaksiHeader", parameterH, commandType: CommandType.StoredProcedure);

            var dt = new DataTable();
            dt.Columns.Add("transaksi_header_id");
            dt.Columns.Add("transaksi_detail_id");
            dt.Columns.Add("transaksi_detail_produk");
            dt.Columns.Add("transaksi_detail_jumlah");
            dt.Columns.Add("transaksi_detail_total");

            int i = 1;
            foreach(var data in transaksi.Details)
            {
                dt.Rows.Add(transaksiKode, i++, data.ProdukId, data.Jumlah, data.Total);
            }

            var parameterD = new DynamicParameters();
            parameterD.Add("@TransaksiDetail", dt.AsTableValuedParameter("TransaksiDetails"));
            parameterD.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = con.ExecuteScalar<int>("AddTransaksiDetail", parameterD, commandType: CommandType.StoredProcedure);
            con.Close();

            return result;
        }

        public List<TransaksiHeader> TransaksiHeader(string id)
        {
            var query = @"select a.transaksi_id as Id, 
                        convert(varchar, a.transaksi_tanggal, 106) as TanggalStr,
                        a.transaksi_total as Total,
                        b.pelanggan_id,
                        b.pelanggan_nama as Nama,
                        b.pelanggan_telp as Telp
                        from transaksi_header a 
                        inner join master_pelanggan b on a.transaksi_pelanggan = b.pelanggan_id
                        where a.transaksi_id = @id";
            con.Open();
            var result = con.Query<TransaksiHeader, Pelanggan, TransaksiHeader>(query, (header, pelanggan) =>
            {
                header.Pelanggan = pelanggan;
                return header;
            }, new { id },
            splitOn: "pelanggan_id").Distinct().ToList();

            con.Close();

            return result;
        }

        public List<TransaksiDetail> TransaksiDetails(string id)
        {
            var query = @"select
                        a.transaksi_header_id as TransaksiHeader,
                        a.transaksi_detail_id as Id,
                        a.transaksi_detail_jumlah as Jumlah,
                        a.transaksi_detail_total as Total,
                        b.produk_id as Produk_Id,
                        b.produk_nama as Nama,
                        b.produk_harga as Harga
                        from transaksi_detail a
                        inner join master_produk b on a.transaksi_detail_produk = b.produk_id
                        where a.transaksi_header_id = @id";

            con.Open();
            var result = con.Query<TransaksiDetail, Produk, TransaksiDetail>(query, (detail, produk) =>
            {
                detail.Produk = produk;
                return detail;
            }, new { id },
            splitOn: "produk_id").Distinct().ToList();
            con.Close();

            return result;

        }
    }
}