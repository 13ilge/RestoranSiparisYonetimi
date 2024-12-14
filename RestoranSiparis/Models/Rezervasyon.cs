namespace RestoranSiparis.Models
{
    public class Rezervasyon
    {
        public int Rezervasyon_ID { get; set; }
        public int Musteri_ID { get; set; }
        public int Masa_ID { get; set; }
        public DateTime RezervasyonTarihi { get; set; }
        public int KisiSayisi { get; set; }
        public string Durum { get; set; }
        public DateTime? IptalTarihi { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
    }

}
