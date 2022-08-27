using System.Collections.Generic;
using Appo.Server.Features.ServiceBookingRating.Model;
using Appo.Server.Features.ServiceBookingRating.Service;
using CoreBusiness.Master;
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
        public IActionResult Create(IEnumerable<ServiceBookingRatingRequestModel> model)
        {

            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        [AllowAnonymous]
        public IActionResult Update(ServiceBookingRatingRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet]
        [Route("by-booking-id")]
        [AllowAnonymous]
        public IEnumerable<ServiceBookingRatingResponseModel> GetByBookingId(int id)
        {
            var result = repository.GetByServiceBookingId(id);
            return result;
        }

        [HttpGet]
        [Route("get-all")]
        [AllowAnonymous]
        public IEnumerable<ServiceBookingRatingResponseModel> GetAll()
        {
            var result = repository.GetAll();

            return result;
        }
    }
}
