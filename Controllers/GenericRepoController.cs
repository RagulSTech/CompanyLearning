using LearningCoreAPI.Data;
using LearningCoreAPI.Model;
using LearningCoreAPI.RepositoryPattern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCoreAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class GenericRepoController : ControllerBase
    {
        private readonly AppDbcontext appDb;
        private readonly IGenericStudentDatas genericStudentDatas;
        public GenericRepoController(AppDbcontext Dbcontexts, IGenericStudentDatas generic_StudentDatas)
        {
            appDb = Dbcontexts;
            genericStudentDatas = generic_StudentDatas;
        }
        [HttpPost("GetGenericStddata")]
        public IActionResult GetInsert([FromQuery] StudentData data)
        {
            var returndata = genericStudentDatas.GetGenericStddata<StudentData>(data);
            return Ok(returndata);
        }
    }
}
