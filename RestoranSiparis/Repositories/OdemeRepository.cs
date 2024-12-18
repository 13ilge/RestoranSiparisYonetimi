using Dapper;
using Npgsql;
using RestoranSiparis.Models;

namespace RestoranSiparis.Repositories
{
    public class OdemeRepository
    {
        private readonly string _connectionString;

        public OdemeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Odeme>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Odeme";
            return await connection.QueryAsync<Odeme>(query);
        }

        public async Task<int> AddAsync(Odeme odeme)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "INSERT INTO Odeme (Kasiyer_ID, SiparisID, Tarih, OdemeTuru, Tutar) VALUES (@Kasiyer_ID, @SiparisID, @Tarih, @OdemeTuru, @Tutar)";
            return await connection.ExecuteAsync(query, odeme);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "DELETE FROM Odeme WHERE Odeme_ID = @id";
            return await connection.ExecuteAsync(query, new { id });
        }

        public async Task<Odeme> GetOdemeByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Odeme WHERE Odeme_ID = @id";
            return await connection.QueryFirstOrDefaultAsync<Odeme>(query, new { id });
        }

        public async Task<int> UpdateAsync(Odeme odeme)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "UPDATE Odeme SET Kasiyer_ID = @Kasiyer_ID, SiparisID = @SiparisID, Tarih = @Tarih, OdemeTuru = @OdemeTuru, Tutar = @Tutar WHERE Odeme_ID = @Odeme_ID";
            return await connection.ExecuteAsync(query, odeme);
        }
    }
}
