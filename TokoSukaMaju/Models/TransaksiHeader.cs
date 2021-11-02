using System;
using System.Collections.Generic;

namespace TokoSukaMaju.Models
{
    public class TransaksiHeader
    {
        public string Id { get; set; }
        public int PelangganId { get; set; }
        public Pelanggan Pelanggan { get; set; }
        //public DateTime Tanggal { get; set; }
        public string TanggalStr { get; set; }
        public int Total { get; set; }
        public List<TransaksiDetail> Details { get; set; } = new List<TransaksiDetail>();
    }
}