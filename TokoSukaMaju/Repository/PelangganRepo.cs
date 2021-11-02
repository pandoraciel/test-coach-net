using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TokoSukaMaju.Models;

namespace TokoSukaMaju.Repository
{
    public class PelangganRepo
    {
        public IDbConnection con;
        public PelangganRepo()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBCon"].ToString();
            con = new SqlConnection(constr);
        }

        public List<Pelanggan> GetListPelanggan()
        {
            var query = @"select 
                        pelanggan_id as Id,
                        pelanggan_nama as Nama,
                        pelanggan_alamat as Alamat,
                        pelanggan_telp as Telp 
                        from master_pelanggan
                        order by pelanggan_id";

            con.Open();
            var result = con.Query<Pelanggan>(query).ToList();
            con.Close();

            return result;
        }

        public Pelanggan GetPelanggan(int id)
        {
            var query = $"select " +
                        $"pelanggan_id as Id," +
                        $"pelanggan_nama as Nama," +
                        $"pelanggan_alamat as Alamat," +
                        $"pelanggan_telp as Telp " +
                        $"from master_pelanggan " +
                        $"where pelanggan_id = @id";
            con.Open();
            var result = con.QueryFirst<Pelanggan>(query, new { id });
            con.Close();

            return result;
        }

        public int AddPelanggan(Pelanggan pelanggan)
        {
            var query = @"insert into master_pelanggan(pelanggan_nama, pelanggan_alamat, pelanggan_telp, created_dt)
                        values (@Nama, @Alamat, @Telp, GETDATE())";

            var parameters = new
            {
                pelanggan.Nama,
                pelanggan.Alamat,
                pelanggan.Telp
            };

            con.Open();
            var result = con.Execute(query, parameters);
            con.Close();

            return result;
        }

        public int DeletePelanggan(int id)
        {
            var query = "delete from master_pelanggan where pelanggan_id = @id";

            con.Open();
            var result = con.Execute(query, new { id });
            con.Close();

            return result;
        }

        public int UpdatePelanggan(Pelanggan pelanggan)
        {
            var query = @"update master_pelanggan 
                        set 
                        pelanggan_nama = @Nama,
                        pelanggan_alamat = @Alamat,
                        pelanggan_telp = @Telp, 
                        updated_dt = GETDATE()
                        where pelanggan_id = @Id";

            var parameters = new
            {
                pelanggan.Id,
                pelanggan.Nama,
                pelanggan.Alamat,
                pelanggan.Telp
            };

            con.Open();
            var result = con.Execute(query, parameters);
            con.Close();

            return result;
        }
    }
}