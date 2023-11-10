using DR.EstaparBackoffice.Domain.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Data.Entity;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace DR.EstaparBackoffice.API.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly DRxEstaparDBContext _dbContext;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            DRxEstaparDBContext dbContext)
            : base(options, logger, encoder, clock)
        {
            _dbContext = dbContext;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Cabeçalho de autenticação inválido");
            }

            var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials)).Split(':', 2);
            var username = credentials[0];
            var password = credentials[1];

            var user =  _dbContext.Usuarios.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("IdGaragem", user.IdGaragem.ToString())

            };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);

                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Falha na autenticação");
        }
    }

}
