namespace RestoranSiparis.Repositories
{
    // Repositories/StokRepository.cs
    using Dapper;
    using Npgsql;
    using RestoranSiparis.Models;
    using System.Collections.Generic;
    using System.Data;

    public class StokRepository
    {
        private readonly string _connectionString;

        public StokRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm stokları listele
        public IEnumerable<Stok> GetAll()
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Stok>("SELECT * FROM Stok");
            }
        }

        // ID'ye göre stok bul
        public Stok GetById(int id)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Stok>("SELECT * FROM Stok WHERE Stok_ID = @Id", new { Id = id });
            }
        }

        // Yeni stok ekle
        public void Add(Stok stok)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "INSERT INTO Stok (Urun_ID, StokDurum, GuncellemeTarih) VALUES (@Urun_ID, @StokDurum, @GuncellemeTarih)";
                dbConnection.Execute(query, stok);
            }
        }

        // Stok güncelle
        public void Update(Stok stok)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "UPDATE Stok SET Urun_ID = @Urun_ID, StokDurum = @StokDurum, GuncellemeTarih = @GuncellemeTarih WHERE Stok_ID = @Stok_ID";
                dbConnection.Execute(query, stok);
            }
        }

        // Stok sil
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "DELETE FROM Stok WHERE Stok_ID = @Id";
                dbConnection.Execute(query, new { Id = id });
            }
        }
    }

}
