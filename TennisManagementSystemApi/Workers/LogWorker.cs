
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
    public static class LogWorker
    {
        public static System.Timers.Timer LogDbTimer = new System.Timers.Timer();

        public static bool saveDbProgress = false;

        public static void StartTimers()
        {
            LogDbTimer.Elapsed += new ElapsedEventHandler(SaveToDb);
            LogDbTimer.Interval = 10000;
            LogDbTimer.Enabled = true;
        }

        private static void SaveToDb(object source, ElapsedEventArgs e)
        {
            if (!saveDbProgress)
            {
                saveDbProgress = true;

                try
                {
                    List<ApplicationLogsDto> appLogList = new List<ApplicationLogsDto>();
                    List<UserLogsDto> userLogList = new List<UserLogsDto>();
                    List<ErrorLogsDto> errorLogList = new List<ErrorLogsDto>();
                    List<QueryLogsDto> queryLogList = new List<QueryLogsDto>();

                    while (Mutuals.ApplicationLogs.Count > 0)
                    {
                        ApplicationLogsDto log;
                        Mutuals.ApplicationLogs.TryDequeue(out log);
                        if (log != null)
                            appLogList.Add(log);
                    }

                    while (Mutuals.UserLogs.Count > 0)
                    {
                        UserLogsDto log;
                        Mutuals.UserLogs.TryDequeue(out log);
                        if (log != null)
                            userLogList.Add(log);
                    }

                    while (Mutuals.ErrorLogs.Count > 0)
                    {
                        ErrorLogsDto log;
                        Mutuals.ErrorLogs.TryDequeue(out log);
                        if (log != null)
                            errorLogList.Add(log);
                    }

                    while (Mutuals.QueryLogs.Count > 0)
                    {
                        QueryLogsDto log;
                        Mutuals.QueryLogs.TryDequeue(out log);
                        if (log != null)
                            queryLogList.Add(log);
                    }

                    using (TennisManagerDBContext db = new TennisManagerDBContext())
                    {
                        bool change = false;

                        if (appLogList.Count > 0)
                        {
                            change = true;
                            var lgs = AutoMapperBase._mapper.Map<List<ApplicationLogsDto>, List<ApplicationLog>>(appLogList).ToArray();
                            db.ApplicationLogs.AddRange(lgs);
                        }

                        if (userLogList.Count > 0)
                        {
                            change = true;
                            var lgs = AutoMapperBase._mapper.Map<List<UserLogsDto>, List<UserLog>>(userLogList).ToArray();
                            db.UserLogs.AddRange(lgs);
                        }

                        if (errorLogList.Count > 0)
                        {
                            change = true;
                            var lgs = AutoMapperBase._mapper.Map<List<ErrorLogsDto>, List<ErrorLog>>(errorLogList).ToArray();
                            db.ErrorLogs.AddRange(lgs);
                        }

                        if (queryLogList.Count > 0)
                        {
                            change = true;
                            var lgs = AutoMapperBase._mapper.Map<List<QueryLogsDto>, List<QueryLog>>(queryLogList).ToArray();
                            db.QueryLogs.AddRange(lgs);
                        }

                        if (change)
                            db.SaveChanges();
                    }


                }
                catch (Exception ex)
                {
                    Mutuals.monitizer.AddException(ex);
                }
            }

            saveDbProgress = false;
        }

    }
}
