using System.Data.OleDb;
using System.IO;
using ADOX;

namespace ThreadDataGenerator.Services;

public class DatabaseService
{
    private OleDbConnection connection = null!;
    private OleDbCommand command = null!;

    public DatabaseService()
    {
        InitializeOleDbConnection();
    }

    private void InitializeOleDbConnection()
    {
        string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "threads.mdb");
        string connectionString = @$"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath}";

        connection = new OleDbConnection(connectionString);
        command = new OleDbCommand();
        command.Connection = connection;
    }

    public async Task SaveToDatabaseAsync(int threadId, string randomString)
    {
        string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "threads.mdb");
        string connectionString = @$"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath}";

        DateTime currentTime = DateTime.Now;
        string formattedDateTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

        try
        {
            if (!File.Exists(databasePath))
            {
                Catalog catalog = new Catalog();
                catalog.Create($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Jet OLEDB:Engine Type=5");

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand createTableCommand = new OleDbCommand())
                {
                    createTableCommand.Connection = connection;
                    createTableCommand.CommandText = @"CREATE TABLE ThreadData (
                                                         ID AUTOINCREMENT PRIMARY KEY,
                                                         thread_id INT,
                                                         date_inserted DATETIME,
                                                         random_string VARCHAR(50));";

                    await connection.OpenAsync();
                    await createTableCommand.ExecuteNonQueryAsync();
                }
            }

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbCommand insertCommand = new OleDbCommand())
            {
                insertCommand.Connection = connection;
                insertCommand.CommandText = @"INSERT INTO ThreadData (
                                                thread_id, 
                                                date_inserted, 
                                                random_string) 
                                             VALUES 
                                                (@ThreadId,     
                                                @Time, 
                                                @RandomString)";

                insertCommand.Parameters.AddWithValue("@ThreadID", threadId);
                insertCommand.Parameters.AddWithValue("@Time", formattedDateTime);
                insertCommand.Parameters.AddWithValue("@RandomString", randomString);

                await connection.OpenAsync();
                await insertCommand.ExecuteNonQueryAsync();
            }
        }
        catch (OleDbException)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
    }
}