using StudentTask.Models;

public interface IStudentRepository
{
    Task<List<TblStudent>> GetAll();
    Task<TblStudent> GetById(int id);
    Task<TblStudent> Add(TblStudent student);
    Task<TblStudent> Update(TblStudent student);
    Task<bool> Delete(int id);
}
