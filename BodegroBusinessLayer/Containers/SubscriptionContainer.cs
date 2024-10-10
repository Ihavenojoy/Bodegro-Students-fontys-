﻿using BLL.Modules;
using BLL.Enums;
using BLL.Containers;
using BLL.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using BodegroInterfaces;

namespace BLL.Containers
{
    public class SubscriptionContainer
    {
        ISubscription DAL = new SubscriptionDAL();
        ProtocolContainer ProtocolContainer;
        private Doctor doctor;
        private List<Patient> patients = new List<Patient> { };
        private List<Protocol> protocols = new List<Protocol> { };
        public SubscriptionContainer(Doctor doctor)
        {
            this.doctor = doctor;
            GetMockData();
        }
        public List<string> GetPatients()
        {// Komt in de database layer
            List<string> list = new List<string>();
            for (int i = 0; i < patients.Count; i++)
            {
                for (int j = 0; j < doctor.Patients.Count(); j++)
                {
                    if (patients[i].IDCheck(doctor.Patients[j].ID))
                    list.Add(patients[i].ToString());
                }
            }
            return list;
        }
        public List<string> GetProtocols()
        {// Komt in de database layer
            List<string> list = new List<string>();
            for (int i = 0; i < protocols.Count; i++)
            {
                list.Add(protocols[i].ToString());
            }
            return list;
        }
        public string AddSubscription(string protocol, string patient, DateTime SDate)
        {
                int proto = 0;
                for (int i = 0; i < protocols.Count; i++)
                {
                    if (protocols[i].Name == protocol) { proto = i; }
                }
                Protocol prot = protocols[proto];
                int patien = 0;
                for (int i = 0; i < patients.Count; i++)
                {
                    if (patients[i].Name == patient) { patien = i; }
                }
                Subscription subscription = new Subscription(SDate, prot);
                patients[patien].Subscriptions.Add(subscription);
                return "Succesvol toegevoegt";
        }
        private void GetMockData()
        {// Komt uiteindelijk te vervallen
            List<string> medicalHistory = new List<string>();
            List<Subscription> subscriptions = new List<Subscription>();
            Patient Mock1 = new Patient(0,"Piet", "pietpuk@gmail.com", 45963049, medicalHistory, subscriptions, Regio.Hart_voor_Brabant, 1);
            Patient Mock2 = new Patient(1,"Henk", "henkklaasen@gmail.com", 54746438, medicalHistory, subscriptions, Regio.Amsterdam, 1);
            Patient Mock3 = new Patient(2,"Jan", "janjansen@gmail.com", 98379626, medicalHistory, subscriptions, Regio.Brabant_Zuidoost, 1);
            Patient Mock4 = new Patient(3,"Tom", "tomvandelest@gmail.com", 74725952, medicalHistory, subscriptions, Regio.West_Brabant, 1);
            patients.Add(Mock1);
            patients.Add(Mock2);
            patients.Add(Mock3);
            patients.Add(Mock4);
            List<Step> steps = new List<Step>();
            Protocol Mock5 = new Protocol("Diabetus", steps, "");
            Protocol Mock6 = new Protocol("Hepatitus", steps, "");
            Protocol Mock7 = new Protocol("Ebola", steps, "");
            Protocol Mock8 = new Protocol("HIV", steps, "");
            protocols.Add(Mock5);
            protocols.Add(Mock6);
            protocols.Add(Mock7);
            protocols.Add(Mock8);
        }
        public bool Datumcheck(DateTime StartDate, DateTime EndDate)
        {
            bool check = false;
            int SDay = Convert.ToInt32(GetDate(StartDate.ToString(), 0, 1));
            int EDay = Convert.ToInt32(GetDate(EndDate.ToString(), 0, 1));
            string[] Ssubs = StartDate.ToString().Split('/');
            string[] Esubs = EndDate.ToString().Split('/');
            int SMonth = Convert.ToInt32(Ssubs[1]);
            int EMonth = Convert.ToInt32(Esubs[1]);
            int SYear = Convert.ToInt32(GetDate(Ssubs[2], 0, 3));
            int EYear = Convert.ToInt32(GetDate(Esubs[2], 0, 3));
            if (SDay <= EDay && SMonth <= EMonth && SYear <= EYear)
            {
                check = true;
            }
            else if (SMonth < EMonth && SYear <= EYear)
            {
                check = true;
            }
            else if (SYear < EYear)
            {
                check = true;
            }
            return check;
        }
        private string GetDate(string input, int min, int max)
        {
            string Date = "";
            for (int i = min; i <= max; i++)
            {
                char temp = input[i];
                Date += temp;
            }
            return Date;
        }
    }
}
