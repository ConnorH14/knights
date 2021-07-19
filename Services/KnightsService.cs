using System.Collections.Generic;
using knights.Data;
using knights.Models;

namespace knights.Services
{
  public class KnightsService
  {
    private readonly KnightsRepository _knightsRepo;

    public KnightsService(KnightsRepository knightsRepo)
    {
      _knightsRepo = knightsRepo;
    }
    public List<Knight> GetAll()
    {
      return _knightsRepo.GetAll();
    }

    public Knight CreateKnight(Knight knightData)
    {
      return _knightsRepo.Create(knightData);
    }
  }
}