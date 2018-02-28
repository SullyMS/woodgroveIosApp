using System.Collections.Generic;
using CalServices.Models;

namespace CalServices.Utils
{
    public class ReferenceData
    {
        public ReferenceData()
        {
        }

        private static ReferenceData _data;
        public static ReferenceData Data => _data ?? (_data = new ReferenceData());

        public Dictionary<int, AppointmentReason> AppointmentTypesDictionary {get; private set;}

        public void SetReferenceAppointmentTypes(List<AppointmentReason> AppointmentTypes)
        {
            AppointmentTypesDictionary = new Dictionary<int, AppointmentReason>();
            foreach (AppointmentReason ar in AppointmentTypes)
            {
                AppointmentTypesDictionary.Add(ar.AppointmentTypeCode, ar);
            }
        }
    }
}
