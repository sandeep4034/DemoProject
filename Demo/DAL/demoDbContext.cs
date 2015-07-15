namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class demoDbContext : DbContext
    {
        // Your context has been configured to use a 'demoDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.demoDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'demoDbContext' 
        // connection string in the application configuration file.
        public demoDbContext()
            : base("name=demoDbContext")
        {
            employees = new List<EmployeeEntity>();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public List<EmployeeEntity> employees;
    }

     

    public class EmployeeEntity
    {
        public string Name { get; set; }

        public int Id { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}