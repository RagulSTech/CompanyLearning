using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqQueryController : ControllerBase
    {
        public string LinqAbb = "Language Intergrated Query";
        public Dictionary<int, string> Collection = new Dictionary<int, string>() {
            {1,"List" },
            {2,"Array" },
            {3,"Dictionary" },
            {4,"Database in EF" },
            {5,"XML" }
            };
        public Dictionary<int, string> Types = new Dictionary<int, string>()
            {
                {1, "Method Syntax"},
                {2, "Query Syntax"},
            };

        [HttpGet("Test")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult TestLinq()
        {
            var resultkey = Collection.Where(c => c.Key == 2).ToList();
            var resultvalue = Collection.Where(c => c.Value == "Dictionary").ToList();

            var returndata = new
            {
                Method = "Method Syntax",
                KeyResult = resultkey,
                ValueResult = resultvalue
            };


            var resultQuerykey = from n in Collection where n.Key == 2 select n;

            var resultQueryValue = from n in Collection where n.Value == "Dictionary" select n;

            var returndataQuery = new
            {
                Method = "Query Syntax",
                KeyResult = resultQuerykey,
                ValueResult = resultQueryValue
            };

            var finalresult = new
            {
                Querybased = returndata,
                Methodbased = returndataQuery
            };

            return Ok(finalresult);
        }

        [HttpGet("List Method")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ListLinqMethods()
        {
            Dictionary<int, string> Methods = new Dictionary<int, string>()
            {
                {1, "Where"},
                {2, "Select"},
                {3, "OrderBy"},
                {4, "GroupBy"},
                {5, "Join"},
                {6, "Aggregate"},
                {7, "Distinct"},
                {8, "FirstOrDefault"},
                {9, "Any"},
                {10, "Count"}
            };

            var result = new
            {
                Methods = Methods
            };

            return Ok(result);
        }

        [HttpGet("Method")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult LinqMethods()
        {
            //int choice = a;

            Dictionary<int, string> Methods = new Dictionary<int, string>()
            {
                { 1, "a" },{ 2, "b" },{ 3, "c" },{ 4, "d" },{ 5, "e" },{ 6, "f" },{ 7, "g" },
                { 8, "h" },{ 9, "i" },{ 10, "j" },{ 11, "k" },{ 12, "l" },{13, "m" },{ 14, "n" },
                { 15, "o" },{ 16, "p" },{ 17, "q" },{ 18, "r" },{ 19, "s" },{ 20, "t" },
                { 21, "u" },{ 22, "v" },{ 23, "w" },{ 24, "x" },{ 25, "y" },{ 26, "z" }
            };

            int[] keys = { 18, 1, 7, 21, 12 };
            //int[] keys = { 19, 18, 9, 11, 1, 14, 20, 8 };

            var Getname = Methods.Where(n => keys.Contains(n.Key)).Select(n => n.Value).ToList();

            var Getqueryname = from K in keys join M in Methods on K equals M.Key select M.Value;

            //var Getqueryname = from  join from M in Methods where Keys.Contains(M.Key) select M.Value;
            string finalname = string.Empty;
            foreach (var data in Getqueryname)
            {
                finalname += data;
            }
            var finaldata = new
            {
                name = finalname.ToUpper()
            };
            return Ok(finaldata);
        }
        [HttpGet("Ordering")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Linqordering()
        {
            Dictionary<int, string> Methods = new Dictionary<int, string>()
            {
                { 1, "a" },{ 2, "b" },{ 3, "c" },{ 4, "d" },{ 5, "e" },{ 6, "f" },{ 7, "g" },
                { 8, "h" },{ 9, "i" },{ 10, "j" },{ 11, "k" },{ 12, "l" },{13, "m" },{ 14, "n" },
                { 15, "o" },{ 16, "p" },{ 17, "q" },{ 18, "r" },{ 19, "s" },{ 20, "t" },
                { 21, "u" },{ 22, "v" },{ 23, "w" },{ 24, "x" },{ 25, "y" },{ 26, "z" }
            };

            var orderdata = Methods.OrderByDescending(m => m.Value).ToList();


            //var orderdataquery =  from m in Methods orderby m.Value descending 

            return Ok(orderdata);
        }

    }
}
