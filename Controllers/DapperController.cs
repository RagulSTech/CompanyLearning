using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace LearningCoreAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase
    {
        private readonly string Connectionstringdata;
        public DapperController(IConfiguration configuration)
        {
            Connectionstringdata = configuration.GetConnectionString("DefaultConnection");
        }
        [HttpGet("GetUsers")]
        public IActionResult GetAllUsers()
        {
            string getconnectiondata = Connectionstringdata;
            using (var connection = new SqlConnection(getconnectiondata))
            {
                var getalluser = connection.Query<User>("select Username, email from AspNetUsers");
                if (getalluser != null)
                {
                    return Ok(getalluser);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpGet("Async Method GetData")]
        public async Task<IActionResult> GetUserdata()
        {
            string getconnectionstring = Connectionstringdata;
            using (var connection = new SqlConnection(getconnectionstring))
            {
                await connection.OpenAsync();
                var users = await connection.QueryAsync<User>("select UserName, Email from AspNetUsers");

                var firstusers = await connection.QueryFirstAsync<User>("select top 1 UserName, Email from AspNetUsers");

                var first_user = await connection.QueryFirstOrDefaultAsync<User>("select UserName, Email from AspNetUsers");

                var QuerySingle = await connection.QuerySingleAsync<User>("select UserName, Email from AspNetUsers where UserName = @username", new { username = "test" });

                var QuerySinglefirstordfault = await connection.QuerySingleOrDefaultAsync<User>("select UserName, Email from AspNetUsers where UserName = @username", new { username = "test" });

                var Executescalar = await connection.ExecuteScalarAsync("select count (*) from AspNetUsers");

                var Multiplequery = await connection.QueryMultipleAsync("select username, email from AspNetUsers; select Id,Name from AspNetRoles");

                var usersdata = await Multiplequery.ReadAsync<User>();
                var rolesdata = await Multiplequery.ReadAsync<Role>();

                var finaldata = new
                {
                    usersdata,
                    rolesdata
                };

                var storedproceduresdapper = await connection.QueryAsync("Test_GetUserRole", new { username = "test" }, commandType: CommandType.StoredProcedure);

                return Ok(storedproceduresdapper);
            }
        }

        [HttpGet("Without Async Method GetData")]
        public IActionResult Get_Userdata()
        {
            string getconnectionstring = Connectionstringdata;
            using (var connection = new SqlConnection(getconnectionstring))
            {
                var users = connection.Query<User>("select UserName, Email from AspNetUsers");

                var firstusers = connection.QueryFirst<User>("select UserName, Email from AspNetUsers");

                var first_user = connection.QueryFirstOrDefault<User>("select UserName, Email from AspNetUsers");

                var QuerySingle = connection.QuerySingle<User>("select UserName, Email from AspNetUsers where UserName = @username", new { username = "test" });

                var QuerySinglefirstordfault = connection.QuerySingleOrDefault<User>("select UserName, Email from AspNetUsers where UserName = @username", new { username = "test" });

                var Executescalar = connection.ExecuteScalar("select count (*) from AspNetUsers");

                var Multiplequery = connection.QueryMultiple("select username, email from AspNetUsers; select Id,Name from AspNetRoles");

                var usersdata = Multiplequery.Read<User>();
                var rolesdata = Multiplequery.Read<Role>();

                var finaldata = new
                {
                    usersdata,
                    rolesdata
                };

                var storedproceduresdapper = connection.Query("Test_GetUserRole", new { username = "test" }, commandType: CommandType.StoredProcedure);

                return Ok(storedproceduresdapper);
            }
        }


        [HttpGet("CRUDOperation_select Query")]
        public IActionResult GetQuery([FromQuery] int getid)
        {
            string getconnectionstring = Connectionstringdata;
            using (var connection = new SqlConnection(getconnectionstring))
            {
                var Queryselect = connection.Query<Getuser>("select sno [ID],sname [Name],semail [Email],sphonenumber [PhoneNo],sdept [Dept] from Samplecruddapper where sno = @sno",
                    new { sno = getid}
                    );
                if (Queryselect != null)
                {
                    return Ok(Queryselect);
                }
            }
            return BadRequest();
        }

        [HttpGet("CRUDOperation_insert Query")]
        public IActionResult InsertQuery([FromQuery] string name, string email, string phoneno, string dept)
        {
            string getconnectionstring = Connectionstringdata;
            using (var connection = new SqlConnection(getconnectionstring))
            {

                var Emailexisting = connection.ExecuteScalar<int>("select count(*) from Samplecruddapper where semail = @semail",
                    new { semail = email }
                    );

                if (Emailexisting > 0)
                {
                    return Ok("Email Already Existing");

                }
                else
                {
                    var Queryselect = connection.Execute("insert into Samplecruddapper(sname,semail,sphonenumber,sdept) values(@sname,@semail,@sphonenumber,@sdept)",
                        new { sname = name, semail = email, sphonenumber = phoneno, sdept = dept }
                        );
                    if (Queryselect != null)
                    {
                        var Resultdata = new
                        {
                            Email = email,
                            Message = "Data Inserted Successfully"
                        };
                        return Ok(Resultdata);
                    }
                    else
                    {
                        var Resultdata = new
                        {
                            Email = email,
                            Message = "Data Inserted Failure"
                        };
                        return Ok(Resultdata);
                    }
                }
            }
        }

        [HttpGet("CRUDOperation_Delete Query")]
        public IActionResult DeleteQuery([FromQuery] int a)
        {
            string getconnectionstring = Connectionstringdata;

            using (var connection = new SqlConnection(getconnectionstring))
            {
                var existsrecord = connection.ExecuteScalar<int>("select count(*) from Samplecruddapper where sno = @id", new { id = a });
                if (existsrecord > 0)
                {
                    var deleterecord = connection.Query("Delete from Samplecruddapper where sno = @id", new { id = a });
                    if (deleterecord != null)
                    {
                        var resultdata = new
                        {
                            Id = a,
                            Message = "Record Deleted Successully"
                        };
                        return Ok(resultdata);
                    }
                }
                else
                {
                    var resultdata = new
                    {
                        Id = a,
                        Message = "Record Not Existing"
                    };
                    return Ok(resultdata);
                }
            }
            return BadRequest();
        }

        [HttpGet("CRUDOperation_Update Query")]
        public IActionResult UpdateQuery([FromQuery] int id, string name, string email, string phoneno, string dept)
        {
            string getconnectionstring = Connectionstringdata;

            using (var connection = new SqlConnection(getconnectionstring))
            {
                var existsrecord = connection.ExecuteScalar<int>("select count(*) from Samplecruddapper where sno = @id", new { id = id});
                if (existsrecord > 0)
                {
                    var updaterecord = connection.Query("Updatecruddapper", new { Id = id, Name = name, Email = email, PhoneNo = phoneno, Dept = dept }, commandType: CommandType.StoredProcedure);
                    if (updaterecord != null)
                    {
                        var resultdata = new
                        {
                            Id = id,
                            Message = "Record Updated Successully"
                        };
                        return Ok(resultdata);
                    }
                }
                else
                {
                    var resultdata = new
                    {
                        Id = id,
                        Message = "Record Not Existing"
                    };
                    return Ok(resultdata);
                }
            }
            return BadRequest();
        }

    }

    public class Getuser { 
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Dept { get; set; }
    }

    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
