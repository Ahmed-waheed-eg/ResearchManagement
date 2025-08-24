using ResearchManage.Domain.Entities;
using ResearchManage.Infrustructure.GenericBases;


namespace ResearchManage.Infrustructure.Abstracts
{
    public interface IScholarRepository:IGenericRepo<Scholar>
    {
        public Task<List<Scholar>> GetScholarListAsync();
    }
}
