using TavernSystem.Model;
using TavernSystem.Repository;

namespace TavernSystem.Logic;

public class AdvManager
{
    private readonly IAdvRepository _advRepository;
    public AdvManager(IAdvRepository advRepository)
    {
        _advRepository = advRepository;
    }
    public List<Adventurer> GetAllAdventurers()
    {
        return _advRepository.GetAllAdventurers();
    }
    public Adventurer GetAdventurerById(int id)
    {
        return _advRepository.GetAdventurerById(id);
    }
    public void AddAdventurer(Adventurer adventurer)
    {
        _advRepository.AddAdventurer(adventurer);
    }
    
    
}