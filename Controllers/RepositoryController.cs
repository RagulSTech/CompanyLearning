using LearningCoreAPI.Model;
using LearningCoreAPI.RepositoryPattern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly IStudentDatas _studentDatas;
        public RepositoryController(IStudentDatas datas)
        {
            _studentDatas = datas;
        }
        [HttpPost]
        public ActionResult Insertdetails([FromQuery] StudentData data)
        {
            var resultdata = _studentDatas.GetStudentDatas(data);
            return Ok(resultdata);
        }
        [HttpGet]
        public ActionResult Getparticularid([FromQuery] int id)
        {
            var resultdata = _studentDatas.GetParticularData(id);
            return Ok(resultdata);
        }
    }
}
