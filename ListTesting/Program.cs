using System;
using System.Collections.Generic;

namespace ListTesting
{
    public interface IPriority
    {
        int priority { get; set; }
    }
    struct Proberty:IPriority
    {
        public Proberty(string v1, int v2) : this()
        {
            this.name = v1;
            this.priority = v2;
        }

        public string name { get; set; }
        public int priority { get; set; }

        public override string ToString()
        {
            return  priority.ToString() + ':' + name;
        }
    }

    public class PriorityComparer<T>:IComparer<T> where T:IPriority
    {
        public int Compare(T a,T b)
        {
            if (a.priority > b.priority)
                return 1;
            else
                return -1;
        }
       public void SearchAndInsert(List<T> list,
       T insert)
        {
            Console.WriteLine("\nBinarySearch and Insert \"{0}\":", insert);

            int index = list.BinarySearch(insert, this);

            if (index < 0)
            {
                list.Insert(~index, insert);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Proberty> proberties;
            PriorityComparer<Proberty> priorityComparer = new PriorityComparer<Proberty>();
            proberties = new List<Proberty>();
            Proberty proberty1 = new Proberty("Normal",1);
            priorityComparer.SearchAndInsert(proberties, proberty1);
            Proberty proberty2 = new Proberty("Normalize", 1);
            priorityComparer.SearchAndInsert(proberties, proberty2);
            Proberty proberty4 = new Proberty("special", 2);
            priorityComparer.SearchAndInsert(proberties, proberty4);
            Proberty proberty3 = new Proberty("Normalize2", 1);
            priorityComparer.SearchAndInsert(proberties, proberty3);
            Proberty proberty5 = new Proberty("special2", 2);
            priorityComparer.SearchAndInsert(proberties, proberty5);
            foreach (Proberty proberty in proberties)
            {
                Console.WriteLine(proberty.ToString());
            }
        }
       
    }
}
