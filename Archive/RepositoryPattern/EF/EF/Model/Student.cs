﻿namespace EF
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"{Id} => {Name}";
    }
}