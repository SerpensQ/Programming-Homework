using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HospitalLibrary;
using System.IO;
using static HospitalLibrary.Person;

namespace HospitalUnitTests
{
    [TestClass]
    public class PersonUnitTests
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            var yoongi = CreateTestPerson();

            Assert.AreEqual("Yoongi", yoongi.Name);
            Assert.AreEqual("Min", yoongi.Surname);
            Assert.AreEqual("19930309", yoongi.PolicyNumber);
            Assert.AreEqual(Person.TypeOfService.InsuranceCover, yoongi.Service);
            Assert.AreEqual("20.11.2017", yoongi.ArrivalDate );
            Assert.AreEqual("30.11.2017", yoongi.DepartureDate);
            Assert.AreEqual("100$", yoongi.CostOfTreatment);



        }
        [TestMethod]

        public void ToStringTestMethod()

        {
            var yoongi = CreateTestPerson();
            Assert.AreEqual("Yoongi Min", yoongi.ToString());
        }

        [TestMethod]
        public void PrintInfoTestMethod()
        {
            var yoongi = CreateTestPerson();
            var youngjae = new Person("Youngjae", "Choi", "19960917", "12.07.2017", "29.07.2017", Person.TypeOfService.SelfPaid, "140$");
            var consoleOut = new[]
            {
                "Yoongi Min",
                $"Policy number: 19930309, The date of arrival: 20.11.2017, " +
                $"The date of departure: 30.11.2017, Type of service: insurance covered, The cost of treatment: 100$",


                "Youngjae Choi",
                $"Policy number: 19960917, The date of arrival: 12.07.2017, " +
                $"The date of departure: 29.07.2017, Type of service: self paid, The cost of treatment: 140$"
            };

            TextWriter oldOut = Console.Out;

            using (FileStream file = new FileStream("test.txt", FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(file))
                {
                    Console.SetOut(writer);
                    yoongi.PrintInfo();
                    youngjae.PrintInfo();
                }
                var i = 0;

                foreach (var line in File.ReadLines("test.txt"))
                    Assert.AreEqual(consoleOut[i++], line);

                File.Delete("test.txt");

            }

            Console.SetOut(oldOut);

        }

        private Person CreateTestPerson()

        {

            return new Person("Yoongi", "Min", "19930309", "20.11.2017", "30.11.2017", Person.TypeOfService.InsuranceCover, "100$");

        }
    }
}
