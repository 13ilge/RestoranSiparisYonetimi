using Dapper;
using Npgsql;
using RestoranSiparis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestoranSiparis.Repositories
{
    public class SiparisRepository
    {
        private readonly string _connectionString;

        public SiparisRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Siparis>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Siparis";
            return await connection.QueryAsync<Siparis>(query);
        }

        public async Task<int> AddAsync(Siparis siparis)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "INSERT INTO Siparis (Masa_ID, Mutfak_ID, Garson_ID, Durum, ToplamFiyat) VALUES (@Masa_ID, @Mutfak_ID, @Garson_ID, @Durum, @ToplamFiyat)";
            return await connection.ExecuteAsync(query, siparis);
        }

        public async Task<Siparis> GetSiparisByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Siparis WHERE Siparis_ID = @id";
            return await connection.QueryFirstOrDefaultAsync<Siparis>(query, new { id });
        }

        public async Task<int> UpdateAsync(Siparis siparis)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "UPDATE Siparis SET Masa_ID = @Masa_ID, Mutfak_ID = @Mutfak_ID, Garson_ID = @Garson_ID, Durum = @Durum, ToplamFiyat = @ToplamFiyat WHERE Siparis_ID = @Siparis_ID";
            return await connection.ExecuteAsync(query, siparis);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "DELETE FROM Siparis WHERE Siparis_ID = @id";
            return await connection.ExecuteAsync(query, new { id });
        }
    }
}
