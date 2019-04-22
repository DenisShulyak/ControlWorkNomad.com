namespace Nomad.comApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NomadContext : DbContext
    {
        // Контекст настроен для использования строки подключения "NomadContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Nomad.comApp.NomadContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "NomadContext" 
        // в файле конфигурации приложения.
        public NomadContext()
            : base("name=NomadContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<TimeSubscription> TimeSubscriptions { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}