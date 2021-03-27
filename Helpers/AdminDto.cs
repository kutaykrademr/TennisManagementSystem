using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Helpers
{
    [DataContract]
    public class AdminDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
