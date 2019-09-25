using System;
using System.Collections.Generic;
using System.Linq;
using SchoolTracker;



namespace SchoolTracker
{   //Ensures that teacher and principal classes implement the Pay method.
    interface IPayee
    {
      void Pay();  
    }

    //The constructor uses the static lists in "Program" to populate the "Payees" list. 
    class Payroll
    {
        public List<IPayee> Payees = new List<IPayee>();

        public Payroll()
        {
            var teacherList = Program.GetTeachers();
            foreach (var teacher in teacherList)
            {
                Payees.Add(teacher);
            }

            var principalList = Program.GetPrincipals();
            foreach (var principal in principalList)
            {
                Payees.Add(principal);
            }
        }
        public void PayAll()
        {
            foreach (var payee in Payees)
            {
                payee.Pay();
            }
        }
    }
}