namespace TokoSukaMaju.Models
{
    public class TransaksiDetail
    {
        public string TransaksiHeader { get; set; }
        public int Id { get; set; }
        public int ProdukId { get; set; }
        public Produk Produk { get; set; }
        public int Jumlah { get; set; }
        public int Total { get; set; }
    }
}