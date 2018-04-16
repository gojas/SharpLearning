using System;
using Microsoft.AspNetCore.Mvc;
using TestApi.Data;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/companies")]
    public class CompanyController : CrudController
    {
        public CompanyController(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        protected override Type GetEntityType()
        {
            return typeof(Company);
        }
    }
}
