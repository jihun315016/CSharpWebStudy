using JwtAuthTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JwtAuthTest.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Request ex)
            //{
            // "Username": "aa",
            // "Password": "bb"
            // }

            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            else
            {
                // 로그인 실패 시 유효한 인증 자격 증명을 제공하지 않았음을 나타내는 401 오류 발생
                // 아래 코드는 커스텀 오류 응답을 반환하는 코드
                // {
                //     "message": "Invalid username or password"
                // }
                return Unauthorized(new { message = "Invalid username or password" });
            }

            return response;            
        }

        private UserModel AuthenticateUser(LoginModel login)
        {
            UserModel user = null;

            // 여기에서 데이터베이스를 이용한 실제 사용자 검증을 진행해주세요.
            // 샘플 사용자 데이터
            var users = new List<UserModel>
            {
                new UserModel { Username = "test1", Password = "password1" },
                new UserModel { Username = "test2", Password = "password2" }
            };

            // 사용자 검증
            user = users.SingleOrDefault(u => u.Username == login.Username && u.Password == login.Password);

            return user;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            // "Jwt": {
            //     "Key": "TempHelloWorldHelloWorldHelloWorldJwt",
            //     "Issuer": "YourAppName"
            // }
            // Key : JWT 토큰을 생성할 때 사용되는 비밀 키, 키는 임의의 문자열을 사용한다. 절대 외부에 노출되어서는 안된다.
            // Issuer : 토큰의 발생자를 나타낸다. 일반적으로 애플리케이션의 이름이나 도메인을 사용한다.


            // _config["Jwt:Key"]에서 설정한 비밀 키를 가져와서 바이트 배열로 변환
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            // securityKey 값에 HmacSha256 암호화 알고리즘을 사용하여 암호화된 값 반환
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // JWT 생성
            // 발행자 : _config["Jwt:Issuer"]
            // 만료 시간 : 현재 시간으로부터 120분 후
            // 서명 자격 증명을 위해 credentials를 사용
            var token = new JwtSecurityToken
            (
                _config["Jwt:Issuer"], 
                _config["Jwt:Issuer"], 
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            // token 값을 문자열로 직렬화하여 반환
            // 클라이언트는 이 토큰을 저장 후 이후 요청에서 이 토큰을 사용하여 자신을 인증한다.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
