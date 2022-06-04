using System;
using System.Collections.Generic;
using System.Linq;

namespace PartBMain
{
    internal class HeadTrainerService : ICrudable<HeadTrainer>
    {
        private readonly PartBMain _context;

        public HeadTrainerService()
        {
            _context = new PartBMain();
        }

        public List<HeadTrainer> GetAll()
        {
            var HeadTrainer = _context.HeadTrainers.ToList();

            return HeadTrainer;
        }

        public void Create(HeadTrainer headtrainer)
        {
            _context.HeadTrainers.Add(headtrainer);
            try
            {
                _context.SaveChanges();
                Console.WriteLine("HeadTrainer created");
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

        public void Update(HeadTrainer headtrainer)
        {
            var HeadTrainerToChange = _context.HeadTrainers.Single(p => p.HeadTrainerID == headtrainer.HeadTrainerID);

            HeadTrainerToChange.Subject = headtrainer.Subject;

            try
            {
                _context.SaveChanges();
                Console.WriteLine($"Update Complete {headtrainer.Person.FirstName} is in. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}