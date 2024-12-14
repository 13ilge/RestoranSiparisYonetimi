namespace RestoranSiparis.Models
{
    // Models/Stok.cs
    public class Stok
    {
        public int Stok_ID { get; set; }
        public int Urun_ID { get; set; }
        public int StokDurum { get; set; }
        public DateTime GuncellemeTarih { get; set; }
    }

}
