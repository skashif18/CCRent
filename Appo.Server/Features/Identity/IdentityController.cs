namespace Appo.Server.Features
{
    using Appo.Server.Features.Identity;
    using Appo.Server.Features.Identity.Models;
    using CoreBusiness.Master;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System;
    using System.Threading.Tasks;
    using System.Transactions;
    using UseCases.DataStorePluginInterfaces.SrvTable.Supplier;

    public class IdentityController : ApiController
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly IIdentityService identity;
        private readonly AppSettings appSetting;
        private readonly ISupplierRepository supplier;
        private readonly ICustomerRepository Customer;
        public IdentityController(
            UserManager<IdentityUser> userManager,
            IIdentityService identity,
            IOptions<AppSettings> appSetting,
            ISupplierRepository _supplier,
            ICustomerRepository _Customer
            )
        {
            this.userManager = userManager;
            this.identity = identity;
            this.appSetting = appSetting.Value;
            supplier = _supplier;
        }

        [HttpPost]
        [Route(nameof(Register))]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.UserName
            };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);

        }

        [HttpPost]
        [Route(nameof(SuplierRegister))]
        [AllowAnonymous]
        public async Task<ActionResult> SuplierRegister(RegisterRequestModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.UserName
            };


            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                SrvSupplier s = new();
                s.NameEn = model.Name;
                s.Email = model.Email;
                s.IsActive = false;
                var v = supplier.Create(s);
                return Ok(v);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(CustomerRegister))]
        [AllowAnonymous]
        public async Task<ActionResult> CustomerRegister(RegisterRequestModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.UserName
            };


            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                SrvCustomer c = new();
                c.NameEn = model.Name;
                c.Email = model.Email;
                c.IsActive = false;
                var v = Customer.Create(c);
                return Ok(v);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var token = this.identity.GenerateJwtToken(
                user.Id,
                user.UserName,
                this.appSetting.Secret);

            return new LoginResponseModel
            {
                Token = token
            };
        }
    }
}
