﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUniversity.Core
{
    public class Enrollment
    {
        public int Id { get; set; }
        //Payload
        public int Grade { get; set; }    
        //FK
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        //nav prop
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
