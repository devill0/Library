using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Guid CurrrentUserId => User.Identity.IsAuthenticated ? Guid.Parse(User.Identity.Name) : Guid.Empty;
    }
}