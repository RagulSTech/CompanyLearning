using LearningCoreAPI.Data;
using LearningCoreAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningCoreAPI.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class EntityframeworksController : ControllerBase
    {
        private readonly AppDbcontext _context;
        public EntityframeworksController(AppDbcontext context)
        {
            _context = context;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("GetData")]
        public async Task<IActionResult> GetList()
        {
            var resultdata = await _context.TestlearnEF.ToListAsync();
            return Ok(resultdata);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("GetParticularid")]
        public async Task<IActionResult> GetParticularList([FromQuery] int id)
        {
            var resultdata = await _context.TestlearnEF.FindAsync(id);
            return Ok(resultdata);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("GetDataLinq")]
        public IActionResult GetListLinq()
        {
            //var returnresult = _context.TestlearnEF.Where(x=>x.Age>25).ToList();

            var returnresultquery = from e in _context.TestlearnEF where e.Age > 25 select (new { e.Name,e.Age });

            return Ok(returnresultquery);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("GetSortingLinq")]
        public IActionResult GetSortinLinq()
        {
            var returnresultsorting = _context.TestlearnEF.OrderByDescending(d => d.Age).ToList();

            var resultresultdata = from data in _context.TestlearnEF orderby data.Age ascending select data;

            return Ok(resultresultdata);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("EFInsert")]
        public async Task<IActionResult> CRUDInsert([FromQuery] TestEFfile testEFfile)
        {
            var today = DateTime.Today;
            int age = today.Year - testEFfile.DOB.Year;

            testEFfile.Age = age;

            _context.TestlearnEF.Add(testEFfile);   
            await _context.SaveChangesAsync();  
            return Ok(testEFfile);                  
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("EFUpdate")]
        public async Task<IActionResult> UpdateList(int id, [FromQuery] TestEFfile testEffile)
        {
            var existingData = await _context.TestlearnEF.FindAsync(id);
            if(existingData == null)
            {
                return NotFound("No Record User");
            }
            else
            {
                var today = DateTime.Today;
                int age = today.Year - testEffile.DOB.Year;

                testEffile.Age = age;

                existingData.Name = testEffile.Name;
                existingData.Phonenumber = testEffile.Phonenumber;
                existingData.Emailid = testEffile.Emailid;
                existingData.DOB = testEffile.DOB;
                existingData.Age = testEffile.Age;

                var resultdata = await _context.SaveChangesAsync();
                if(resultdata > 0)
                {
                    return Ok("Updated Succesully");
                }
                else
                {
                    return BadRequest("Updated Not Successfully");
                }
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("EFDelete")]
        public async Task<IActionResult> DeleteEfrecord(int id)
        {
            var existingData = await _context.TestlearnEF.FindAsync(id);
            if(existingData == null)
            {
                return NotFound("No Record User");
            }
            else
            {
                _context.TestlearnEF.Remove(existingData);
                var resultdata = await _context.SaveChangesAsync();
                if (resultdata > 0)
                {
                    return Ok("Deleted Succesully");
                }
                else
                {
                    return BadRequest("Deleted Not Successfully");
                }
            }
        }

        [HttpDelete("EFTruncate")]
        public async Task<IActionResult> TruncateEfrecord()
        {
            var truncatedata = await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE TestlearnEF");
            if(truncatedata == -1)
            {
                return Ok("Truncate Successfully");
            }
            else
            {
                return Ok("Truncate Not Successfully");
            }
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("SqlRawInsert")]
        public async Task<IActionResult> Rawinsertdata([FromQuery] TestEFfile testE)
        {
            var returnresult = await _context.Database.ExecuteSqlRawAsync("Insert into TestlearnEF(Name,Phonenumber,Emailid) values ({0},{1},{2},{3},{4})",
                testE.Name,testE.Phonenumber, testE.Emailid, testE.DOB, testE.Age
                );

            if(returnresult != null)
            {
                return Ok("Inserted Successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("StoredProcedure")]
        public async Task<IActionResult> Storedproceduredata(int id)
        {
            var resultdata = await _context.Database.ExecuteSqlRawAsync("EXEC proc_testLearnef @id={0}", id);
            return Ok(resultdata);
        }
    }
}
