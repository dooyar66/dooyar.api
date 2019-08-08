using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dooyar.models.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string Pwd { get; set; }
    }
}
