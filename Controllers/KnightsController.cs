using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using knights.Services;
using knights.Models;

namespace knights.Controllers 
{
  [ApiController]
  [Route("api/[Controller]")]
  public class KnightsController : ControllerBase
  {
    private readonly KnightsService _ks;
    public KnightsController(KnightsService ks)
    {
      _ks = ks;
    }

    [HttpGet]
    public ActionResult<List<Knight>> GetKnight()
    {
      try
      {
        var knights = _ks.GetAll();
        return Ok(knights);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Knight> CreateKnight([FromBody] Knight knightData)
    {
      try
      {
        var knight = _ks.CreateKnight(knightData);
        return Created("api/knights/" + knight.Id, knight);

      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}