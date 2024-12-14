using Dapper;
using Npgsql;
using RestoranSiparis.Models;
using System.Collections.Generic;
using System.Data;

namespace RestoranSiparis.Repositories
{
    // Repositories/RezerveRepository.cs
   

    public class RezervasyonRepository
    {
        private readonly string _connectionString;

        public RezervasyonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm rezervasyonları listele
        public IEnumerable<Rezervasyon> GetAll()
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Rezervasyon>("SELECT * FROM Rezervasyon");
            }
        }

        // ID'ye göre rezervasyon bul
        public Rezervasyon GetById(int id)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Rezervasyon>("SELECT * FROM Rezervasyon WHERE Rezervasyon_ID = @Id", new { Id = id });
            }
        }

        // Yeni rezervasyon ekle
        public void Add(Rezervasyon rezervasyon)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "INSERT INTO Rezervasyon (Musteri_ID, Masa_ID, RezervasyonTarihi, KisiSayisi, Durum, IptalTarihi, GuncellenmeTarihi) " +
                               "VALUES (@Musteri_ID, @Masa_ID, @RezervasyonTarihi, @KisiSayisi, @Durum, @IptalTarihi, @GuncellenmeTarihi)";
                dbConnection.Execute(query, rezervasyon);
            }
        }

        // Rezervasyon güncelle
        public void Update(Rezervasyon rezervasyon)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "UPDATE Rezervasyon SET Musteri_ID = @Musteri_ID, Masa_ID = @Masa_ID, RezervasyonTarihi = @RezervasyonTarihi, " +
                               "KisiSayisi = @KisiSayisi, Durum = @Durum, IptalTarihi = @IptalTarihi, GuncellenmeTarihi = @GuncellenmeTarihi " +
                               "WHERE Rezervasyon_ID = @Rezervasyon_ID";
                dbConnection.Execute(query, rezervasyon);
            }
        }

        // Rezervasyon sil
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "DELETE FROM Rezervasyon WHERE Rezervasyon_ID = @Id";
                dbConnection.Execute(query, new { Id = id });
            }
        }
    }

}
