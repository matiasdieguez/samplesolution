using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectName.Api.Filters;
using ProjectName.Api.Models.Context;
using ProjectName.Api.Models.Mappings;
using ProjectName.Dto;

namespace ProjectName.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns>List of Dto</returns>
        [HttpGet]
        [RequireKey]
        public virtual ActionResult<List<LanguageDto>> Get()
        {
            try
            {
                using (var context = new ProjectNameDbContext())
                {
                    var list = context.Languages.ToList();
                    var dto = list.ToDto();
                    return Ok(dto);
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Get Dto by Id
        /// </summary>
        /// <param name="id">Integer id</param>
        /// <returns>Dto</returns>
        [HttpGet]
        [Route("{id}")]
        [RequireKey]
        public virtual ActionResult<LanguageDto> Get(int id)
        {
            try
            {
                using (var context = new ProjectNameDbContext())
                {
                    var list = context.Languages.SingleOrDefault(x => x.Id == id);
                    var dto = list.ToDto();
                    return Ok(dto);
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Add Dto
        /// </summary>
        /// <param name="data">Dto</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [RequireKey]
        public virtual ActionResult Add(LanguageDto data)
        {
            if (data == null)
            {
                return BadRequest();
            }
            try
            {
                var item = data.FromDto();
                using (var context = new ProjectNameDbContext())
                {
                    context.Languages.Add(item);
                    context.SaveChanges();
                }
                return Ok(item.ToDto());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Update Dto
        /// </summary>
        /// <param name="data">Dto</param>
        /// <returns>Actionresult</returns>
        [HttpPut]
        [RequireKey]
        public virtual ActionResult Edit(LanguageDto data)
        {
            if (data == null)
            {
                return BadRequest();
            }
            try
            {
                var item = data.FromDto();
                using (var context = new ProjectNameDbContext())
                {
                    context.Entry(item).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return Ok(item.ToDto());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Delete Dto
        /// </summary>
        /// <param name="Id">Int</param>
        /// <returns>ActionResult</returns>
        [HttpDelete]
        [RequireKey]
        public virtual ActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            try
            {

                using (var context = new ProjectNameDbContext())
                {
                    var item = context.Languages.SingleOrDefault(x => x.Id == Id);
                    context.Languages.Remove(item);
                    context.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }
    }
}