using LearnAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoasController : ControllerBase
    {
        private readonly quanlycanbohumgContext _context;
        public KhoasController(quanlycanbohumgContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //// trả về 1 mảng sd Ienumerable - đồng nghĩa là trả về 200
        //// trả về 1mess - và mảng : sd iactionrelust
        //public async Task<IEnumerable<Khoa>> GetKhoas([FromQuery] string tenkhoa , [FromQuery] int idkhoa)
        //{
        //    var CNTT = _context.Khoas.Where(x => x.TenKhoa.StartsWith(tenkhoa) && x.IdKhoa == idkhoa).ToListAsync();

        //    return await CNTT;
        //}
        ////Lay ra thong tin khoa CNTT
        //[HttpGet("{tenKhoa}")]
        //public async Task<IEnumerable<Khoa>> GetKhoaCNTT(string tenKhoa)
        //{
        //    var CNTT = _context.Khoas.Where(x => x.TenKhoa.StartsWith(tenKhoa)).ToListAsync();
        //    return await CNTT;
        //}
        [HttpGet]
        public async Task<IEnumerable<Khoa>> GetKhoas()
        {
            return await _context.Khoas.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CreateKhoa(Khoa KhoaCreate)
        {
            _context.Khoas.Add(KhoaCreate);
            await _context.SaveChangesAsync();
            return StatusCode(201, KhoaCreate);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKhoa(Khoa KhoaUd,int id)
        {
            if(id != KhoaUd.IdKhoa)
            {
                return BadRequest();
            }
            _context.Khoas.Update(KhoaUd);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoa(int id)
        {
            var khoadel = _context.Khoas.Find(id); 
            _context.Khoas.Remove(khoadel);
            await _context.SaveChangesAsync();
            return StatusCode(200, khoadel);

        }
    }
}
