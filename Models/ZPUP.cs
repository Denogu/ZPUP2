using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestApi.Models
{
    public class ZPUP
    {
        public int UserId { get; set; }
        public string IpAddress { get; set; }
        public int ZebraPrinterId { get; set; }
        [Key]
        public int ZPUPId { get; set; }
    }
}
