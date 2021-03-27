using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Helpers
{
    [DataContract]
    public class CompanySettingsDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string SunucuIp { get; set; }
        [DataMember]
        public bool? M1 { get; set; }
        [DataMember]
        public bool? M2 { get; set; }
        [DataMember]
        public bool? M3 { get; set; }
        [DataMember]
        public bool? M4 { get; set; }
        [DataMember]
        public bool? M5 { get; set; }
        [DataMember]
        public bool? M6 { get; set; }
        [DataMember]
        public int CourtCount { get; set; }
        [DataMember]
        public string PhotoUrl { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public DateTime ExpirationDate { get; set; }
    }
}
