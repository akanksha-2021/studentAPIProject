using StudentTask.Models;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;

    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<TblStudent>> GetStudents()
    {
        return await _repo.GetAll();
    }

    public async Task<TblStudent> GetStudent(int id)
    {
        return await _repo.GetById(id);
    }

    public async Task<TblStudent> Create(TblStudent student)
    {
        return await _repo.Add(student);
    }

    public async Task<TblStudent> Update(TblStudent student)
    {
        return await _repo.Update(student);
    }

    public async Task<bool> Delete(int id)
    {
        return await _repo.Delete(id);
    }
}