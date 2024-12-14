using Dapper;
using Npgsql;
using RestoranSiparis.Models;
using System.Collections.Generic;
using System.Data;
namespace RestoranSiparis.Repositories
{
    // Repositories/UrunlerRepository.cs
    

    public class UrunlerRepository
    {
        private readonly string _connectionString;

        public UrunlerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm ürünleri listele
        public IEnumerable<Urunler> GetAll()
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Urunler>("SELECT * FROM Urunler");
            }
        }

        // ID'ye göre ürün bul
        public Urunler GetById(int id)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Urunler>("SELECT * FROM Urunler WHERE Urun_ID = @Id", new { Id = id });
            }
        }

        // Yeni ürün ekle
        public void Add(Urunler urun)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "INSERT INTO Urunler (Kategori_ID, Ad, StokDurum, Fiyat) VALUES (@Kategori_ID, @Ad, @StokDurum, @Fiyat)";
                dbConnection.Execute(query, urun);
            }
        }

        // Ürünü güncelle
        public void Update(Urunler urun)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "UPDATE Urunler SET Kategori_ID = @Kategori_ID, Ad = @Ad, StokDurum = @StokDurum, Fiyat = @Fiyat WHERE Urun_ID = @Urun_ID";
                dbConnection.Execute(query, urun);
            }
        }

        // Ürünü sil
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "DELETE FROM Urunler WHERE Urun_ID = @Id";
                dbConnection.Execute(query, new { Id = id });
            }
        }
    }

}
