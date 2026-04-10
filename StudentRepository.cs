using Microsoft.EntityFrameworkCore;
using StudentTask.Models;

public class StudentRepository : IStudentRepository
{
    private readonly StudentContext _context;

    public StudentRepository(StudentContext context)
    {
        _context = context;
    }

    public async Task<List<TblStudent>> GetAll()
    {
        return await _context.TblStudents.ToListAsync();
    }

    public async Task<TblStudent> GetById(int id)
    {
        return await _context.TblStudents.FindAsync(id);
    }

    public async Task<TblStudent> Add(TblStudent student)
    {
        _context.TblStudents.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<TblStudent> Update(TblStudent student)
    {
        _context.TblStudents.Update(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<bool> Delete(int id)
    {
        var student = await _context.TblStudents.FindAsync(id);
        if (student == null) return false;

        _context.TblStudents.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }
}