using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShoppe.Models;
using PetShoppe.Services;

namespace PetShoppe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatsController : ControllerBase
    {
        private readonly CatsService _cs;

        public CatsController(CatsService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public List<Cat> GetCats()
        {
            return _cs.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Cat> GetCat(int id)
        {
            try
            {
                var cat = _cs.GetCatById(id);
                if (cat == null)
                {
                    return BadRequest("Invalid Id");
                }
                return Ok(cat);
            }
            catch (System.Exception e)
            {
                return Forbid(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Cat> CreateCat([FromBody] Cat catData)
        {
            try
            {
                var cat = _cs.createCat(catData);
                return Created("api/cats/" + cat.Id, cat);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Cat> EditCat(int id, [FromBody] Cat catData)
        {
            try
            {
                // edit the cat
                return Ok(catData);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<Cat> KillCat(int id)
        {
            try
            {
                var cat = _cs.removeCat(id);
                return Ok(cat);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}