using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hw4_27EFImageProject.Data
{
    public class ImageContextFactory : IDesignTimeDbContextFactory<ImageContext>
    {
        public ImageContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}Hw4-27EFImageproject.web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new ImageContext(config.GetConnectionString("ConStr"));
            //throw new NotImplementedException();
        }
    }
}
