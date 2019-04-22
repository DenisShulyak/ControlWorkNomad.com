using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.comApp
{
   public class Publisher
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        

        public ICollection<User> Users { get; set; }
       
    }
}
