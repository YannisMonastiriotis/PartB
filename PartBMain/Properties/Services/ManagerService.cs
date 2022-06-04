using System;
using System.Collections.Generic;
using System.Linq;

namespace PartBMain
{
    internal class ManagerService : ICrudable<Manager>
    {
        private readonly PartBMain _context;
        public List<Payment> _Payments { get; set; }

        public ManagerService()
        {
            _context = new PartBMain();
            _Payments = new List<Payment>();
        }

        public List<Manager> GetAll()
        {
            var manager = _context.Managers.ToList();

            return manager;
        }

        public void Create(Manager manager)
        {
            _context.Managers.Add(manager);
            try
            {
                _context.SaveChanges();
                Console.WriteLine("Manager created");
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

        public void Update(Manager manager)
        {
            var ManagerToChange = _context.Managers.Single(p => p.ManagerID == manager.ManagerID);

            ManagerToChange.PersonID = manager.PersonID;
            ManagerToChange.AnnualPayment = manager.AnnualPayment;

            try
            {
                _context.SaveChanges();
                Console.WriteLine($"Update Complete {manager.Person.FirstName} is in. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}