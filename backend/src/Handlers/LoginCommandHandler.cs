using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IConfiguration _configuration;

    public LoginCommandHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (request.Username == "test" && request.Password == "password")
        {
            var token = await Task.Run(() => GenerateJwtToken());
            return token;
        }
        return string.Empty;
    }

    private string GenerateJwtToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
          _configuration["Jwt:Audience"],
          null,
          expires: DateTime.Now.AddMinutes(30),
          signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}