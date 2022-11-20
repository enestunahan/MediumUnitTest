﻿namespace MediumUnitTest.Library.Models
{
    public class Student
    {
        public  string FirstName { get; set; }
        public  string LastName  { get; set; }
        public  string FullName
        {
            get
            {
                return string.Concat(FirstName, " "  ,LastName);
            }
        }


    }
}
