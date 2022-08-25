using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster
{
    public interface IServiceTypeEvaluationCriterionRepository
    {
        Response Create(SrvServiceTypeEvaluationCriterion model);

        IEnumerable<SrvServiceTypeEvaluationCriterion> GetAll();

        Response Update(SrvServiceTypeEvaluationCriterion model);
        SrvServiceTypeEvaluationCriterion GetById(int id);

        IEnumerable<SrvServiceTypeEvaluationCriterion> GetByServiceTypeId(int id);
        Response Delete(int id);

    }
}
