using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Bigoton.Web.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public User User { get; set; }


        public Reservation Reservation { get; set; }

        public CutStyle CutStyle { get; set; }

        public Payment Payment { get; set; }

    }
}
