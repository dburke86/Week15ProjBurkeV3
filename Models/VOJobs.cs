using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Week15ProjBurkeV2.Models
{
    public class VOJobs
    {
        public int JobId { get; set; }
        [Key] 
        
        public int ClientId { get; set; }
        
        public string Description { get; set; }
                        
        public string ClientName { get; set; }
        
        public string ClientEmail { get; set; }
                
        public DateTime DueDate { get; set; }
    }
}
