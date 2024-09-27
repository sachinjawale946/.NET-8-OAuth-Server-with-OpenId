using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Sachin 
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddHttpContextAccessor();
// Sachin - Default Authentication With Cookie Scheme
builder.Services.AddAuthentication(config =>
{
    config.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
     .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
     {
         // this is Authorization Server Port - use it from AppSettings ( could be authenticate.ncpdp.org )
         options.Authority = builder.Configuration.GetValue<string>("NCPDPOAuth:issuer");
         options.ClientId = builder.Configuration.GetValue<string>("NCPDPOAuth:client_id");
         options.ClientSecret = builder.Configuration.GetValue<string>("NCPDPOAuth:client_secret");
         options.ResponseType = builder.Configuration.GetValue<string>("NCPDPOAuth:response_type");
         options.SaveTokens = builder.Configuration.GetValue<bool>("NCPDPOAuth:save_tokens");
         options.Scope.Add(builder.Configuration.GetValue<string>("NCPDPOAuth:scope"));
         options.GetClaimsFromUserInfoEndpoint = true;

         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuerSigningKey = false,
             SignatureValidator = (string token, TokenValidationParameters _) => new JsonWebToken(token),
         };

     });
// Sachin

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Sachin - Added Authentication
app.UseAuthentication();
// Sachin - Added Authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
