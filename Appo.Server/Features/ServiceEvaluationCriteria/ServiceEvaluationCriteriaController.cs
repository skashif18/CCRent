using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appo.Server.Features.ServiceEvaluationCriteria.Model;
using Appo.Server.Features.ServiceEvaluationCriteria.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Appo.Server.Features.ServiceEvaluationCriteria
{
    public class ServiceEvaluationCriteriaController : ApiController
    {
        private readonly IServiceEvaluationCriteriaService repository;

        public ServiceEvaluationCriteriaController(IServiceEvaluationCriteriaService _repository)
        {
            repository = _repository;
        }
        // GET: /<controller>/
        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IActionResult Create(ServiceEvaluationCriteriaRequestModel model)
        {

            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet]
        [Route("get-by-service-id")]
        [AllowAnonymous]
        public IEnumerable<ServiceEvaluationCriteriaResponseModel> GetByServiceTypeId(int id)
        {
            var result = repository.GetByServiceTypeId(id);

            return result;

        }


    }
}

