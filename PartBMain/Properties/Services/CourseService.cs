using System;
using System.Collections.Generic;
using System.Linq;

namespace PartBMain
{
    internal class CourseService : ICrudable<Course>
    {
        private readonly PartBMain _context;

        public CourseService()
        {
            _context = new PartBMain();
        }

        public List<Course> GetAll()
        {
            var course = _context.Courses.ToList();

            return course;
        }

        public void Create(Course course)
        {
            _context.Courses.Add(course);
            try
            {
                _context.SaveChanges();
                Console.WriteLine("Course created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
            }
        }

        public void Delete(int id)
        {
            var toBeDeleted = _context.Courses.Where(s => s.CourseID == id);
            foreach (var item in toBeDeleted)
            {
                _context.Courses.Remove(item);
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

        public void Update(Course course)
        {
            var CourseToChange = _context.Courses.Single(p => p.CourseID == course.CourseID);

            CourseToChange.Title = course.Title;
            CourseToChange.Start_Date = course.Start_Date;
            CourseToChange.End_Date = course.End_Date;
            CourseToChange.Trainers = course.Trainers;
            CourseToChange.Assignments = course.Assignments;

            try
            {
                _context.SaveChanges();
                Console.WriteLine($"Update Complete {course.Title} is in. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}