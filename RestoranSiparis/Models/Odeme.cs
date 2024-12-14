namespace RestoranSiparis.Models
{
    public class Odeme
    {
        public int Odeme_ID { get; set; }
        public int Kasiyer_ID { get; set; }
        public int SiparisID { get; set; }
        public DateTime Tarih { get; set; }
        public string OdemeTuru { get; set; }
        public decimal Tutar { get; set; }
    }

}
