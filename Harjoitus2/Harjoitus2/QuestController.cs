using Harjoitus2;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class QuestController : ControllerBase
{
    private static List<Quest> quests = new List<Quest>
    {
        new Quest { Id = 1, Name = "Tuhoa rotat", Description = "Tapa 3 rottaa ja tuo nahat minulle.", Reward = 50 },
        new Quest { Id = 2, Name = "Etsi Viljo", Description = "Onkos Viljoo näkyny.", Reward = 100 }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Quest>> GetQuests()
    {
        return Ok(quests);
    }

    [HttpGet("{id}")]
    public ActionResult<Quest> GetQuest(int id)
    {
        var quest = quests.FirstOrDefault(q => q.Id == id);
        if (quest == null)
        {
            return NotFound();
        }
        return Ok(quest);
    }

    [HttpPost]
    public ActionResult<Quest> CreateQuest([FromBody] Quest newQuest)
    {
        newQuest.Id = quests.Max(q => q.Id) + 1;
        quests.Add(newQuest);
        return CreatedAtAction(nameof(GetQuest), new { id = newQuest.Id }, newQuest);
    }
}
