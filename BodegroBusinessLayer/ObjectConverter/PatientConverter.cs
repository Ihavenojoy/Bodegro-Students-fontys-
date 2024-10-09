using BLL.Containers;
using BLL.DTOConverter;
using BLL.Enums;
using BLL.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ObjectConverter
{
    public class PatientConverter
    {
        private Patient DTOToObject(PatientDTO patientDTO)
        {
            SubscriptionConverter subscriptionConverter = new SubscriptionConverter();
            Patient patient = new Patient(
                patientDTO.ID,
                patientDTO.Name,
                patientDTO.Email,
                patientDTO.PhoneNumber,
                patientDTO.MedicalHistory,
                subscriptionConverter.DTOToObject(patientDTO.subscriptions),
                (Regio)patientDTO.Regio,
                patientDTO.Doctor_ID);
            return patient;
        }
    }
}
