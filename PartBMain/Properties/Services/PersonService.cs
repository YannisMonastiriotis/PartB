using System;
using System.Collections.Generic;
using System.Linq;

namespace PartBMain
{
    internal class PersonService : ICrudable<Person>
    {
        private readonly PartBMain _context;

        public PersonService()
        {
            _context = new PartBMain();
        }

        public List<Person> GetAll()
        {
            var people = _context.People.ToList();

            return people;
        }

        public void Create(Person person)
        {
            _context.People.Add(person);
            try
            {
                _context.SaveChanges();
                Console.WriteLine("Person created");
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

        public void Update(Person person)
        {
            var PersonToChange = _context.People.Single(p => p.PersonID == person.PersonID);

            PersonToChange.FirstName = person.FirstName;
            PersonToChange.LastName = person.LastName;
            PersonToChange.MiddleName = person.MiddleName;
            PersonToChange.BirthDate = person.BirthDate;
            PersonToChange.Address = person.Address;
            PersonToChange.PhoneNum = person.PhoneNum;

            try
            {
                _context.SaveChanges();
                Console.WriteLine($"Update Complete {person.FirstName} is in. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }
    }
}