using ItoApp.Application.Abstractions;
using Microsoft.Data.SqlClient;

namespace ItoApp.Infrastructure.Repositories;

using System.Data;


public class SqlOtpRepository : IOtpRepository
{
    private readonly string _cs;
    public SqlOtpRepository(string connectionString) => _cs = connectionString;

    public async Task SaveAsync(string phone, string purpose, string otpHash, DateTime expiresAt)
    {
        const string sql = @"
INSERT INTO dbo.OtpCodes(phone, purpose, otp_hash, expires_at)
VALUES (@phone, @purpose, @otp_hash, @expires_at);";

        using var conn = new SqlConnection(_cs);
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@phone", phone);
        cmd.Parameters.AddWithValue("@purpose", purpose);
        cmd.Parameters.AddWithValue("@otp_hash", otpHash);
        cmd.Parameters.Add("@expires_at", SqlDbType.DateTime2).Value = expiresAt;

        await conn.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }

    public async Task<OtpRecord?> GetLatestAsync(string phone, string purpose)
    {
        const string sql = @"
SELECT TOP 1 otp_id, otp_hash, expires_at, used_at, attempt_count
FROM dbo.OtpCodes
WHERE phone=@phone AND purpose=@purpose
ORDER BY created_at DESC;";

        using var conn = new SqlConnection(_cs);
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@phone", phone);
        cmd.Parameters.AddWithValue("@purpose", purpose);

        await conn.OpenAsync();
        using var r = await cmd.ExecuteReaderAsync();
        if (!await r.ReadAsync()) return null;

        return new OtpRecord(
            r.GetInt64(0),
            r.GetString(1),
            r.GetDateTime(2),
            r.IsDBNull(3) ? null : r.GetDateTime(3),
            r.GetInt32(4)
        );
    }

    public async Task MarkUsedAsync(long otpId)
    {
        const string sql = @"UPDATE dbo.OtpCodes SET used_at=SYSDATETIME() WHERE otp_id=@id;";
        using var conn = new SqlConnection(_cs);
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", otpId);
        await conn.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }

    public async Task IncreaseAttemptAsync(long otpId)
    {
        const string sql = @"UPDATE dbo.OtpCodes SET attempt_count = attempt_count + 1 WHERE otp_id=@id;";
        using var conn = new SqlConnection(_cs);
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", otpId);
        await conn.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }
}
