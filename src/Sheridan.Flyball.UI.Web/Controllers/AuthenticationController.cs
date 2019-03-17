using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sheridan.Flyball.Core.ViewModels;
using Sheridan.Flyball.UI.Web.Configuration;

namespace Sheridan.Flyball.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class AuthenticationController : ControllerBase
    {
        private readonly IOptions<AppConfig> _appConfig;        
        private readonly RegionEndpoint _region = RegionEndpoint.USWest2;

        public AuthenticationController(IOptions<AppConfig> appConfig)
        {
            _appConfig = appConfig;         
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {

            var cognito = new AmazonCognitoIdentityProviderClient(_region);

            var request = new SignUpRequest
            {
                ClientId = _appConfig.Value.AppClientId,
                Password = user.Password,
                Username = user.Username
            };

            var emailAttribute = new AttributeType
            {
                Name = "email",
                Value = user.Email
            };
            request.UserAttributes.Add(emailAttribute);

            var response = await cognito.SignUpAsync(request);

            return new OkObjectResult("Signup Successful");
        }


        [HttpPost("confirm")]
        public async Task<IActionResult> Confirm(User user)
        {
            var cognito = new AmazonCognitoIdentityProviderClient(_region);

            ConfirmSignUpRequest confirmRequest = new ConfirmSignUpRequest
            {
                Username = user.Username,
                ClientId = _appConfig.Value.AppClientId,
                ConfirmationCode = user.ConfirmationCode,
                //SecretHash = (username, configuration["cognito:clientId"], configuration["cognito:secretKey"])
            };

            await cognito.ConfirmSignUpAsync(confirmRequest);

            return new OkObjectResult("Account has been confirmed");
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(User user)
        {
            var cognito = new AmazonCognitoIdentityProviderClient(_region);

            var request = new AdminInitiateAuthRequest
            {
                UserPoolId = _appConfig.Value.PoolId,
                ClientId = _appConfig.Value.AppClientId,
                AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH
            };

            request.AuthParameters.Add("USERNAME", user.Username);
            request.AuthParameters.Add("PASSWORD", user.Password);

            var response = await cognito.AdminInitiateAuthAsync(request);

            return Ok(response.AuthenticationResult.IdToken);
        }
       
    }
}