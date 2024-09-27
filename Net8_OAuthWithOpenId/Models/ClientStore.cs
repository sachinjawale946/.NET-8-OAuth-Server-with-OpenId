namespace Net8_OAuthWithOpenId.Models
{
    public class ClientStore
    {
        public IEnumerable<Client> Clients = new[]
        {
            new Client
            {
                ClientName = "PRM",
                ClientId = "PRM_001",
                ClientSecret = "123456789",
                AllowedScopes = new[]{ "openid", "profile", "Net8_WebApi.Read" },
                GrantType = GrantTypes.Code,
                IsActive = true,
                ClientUri = "https://localhost:7197",
                RedirectUri = "https://localhost:7197/signin-oidc",
                UsePkce = true,
            },
            new Client
            {
                ClientName = "Medimpact",
                ClientId = "Medimpact_002",
                ClientSecret = "987654321",
                AllowedScopes = new[]{ "openid", "profile"},
                GrantType = GrantTypes.Code,
                IsActive = true,
                ClientUri = "https://localhost:7026",
                RedirectUri = "https://localhost:7026/signin-oidc"
            }
        };
    }

}
