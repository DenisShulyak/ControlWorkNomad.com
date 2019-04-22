using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.comApp
{
    public class Subscription
    {
        public int Id { get; set; }

        public int TimeSubscriptionId { get; set; }
        public TimeSubscription TimeSubscription { get; set; }

        public int Price { get; set; }
       

        public int MagazineId { get; set; } // Журналы
        public Magazine Magazine { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
