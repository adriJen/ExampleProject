using System;
using System.Collections.Generic;
using System.Linq;


namespace SchoolTracker
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();
        static List<Principal> principals = new List<Principal>();     

        static void Main(string[] args)
        {

        string intro;
        bool b = false;
        bool authenticated = false;


        while (!b)  
        {
        Console.WriteLine("Hi, what would you like to do today?\n");
        Console.WriteLine("Options are:\n");
        Console.WriteLine("a) Create user and Log in");
        Console.WriteLine("b) Use school administrator");
        Console.WriteLine("Exit\n");
        intro = Console.ReadLine();

        switch(intro)
        {
            case "a":
            string passcode = Passcode();
            string output = PasscodeChecker(passcode);

            Console.WriteLine(output);
            Console.WriteLine("Password:");
            string input = Console.ReadLine();

                   if (input == passcode)
                   {
                        Console.WriteLine("\nYou are authenticated!\n");
                        authenticated = true; 
                   }
                   else
                   {
                        Console.WriteLine("\nWrong! Please try again\n");
                   }
            break;
            
            case "b":
                    if (authenticated)
                    {
                        schoolTracker();
                    }
                    else
                    {
                        Console.WriteLine("Denied, please log in");
                    }
                    break;

            case "Exit":
            Console.WriteLine("Goodbye!\n");
            b = true;
            break;
            default:
            Console.WriteLine("Invalid option\n");
            break;
            
            }
        }    
    }

        static string Passcode()
        {         
            Console.WriteLine("\nPlease choose a password\n");
            string passcode = Console.ReadLine();

            return passcode;
        }  

        //Checks the strength of the passcode chosen by the user. The return string assigns the passcode a strength level based on a hidden score. 
        static string PasscodeChecker(string passcode)
        {
            int passcodeStrength = 0;
            bool isSymbol = false;
            string returnString;

            foreach (char c in passcode)
            {
                if (char.IsSymbol(c))
                {
                    isSymbol = true;
                }
            }

            if (isSymbol)
            {
                passcodeStrength++;
            }

            if (passcode.Any(char.IsUpper) &&
                passcode.Any(char.IsLower))
            {
                passcodeStrength++;
            }

            if (passcode.Length >= 8)
            {
                passcodeStrength++;
            }

            if (passcode.Length <= 5)
            {
                passcodeStrength++;
            }

            if (passcodeStrength <= 1)
            {
                returnString = "\nYour password is quite weak\n";
            }

            else if (passcodeStrength == 2)
            {
                returnString = "\nYour password okay\n";
            }

            else
            {
                returnString = "\nYour password is strong\n";
            }

            return returnString;
        }

        //This method performs most of the actions a user can make. 
        static void schoolTracker()
        {   
               
            

            students.Add(new Student { Name = "John", Grade = 89, Birthday = "Oct 8", Adress = "Tverrveien", Phone = 123587, School = (School)0});
            students.Add(new Student { Name = "Rebecca", Grade = 46, Birthday = "jan 8", Adress = "Tverrveien", Phone = 1644983, School = (School)2});
            students.Add(new Student { Name = "Arthur", Grade = 79, Birthday = "Nov 8", Adress = "Tverrveien", Phone = 46587133, School = (School)3});

            teachers.Add(new Teacher { Name = "Anderson", Adress = "London", Phone = 93623487, Faculty = "Sciences", Major = "Physics", Salary = 2300, School = (School)2 });
            teachers.Add(new Teacher { Name = "Jackson", Adress = "New York", Phone = 23413523, Faculty = "Arts", Major = "Music", Salary = 2200, School = (School)2 });

            principals.Add(new Principal { Name = "Dumbledore", Adress = "Secret", Phone = 23155132, Salary = 4500, School = (School)0 });


            bool b = false;

            while (!b) 
            {

            Console.WriteLine("This is the student tracker. Would you like to:\n");
            Console.WriteLine("a) Register a new student with corresponding grades?");
            Console.WriteLine("b) Display a particular student with corresponding grades?");
            Console.WriteLine("c) Display all current students with corresponding grades?");
            Console.WriteLine("d) Hire staff?");
            Console.WriteLine("e) Issue monthly pay?");
            Console.WriteLine("e) Exit\n");

            var input = Console.ReadLine();

            
             switch(input)
              {

                case "a":
                    try
                    {
                        
                    var newStudent = new Student();

                    newStudent.Name = Util.Console.Ask("Student name: ");
                    newStudent.Grade = Util.Console.AskInt("Student grade: ");
                    newStudent.Birthday = Util.Console.Ask("Student birthday: ");
                    newStudent.Phone = Util.Console.AskInt("Student phone: ");
                    newStudent.Adress = Util.Console.Ask("Student adress: ");
                    newStudent.School = (School)Util.Console.AskInt("Student school: \nType the corresponding number: \n 0: Hogwarts \n 1: UiA \n 2: Oxford \n 3: UCLA\n) ");
                                   
                    students.Add(newStudent);
                    
                    }

                    catch (FormatException msg)
                    {
                        Console.WriteLine(msg.Message);
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("Error adding student, please try again");
                    }

                    
            
                break;
                case "b":
                    var findStudent = Console.ReadLine();
                    var item = students.Where(o => o.Name == findStudent);
                    
                    if (item != null)
                    {    
                       foreach (var student in students.Where(o => o.Name == findStudent))
                       {
                           Console.WriteLine("Student information:\n");
                           Console.WriteLine("Student name:" + student.Name);
                           Console.WriteLine("Student grade:" + student.Grade);
                           Console.WriteLine("Student birthday:" + student.Birthday);
                           Console.WriteLine("Student information:" + student.Phone);
                           Console.WriteLine("Student adress:" + student.Adress);
                           Console.WriteLine("Student school:" + student.School + "\n");
                       }
                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }

                break;
                case "c":
                    foreach (var student in students)
                    {
                     Console.WriteLine("Student {0} has the grade {1}", student.Name, student.Grade);                   
                    }
                break;
                case "d":
                        HireStaff();
                break;
                case "e":
                        Payroll systemPayroll = new Payroll();

                        
                        
                        systemPayroll.PayAll();
                break;
                default:
                    b = true;
                break;
              }
            }
        }

    //Allows the user to create new teacher and principal objects. 
    static void HireStaff()
    {
            Console.WriteLine("Would you like to hire a) a teacher, or b) a principal?");
            string input = Console.ReadLine();

            try
            {
                switch (input)
                {
                    case "a":
                        var newTeacher = new Teacher();
                        newTeacher.Name = Util.Console.Ask("Teacher Name: ");
                        newTeacher.Adress = Util.Console.Ask("Teacher Adress: ");
                        newTeacher.Phone = Util.Console.AskInt("Teacher Phone: ");
                        newTeacher.Major = Util.Console.Ask("Teacher Major: ");
                        newTeacher.Faculty = Util.Console.Ask("Teacher Faculty: ");
                        newTeacher.Salary = Util.Console.AskInt("Teacher Salary: ");
                        newTeacher.School = (School)Util.Console.AskInt("Teacher school: \nType the corresponding number: \n 0: Hogwarts \n 1: UiA \n 2: Oxford \n 3: UCLA\n) ");
                        teachers.Add(newTeacher);
                        break;
                    case "b":
                        var newPrincipal = new Principal();
                        newPrincipal.Name = Util.Console.Ask("Principal Name: ");
                        newPrincipal.Adress = Util.Console.Ask("Principal Adress: ");
                        newPrincipal.Phone = Util.Console.AskInt("Principal Phone: ");
                        newPrincipal.Salary = Util.Console.AskInt("Principal Salary: ");
                        newPrincipal.School = (School)Util.Console.AskInt("Principal school: \nType the corresponding number: \n 0: Hogwarts \n 1: UiA \n 2: Oxford \n 3: UCLA\n) ");
                        principals.Add(newPrincipal);
                        break;
                    default:
                        break;
                }
            }

            catch (FormatException msg)
            {
                Console.WriteLine(msg.Message);
            }

            catch (Exception)
            {
                Console.WriteLine("Error adding student, please try again");
            }

        }

        //Used by the payroll class constructor to add payees.
        public static List<Teacher> GetTeachers()
        {
            return teachers;
        }

        public static List<Principal> GetPrincipals()
        {
            return principals;
        }
    }

}

