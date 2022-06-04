using System;
using System.Collections.Generic;
using System.Linq;

namespace PartBMain
{
    internal class StudentService : ICrudable<Student>
    {
        private readonly PartBMain _context;

        public StudentService()
        {
            _context = new PartBMain();
        }

        public List<Student> GetAll()
        {
            var student = _context.Students.ToList();

            return student;
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            try
            {
                _context.SaveChanges();
                Console.WriteLine("Student created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e);
            }
        }

        public void Delete(int id)
        {
            //var ProjectToDel = _context.Projects.Single(p => p.ID == id);

            //_context.Projects.Remove(ProjectToDel);

            var toBeDeleted = _context.Students.Where(s => s.StudentID == id);
            foreach (var item in toBeDeleted)
            {
                _context.Students.Remove(item);
            }

            try
            {
                _context.SaveChanges();
                Console.WriteLine($"All good! {toBeDeleted} removed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }

        public void Update(Student student)
        {
            var StudentToChange = _context.Students.Single(p => p.StudentID == student.StudentID);

            StudentToChange.PersonID = student.PersonID;
            StudentToChange.Tuition__Fees = student.Tuition__Fees;

            try
            {
                _context.SaveChanges();
                Console.WriteLine($"Update Complete {student.PersonID} is in. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}