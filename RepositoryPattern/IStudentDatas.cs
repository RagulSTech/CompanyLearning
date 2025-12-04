using LearningCoreAPI.Model;

namespace LearningCoreAPI.RepositoryPattern
{
    public interface IStudentDatas
    {
        object GetStudentDatas(StudentData std);
        object GetParticularData(int id);
    }
    public interface IGenericStudentDatas
    {
        object GetGenericStddata<T>(T entite) where T:class;
    }
}
