using Appo.Server.Features.ServiceBookingRating.Model;
using Appo.Server.Features.ServiceBookingRating.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appo.Server.Features.ServiceBookingRating
{
    public class ServiceBookingRatingController : ApiController
    {
        private readonly IServiceBookingRatingService repository;

        public ServiceBookingRatingController(IServiceBookingRatingService _repository)
        {
            repository = _repository;
        }


        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IActionResult Create(ServiceBookingRatingRequestModel model)
        {

            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(ServiceBookingRatingRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
