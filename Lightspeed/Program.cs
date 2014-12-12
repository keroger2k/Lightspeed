using System;
using System.Linq;

namespace Lightspeed
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new LightSpeed();
            var y = x.GetItem(41);
            //var a = x.GetItems();
            //var z = x.GetAllCategories();
            
            //var b = x.GetItemImage(99);

            //foreach (var item in a)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //Console.WriteLine("Total Items: {0}", a.Count);
            Console.ReadLine();
        }
    }
}
