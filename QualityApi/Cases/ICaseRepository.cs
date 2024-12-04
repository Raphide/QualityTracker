using CaseEntity = QualityApi.Cases.Entities.Case;

namespace QualityApi.Cases
{
    public interface ICaseRepository
    {
        Task<CaseEntity> AddCaseAsync(CaseEntity cases);
        Task<IEnumerable<CaseEntity>> GetAllAsync();
        Task<CaseEntity> GetByIdAsync(long id);
        Task DeleteCase(long id);
        Task<CaseEntity> UpdateCaseAsync(CaseEntity caseEntity);
    }
}