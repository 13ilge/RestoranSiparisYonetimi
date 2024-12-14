using Dapper;
using Npgsql;
using RestoranSiparis.Models;

namespace RestoranSiparis.Repositories
{
    

    public class MasaRepository
    {
        private readonly string _connectionString;

        public MasaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm Masaları Listeleme
        public async Task<IEnumerable<Masa>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Masa";
            return await connection.QueryAsync<Masa>(query);
        }

        // ID'ye Göre Masa Getirme
        public async Task<Masa> GetMasaByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Masa WHERE Masa_ID = @id";
            return await connection.QueryFirstOrDefaultAsync<Masa>(query, new { id });
        }

        // Yeni Masa Ekleme
        public async Task<int> AddAsync(Masa masa)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "INSERT INTO Masa (Masa_ID) VALUES (@Masa_ID)";
            return await connection.ExecuteAsync(query, masa);
        }

        // Masa Güncelleme
        public async Task<int> UpdateAsync(Masa masa)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "UPDATE Masa SET Masa_ID = @Masa_ID WHERE Masa_ID = @Masa_ID";
            return await connection.ExecuteAsync(query, masa);
        }

        // Masa Silme
        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "DELETE FROM Masa WHERE Masa_ID = @id";
            return await connection.ExecuteAsync(query, new { id });
        }
    }

}
