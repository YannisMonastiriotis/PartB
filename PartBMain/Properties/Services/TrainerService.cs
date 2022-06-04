using System;
using System.Collections.Generic;
using System.Linq;

namespace PartBMain
{
    internal class TrainerService : ICrudable<Trainer>
    {
        private readonly PartBMain _context;

        public TrainerService()
        {
            _context = new PartBMain();
        }

        public List<Trainer> GetAll()
        {
            var trainer = _context.Trainers.ToList();

            return trainer;
        }

        public Trainer GetTrainerByID(int id)
        {
            var Trainer = _context.Trainers.Single(t => t.TrainerID == id);

            return Trainer;
        }

        public void Create(Trainer trainer)
        {
            _context.Trainers.Add(trainer);

            try
            {
                _context.SaveChanges();
                Console.WriteLine("Trainer created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Trainer trainer)
        {
            var TrainerToChange = _context.Trainers.Single(p => p.TrainerID == trainer.TrainerID);

            TrainerToChange.Subject = trainer.Subject;
            TrainerToChange.HeadTrainerID = trainer.HeadTrainerID;

            try
            {
                _context.SaveChanges();
                Console.WriteLine($"Update Complete {trainer.PersonID} is in. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}