using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
    class Program
    {
        private static List<Teacher> Teachers;
        private static List<Student> Students;

        static void Main(string[] args)
        {
            Teachers = new List<Teacher>()
            {
                new Teacher() { Name = "Mrs. Jones", Age = 24, Id = 1, Grade = 2 },
                new Teacher() { Name = "Mr. Smith", Age = 48, Id = 2, Grade = 3 },
                new Teacher() { Name = "Ms. Kelley", Age = 28, Id = 3, Grade = 4 },
                new Teacher() { Name = "Mr. Levy", Age = 32, Id = 5, Grade = 3 },
                new Teacher() { Name = "Miss. Friendly", Age = 52, Id = 4, Grade = 5 }
            };

            Students = new List<Student>()
            {
                new Student() { Name = "Billy Cunningham", Age = 7, TeacherId = 1, Id = 1, Gender = "M" },
                new Student() { Name = "Susy Jones", Age = 8, TeacherId = 1, Id = 2, Gender = "F" },
                new Student() { Name = "Austin Wentworth", Age = 7, TeacherId = 1, Id = 3, Gender = "M" },
                new Student() { Name = "Graham Underwood", Age = 7, TeacherId = 1, Id = 4, Gender = "M" },
                new Student() { Name = "Chris Smith", Age = 7, TeacherId = 1, Id = 5, Gender = "M" },
                new Student() { Name = "Samantha Jones", Age = 7, TeacherId = 1, Id = 6, Gender = "F" },
                new Student() { Name = "Jenny Green", Age = 7, TeacherId = 1, Id = 7, Gender = "F" },
                new Student() { Name = "Bob Roberts", Age = 7, TeacherId = 1, Id = 8, Gender = "M" },
                new Student() { Name = "Linda Billings", Age = 7, TeacherId = 1, Id = 9, Gender = "F" },
                new Student() { Name = "Louis Jones", Age = 7, TeacherId = 1, Id = 10, Gender = "M" },
                new Student() { Name = "Sandy Smith", Age = 8, TeacherId = 2, Id = 11, Gender = "F" },
                new Student() { Name = "Conner Oberst", Age = 8, TeacherId = 2, Id = 12, Gender = "M" },
                new Student() { Name = "Jason Nessen", Age = 8, TeacherId = 2, Id = 13, Gender = "M" },
                new Student() { Name = "Billy Jones", Age = 8, TeacherId = 2, Id = 14, Gender = "M" },
                new Student() { Name = "Joe Lewis", Age = 8, TeacherId = 2, Id = 15, Gender = "M" },
                new Student() { Name = "Harold Cochran", Age = 8, TeacherId = 2, Id = 16, Gender = "M" },
                new Student() { Name = "Owen Wilson", Age = 9, TeacherId = 2, Id = 17, Gender = "M" },
                new Student() { Name = "Rita Monroe", Age = 9, TeacherId = 2, Id = 18, Gender = "F" },
                new Student() { Name = "Loretta Bass", Age = 9, TeacherId = 3, Id = 19, Gender = "F" },
                new Student() { Name = "Hank Williams", Age = 9, TeacherId = 3, Id = 20, Gender = "M" },
                new Student() { Name = "Jack Sprat", Age = 17, TeacherId = 3, Id = 21, Gender = "M" },
                new Student() { Name = "Bella Jones", Age = 9, TeacherId = 3, Id = 22, Gender = "F" },
                new Student() { Name = "Marvin Myers", Age = 10, TeacherId = 4, Id = 23, Gender = "M" },
                new Student() { Name = "Angelina Pitt", Age = 9, TeacherId = 4, Id = 24, Gender = "F" },
                new Student() { Name = "Marilyn Hayworth", Age = 11, TeacherId = 4, Id = 25, Gender = "F" },
                new Student() { Name = "John Jones", Age = 9, TeacherId = 4, Id = 26, Gender = "M" },
                new Student() { Name = "Sandra Block", Age = 9, TeacherId = 4, Id = 27, Gender = "F" },
                new Student() { Name = "Christopher Catan", Age = 9, TeacherId = 4, Id = 28, Gender = "M" },
                new Student() { Name = "Horatio Gomez", Age = 9, TeacherId = 4, Id = 29, Gender = "M" },
                new Student() { Name = "Ronald Daltry", Age = 9, TeacherId = 4, Id = 30, Gender = "M" },
                new Student() { Name = "Elizabeth Patterson", Age = 9, TeacherId = 4, Id = 31, Gender = "F" },
                new Student() { Name = "Melisssa Finch", Age = 9, TeacherId = 4, Id = 32, Gender = "F" },
                new Student() { Name = "Sandra Mayfield", Age = 9, TeacherId = 4, Id = 33, Gender = "F" },
                new Student() { Name = "Dawn Johns", Age = 9, TeacherId = 4, Id = 34, Gender = "F" },
                new Student() { Name = "Catherine Angus", Age = 9, TeacherId = 4, Id = 35, Gender = "F" }, //
                new Student() { Name = "George Laws", Age = 9, TeacherId = 5, Id = 36, Gender = "M" },
                new Student() { Name = "Hector Wells", Age = 9, TeacherId = 5, Id = 37, Gender = "M" },
                new Student() { Name = "Rob Roundry", Age = 9, TeacherId = 5, Id = 38, Gender = "M" },
                new Student() { Name = "Angela Patts", Age = 9, TeacherId = 5, Id = 39, Gender = "F" },
                new Student() { Name = "Bobby Miller", Age = 9, TeacherId = 5, Id = 40, Gender = "F" },
                new Student() { Name = "Susy Smith", Age = 9, TeacherId = 5, Id = 41, Gender = "F" },
                new Student() { Name = "Adriana Michaels", Age = 9, TeacherId = 5, Id = 42, Gender = "F" },
                new Student() { Name = "Jennifer Randall", Age = 9, TeacherId = 5, Id = 43, Gender = "F" }

            };

            //Instructions: Use a Linq or Lambda query to answer the questions.
            //Each answer should be written to the console

            //1. How many teachers are there
            Console.WriteLine(Teachers.Count());

            //2. Output each Teacher's name and the number of students that are in their class
            Teachers.Select(teacher => new Teacher()
            {
                Name = teacher.Name,
                Students = Students.Where(student => student.TeacherId == teacher.Id).ToList()
            }).ToList()
            .ForEach(t => Console.WriteLine($"{ t.Name } has { t.Students.Count() } students."));

            //3. How many boys are in Miss. Friendly's class
            Console.WriteLine(Students
                .Where(t => t.TeacherId == (Teachers.Where(teacher => teacher.Name == "Miss. Friendly").FirstOrDefault().Id) && t.Gender == "M").Count());

            //4. Who is the oldest student
            Console.WriteLine(Students.OrderByDescending(s => s.Age).FirstOrDefault().Name);

            //5. Who is the oldest student in the oldest teacher's class
            Console.WriteLine(Students.Where(teacher => teacher.TeacherId == (Teachers.OrderByDescending(t => t.Age).FirstOrDefault().Id)).OrderByDescending(s => s.Age).FirstOrDefault().Name);

            //6. Who is the oldest student in the 2nd grade
            Console.WriteLine((from t in Teachers
             from s in Students
             where s.TeacherId == t.Id && t.Grade == 2
             select s).OrderByDescending(t => t.Age).ToList().FirstOrDefault().Name);

            //7. How many students are in the 3rd grade
            Console.WriteLine((from t in Teachers
             from s in Students
             where t.Grade == 3 && s.TeacherId == t.Id
             select s).Count() + " students in the third grade.");

            //8. Output a comma seperated list of the names of all females in the 5th grade
            Console.Write(String.Join(", ", (from t in Teachers
                           from s in Students
                           where t.Grade == 5 && s.Gender == "F" && s.TeacherId == t.Id
                           select s.Name).ToArray()));

            //9. Create an anonymous list that contains the teacher name, student name, student age and student gender 
            var teacherStudentList = (from t in Teachers
                                      from s in Students
                                      where s.TeacherId == t.Id
                                      select new { Teacher = t.Name, Student = s.Name, StudentAge = s.Age, StudentGender = s.Gender }).ToList();

            teacherStudentList.ForEach(s =>
            {
                Console.WriteLine($"{ s.Teacher } - { s.Student } - { s.StudentAge } - { s.StudentGender }");
            });

            //10. Output the Student's ages in descending order
            Students.OrderByDescending(s => s.Age).ToList().ForEach(f => { Console.WriteLine(f.Age); });

            Console.Read();
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class Teacher : Person
    {
        public Teacher()
        {
            Students = new List<Student>();
        }

        public int Id { get; set; }

        public List<Student> Students { get; set; }

        public int Grade { get; set; }
    }

    public class Student : Person
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public string Gender { get; set; }
    }
}