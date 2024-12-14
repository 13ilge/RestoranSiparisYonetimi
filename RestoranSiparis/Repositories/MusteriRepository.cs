using Dapper;
using Npgsql;
using RestoranSiparis.Models;

namespace RestoranSiparis.Repositories
{
    public class MusteriRepository
    {
        private readonly string _connectionString;

        public MusteriRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MusteriRepository()
        {
        }

        // Tüm Müşterileri Listeleme
        public async Task<IEnumerable<Musteri>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Musteri";
            return await connection.QueryAsync<Musteri>(query);
        }

        // ID'ye Göre Müşteri Getirme
        public async Task<Musteri> GetMusteriByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Musteri WHERE Musteri_ID = @id";
            return await connection.QueryFirstOrDefaultAsync<Musteri>(query, new { id });
        }

        // Yeni Müşteri Ekleme
        public async Task<int> AddAsync(Musteri musteri)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "INSERT INTO Musteri (Ad, Soyad, Telefon) VALUES (@Ad, @Soyad, @Telefon)";
            return await connection.ExecuteAsync(query, musteri);
        }

        // Müşteri Güncelleme
        public async Task<int> UpdateAsync(Musteri musteri)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "UPDATE Musteri SET Ad = @Ad, Soyad = @Soyad, Telefon = @Telefon WHERE Musteri_ID = @Musteri_ID";
            return await connection.ExecuteAsync(query, musteri);
        }

        // Müşteri Silme
        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "DELETE FROM Musteri WHERE Musteri_ID = @id";
            return await connection.ExecuteAsync(query, new { id });
        }
    }
}
