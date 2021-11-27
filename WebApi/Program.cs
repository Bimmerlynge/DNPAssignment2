using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SQLitePCL;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SetUpAdults();
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        

        private static void SetUpAdults()
        {
            
                FileContext adults = new FileContext();
                IList<Adult> list = adults.Adults;
                foreach (Adult adult in list)
                    using (MyDBContext context = new MyDBContext())
                    {
                        context.Adults.AddAsync(adult);
                        context.SaveChangesAsync();
                    }


                Console.WriteLine("Loaded in adults");
        }
    }
}