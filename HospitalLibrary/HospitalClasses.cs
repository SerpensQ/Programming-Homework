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
        public DateTime ArrivalDate;
        public DateTime DepartureDate;
        public TypeOfService Service;
        public int CostOfTreatment;

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

    public class HospitalPatient : Patient
    {
        public string MedicalDepartment { get; set; }
        public int RoomNumber { get; set; }

        public HospitalPatient(string name, string surname, string policynumber, string medicaldepartment, int roomnumber)
        : base(name, surname, policynumber)
        {
            MedicalDepartment = medicaldepartment;
            RoomNumber = roomnumber;

        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Hospital patient from {MedicalDepartment} department, room number: {RoomNumber}");

        }

    }
    public class DayHospitalPatient : Patient
    {
        public DateTime ComeInTime { get; set; }
        public DateTime LeaveTime { get; set; }
        public DayHospitalPatient(string name, string surname, string policynumber, DateTime comeintime, DateTime leavetime)
         : base(name, surname, policynumber)
        {
            ComeInTime = comeintime;
            LeaveTime = leavetime;

        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Day Hospital patient came in at {ComeInTime.ToShortTimeString()} o'clock and left at {LeaveTime.ToShortTimeString()} o'clock");

        }

    }



    public class OutPatient : Patient
    {
        public string DoctorName { get; set; }
        
        public OutPatient(string name, string surname, string policynumber, string doctorname)
         : base(name, surname, policynumber)
        {
            DoctorName = doctorname;

        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"The patient was treated by Doctor {DoctorName}");

        }

    }


}



