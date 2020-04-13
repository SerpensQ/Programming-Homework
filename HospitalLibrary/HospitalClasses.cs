using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    public class Person
    {
        public enum TypeOfService

        {
            InsuranceCover,
            SelfPaid
        }

        public string Name;
        public string Surname;
        public readonly string PolicyNumber;
        public string ArrivalDate;
        public string DepartureDate;
        public TypeOfService Service;
        public string CostOfTreatment;


        public Person(string name, string surname, string policynumber,
                        string arrival, string departure, TypeOfService treatment, string cost)

        {
            Name = name;

            Surname = surname;

            PolicyNumber = policynumber;

            ArrivalDate=arrival;

            DepartureDate = departure;

            Service = treatment;

            CostOfTreatment = cost;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
        public void PrintInfo()
        {
            Console.WriteLine(this);
            var treatment = "";

            switch (Service)
            {
                case TypeOfService.InsuranceCover:
                    treatment = "insurance covered";
                    break;
                case TypeOfService.SelfPaid:
                    treatment = "self paid";
                    break;
            }

            Console.WriteLine($"Policy number: {PolicyNumber}, The date of arrival: {ArrivalDate}, The date of departure: {DepartureDate}, Type of service: {treatment}, The cost of treatment: {CostOfTreatment}");
        }
    }
}
