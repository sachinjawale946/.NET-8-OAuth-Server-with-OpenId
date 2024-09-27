using Net8_OAuthWithOpenId.OauthRequest;
using Net8_OAuthWithOpenId.OauthResponse;

namespace Net8_OAuthWithOpenId.Services
{
    public interface IAuthorizeResultService
    {
        TokenResponse GenerateToken(IHttpContextAccessor httpContextAccessor);
        AuthorizeResponse AuthorizeRequest(IHttpContextAccessor httpContextAccessor, AuthorizationRequest authorizationRequest);
    }
}
