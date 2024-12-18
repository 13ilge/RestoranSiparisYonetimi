namespace RestoranSiparis.Models
{
    
    public class Urunler
    {
        public int Urun_ID { get; set; }
        public int Kategori_ID { get; set; }
        public string? Ad { get; set; }
        public decimal Fiyat { get; set; }
    }

}
