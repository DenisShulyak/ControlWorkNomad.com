using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.comApp
{
    class Program
    {
        static void Main(string[] args)
        {
                /*  using (var context = new NomadContext())
                  {
                /*     Publisher nomad = new Publisher
                     {
                         Name = "Nomad.com",
                         PhoneNumber = "+19362182702"
                     };
                     context.Publishers.Add(nomad);

                context.TimeSubscriptions.Add(new TimeSubscription { CountMonths = 12 });
                context.TimeSubscriptions.Add(new TimeSubscription { CountMonths = 24 });
                context.TimeSubscriptions.Add(new TimeSubscription { CountMonths = 36 });
                context.SaveChanges();

                      var resultTime = context.TimeSubscriptions.ToList();
                      var resultMAgazine = context.Magazines.ToList();

                      var res = context.Magazines.ToList();
                      for(int i = 0; i < res.Count;i++)
                      {
                          context.Subscriptions.Add(new Subscription { TimeSubscriptionId = resultTime[i].Id, Price = 7000 + (i * 6000), MagazineId = resultMAgazine[i].Id });
                      }
                     // var p = context.Publishers.ToList();

                     // context.Users.Add(new User { Login = "den", Password = "123", Address = "ул. Пушкина д.12 кв.43", PhoneNumber = "+77711651230",
                       //   PublisherId = p[0].Id, SubscriptionId = null, StateDeliveryLastMagazine = null, StateSubscription = false });


                      context.SaveChanges();
                      var result = context.Users.ToList();
                  }*/
        /*    using (var context = new NomadContext())
            {
                Publisher nomad = new Publisher
                {
                    Name = "Nomad.com",
                    PhoneNumber = "+19362182702"
                };
            context.Publishers.Add(nomad);
                context.SaveChanges();
            }
            */
            int defaultNumber = 0;
            using (var context = new NomadContext())
            {

                var res = context.Users.ToList();
            }


            while (true)
            {
                Console.Clear();
                Console.WriteLine("1) Войти");
                Console.WriteLine("2) Регестрация");
                int choice = int.Parse(Console.ReadLine());
                while (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Login: ");
                    string login = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();
                    bool ifRight = false;
                    using (var context = new NomadContext())
                    {

                        var infoUsers = context.Users.ToList();
                        for (int i = 0; i < infoUsers.Count; i++)
                        {
                            if (infoUsers[i].Login == login && infoUsers[i].Password == password)
                            {
                                ifRight = true;
                            }
                        }

                        if (ifRight)
                        {
                            var infoUser = context.Users.Where(name => name.Login == login).ToList();

                            Console.Clear();
                            Console.WriteLine("Добро пожаловать " + login + " в Nomad.com!");
                            Console.ReadLine();
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("1) Оформить подписку");
                                Console.WriteLine("2) Прекратить подписку");
                                int choiceInNomad = int.Parse(Console.ReadLine());
                                if (choiceInNomad == 1)
                                {
                                    if (infoUser[defaultNumber].StateSubscription == true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Подписка уже есть!");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Выберите время подписки: ");
                                        var infoTimeSubscription = context.TimeSubscriptions.ToList();

                                        for (int i = 0; i < infoTimeSubscription.Count; i++)
                                        {
                                            Console.WriteLine(i + 1 + ") " + infoTimeSubscription[i].CountMonths + " месяцев");
                                        }
                                        int choiceCountMonths = int.Parse(Console.ReadLine());

                                        var infoSubscriptions = context.Subscriptions.ToList();
                                        Console.Clear();
                                        for (int i = 0; i < infoTimeSubscription.Count; i++)
                                        {
                                            if (i + 1 == choiceCountMonths)
                                            {
                                                for (int j = 0; j < infoSubscriptions.Count; j++)
                                                {
                                                    if (infoSubscriptions[j].TimeSubscriptionId == infoTimeSubscription[i].Id)
                                                    {
                                                        Console.WriteLine("С вас " + infoSubscriptions[j].Price + " тг(Нажмите Enter для оплаты)");
                                                        Console.ReadLine();
                                                        infoUser[0].SubscriptionId = infoSubscriptions[j].Id;
                                                        infoUser[i].StateSubscription = true;
                                                        infoUser[0].StateDeliveryLastMagazine = false;
                                                        context.SaveChanges();

                                                    }
                                                }


                                            }
                                        }
                                        Console.Clear();
                                        Console.WriteLine("Подписка оформлена!");
                                        Console.ReadLine();
                                    }
                                }
                                else if (choiceInNomad == 2)
                                {
                                    Console.WriteLine("Ваша текущая подписка:");
                                    var infoSubscriptions = context.Subscriptions.Where(id => id.Id == infoUser[defaultNumber].SubscriptionId).ToList();
                                    var infoTimeSubscription = context.TimeSubscriptions.Where(id => id.Id == infoSubscriptions[defaultNumber].TimeSubscriptionId).ToList();
                                    Console.WriteLine("Кол-во месяцев: " + infoTimeSubscription[defaultNumber].CountMonths);
                                    Console.WriteLine("Цена: " + infoSubscriptions[defaultNumber].Price);
                                    Console.WriteLine("Прекратить подписку?");
                                    Console.WriteLine("1) Да");
                                    Console.WriteLine("2) Нет");
                                    int yesOrNo = int.Parse(Console.ReadLine());
                                    if (yesOrNo == 1)
                                    {
                                        infoUser[defaultNumber].StateSubscription = false;
                                        infoUser[defaultNumber].SubscriptionId = null;
                                        infoUser[defaultNumber].StateDeliveryLastMagazine = null;
                                        Console.WriteLine("Подписка прекращена!");
                                    }
                                    else if (yesOrNo == 2)
                                    {
                                        break;
                                    }
                                }

                                Console.WriteLine();
                            }

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Логин или пароль введены не верно!");
                            Console.ReadLine();
                        }
                    }
                }
    while(choice == 2)
                {
                    Console.WriteLine("Введите логин: ");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль: ");
                    string password = Console.ReadLine();
                    Console.WriteLine("Введите номер телефона без +7: ");
                    long phone = long.Parse(Console.ReadLine());
                    string phoneNumber = "+7" + phone.ToString();
                    Console.WriteLine("Введиет адресс: ");
                    string adress = Console.ReadLine();

                    using (var context = new NomadContext())
                    {
                        var publishers = context.Publishers.ToList();
                        context.Users.Add(new User
                        {
                            Login = login,
                            Password = password,
                            Address = adress,
                            PhoneNumber = phoneNumber,
                               PublisherId = publishers.FirstOrDefault().Id,
                            SubscriptionId = null,
                            StateDeliveryLastMagazine = null, StateSubscription = false });
                        context.SaveChanges();
                        }
                   
                    Console.Clear();
                    Console.WriteLine("Вы зарегестрированы!");
                    Console.ReadLine();
                    break;
                }
            }

        }
    }
}
