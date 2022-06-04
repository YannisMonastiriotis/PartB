using System;
using System.Collections.Generic;
using System.Linq;

namespace PartBMain
{
    internal class AssignmentService : ICrudable<Assignment>
    {
        private readonly PartBMain _context;

        public AssignmentService()
        {
            _context = new PartBMain();
        }

        public List<Assignment> GetAll()
        {
            var assignment = _context.Assignments.ToList();

            return assignment;
        }

        public void Create(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            try
            {
                _context.SaveChanges();
                Console.WriteLine("Assignment created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
            }
        }

        public void Delete(int id)
        {
            var toBeDeleted = _context.Assignments.Where(s => s.AssignmentID == id);
            foreach (var item in toBeDeleted)
            {
                _context.Assignments.Remove(item);
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

        public void Update(Assignment assignment)
        {
            var AssignmentToChange = _context.Assignments.Single(p => p.AssignmentID == assignment.AssignmentID);

            AssignmentToChange.Title = assignment.Title;
            AssignmentToChange.Description = assignment.Description;
            AssignmentToChange.Submision_Date_Time = assignment.Submision_Date_Time;

            try
            {
                _context.SaveChanges();
                Console.WriteLine($"Update Complete {assignment.Title} is in. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}