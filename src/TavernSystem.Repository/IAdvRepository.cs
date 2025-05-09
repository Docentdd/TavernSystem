using TavernSystem.Model;

namespace TavernSystem.Repository;

public interface IAdvRepository
{
    List<Adventurer> GetAllAdventurers();
    Adventurer GetAdventurerById(int id);
    void AddAdventurer(Adventurer adventurer);
    Person GetPersonById(string id);
}