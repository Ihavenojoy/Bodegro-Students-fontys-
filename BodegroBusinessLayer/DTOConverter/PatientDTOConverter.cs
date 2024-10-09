using BLL.Containers;
using BLL.Enums;
using BLL.Modules;
using BLL.ObjectConverter;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOConverter
{
    public class PatientDTOConverter
    {
        private PatientDTO ObjectToDTO(Patient patient)
        {
            SubscriptionDTOConverter subscriptionDTOConverter = new SubscriptionDTOConverter();
            PatientDTO patientDTO = new PatientDTO(
                patient.ID,
                patient.Name,
                patient.Email,
                patient.PhoneNumber,
                patient.MedicalHistory,
                subscriptionDTOConverter.ObjectToDTO(patient.Subscriptions),
                (int)patient.Regio,
                patient.DoctorID);
            return patientDTO;
        }
    }
}
