using System;
using System.Net;
using System.Threading.Tasks;
using CalServices.Models;
using Newtonsoft.Json;

namespace CalServices.DataSources
{
    public class ScheduleDataSource : BaseDataSource
    {
        #region Constructors
        public ScheduleDataSource(DateTime StartDate, DateTime EndDate, string BranchNumber, int AppointmentType, int AppointmentSubType, int ClientLanguage)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.BranchNumber = BranchNumber;
            this.AppointmentType = AppointmentType;
            this.AppointmentSubType = AppointmentSubType;
            this.ClientLanguage = ClientLanguage;
        }
        public ScheduleDataSource() {}
        #endregion

        public async override System.Threading.Tasks.Task<bool> Load()
        {
            DataServiceResponse<ScheduleResults> response = await GetData<ScheduleResults>(ServiceUrl);
            if(response.Success){
                Schedule = response.Data;
                return true;
            }
            return false;
        }

        public async Task<ConfirmationResponse> ConfirmAppointmentAsync(ConfirmationRequest Request)
        {
            string json = JsonConvert.SerializeObject(Request);
            DataServiceResponse <ConfirmationResponse> seriveResponse = await PutData<ConfirmationResponse>(CONF_URL, json);
            return seriveResponse.Data;
        }

        #region Properties
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private string BranchNumber { get; set; }
        private int AppointmentType { get; set; }
        private int AppointmentSubType { get; set; }
        private int ClientLanguage { get; set; }
        private string ServiceUrl
        {
            get
            {
                string sd = Uri.EscapeDataString($"{StartDate:M/d/yyyy}");
                string ed = Uri.EscapeDataString($"{EndDate:M/d/yyyy}");
                string url = string.Format(SERVICE_URL, BranchNumber, AppointmentType, AppointmentSubType, sd, ed, ClientLanguage);
#if DEBUG
                System.Diagnostics.Debug.WriteLine(url);
#endif
                return url;
            }
        }
        public ScheduleResults Schedule { get; private set; }
        #endregion

        #region Constants
        private const string SERVICE_URL = "https://xrmdataservices.azurewebsites.net/api/ScheduleEngine/GetBranchSchedule?BranchId={0}&AppointmentType={1}&AppointmentReason={2}&StartDate={3}&EndDate={4}&ClientLanguage={5}&UILanguageCode=1033&ListOnlyAvailable=true";
        private const string CONF_URL = "https://xrmdataservices.azurewebsites.net/api/ScheduleEngine/ConfirmAppointment";
        private const string CANCEL_URL = "";
        #endregion
    }
}
