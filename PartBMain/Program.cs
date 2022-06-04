using System;
using System.Collections.Generic;
using System.Linq;

namespace PartBMain
{
    internal class Program
    {
        private static int[] DO = new int[] { 131, 262, 523, 1046 };
        private static int[] RE = new int[] { 147, 294, 587, 1174 };
        private static int[] MI = new int[] { 165, 330, 659, 1318 };
        private static int[] FA = new int[] { 175, 349, 698, 1396 };
        private static int[] SO = new int[] { 196, 392, 784, 1568 };
        private static int[] LA = new int[] { 220, 440, 880, 1760 };
        private static int[] TI = new int[] { 247, 494, 988, 1976 };

        private static void sweetChild()
        {
            int oct2 = 1;
            int oct3 = 2;
            int oct4 = 3;
            for (int i = 0; i < 2; i++)
            {
                Console.Beep(SO[oct2], 250);
                Console.Beep(SO[oct3], 250);
                Console.Beep(RE[oct3], 250);
                Console.Beep(DO[oct3], 250);
                Console.Beep(DO[oct4], 250);
                Console.Beep(RE[oct3], 250);
                Console.Beep(TI[oct3], 250);
                Console.Beep(RE[oct3], 250);
            }

            for (int i = 0; i < 2; i++)
            {
                Console.Beep(LA[oct2], 250);
                Console.Beep(SO[oct3], 250);
                Console.Beep(RE[oct3], 250);
                Console.Beep(DO[oct3], 250);
                Console.Beep(DO[oct4], 250);
                Console.Beep(RE[oct3], 250);
                Console.Beep(TI[oct3], 250);
                Console.Beep(RE[oct3], 250);
            }

            for (int i = 0; i < 2; i++)
            {
                Console.Beep(DO[oct3], 250);
                Console.Beep(SO[oct3], 250);
                Console.Beep(RE[oct3], 250);
                Console.Beep(DO[oct3], 250);
                Console.Beep(DO[oct4], 250);
                Console.Beep(RE[oct3], 250);
                Console.Beep(TI[oct3], 250);
                Console.Beep(RE[oct3], 250);
            }

            Console.Beep(SO[oct2], 250);
            Console.Beep(SO[oct3], 250);
            Console.Beep(RE[oct3], 250);
            Console.Beep(DO[oct3], 250);
            Console.Beep(DO[oct4], 250);
            Console.Beep(RE[oct3], 250);
            Console.Beep(TI[oct3], 250);
            Console.Beep(RE[oct3], 250);
        }

        public static void AlistOfStudents()
        {
            PartBMain main = new PartBMain();

            var studentGroup = from s in main.Students
                               join p in main.People
                               on s.PersonID equals p.PersonID
                               select s;

            foreach (var student in studentGroup)
            {
                Console.WriteLine(student);
            }
        }

        public static void AListOfTrainers()
        {
            PartBMain main = new PartBMain();

            var trainerGroup = from t in main.Trainers.Where(t => t.TrainerID == t.TrainerID)
                               join p in main.People
                               on t.PersonID equals p.PersonID
                               select t;

            foreach (var trainer in trainerGroup)
            {
                Console.WriteLine(trainer);
            }
        }

        public static void AListOfAssignments()
        {
            PartBMain main = new PartBMain();

            var queryAssignments = from a in main.Assignments
                                   select new { Title = a.Title, Description = a.Description, SubmisionDateTime = a.Submision_Date_Time };

            var newListOfAssignment = queryAssignments.ToList();

            foreach (var assignment in newListOfAssignment)
            {
                Console.WriteLine(assignment);
            }
        }

        public static void AListOfCourses()
        {
            PartBMain main = new PartBMain();

            var queryCourses = from c in main.Courses
                               select new { Title = c.Title, CourseStart = c.Start_Date };
            var newListOfCourses = queryCourses.ToList();

            foreach (var course in newListOfCourses)
            {
                Console.WriteLine(course);
            }
        }

        public static void StudentsPerCourse()
        {
            PartBMain main = new PartBMain();

            var queryStudentsPerCourse = main.Students.Where(s => s.Courses.Any(sb => sb.CourseID == sb.CourseID));
            var count = 0;
            foreach (var group in queryStudentsPerCourse)
            {
                Console.WriteLine($"************* {count}  *****************");
                Console.WriteLine($"****************************************");
                count++;
                Console.WriteLine($"Student: \t");
                Console.WriteLine(group.Person.FirstName, group.Person.LastName);
                Console.WriteLine(group);
                Console.WriteLine(" ");

                foreach (var course in group.Courses)
                {
                    Console.WriteLine($" \t Course: ");
                    Console.WriteLine(course);
                }
            }
        }

