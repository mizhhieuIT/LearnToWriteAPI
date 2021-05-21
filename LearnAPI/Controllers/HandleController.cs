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
    public class HandleController : ControllerBase
    {
        private readonly quanlycanbohumgContext _context;
        public HandleController(quanlycanbohumgContext context)
        {
           _context = context; 
        }
        [HttpGet("SearchCb/{mcb}")]
        public async Task<IEnumerable<Canbo>> SearchCanbo(int mcb)
        {
            return await _context.Canbos.Where(cb => cb.Idcb == mcb).ToListAsync();
        }
        [HttpGet("SearchDV/{mdv}")]
        public async Task<IEnumerable<Bomon>> SearchDonvi(int mdv)
        {
            return await _context.Bomons.Where(dv => dv.IdBoMon == mdv).ToListAsync();
        }
        [HttpGet("SearchChucvu")]
        public async Task<IEnumerable<object>> SearchCanbo([FromQuery] string cvseach)
        {
            return await _context.Canbos
                .Join(_context.Chucvus, cb => cb.Idchucvu, cv => cv.Idchucvucanbo, (cb, cv) => new {  })
                .Where(x => x.cv.Tenchucvucanbo.Contains(cvseach))
                .ToListAsync();
        }
    }
}
