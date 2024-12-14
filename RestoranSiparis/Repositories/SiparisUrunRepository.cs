// Repositories/SiparisUrunRepository.cs
using Dapper;
using Npgsql;
using RestoranSiparis.Models;
using System.Collections.Generic;
using System.Data;

namespace RestoranSiparis.Repositories
{
    
    public class SiparisUrunRepository
    {
        private readonly string _connectionString;

        public SiparisUrunRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Siparişe ürün eklemek
        public void Add(SiparisUrun siparisUrun)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "INSERT INTO Siparis_Urun (Siparis_ID, Urun_ID) " +
                               "VALUES (@Siparis_ID, @Urun_ID)";
                dbConnection.Execute(query, siparisUrun);
            }
        }

        // Siparişin ürünlerini almak
        public IEnumerable<SiparisUrun> GetBySiparisId(int siparisId)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "SELECT * FROM Siparis_Urun WHERE Siparis_ID = @Siparis_ID";
                return dbConnection.Query<SiparisUrun>(query, new { Siparis_ID = siparisId });
            }
        }

        // Siparişten ürün silmek
        public void Delete(int siparisId, int urunId)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "DELETE FROM Siparis_Urun WHERE Siparis_ID = @Siparis_ID AND Urun_ID = @Urun_ID";
                dbConnection.Execute(query, new { Siparis_ID = siparisId, Urun_ID = urunId });
            }
        }

        // Tüm Sipariş-Ürün ilişkilerini listelemek
        public IEnumerable<SiparisUrun> GetAll()
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<SiparisUrun>("SELECT * FROM Siparis_Urun");
            }
        }
    }

}
