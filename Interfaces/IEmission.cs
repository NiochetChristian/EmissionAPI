using EmisionAPI.Models;

namespace EmisionAPI.Interfaces
{
    public interface IEmission
    {
        Task<List<Emission>> GetAllEmissions();
        Task<Emission> GetEmissionById(int id);
        Task<List<Emission>> GetEmissionsByCompanyId(int companyId);
        Task<Emission> AddEmission(Emission emission);
        Task<Emission> UpdateEmission(Emission emission);
        Task<bool> DeleteEmission(int id);
        Task<bool> EmissionExists(int id);
    }
}
