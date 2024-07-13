using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project01.ViewModels
{
    public class EditRoleViewModel
    {
        [Required, StringLength(256)]
        public string Name { get; set; }
        public string Id { get;  set; }
    }
}
