using Microsoft.EntityFrameworkCore;
using QualityApi.Data;
using CaseEntity = QualityApi.Cases.Entities.Case;

namespace QualityApi.Cases
{
    public class CaseRepository : ICaseRepository
    {
        private readonly ApplicationDbContext _context;
        public CaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CaseEntity> AddCaseAsync(CaseEntity cases)
        {
            _context.Cases.Add(cases);
            await _context.SaveChangesAsync();
            return cases;

        }

        public async Task<IEnumerable<CaseEntity>> GetAllAsync()
        {
            return await _context.Cases
             .Include(c => c.Location).Include(c => c.Product)
             .ToListAsync();
        }

        public async Task<CaseEntity> GetByIdAsync(long id)
        {
            return await _context.Cases
            .Include(c => c.Location)
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task DeleteCase(long id)
        {
            var existingCase = await _context.Cases.FirstOrDefaultAsync(e => e.Id == id);
            if (existingCase != null)
            {
                _context.Cases.Remove(existingCase);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CaseEntity> UpdateCaseAsync(CaseEntity caseEntity)
        {
            _context.Entry(caseEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return caseEntity;
        }
    }
}