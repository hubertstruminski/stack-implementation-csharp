using System;

namespace Stack_implementation.src
{
    class Program
    {
        private class Order
        {
            public Order(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return "Id: " + Id + ", Name: " + Name;
            }
        }
        static void Main(string[] args)
        {
            StosWTablicy<string> s = new StosWTablicy<string>(2);
            s.Push("km");
            s.Push("aa");
            s.Push("xx");
            foreach (var x in s.ToArray())
            {
                Console.WriteLine(x);
            }

            foreach(var x in s.ToArrayReadOnly())
            {
                Console.WriteLine(x);
            }

            Order order1 = new Order(1, "Pizza");
            Order order2 = new Order(2, "Wine");

            StosWTablicy<Order> s2 = new StosWTablicy<Order>(2);
            s2.Push(order1);
            s2.Push(order2);

            foreach(var x in s2.ToArrayReadOnly())
            {
                x.Name = "Water x2";
                Console.WriteLine(x.ToString());
            }

            Console.WriteLine();


        }
    }
}
