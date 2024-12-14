using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        // Yeni ödeme oluşturma
        public async Task<int> AddOdemeAsync(Odeme odeme)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            string query = @"
            INSERT INTO Odeme (Kasiyer_ID, SiparisID, Tarih, OdemeTuru, Tutar) 
            VALUES (@Kasiyer_ID, @SiparisID, @Tarih, @OdemeTuru, @Tutar) 
            RETURNING Odeme_ID";

            return await connection.ExecuteScalarAsync<int>(query, odeme);
        }

        // Ödeme ID ile ödeme bilgilerini getirme
        public async Task<Odeme> GetOdemeByIdAsync(int odemeId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            string query = "SELECT * FROM Odeme WHERE Odeme_ID = @OdemeID";
            return await connection.QuerySingleOrDefaultAsync<Odeme>(query, new { OdemeID = odemeId });
        }

        // Sipariş ID ile ödeme bilgilerini getirme
        public async Task<IEnumerable<Odeme>> GetOdemeBySiparisIdAsync(int siparisId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            string query = "SELECT * FROM Odeme WHERE SiparisID = @SiparisID";
            return await connection.QueryAsync<Odeme>(query, new { SiparisID = siparisId });
        }

        // Ödeme güncelleme
        public async Task UpdateOdemeAsync(Odeme odeme)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            string query = @"
            UPDATE Odeme
            SET Kasiyer_ID = @Kasiyer_ID, SiparisID = @SiparisID, Tarih = @Tarih, 
                OdemeTuru = @OdemeTuru, Tutar = @Tutar
            WHERE Odeme_ID = @Odeme_ID";

            await connection.ExecuteAsync(query, odeme);
        }

        // Ödeme silme
        public async Task DeleteOdemeAsync(int odemeId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            string query = "DELETE FROM Odeme WHERE Odeme_ID = @OdemeID";
            await connection.ExecuteAsync(query, new { OdemeID = odemeId });
        }
    }

}
