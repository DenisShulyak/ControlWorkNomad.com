using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.comApp
{
    public class TimeSubscription
    {
        public int Id { get; set; }
        public int CountMonths { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
