using Bogus;
using LexiconUniversity.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUniversity.Data
{
    public class SeedData
    {
        private static Faker faker = null!;
        public static async Task InitAsync(LexiconUniversityContext db)
        {
            if (await db.Student.AnyAsync()) return;

            faker = new Faker("sv");
            var students = GenerateStudents(30);
            await db.AddRangeAsync(students);
            await db.SaveChangesAsync();    
        }

        private static IEnumerable<Student> GenerateStudents(int numberOfStudents)
        {
            var students = new List<Student>();
            for (int i = 0; i < numberOfStudents; i++)
            {
                var fName = faker.Name.FirstName();
                var lName = faker.Name.LastName();
                var avatar = faker.Internet.Avatar();
                var email = faker.Internet.Email($"{fName}{lName}");

                var student = new Student(avatar, fName, lName, email)
                {
                    Address = new Address
                    {
                        City = faker.Address.City(),
                        Street = faker.Address.StreetAddress(),
                        ZipCode = faker.Address.ZipCode()
                    }
                };

                students.Add(student);
            }

            return students;
        }
    }
}
