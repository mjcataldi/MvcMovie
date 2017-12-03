using System;

namespace MvcMovie
{

    public class Person 
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>This is the summary for this method
        /// The <paramref name="LastName" /> parameter takes a Last Name
        /// <returns>Returns a string of someone's full name</returns>
        /// <param name="FirstName">Needs the First Name</param>
        /// </summary>
        /// 
        /// <summary>
        ///     <param name="FirstName"></param>
        ///     <param name="LastName"></param>
        /// </summary>
        // / <param name="FirstName"></param>
        // / <param name="LastName"></param>
        // / <returns></returns>
        public static string FullName(string FirstName, string LastName) => $"{ FirstName } { LastName }";

        public virtual string SaySomething()
        {
            return "Blah Base Class";
        }        
    }

    public class Musician : Person
    {
        public Musician (string firstName, string lastName) 
            :base (firstName, lastName)
        {
            
        }

        public override string SaySomething()
        {
            return "Blah";
        }
    }

    public class Crap
    {
        public void MyNewMethod()
        {
            Musician musician = new Musician(firstName: "Matthew", lastName: "Cataldi");
            var crap = ((Person)musician).SaySomething();
        }
    }


}