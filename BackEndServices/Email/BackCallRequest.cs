using System;
using System.Collections.Generic;
using System.Text;

namespace BackEndServices
{
    public class BackCallRequest
    {
        public string UserName { get; set; }
        
        public  string Phone { get; set; }
        
        public string Email { get; set; }
        
        public int UserType { get; set; }

    }
}
