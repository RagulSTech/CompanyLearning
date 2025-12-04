using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.OleDb;
using Microsoft.Data.SqlClient;

namespace LearningCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public EmployeeController(ILogger<EmployeeController> logger, IWebHostEnvironment env, IConfiguration configuration)
        {
            _logger = logger;
            _env = env;
            _configuration = configuration;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("ImportExcelToDb")]
        public IActionResult ImportExcelToDb()
        {
            string excelFilePath = @"C:\Users\80128\Downloads\Oledbtestfile.xlsx";  
            string excelConnString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties='Excel 12.0 Xml;HDR=YES;'";

            try
            {
                // 1️⃣ Read Excel into DataTable
                DataTable dt = new DataTable();
                using (OleDbConnection conn = new OleDbConnection(excelConnString))
                {
                    conn.Open();
                    DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();   

                    using (OleDbCommand cmd = new OleDbCommand($"SELECT * FROM [{sheetName}]", conn))
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                    conn.Close();
                }

                // 2️⃣ Bulk insert into SQL Server
                string sqlConnString = _configuration.GetConnectionString("DefaultConnection");

                using (SqlConnection sqlConn = new SqlConnection(sqlConnString))
                {
                    sqlConn.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConn))
                    {
                        bulkCopy.DestinationTableName = "Employees_Oledb"; // SQL table
                        bulkCopy.ColumnMappings.Add("EmployeeId", "EmployeeId");
                        bulkCopy.ColumnMappings.Add("Name", "Name");
                        bulkCopy.ColumnMappings.Add("Age", "Age");
                        bulkCopy.ColumnMappings.Add("Department", "Department");

                        bulkCopy.WriteToServer(dt);
                    }
                    sqlConn.Close();
                }

                return Ok(new { Status = "Excel data imported successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Error importing Excel", Error = ex.Message });
            }
        }

    }
}
