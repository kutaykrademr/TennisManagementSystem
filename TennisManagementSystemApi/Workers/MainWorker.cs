
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using TennisManagementSystemApi.Mapping;
using TennisManagementSystemApi.Models;

namespace TennisManagementSystemApi.Workers
{
    public static class MainWorker
    {
        public static System.Timers.Timer ListFillerTimer = new System.Timers.Timer();

        public static void StartTimers()
        {
            UpdateLists(null, null);

            ListFillerTimer.Elapsed += new ElapsedEventHandler(UpdateLists);
            ListFillerTimer.Interval = 300000;
            ListFillerTimer.Enabled = true;
        }

        private static void UpdateLists(object source, ElapsedEventArgs e)
        {
            FillStableQueryCache();
        }

        public static void FillStableQueryCache()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Mutuals.monitizer.AddException(ex, true);
            }
        }

    }
}
