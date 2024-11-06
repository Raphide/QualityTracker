using CaseEntity = QualityApi.Cases.Entities.Case;

namespace QualityApi.Cases{
    public interface ICaseRepository{
        Task<CaseEntity> AddCaseAsync(CaseEntity cases);
    }
}