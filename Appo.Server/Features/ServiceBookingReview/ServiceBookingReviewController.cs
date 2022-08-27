using System.Collections.Generic;
using Appo.Server.Features.ServiceBookingReview.Model;
using Appo.Server.Features.ServiceBookingReview.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appo.Server.Features.ServiceBookingReview
{
    public class ServiceBookingReviewController : ApiController
    {
        private readonly IServiceBookingReviewService repository;

        public ServiceBookingReviewController(IServiceBookingReviewService _repository)
        {
            repository = _repository;
        }


        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IActionResult Create(ServiceBookingReviewRequestModel model)
        {

            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        [AllowAnonymous]
        public IActionResult Update(ServiceBookingReviewRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet]
        [Route("by-booking-id")]
        [AllowAnonymous]
        public IEnumerable<ServiceBookingReviewResponseModel> GetByServiceBookingId(int serviceBookingId)
        {
            var result = repository.GetByServiceBookingId(serviceBookingId);

            return result;
        }
    }
}
