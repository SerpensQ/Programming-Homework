using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HospitalLibrary;
using System.IO;
using static HospitalLibrary.Patient;

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

            var youngjae = new Patient("Youngjae", "Choi", "19960917")
            {ArrivalDate = new DateTime(2017, 07, 12), DepartureDate= new DateTime(2017, 07, 29), Service=TypeOfService.SelfPaid, CostOfTreatment=5850 };
            var consoleOut = new[]
            {
                "Yoongi Min",
                $"Policy number: 19930309, The date of arrival: 20.11.2017, " +
                $"The date of departure: 30.11.2017, Type of service: insurance covered, The cost of treatment: 4500",
               "Youngjae Choi",
                $"Policy number: 19960917, The date of arrival: 12.07.2017, " +
                $"The date of departure: 29.07.2017, Type of service: self paid, The cost of treatment: 5850"

        };

            TextWriter oldOut = Console.Out;

            using (FileStream file = new FileStream("test.txt", FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(file))
                {
                    Console.SetOut(writer);
                    yoongi.PrintInfo();

                }
                var i = 0;

                foreach (var line in File.ReadLines("test.txt"))
                    Assert.AreEqual(consoleOut[i++], line);

                File.Delete("test.txt");

            }
            Console.SetOut(oldOut);
        }

        private Patient CreateTestPerson()
        {
            return new Patient("Yoongi", "Min", "19930309")
            { ArrivalDate = new DateTime(2017, 11, 20), DepartureDate = new DateTime(2017, 11, 30), Service=TypeOfService.InsuranceCover, CostOfTreatment = 4500 };
        }
    }
    

}