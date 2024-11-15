using Microsoft.EntityFrameworkCore;
using QualityApi.Data;
using CaseEntity = QualityApi.Cases.Entities.Case;

namespace QualityApi.Cases{
    public class CaseRepository : ICaseRepository{
        private readonly ApplicationDbContext _context;
        public CaseRepository(ApplicationDbContext context){
            _context = context;
        }
        public async Task<CaseEntity> AddCaseAsync(CaseEntity cases){
            _context.Cases.Add(cases);
            await _context.SaveChangesAsync();
            return cases;

        }

        public async Task<IEnumerable<CaseEntity>> GetAllAsync(){
            return await _context.Cases.ToListAsync();
        }

        public async Task<CaseEntity> GetByIdAsync(long id){
            return await _context.Cases.FindAsync(id);
        }
    }
}