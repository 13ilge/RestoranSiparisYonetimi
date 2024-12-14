using Dapper;
using Npgsql;
using RestoranSiparis.Models;

namespace RestoranSiparis.Repositories
{
    public class KasiyerRepository
    {
        private readonly string _connectionString;

        public KasiyerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm Kasiyerleri Listeleme
        public async Task<IEnumerable<Kasiyer>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Kasiyer";
            return await connection.QueryAsync<Kasiyer>(query);
        }

        // ID'ye Göre Kasiyer Getirme
        public async Task<Kasiyer> GetKasiyerByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Kasiyer WHERE Kasiyer_ID = @id";
            return await connection.QueryFirstOrDefaultAsync<Kasiyer>(query, new { id });
        }

        // Yeni Kasiyer Ekleme
        public async Task<int> AddAsync(Kasiyer kasiyer)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "INSERT INTO Kasiyer (Ad, Soyad) VALUES (@Ad, @Soyad)";
            return await connection.ExecuteAsync(query, kasiyer);
        }

        // Kasiyer Güncelleme
        public async Task<int> UpdateAsync(Kasiyer kasiyer)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "UPDATE Kasiyer SET Ad = @Ad, Soyad = @Soyad WHERE Kasiyer_ID = @Kasiyer_ID";
            return await connection.ExecuteAsync(query, kasiyer);
        }

        // Kasiyer Silme
        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "DELETE FROM Kasiyer WHERE Kasiyer_ID = @id";
            return await connection.ExecuteAsync(query, new { id });
        }
    }

}
