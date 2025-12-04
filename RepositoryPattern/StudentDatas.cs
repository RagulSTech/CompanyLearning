using LearningCoreAPI.Data;
using LearningCoreAPI.Model;

namespace LearningCoreAPI.RepositoryPattern
{
    public class StudentDatas: IStudentDatas, IGenericStudentDatas
    {
        private readonly AppDbcontext _context;
        public StudentDatas(AppDbcontext context)
        {
            _context = context;
        }
        public object GetStudentDatas(StudentData std)
        {
            _context.DStudentList.Add(std);
            var returndata = _context.SaveChanges();
            return new { data = "Inserted Successfully" };
        }
        public object GetParticularData(int id)
        {
            var returndata = from std in _context.DStudentList where std.Stdid >= id select std;
            return new { data = returndata };
        }


        public object GetGenericStddata<T>(T obj) where T : class
        {
            _context.Set<T>().Add(obj);
            var returndata = _context.SaveChanges();
            return new { data = returndata };
        }
    }
}
