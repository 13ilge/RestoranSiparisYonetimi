using Dapper;
using Npgsql;
using RestoranSiparis.Models;
using System.Data;

namespace RestoranSiparis.Repositories
{
    // Repositories/MutfakPersoneliRepository.cs
    

    public class MutfakPersoneliRepository
    {
        private readonly string _connectionString;

        public MutfakPersoneliRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm mutfak personelini listele
        public IEnumerable<MutfakPersoneli> GetAll()
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<MutfakPersoneli>("SELECT * FROM MutfakPersoneli");
            }
        }

        // ID'ye göre mutfak personelini bul
        public MutfakPersoneli GetById(int id)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<MutfakPersoneli>("SELECT * FROM MutfakPersoneli WHERE MutfakP_ID = @Id", new { Id = id });
            }
        }

        // Yeni mutfak personeli ekle
        public void Add(MutfakPersoneli mutfakPersoneli)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "INSERT INTO MutfakPersoneli (Ad, Soyad) VALUES (@Ad, @Soyad)";
                dbConnection.Execute(query, mutfakPersoneli);
            }
        }

        // Mutfak personelini güncelle
        public void Update(MutfakPersoneli mutfakPersoneli)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "UPDATE MutfakPersoneli SET Ad = @Ad, Soyad = @Soyad WHERE MutfakP_ID = @MutfakP_ID";
                dbConnection.Execute(query, mutfakPersoneli);
            }
        }

        // Mutfak personelini sil
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = "DELETE FROM MutfakPersoneli WHERE MutfakP_ID = @Id";
                dbConnection.Execute(query, new { Id = id });
            }
        }
    }

}
