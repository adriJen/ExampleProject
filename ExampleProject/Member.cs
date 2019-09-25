using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTracker
{

public enum School
        {
            Hogwarts,
            UiA,
            Oxford,
            UCLA
        }

//Parent class for the children: student, teacher and principal.
class Member
{
        public string Name { get; set; }
        public string Adress { get; set; }
        public School School { get; set; }
        public int Phone { get; set; }


    }

class Student : Member
{   
    public int Grade { get; set; }
    public string Birthday { get; set; }

 }

class Teacher : Member, IPayee
{
        private int _salary;

        public string Major { get; set; }
        public string Faculty { get; set; }
        public int Salary { get { return _salary; } set
            {
                try
                {

                    if (value < 2000)
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        _salary = value;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Paying Teachers less than 2000$ is against school policy");
                }
            }
        }
    public void Pay()
    {
        Console.WriteLine($"Paying teacher {Salary}$");
    }
    
    
}


class Principal : Member, IPayee
{
    private int _salary;
        public int Salary
        {
            get { return _salary; }
            set
            {
                try
                {

                    if (value < 2500)
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        _salary = value;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Paying Principals less than 2500$ is against school policy");
                }
            }
        }
    public void Pay()
    {
        Console.WriteLine($"Paying principal {Salary}$");
    }
}

}