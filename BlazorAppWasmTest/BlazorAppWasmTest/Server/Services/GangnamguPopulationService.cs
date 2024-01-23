using BlazorAppWasmTest.Server.Interfaces;
using BlazorAppWasmTest.Server.Models;
using BlazorAppWasmTest.Shared;

namespace BlazorAppWasmTest.Server.Services
{    
    public class GangnamguPopulationService : IGangnamguPopulation
    {
        // BlazorWasmDbContext : CRUD를 하는 중계 역할
        // 그 기능을들 서비스에서 수행할 것
        // 그래서 DBContext를 하나 생성한다.
        private readonly BlazorWasmDbContext _dbContext;

        public GangnamguPopulationService(BlazorWasmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddGangnamguPopulation(GangnamguPopulation population)
        {
            try
            {
                _dbContext.GangnamguPopulations.Add(population);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void DeleteGangnamguPopulation(int id)
        {
            try
            {
                GangnamguPopulation? gangnamguPopulation = _dbContext.GangnamguPopulations.Find(id);
                if (gangnamguPopulation != null) 
                {
                    _dbContext.GangnamguPopulations.Remove(gangnamguPopulation);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<GangnamguPopulation> GetAllGangnamguPopulations()
        {
            try
            {
                return _dbContext.GangnamguPopulations.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public GangnamguPopulation GetGangnamguPopulation(int id)
        {
            try
            {
                GangnamguPopulation? gangnamguPopulation = _dbContext.GangnamguPopulations.Find(id);
                if (gangnamguPopulation != null) 
                {
                    return gangnamguPopulation;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UpdateGangnamguPopulation(GangnamguPopulation population)
        {
            try
            {
                _dbContext.GangnamguPopulations.Update(population);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
