using Dapper;
using Npgsql;
using RestoranSiparis.Models;
namespace RestoranSiparis.Repositories
{
    

    public class SiparisRepository
    {
        private readonly string _connectionString;

        public SiparisRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Tüm Siparişleri Listeleme
        public async Task<IEnumerable<Siparis>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Siparis";
            return await connection.QueryAsync<Siparis>(query);
        }

        // ID'ye Göre Sipariş Getirme
        public async Task<Siparis> GetSiparisByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "SELECT * FROM Siparis WHERE Siparis_ID = @id";
            return await connection.QueryFirstOrDefaultAsync<Siparis>(query, new { id });
        }

        // Yeni Sipariş Ekleme
        public async Task<int> AddAsync(Siparis siparis)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "INSERT INTO Siparis (Masa_ID, MusteriID, Mutfak_ID, Garson_ID, Durum, ToplamFiyat) " +
                        "VALUES (@Masa_ID, @MusteriID, @Mutfak_ID, @Garson_ID, @Durum, @ToplamFiyat)";
            return await connection.ExecuteAsync(query, siparis);
        }

        // Sipariş Güncelleme
        public async Task<int> UpdateAsync(Siparis siparis)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "UPDATE Siparis SET Masa_ID = @Masa_ID, MusteriID = @MusteriID, Mutfak_ID = @Mutfak_ID, " +
                        "Garson_ID = @Garson_ID, Durum = @Durum, ToplamFiyat = @ToplamFiyat WHERE Siparis_ID = @Siparis_ID";
            return await connection.ExecuteAsync(query, siparis);
        }

        // Sipariş Silme
        public async Task<int> DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            var query = "DELETE FROM Siparis WHERE Siparis_ID = @id";
            return await connection.ExecuteAsync(query, new { id });
        }
    }

}
