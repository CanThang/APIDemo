using APIDemo.Contracts;
using APIDemo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangController : ControllerBase
    {
        private readonly IHangRepository _hangRepo;
        
        public HangController(IHangRepository hangRepo)
        {
            _hangRepo = hangRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetHangs()
        {
            try
            {
                var hang = await _hangRepo.GetHangs();
                return Ok(hang);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}", Name = "HangByID")]
        public async Task<IActionResult> GetHang(string id)
        {
            try
            {
                var hang = await _hangRepo.GetHang(id);
                if (hang == null)
                   return NotFound();

                return Ok(hang);  
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateHang(Hang h)
        {
            try
            {
                var createdHang = await _hangRepo.CreateHang(h);
                return CreatedAtRoute("HangById", new { id = createdHang.MaHang }, createdHang);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHang (string id, Hang h)
        {
            try
            {
                var dbHang = await _hangRepo.GetHang(id);
                if (dbHang == null)
                    return NotFound();

                await _hangRepo.UpdateHang(id, h);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHang(string id)
        {
            try
            {
                var dbHang = await _hangRepo.GetHang(id);
                if (dbHang == null)
                    return NotFound();

                await _hangRepo.DeleteHang(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
