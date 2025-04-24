using COMP003B.Assigment5.Models;
using COMP003B.Assigment5.Data;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assigment5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PartsController : Controller
    {
        [HttpGet]
        public ActionResult<List<Parts>> GetParts()
        {
            return Ok(PartsStore.Parts);
        }

        [HttpGet("{id}")]

        public ActionResult<Parts> GetParts(int id)
        {
            var parts = PartsStore.Parts.FirstOrDefault(p => p.Id == id);

            if (parts is null)
                return NotFound();

            return Ok(parts);
        }
        [HttpPost]

        public ActionResult<Parts> CreateParts(Parts parts)
        {
            parts.Id = PartsStore.Parts.Max(p => p.Id) + 1;

            PartsStore.Parts.Add(parts);

            return CreatedAtAction(nameof(GetParts), new { id = parts.Id } );
        }

        [HttpPut("{id}")]

        public IActionResult UpdateParts(int id, Parts updatedPart)
        {
            var existingParts = PartsStore.Parts.FirstOrDefault(p =>p.Id == id);

            if (existingParts is null)
                return NotFound();

            existingParts.Name = updatedPart.Name;
            existingParts.Price = updatedPart.Price;

            return NoContent();
        }


        [HttpDelete("{id}")]

        public IActionResult DeleteParts(int id)
        {
            var parts = PartsStore.Parts.First(p => p.Id == id);
            
            if (parts is null)
                return NotFound();

            PartsStore.Parts.Remove(parts);

            return NoContent();
        }

        [HttpGet("filter")]

        public ActionResult<List<Parts>> FilterParts(decimal price)
        {
            var filteredParts = PartsStore.Parts
                .Where(p => p.Price <= price)
                .OrderBy(p => p.Price)
                .ToList();

            return Ok(filteredParts);
        }

        [HttpGet("names")]

        public ActionResult<List<string>> GetPartsNames()
        {
            var partsNames = PartsStore.Parts
                .OrderBy(p => p.Name)
                .Select(p => p.Name)
                .ToList();

            return Ok(partsNames);
        }
    }
    
}
