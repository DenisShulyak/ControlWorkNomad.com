using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.comApp
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public bool StateSubscription { get; set; } //Подписка: есть - нет

        public int? SubscriptionId { get; set; } //если null то подписка не оформлена
        public Subscription Subscription { get; set; }
        

        public bool? StateDeliveryLastMagazine { get; set; } //если null то подписки нет

       // public int Score { get; set; } // Кол-во денег пользователя

    }
}
