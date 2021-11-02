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
    public class ProdukRepo
    {
        readonly IDbConnection con;
        public ProdukRepo()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
            con = new SqlConnection(constr);
        }

        public List<Produk> GetListProduk()
        {
            var query = @"select 
                        produk_id as Id,
                        produk_nama as Nama,
                        produk_harga as Harga,
                        produk_deskripsi as Deskripsi
                        from master_produk";
            con.Open();
            var result = con.Query<Produk>(query).ToList();
            con.Close();

            return result;
        }

        public Produk GetProduk(int id)
        {
            var query = @"select 
                        produk_id as Id,
                        produk_nama as Nama,
                        produk_harga as Harga,
                        produk_deskripsi as Deskripsi
                        from master_produk
            where produk_id = @id";
            con.Open();
            var result = con.QuerySingle<Produk>(query, new { id });
            con.Close();

            return result;
        }

        public int AddProduk(Produk produk)
        {
            var parameters = new
            {
                produk.Nama,
                produk.Harga,
                produk.Deskripsi
            };

            var query = @"insert into master_produk(produk_nama, produk_harga, produk_deskripsi, created_dt)
                        values(@Nama, @Harga, @Deskripsi, GETDATE())";

            con.Open();
            var result = con.Execute(query, parameters);
            con.Close();

            return result;
        }

        public int UpdateProduk(Produk produk)
        {
            var parameters = new
            {
                produk.Id,
                produk.Nama,
                produk.Harga,
                produk.Deskripsi
            };

            var query = @"update master_produk
                        set
                        produk_nama = @Nama,
                        produk_harga = @Harga,
                        produk_deskripsi = @Deskripsi
                        where produk_id = @Id";

            con.Open();
            var result = con.Execute(query, parameters);
            con.Close();

            return result;
        }

        public int DeleteProduk(int id)
        {
            var query = "delete from master_produk where produk_id = @id";
            con.Open();
            var result = con.Execute(query, new { id });
            con.Close();

            return result;
        }
    }
}