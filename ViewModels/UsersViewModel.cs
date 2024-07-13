using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project01.ViewModels
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
