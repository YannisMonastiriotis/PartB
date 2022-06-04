using System;
using System.Collections.Generic;
using System.Linq;

namespace PartBMain
{
    internal class Private_SchoolService : ICrudable<Private_School>
    {
        private readonly PartBMain _context;

        public Private_SchoolService()
        {
            _context = new PartBMain();
        }

        public List<Private_School> GetAll()
        {
            var privateschool = _context.Private_Schools.ToList();

            return privateschool;
        }

        public void Create(Private_School privateschool)
        {
            _context.Private_Schools.Add(privateschool);
            try
            {
                _context.SaveChanges();
                Console.WriteLine("Private_School created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Private_School privateschool)
        {
            var Private_SchoolToChange = _context.Private_Schools.Single(p => p.PrivateSchoolID == privateschool.PrivateSchoolID);

            Private_SchoolToChange.Inventory = privateschool.Inventory;
            Private_SchoolToChange.Expenses = privateschool.Expenses;

            try
            {
                _context.SaveChanges();
                Console.WriteLine($"Update Complete {privateschool.PrivateSchoolID} is in. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}