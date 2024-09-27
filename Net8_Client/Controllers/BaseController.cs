using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Net8_Client.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
