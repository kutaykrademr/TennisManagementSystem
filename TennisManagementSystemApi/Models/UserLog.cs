﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TennisManagementSystemApi.Models
{
    public partial class UserLog
    {
        public int UserLogId { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Type { get; set; }
        public string Explanation { get; set; }
        public string Application { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
    }
}
