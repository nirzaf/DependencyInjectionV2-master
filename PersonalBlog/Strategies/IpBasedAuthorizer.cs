using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PersonalBlog.Interface;

namespace PersonalBlog.Strategies
{
    public class IpBasedAuthorizer : IAuthorizer
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IConfiguration _configuration;
        public IpBasedAuthorizer(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            _configuration = configuration;
        }
        public bool IsAuthorized()
        {
            var ipV4 = _accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var validIp = _configuration.GetSection("Security").GetValue<string>("ValidIp");
            return string.Compare(ipV4, validIp) == 0;
        }
    }
}
