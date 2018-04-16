using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApi.Data;
using System.Linq;
using System.Web;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    public abstract class CrudController : Controller
    {
        protected ApplicationContext _context;

        protected abstract Type GetEntityType();

        public CrudController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet, /*Authorize*/] // token check, for now without it...
        public JsonResult Get()
        {
            // hm, set type?
            return Json(
               _context.Set<Company>().ToList()
            );
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(
                GetOne(GetEntityType(), id)
            );
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]string value)
        {
            Type type = GetEntityType();

            dynamic entity = Activator.CreateInstance(type);

            // hydrate
            entity.Name = "kolega";

            _context.Add(entity);
            _context.SaveChanges();

            return Json(
                entity
            );
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]string value)
        {
            Type type = GetEntityType();

            dynamic entity = GetOne(type, id);

            // hydrate
            entity.Name = "MRS";

            _context.Update(entity);
            _context.SaveChanges();

            return Json(
                value
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Type type = GetEntityType();

            dynamic entity = GetOne(type, id);

            // override Remove for softDelete etc?
            _context.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        protected dynamic GetOne(Type type, int id)
        {
            dynamic entity = _context.Find(type, id);

            if (entity == null) {
                throw new Exception($"Entity of type {type} not found for id {id}");
            }

            return entity;
        }
    }
}