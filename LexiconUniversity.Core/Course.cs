using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUniversity.Core
{
    public class Course
    {
        private Course()
        {
            Title = null!;
        }
        public Course(string title)
        {
            Title = title;
        }
        public int Id { get; set; }
        public string Title { get; set; }

        //Nav prop
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public ICollection<Student> Students { get; set; }=new List<Student>();  

    }
}
