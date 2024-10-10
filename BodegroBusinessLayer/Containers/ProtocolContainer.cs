﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Modules;
using BodegroInterfaces;
using DTO;

namespace BLL.Containers
{
    public class ProtocolContainer
    {
        IProtocol Dal = new ProtocolDAL();
        StepContainer StepContainer;
        public void AddProtocol(string Name, string Description, List<Step> Steps)
        {
            Protocol protocol = new Protocol(Name, Steps, Description);

        }
    }
}
