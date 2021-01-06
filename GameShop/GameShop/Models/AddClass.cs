using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class AddClass
    {
        public static void Initialize(ShopGamesDBContext context)
        {
            if (context.Developer.Any())
            {
                return;
            }
            context.Developer.AddRange(
                new Developer
                {
                    IdDeveloper = 1,
                    NameOfDeveloper = "CDPR",
                    LinkToTheWebSite = "https://en.cdprojektred.com/"
                },
                new Developer
                {
                    IdDeveloper = 2,
                    NameOfDeveloper = "DICE",
                    LinkToTheWebSite = "https://www.dice.se/"
                },
                new Developer
                {
                    IdDeveloper = 3,
                    NameOfDeveloper = "Ubisoft",
                    LinkToTheWebSite = "https://www.ubisoft.com/ru-ru/"
                },
                new Developer
                {
                    IdDeveloper = 4,
                    NameOfDeveloper = "Blizzard Entetainment",
                    LinkToTheWebSite = "https://www.blizzard.com/ru-ru/"
                }
                );
            context.SaveChanges();
        }
    }
}
