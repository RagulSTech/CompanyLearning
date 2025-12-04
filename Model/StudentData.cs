using System.ComponentModel.DataAnnotations;
namespace LearningCoreAPI.Model
{
    public class StudentData
    {
        [Key]
        public int Stdid { get; set; }
        public string StdName {  get; set; }
        public int StdAge { get; set; }
        public string StdCity { get; set; }
        public string StdCountry { get; set; }
    }
}
