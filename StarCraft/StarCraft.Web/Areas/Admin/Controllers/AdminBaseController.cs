﻿namespace StarCraft.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class AdminBaseController : Controller
    {
    }
}