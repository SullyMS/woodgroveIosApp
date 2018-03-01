using System;
namespace CalServices.Utils
{
    public class SchedulerSettings
    {
        private static SchedulerSettings _settings = null;

        public SchedulerSettings()
        {
        }

        #region Properties
        public static SchedulerSettings Settings => _settings ?? (_settings = new SchedulerSettings());
        public string ScheduleBaseUrl { get; set; }
        #endregion
    }
}
