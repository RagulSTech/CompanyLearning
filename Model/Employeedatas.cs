using System.ComponentModel.DataAnnotations;
namespace LearningCoreAPI.Model
{
    public class Employeedatas
    {
        [Key]
        public int empid { get; set; }
        public string empname { get; set; }
        public string empcity { get; set; }
        public int empage { get; set; }
        public string empposition { get; set; }
    }
}
