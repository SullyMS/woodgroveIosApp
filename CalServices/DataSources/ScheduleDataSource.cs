using System;
using System.Threading.Tasks;
using CalServices.Models;
using CalServices.Utils;
using Newtonsoft.Json;

namespace CalServices.DataSources
{
    public class ScheduleDataSource : BaseDataSource
    {
        #region Constructors
        public ScheduleDataSource() {}
        #endregion

        public async Task<DataServiceResponse<ScheduleResults>> GetAvailableTimes(DateTime StartDate, DateTime EndDate, string BranchNumber, int AppointmentType, int AppointmentSubType, int ClientLanguage)
        {
            string url = string.Format(SERVICE_URL, BranchNumber, AppointmentType, AppointmentSubType, StartDate.ToString("o"), 
                                       EndDate.ToString("o"), ClientLanguage);
            url = GetOperation(url);
            DataServiceResponse<ScheduleResults> response = await GetData<ScheduleResults>(url);
            return response;
        }

        public async Task<DataServiceResponse<ConfirmationResponse>> ConfirmAppointmentAsync(ConfirmationRequest Request)
        {
            string json = JsonConvert.SerializeObject(Request);
            DataServiceResponse <ConfirmationResponse> seriveResponse = await PutData<ConfirmationResponse>(GetOperation(CONF_URL), json);
            return seriveResponse;
        }

        public async Task<DataServiceResponse<CancelAppointmentResponse>> CancelAppointmentAsync(CancelAppointmentRequest Request)
        {
            string json = JsonConvert.SerializeObject(Request);
            DataServiceResponse<CancelAppointmentResponse> response = await PutData<CancelAppointmentResponse>(GetOperation(CANCEL_URL), json);
            return response;
        }

        public async Task<DataServiceResponse<CheckInResponse>> CheckInAsync(string ConfirmationNumber)
        {
            string operation = string.Format(CHECKIN_URL, ConfirmationNumber);
            DataServiceResponse<CheckInResponse> response = await PutData<CheckInResponse>(GetOperation(operation), ConfirmationNumber);
            return response;
        }

        private string GetOperation(string RelativeOperation)
            {
            return $"{SchedulerSettings.Settings.ScheduleBaseUrl}{RelativeOperation}";
        }

        #region Constants
        private const string SERVICE_URL = "ScheduleEngine/GetBranchSchedule?BranchId={0}&AppointmentType={1}&AppointmentReason={2}&StartDate={3}&EndDate={4}&ClientLanguage={5}&UILanguageCode=1033&ListOnlyAvailable=true";
        private const string CONF_URL = "ScheduleEngine/ConfirmAppointment";
        private const string CANCEL_URL = "ScheduleEngine/CancelAppointment";
        private const string CHECKIN_URL = "ScheduleEngine/AppointmentCheckIn?ConfirmationNumber={0}";
        #endregion
    }
}
