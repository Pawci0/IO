using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Model
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Username { get; set; }

        public User(string name)
        {
            Username = name;
        }
    }
}
