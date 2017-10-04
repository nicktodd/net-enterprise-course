using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace BasicUnityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<Vehicle, Car>();
            Person p = container.Resolve<Person>();
            p.Vehicle.Move();

            

            
        }
    }

    public interface Vehicle
    {
        void Move();
    }
    public class Car : Vehicle
    {
        public void Move()
        {
            Console.WriteLine("Move car");
        }
    }

    public class Plane : Vehicle
    {
        public void Move()
        {
            Console.WriteLine("Move plane");
        }
    }

    public class Person
    {
        [Dependency]
        public Vehicle Vehicle { get; set; }
    }


}
