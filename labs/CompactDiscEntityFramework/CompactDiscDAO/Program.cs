using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompactDiscEntityFramework;
using Microsoft.Practices.Unity;

namespace CompactDiscDAO
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<CompactDiscDao, EFCompactDiscDao>();
            CompactDiscService service = container.Resolve<CompactDiscService>();
            foreach (CompactDisc disc in service.GetCatalog())
            {
                Console.WriteLine(disc.title);
            }
            Console.ReadKey();

            ICompactDiscService txService = new TransactionalCompactDiscService();
            txService.AddToCatalog(new CompactDisc() {artist = "Lionel Richie", title="Hello", price = (decimal?)7.99, tracks = (int?)14});

        }
    }
}
