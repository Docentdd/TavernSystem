using Microsoft.Data.SqlClient;
using TavernSystem.Model;

namespace TavernSystem.Repository;

public class AdvRepository : IAdvRepository
{
    private readonly string _connectionString;

    public AdvRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public List<Adventurer> GetAllAdventurers()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT * FROM Adventurers", connection);
            var reader = command.ExecuteReader();
            var adventurers = new List<Adventurer>();
            while (reader.Read())
            {
                var adventurer = new Adventurer
                {
                    Id = reader.GetInt32(0),
                    Nickname = reader.GetString(1),
                };
                adventurers.Add(adventurer);
            }
            return adventurers;
        }
    }
    public Adventurer GetAdventurerById(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT * FROM Adventurers WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Adventurer
                {
                    Id = reader.GetInt32(0),
                    Nickname = reader.GetString(1),
                };
            }
            return null;
        }
    }
    public Person GetPersonById(string id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT * FROM Persons WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Person
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    MiddleName = reader.GetString(2),
                    LastName = reader.GetString(2),
                     HasBounty= reader.GetBoolean(3),
                };
            }
            return null;
        }
    }
    public void AddAdventurer(Adventurer adventurer)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO Adventurers (PersonId, Nickname) VALUES (@PersonId, @Nickname)", connection);
            command.Parameters.AddWithValue("@PersonId", adventurer.PersonID);
            command.Parameters.AddWithValue("@Nickname", adventurer.Nickname);
            command.ExecuteNonQuery();
        }
    }
    
}