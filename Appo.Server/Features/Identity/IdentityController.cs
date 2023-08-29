namespace Appo.Server.Features
{
    using Appo.Server.Features.Identity;
    using Appo.Server.Features.Identity.Models;
    using CoreBusiness;
    using CoreBusiness.Master;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System;
    using System.Threading.Tasks;
    using System.Transactions;
    using System.Web;
    using UseCases.DataStorePluginInterfaces;
    using UseCases.DataStorePluginInterfaces.SrvTable.Supplier;
    using static Humanizer.In;

    public class IdentityController : ApiController
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly IIdentityService identity;
        private readonly AppSettings appSetting;
        private readonly ISupplierRepository supplier;
        private readonly ICustomerRepository customer;
        private readonly IEmailServiceRepository emailService;
        public IdentityController(
            UserManager<IdentityUser> userManager,
            IIdentityService identity,
            IOptions<AppSettings> appSetting,
            ISupplierRepository _supplier,
            ICustomerRepository _customer,
            IEmailServiceRepository _emailService
            )
        {
            this.userManager = userManager;
            this.identity = identity;
            this.appSetting = appSetting.Value;
            supplier = _supplier;
            customer = _customer;  
            emailService = _emailService;
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
                s.UserDefined1 = model.Type;
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
                var v = customer.Create(c);
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
                Token = token,
                Email = user.Email
            };
        }

        [HttpPost]
        [Route(nameof(ForgetPwd))]
        [AllowAnonymous]
        public async Task<ActionResult<Response>> ForgetPwd(ForgetPwdModel model)
        {
            var response = new Response();
            string url = "http://136.243.174.48:5001";
            var user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            var token = await this.userManager.GeneratePasswordResetTokenAsync(user);

            SentEmailModel email = new();
            email.Email = user.Email;
            email.Name = user.UserName;
            email.Subject = "Reset Your Account Password";
            email.Body = $"<html><body><b>Dear {user.Email} <br><br> We noticed that you've requested a password reset for your account. To ensure the security of your account, " +
                $"we're here to help you regain access. Follow the steps below to reset your password: <br><br>" +
                $"Click the Reset Password Button: " +
                $"<a href='{url}/screens/change-pwd/{HttpUtility.UrlEncode(token)}?email={user.Email}'>Password Reset</a></b>" +
                $"<br><br> Create a Strong Password: Choose a new password that's unique and secure. " +
                $"Include a mix of uppercase and lowercase letters, numbers, and symbols. Avoid using easily guessable information.<br><br>" +
                $"Thank you for choosing Addrriyah<br>Best regards </html></body>";
            response.Message = email.Body;
            var sent = await emailService.SentEmail(email);
            if (sent)
            {
                response.IsSuccess = true;
            }
            else
            {
                response.Message = "Error sending Email";
            }
            return Ok(response);
        }


        [HttpPost]
        [Route(nameof(ResetPwd))]
        [AllowAnonymous]
        public async Task<ActionResult<Response>> ResetPwd(ChangePwdModel model)
        {
            var response = new Response();
            var user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            var verify = await this.userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (verify.Succeeded)
            {
                response.IsSuccess = true;
            }
            else
            {
                response.Objects = verify.Errors;
            }
            return response;
        }
    }
}
