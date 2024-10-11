using EmisionAPI.Interfaces;
using EmisionAPI.Models;
using EmisionAPI.Models.ContextModel;
using Microsoft.EntityFrameworkCore;

namespace EmisionAPI.Services
{
    public class EmissionService : IEmission
    {
        private readonly AppDbContext _context;

        public EmissionService(AppDbContext context)
        {
            _context = context;
        }

        // 1. Obtener todas las emisiones
        public async Task<List<Emission>> GetAllEmissions()
        {
            return await _context.Emissions.ToListAsync();
        }

        // 2. Obtener una emisión por ID
        public async Task<Emission> GetEmissionById(int id)
        {
            return await _context.Emissions.FindAsync(id) ?? new();
        }

        public async Task<List<Emission>> GetEmissionsByCompanyId(int companyId)
        {
            return await _context.Emissions
                .Where(e => e.CompanyId == companyId)
                .ToListAsync();
        }

        // 4. Registrar una nueva emisión
        public async Task<Emission> AddEmission(Emission emission)
        {
            _context.Emissions.Add(emission);
            await _context.SaveChangesAsync();
            return emission;
        }

        // 5. Actualizar una emisión existente
        public async Task<Emission> UpdateEmission(Emission emission)
        {
            _context.Entry(emission).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return emission;
        }

        // 6. Eliminar una emisión
        public async Task<bool> DeleteEmission(int id)
        {
            var emission = await _context.Emissions.FindAsync(id);
            if (emission == null)
            {
                return false;
            }

            _context.Emissions.Remove(emission);
            await _context.SaveChangesAsync();
            return true;
        }

        // Verificar si la emisión existe
        public async Task<bool> EmissionExists(int id)
        {
            return await _context.Emissions.AnyAsync(e => e.Id == id);
        }
    }
}