        public static void TrainersPerCourse()
        {
            PartBMain main = new PartBMain();

            var queryTrainersPerCourse = main.Trainers.Where(s => s.Courses.Any(sb => sb.CourseID == sb.CourseID));
            var count1 = 0;
            foreach (var group1 in queryTrainersPerCourse)
            {
                Console.WriteLine($"************* {count1}  *****************");
                Console.WriteLine($"****************************************");
                count1++;
                Console.WriteLine($"Trainer: \t");
                Console.WriteLine(group1.Person.FirstName, group1.Person.LastName);
                Console.WriteLine(group1);
                Console.WriteLine(" ");

                foreach (var course in group1.Courses)
                {
                    Console.WriteLine($" \t Course: ");
                    Console.WriteLine(course);
                }
            }
        }

        public static void AssignmentsPerCourse()
        {
            PartBMain main = new PartBMain();

            var queryAssignmentsPerCourse = main.Assignments.Where(s => s.Courses.Any(sb => sb.CourseID == sb.CourseID));
            var count2 = 0;
            foreach (var group1 in queryAssignmentsPerCourse)
            {
                Console.WriteLine($"************* {count2}  *****************");
                Console.WriteLine($"****************************************");
                count2++;
                Console.WriteLine($"Assignment: \t");
                Console.WriteLine(group1);
                Console.WriteLine(" ");

                foreach (var course in group1.Courses)
                {
                    Console.WriteLine($" \t Course: ");
                    Console.WriteLine(course);
                }
            }
        }

