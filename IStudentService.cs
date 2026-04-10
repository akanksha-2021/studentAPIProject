using StudentTask.Models;

public interface IStudentService
{
    Task<List<TblStudent>> GetStudents();
    Task<TblStudent> GetStudent(int id);
    Task<TblStudent> Create(TblStudent student);
    Task<TblStudent> Update(TblStudent student);
    Task<bool> Delete(int id);
}