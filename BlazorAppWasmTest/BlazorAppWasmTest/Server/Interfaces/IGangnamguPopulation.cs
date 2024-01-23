using BlazorAppWasmTest.Shared;

namespace BlazorAppWasmTest.Server.Interfaces
{
    public interface IGangnamguPopulation
    {
        public void AddGangnamguPopulation(GangnamguPopulation population);

        public void UpdateGangnamguPopulation(GangnamguPopulation population);

        // 파라미터 -> 원래는 id 값이 있어야 하는데 테이블에 id 값이 없어서 이걸로 대체
        public void DeleteGangnamguPopulation(int id);

        public GangnamguPopulation GetGangnamguPopulation(int id);

        public List<GangnamguPopulation> GetAllGangnamguPopulations();
    }
}
