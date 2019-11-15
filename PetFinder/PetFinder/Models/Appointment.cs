using System;
using System.Collections.Generic;
using System.Text;

namespace PetFinder.Models
{
    public class Appointment
    {
        //TODO Test AppointmentID here and create it with un GUID in the PetRepository
        public string AppointmentId { get; set; } = System.Guid.NewGuid().ToString();
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AnimalName { get; set; }
        public string OrganizationName { get; set; }
    }
}
