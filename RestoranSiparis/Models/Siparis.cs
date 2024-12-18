namespace RestoranSiparis.Models
{
    public class Siparis
    {
        public int Siparis_ID { get; set; }
        public int Masa_ID { get; set; }
        public int Mutfak_ID { get; set; }
        public int Garson_ID { get; set; }
        public string? Durum { get; set; }
        public int ToplamFiyat { get; set; }
    }
}
