using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreULub.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }       
        public string UserLast { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(UserLast);
    }
}
