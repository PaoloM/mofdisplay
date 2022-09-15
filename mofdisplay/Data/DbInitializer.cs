using mofdisplay.Models;

namespace mofdisplay.Data
{
    public static class DbInitializer
    {
        public static void Initialize(mofdisplayContext context)
        {
            if (context.Contributors.Any())
            {
                return; // DB has been seeded
            }

            var contributors = new Contributor[]
            {
                new Contributor{Name="Paolo Marcucci", ContributorID=1 },
                new Contributor{Name="Neil Makar", ContributorID=2 }
            };

            context.Contributors.AddRange(contributors);
            context.SaveChanges();

            var displays = new Display[]
            {
                new Display{DisplayID=1, Title="T-6 monograph", StartDate=new DateTime(2022, 8, 1), CuratorID=1},
                new Display{DisplayID=2, Title="Aircrafts of the aces",StartDate=new DateTime(2023, 2, 2), CuratorID=2}
            };

            context.Displays.AddRange(displays);
            context.SaveChanges();

            var kits = new Kit[]
            {
                new Kit {KitID=1, Name="Italian Harvard"}
            };

            context.Kits.AddRange(kits);
            context.SaveChanges();
        }

    }
}
