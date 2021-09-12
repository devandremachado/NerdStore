using Microsoft.AspNetCore.Mvc;
using System;

namespace NerdStore.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected Guid ClienteId = Guid.Parse("02ce96fa-aa2a-4668-91df-0cb0155651cc");
    }
}
