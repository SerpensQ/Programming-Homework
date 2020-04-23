using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary
{
    public class Patient
    {
        public enum TypeOfService

        {
            InsuranceCover,
            SelfPaid
        }

        public string Name;
        public string Surname;
        public readonly string PolicyNumber;
        public DateTime ArrivalDate = new DateTime(2017, 11, 20);
        public DateTime DepartureDate = new DateTime(2017, 11, 30);
        public TypeOfService Service;
        public int CostOfTreatment = 4500;

        public Patient(string name, string surname, string policynumber)

        {
            Name = name;

            Surname = surname;

            PolicyNumber = policynumber;
   

        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
        public virtual void PrintInfo()
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

            Console.WriteLine($"Policy number: {PolicyNumber}, The date of arrival: {ArrivalDate.ToShortDateString()}, The date of departure: {DepartureDate.ToShortDateString()}, Type of service: {treatment}, The cost of treatment: {CostOfTreatment}");
        }

    }

}

