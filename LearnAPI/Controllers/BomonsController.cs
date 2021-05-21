using LearnAPI.Models;
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
    public class BomonsController : ControllerBase
    {
        private readonly quanlycanbohumgContext _context; 
        public BomonsController(quanlycanbohumgContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Bomon>> GetBomons()
        {
            return await _context.Bomons.ToListAsync();
        }
        [HttpPost] 
        public async Task<IActionResult> CreateBomons(Bomon bomoncreate)
        {
            _context.Bomons.Add(bomoncreate);
            await _context.SaveChangesAsync();
            return StatusCode(201, bomoncreate); 
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBomons(Bomon bomonupdate,int id)
        {
            if(id != bomonupdate.IdBoMon)
            {
                return BadRequest(); 
            }
            _context.Bomons.Update(bomonupdate);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBomon(int id)
        {
            var Bomondel = _context.Khoas.Find(id);
            _context.Khoas.Remove(Bomondel);
            await _context.SaveChangesAsync();
            return StatusCode(200, Bomondel);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchBomon([FromQuery] string tenbm)
        {
            var kq = await _context.Bomons.Where(bm => bm.TenBoMon.Contains(tenbm)).ToListAsync();
            return  StatusCode(200,kq); 

        }
        public int Count { get; set; }
        public int PageNow { get; set; }
        public int size { get; set; }
        public string queryPage { get; set; }
        [HttpGet("pagination")]
        public async Task<IEnumerable<Bomon>> pagination( [FromQuery] int? page)
        {
            // giống với [fromQuery] là value của 
            if(page <= 0 || page == null)
            {
                page = 1;
            }
            size = 1;
            int pageBymber = (page ?? 1); // toán tử ?? trong c# mô tả nếu khác null thì lấy 
            // giá trị page . null thì lấy 1 
            
            // xem tổng có bao nhiêu trang 
            PageNow = (int)Math.Ceiling((double)Count / size);
            var listPages = await  _context.Bomons.Skip(pageBymber * size - size).Take(size).ToListAsync();
            return listPages; 
        }
    }
}
