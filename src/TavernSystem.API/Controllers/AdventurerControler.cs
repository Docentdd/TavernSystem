using System.Text.RegularExpressions;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using TavernSystem.Model;
using TavernSystem.Repository;

namespace TavernSystem.API.Controllers;

[ApiController]
[Route("api/adventurers")]
public class AdventurerControler
{
    private readonly IAdvRepository _repository;

    public AdventurerControler(IAdvRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IResult GetAllAdventurers()
    {
        var adventurers = _repository.GetAllAdventurers()
            .Select(a => new { a.Id, a.Nickname });
        return Results.Ok(adventurers);
    }

    [HttpGet("{id}")]
    public IResult GetAdvById(int id)
    {
        var adventurer = _repository.GetAdventurerById(id);
        if (adventurer == null)
        {
            return Results.NotFound();
        }

        // Fetch related Person data (mocked here, replace with actual repository call)
        var person = _repository.GetPersonById(adventurer.PersonID);
        if (person == null)
        {
            return Results.NotFound("Person data not found.");
        }


        var response = new
        {
            id = adventurer.Id,
            nickname = adventurer.Nickname,
            race = "dwarf", // Replace with actual race data if available
            experienceLevel = "Intermediate", // Replace with actual experience level if available
            personData = new
            {
                id = person.Id,
                firstName = person.FirstName,
                middleName = person.MiddleName,
                lastName = person.LastName,
                hasBounty = person.HasBounty
            }
        };

        return Results.Ok(response);
    }
    [HttpPost]
    public IResult CreateAdventurer([FromBody] Adventurer newAdventurer)
    {
        if (!IsValidPersonId(newAdventurer.PersonID.ToString()))
        {
            return Results.BadRequest("Invalid Person ID format.");
        }

        using (var transaction = new TransactionScope(TransactionScopeOption.Required))
        {
            try
            {
                // Check if adventurer already exists
                var existingAdventurer = _repository.GetAllAdventurers()
                    .FirstOrDefault(a => a.PersonID == newAdventurer.PersonID);
                if (existingAdventurer != null)
                {
                    return Results.Conflict("Adventurer with this Person ID already exists.");
                }

                // Add the new adventurer
                _repository.AddAdventurer(newAdventurer);

                // Commit the transaction
                transaction.Complete();

                return Results.Created($"/api/adventurers/{newAdventurer.Id}", newAdventurer);
            }
            catch
            {
                transaction.Dispose();
                return Results.StatusCode(500);
            }
        }
    }

    
    private bool IsValidPersonId(string personId)
    {
        var regex = new Regex(@"^[A-Z]{2}[0-9]{4}(0[1-9]|1[0-1])(0[1-9]|1[0-9]|2[0-8])[0-9]{4}[A-Z]{2}$");
        return regex.IsMatch(personId);
    }
 
}