        public static void AssignmentsPerCoursePerStudent()
        {
            PartBMain main = new PartBMain();

            int count3 = 0;
            var queryAssignmentsPerCoursePerStudent = main.Courses.Where(s => s.Students.Any(sb => sb.StudentID == sb.StudentID));

            foreach (var group in queryAssignmentsPerCoursePerStudent)
            {
                count3++;
                Console.WriteLine($"$$$$$$$$$$$$$$$$$$$$$$$$$$  COURSE  :  $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                Console.WriteLine(group);
                Console.WriteLine(" ");

                foreach (Assignment assignment in group.Assignments)
                {
                    Console.WriteLine($"*******************************************ASSIGNMENTS :  *******************************************");
                    Console.WriteLine();
                    Console.WriteLine(assignment);
                    Console.WriteLine();
                    foreach (Student student in group.Students)

                    {
                        Console.WriteLine("\t*******************************************Student: *******************************\t");
                        Console.WriteLine();
                        Console.WriteLine(student);
                        Console.WriteLine(" ");
                    }
                };
            }
        }

        public static void studentsWithMoreThanOneCourses()
        {
            PartBMain main = new PartBMain();

            var studentsWithMoreThanOneCourses = main.Students.Where(c => c.Courses.Count() > 1);

            foreach (var student in studentsWithMoreThanOneCourses)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintingMenu()
        {
            int oct3 = 2;
            int oct4 = 3;
            Console.Beep(LA[oct3], 100);
            Console.Beep(TI[oct3], 100);
            Console.Beep(DO[oct4], 100);
            Console.WriteLine("\t-------------------------------------PRINTING--MENU--------------------------------------\n");

            Console.WriteLine("1.\t ========================== A LIST OF  ALL STUDENTS =================================== \n");
            Console.WriteLine("2.\t ==========================A LIST OF  ALL TRAINERS==================================== \n");
            Console.WriteLine("3.\t ==========================A LIST OF  ALL ASSIGNMENTS================================== \n");
            Console.WriteLine("4.\t ========================== A LIST OF  ALL COURSES==================================== \n");
            Console.WriteLine("5.\t ==========================ALL STUDENTS PER COURSE==================================== \n");
            Console.WriteLine("6.\t ==========================ALL TRAINERS PER COURSE==================================== \n");
            Console.WriteLine("7.\t ==========================ALL ASSIGNMENTS PER COURSE================================== \n");
            Console.WriteLine("8.\t ==========================ALL ASSIGNMENTS PER COURSE PER STUDENT======================= \n");
            Console.WriteLine("9.\t ==========================ALL STUDENTS WITH MORE THAN ONE COURSES===================== \n");
            Console.WriteLine("================================================================================================");
            Console.WriteLine("Press 1 - 9 and ENTER For a print of your choice. 10 For Exit. 11 For Main Menu");

            int PrintingUserInput = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (PrintingUserInput)
            {
                case 1:
                    AlistOfStudents();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 2:
                    AListOfTrainers();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 3:
                    AListOfAssignments();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 4:
                    AListOfCourses();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 5:
                    StudentsPerCourse();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 6:
                    TrainersPerCourse();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 7:
                    Program.AssignmentsPerCourse();

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 8:
                    Program.AssignmentsPerCoursePerStudent();
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 9:
                    Program.studentsWithMoreThanOneCourses();
                    Console.ReadKey();
                    Console.WriteLine("Press any key to continue");
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 10:
                    Console.WriteLine("Thank you come again!");
                    sweetChild();
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 11:
                    MainMenu();
                    break;

                default:
                    PrintingMenu();
                    break;
            }
        }

        public static void CreatingStudent()
        {
            PersonService personService = new PersonService();
            StudentService studentservice = new StudentService();
            personService.Create(new Person()
            {
                FirstName = "Maria",
                LastName = "Adouaneta",
                MiddleName = "M",
                BirthDate = "1957-01-01",
                Address = "Londinou 5",
                PhoneNum = "6956567832"
            });

            personService.Create(new Person()
            {
                FirstName = "Nej",
                LastName = "Menia",
                MiddleName = "J",
                BirthDate = "1956-05-01",
                Address = "Tzitzikatou 1",
                PhoneNum = "6988764532"
            });

            studentservice.Create(new Student()
            {
                PersonID = 49,
                Tuition__Fees = "2000"
            });

            studentservice.Create(new Student()
            {
                PersonID = 50,
                Tuition__Fees = "2700"
            });
        }

        public static void CreatingTrainer()
        {
            PersonService personService = new PersonService();
            TrainerService trainerService = new TrainerService();

            personService.Create(new Person()
            {
                FirstName = "Dis",
                LastName = "Mastrogianakou",
                MiddleName = "Tzul",
                BirthDate = "1998-01-02",
                Address = "Mauridou 11",
                PhoneNum = "6945665678"
            });

            trainerService.Create(new Trainer()
            {
                PrivateSchoolID = 2,
                HeadTrainerID = 2,
                PersonID = 51,
                Subject = "Programming 24/7"
            });
        }

        public static void CreatingAssignment()
        {
            AssignmentService assignmentService = new AssignmentService();

            assignmentService.Create(new Assignment()
            {
                Description = "How to Write Properly an XML document",
                Title = "Part A.1",
                Submision_Date_Time = DateTime.Now.AddDays(20)
            });
        }

        public static void CreatingCourse()
        {
            CourseService courseService = new CourseService();

            courseService.Create(new Course()
            {
                Title = "Rust",
                Start_Date = DateTime.Now.AddDays(430),
                End_Date = DateTime.Now.AddDays(520)
            });
        }

        public static void CreatingStudentPerCourse()
        {
            PersonService personService = new PersonService();
            CourseService courseService = new CourseService();
            personService.Create(new Person()
            {
                FirstName = "Bib",
                LastName = "Iamarobot",
                MiddleName = "Bop",
                BirthDate = "1985-02-02",
                Address = "Arianou 4",
                PhoneNum = "6944556782"
            });

            personService.Create(new Person()
            {
                FirstName = "Tzun",
                LastName = "Kazama",
                BirthDate = "1964-03-04",
                Address = "Streetfighter 1",
                PhoneNum = "6988586843"
            });

            courseService.Create(new Course()
            {
                Title = "Scala",
                Start_Date = DateTime.Now.AddDays(2),
                End_Date = DateTime.Now.AddDays(122),
                Students = new List<Student>()
                             {
                                 new Student()
                                  {
                                      PersonID = 52,
                                      StudentID = 34,
                                      Tuition__Fees = "1200"
                                 },
                                 new Student()
                                 {
                                      PersonID = 53,
                                     StudentID = 35,
                                     Tuition__Fees = "1300"
                                 }
                             }
            });
        }

        public static void CreatingTrainerPerCourse()
        {
            PersonService personService = new PersonService();

            CourseService courseService = new CourseService();

            personService.Create(new Person()
            {
                FirstName = "Sonya",
                LastName = "Blade",
                BirthDate = "1988-02-06",
                Address = "Mortal Kombat 1",
                PhoneNum = "6976445312"
            });

            personService.Create(new Person()
            {
                FirstName = "Jade",
                LastName = "Kitana",
                BirthDate = "1966-06-06",
                Address = "Mortal Kombat 2",
                PhoneNum = "6988754432"
            });

            courseService.Create(new Course()
            {
                Title = "Matlab",
                Start_Date = DateTime.Now.AddDays(4),
                End_Date = DateTime.Now.AddDays(124),
                Trainers = new List<Trainer>()
                             {
                                 new Trainer()
                                  {
                                  PersonID = 54,
                                 TrainerID = 36,
                                 HeadTrainerID = 2,
                                 Subject = "Restoring Databases",
                                 PrivateSchoolID = 2
                                 },
                                 new Trainer()
                                 {
                                     PersonID = 55,
                                     TrainerID = 37,
                                     HeadTrainerID = 2,
                                     Subject = "Fun with Matlab",
                                    PrivateSchoolID = 2
                                 }
                             }
            });
        }

        public static void CreatingAssignmentStudentCourse()
        {
            PersonService personService = new PersonService();
            CourseService courseService = new CourseService();

            personService.Create(new Person()
            {
                FirstName = "Kitana",
                LastName = "Linque",
                MiddleName = "Cage",
                BirthDate = "1982-02-01",
                Address = "Mortal Kombat 3",
                PhoneNum = "6966564632"
            });

            personService.Create(new Person()
            {
                FirstName = "Sindel",
                LastName = "Mileena",
                BirthDate = "1978-03-01",
                Address = "Mortal Kombat Trilogy",
                PhoneNum = "6988776654"
            });

            courseService.Create(new Course()
            {
                Title = "Web Development",
                Start_Date = DateTime.Now.AddDays(6),
                End_Date = DateTime.Now.AddDays(126),
                Students = new List<Student>()
                 {
                     new Student()
                      {
                 PersonID = 56,
                 StudentID = 38,
                 Tuition__Fees = "2200"
                     },
                     new Student()
                     {
                         PersonID = 57,
                         StudentID = 39,
                         Tuition__Fees = "2000"
                     }
                 },
                Assignments = new List<Assignment>()
                {
                    new Assignment()
                    {   Title  = "The End",
                        Description= "I want to thank my instructor for being patient with me",
                        Submision_Date_Time = DateTime.Now.AddDays(1)
                    }
                }
            });
        }

        public static void CreatingMenu()
        {
            int oct3 = 2;

            Console.Beep(DO[oct3], 100);
            Console.Beep(RE[oct3], 100);
            Console.Beep(MI[oct3], 100);

            Console.WriteLine("********************************CREATING AND ADDING DATA TO THE DATABASE *************************************************\n");
            Console.WriteLine("WARNING DO NOT CREATE MORE THAN ONE TIME PER CHOICE. SOME CREATIONS ARE UNIQUE . PROBLEMS WILL ARISE IF ELSE. ACT AT YOUR OWN RISK");
            Console.WriteLine("1. -----------------------STUDENT----------------------------------\n");
            Console.WriteLine("2.------------------------TRAINER----------------------------------\n");
            Console.WriteLine("3.-----------------------ASSIGNMENT----------------------------------\n");
            Console.WriteLine("4.------------------------COURSE-----------------------------------\n");
            Console.WriteLine("5.---------------------STUDENTS PER COURSE---------------------------\n");
            Console.WriteLine("6.---------------------TRAINER - COURSE-------------------------------\n");
            Console.WriteLine("7.-----------------ASSIGNMENT - STUDENT - COURSE----------------------\n");
            Console.WriteLine("Press 1 - 7 and ENTER For a print of your choice. 8 For Exit 9 To Main Menu");

            int PrintingUserInput = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (PrintingUserInput)
            {
                case 1:

                    CreatingStudent();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 2:
                    CreatingTrainer();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 3:
                    CreatingAssignment();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 4:
                    CreatingCourse();

                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 5:
                    CreatingStudentPerCourse();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 6:
                    CreatingTrainerPerCourse();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 7:
                    CreatingAssignmentStudentCourse();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    PrintingMenu();
                    break;

                case 8:
                    Console.WriteLine("Thank you come again!");
                    sweetChild();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 9:
                    MainMenu();
                    break;

                default:
                    PrintingMenu();

                    break;
            }
        }

        private static void MainMenu()
        {
            Console.Beep(DO[1], 131);
            Console.WriteLine();
            Console.Beep(DO[1], 131);

            Console.Beep(DO[1], 131);
            Console.WriteLine();

            Console.Beep(DO[1], 131);
            Console.WriteLine("Press 1 for printing menu. Press 2 for Creating Menu. Press 3 to Exit");
            int UserInput = Convert.ToInt32(Console.ReadLine());

            if (UserInput == 1)
            {
                Program.PrintingMenu();
            }
            else if (UserInput == 2)
            {
                Program.CreatingMenu();
            }
            else if (UserInput == 3)
            {
                Console.WriteLine("Thank you come again");

                sweetChild();
            }
            else
            {
                MainMenu();
            }
        }

        private static void Main(string[] args)
        {
            MainMenu();

            Console.ReadKey();
        }
    }
}