namespace Appo.Server.Features
{
    using Appo.Server.Features.Identity;
    using Appo.Server.Features.Identity.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;
    public class IdentityController : ApiController
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly IIdentityService identity;
        private readonly AppSettings appSetting;

        public IdentityController(
            UserManager<IdentityUser> userManager, 
            IIdentityService identity,
            IOptions<AppSettings> appSetting
            )
        {
            this.userManager = userManager;
            this.identity = identity;
            this.appSetting = appSetting.Value;
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
