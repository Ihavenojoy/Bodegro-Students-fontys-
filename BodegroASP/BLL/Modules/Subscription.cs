﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Domain.Modules
{
    public class Subscription
    {
        public DateTime StartDate { get; set; }
        public Protocol Protocol { get; set; }
        public Patient Patient { get; set; }
        public int StepsTaken { get; set; }

        public Subscription(DateTime StarDate, Protocol Protocol, Patient patient)
        {
            StartDate = StarDate;
            this.Protocol = Protocol;
            StepsTaken = 0;
            Patient = patient;
        }
        public bool CheckDateBefore(DateTime StartDate, DateTime EndDate)
        {
            bool check = false;
            if (StartDate.Year < EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Month < EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Day < EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Hour < EndDate.Hour && StartDate.Day <= EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Minute < EndDate.Minute && StartDate.Hour <= EndDate.Hour && StartDate.Day <= EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Second < EndDate.Second && StartDate.Minute <= EndDate.Minute && StartDate.Hour <= EndDate.Hour && StartDate.Day <= EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            return check;
        }
    }
}
