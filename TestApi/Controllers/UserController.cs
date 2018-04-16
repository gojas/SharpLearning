using System;
using Microsoft.AspNetCore.Mvc;
using TestApi.Data;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/users")]
    public class UserController : CrudController
    {
        public UserController(ApplicationContext context): base(context)
        {
            _context = context;
        }

        protected override Type GetEntityType()
        {
            return typeof(User);
        }
    }
}
