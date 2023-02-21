using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Comp> comps = new List<Comp>()
            {
                new Comp(){ Cod=1,Brand="AMD", TypeCPU="Duron", CPUfsb=1.2, VRam=1, VHHD=1, VGraphicscard=1, Price=12.50, Summa=1},
                new Comp(){ Cod=2,Brand="Intel", TypeCPU="Celeron D", CPUfsb=1, VRam=1, VHHD=1, VGraphicscard=1, Price=11.50, Summa=0},
                new Comp(){ Cod=3,Brand="AMD", TypeCPU="Atlon 64", CPUfsb=3.2, VRam=2, VHHD=1, VGraphicscard=2, Price=12.50, Summa=4},
                new Comp(){ Cod=4,Brand="Intel", TypeCPU="Pentium", CPUfsb=2.5, VRam=2, VHHD=3, VGraphicscard=2, Price=22.50, Summa=23},
                new Comp(){ Cod=5,Brand="Apple", TypeCPU="A6X", CPUfsb=1.4, VRam=4, VHHD=3, VGraphicscard=3, Price=32.50, Summa=3},
                new Comp(){ Cod=6,Brand="Intel", TypeCPU="Pentium", CPUfsb=4, VRam=4, VHHD=5, VGraphicscard=4, Price=45.50, Summa=10},
                new Comp(){ Cod=7,Brand="AMD", TypeCPU="Ryzen 7 3700X", CPUfsb=5.9, VRam=6, VHHD=6, VGraphicscard=6, Price=43.50, Summa=25},
                new Comp(){ Cod=8,Brand="Apple", TypeCPU="M2", CPUfsb=2.133, VRam=6, VHHD=6, VGraphicscard=6, Price=55.50, Summa=150},
            };
            Console.WriteLine("Определить компьютеры с указанным процессором");
            Console.WriteLine("Введите название фирмы");
            string brand = Console.ReadLine();
            List<Comp> comps1 = comps.Where(x => x.Brand == brand).ToList();
            Print(comps1);

            Console.WriteLine("Определить компьютеры с объемом ОЗУ не ниже, чем указано");
            Console.WriteLine("Введите количество памяти");
            int vram = Convert.ToInt32(Console.ReadLine());
            List<Comp> comps2 = comps.Where(x => x.VRam >= vram).ToList();
            Print(comps2);

            Console.WriteLine("Вывести список, отсортированный по увеличению стоимости");
            List<Comp> comps3 = comps.OrderBy(x => x.Price).ToList();
            Print(comps3);

            Console.WriteLine("Вывести список, сгруппированный по типу процессора");
            IEnumerable<IGrouping<string, Comp>> comps4 = comps.GroupBy(x => x.TypeCPU);
            foreach (IGrouping<string, Comp> gr in comps4)
            {
                Console.WriteLine(gr.Key);
                foreach (Comp e in gr)
                {
                    Console.WriteLine($"{e.Cod} { e.Brand} { e.TypeCPU} { e.CPUfsb} { e.VRam} {e.VGraphicscard} {e.VHHD} {e.Price} {e.Summa}");
                }
            }

            Console.WriteLine("Найти самый дорогой компьютер");
            Comp comps5 = comps.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine($"{comps5.Cod} { comps5.Brand} { comps5.TypeCPU} { comps5.CPUfsb} { comps5.VRam} {comps5.VGraphicscard} {comps5.VHHD} {comps5.Price} {comps5.Summa}");

            Console.WriteLine("Найти самый бюджетный компьютер");
            Comp comps6 = comps.OrderBy(x => x.Price).FirstOrDefault();
            Console.WriteLine($"{comps5.Cod} { comps6.Brand} { comps6.TypeCPU} { comps6.CPUfsb} { comps6.VRam} {comps6.VGraphicscard} {comps6.VHHD} {comps6.Price} {comps6.Summa}");

            Console.WriteLine("Есть ли компьютер в количестве не менее 30 шт");
            Console.WriteLine(comps.Any(x => x.Summa > 30));

            Console.ReadKey();
        }
        static void Print(List<Comp> comps)
        {
            foreach (Comp e in comps)
            {
                Console.WriteLine($"{e.Cod} { e.Brand} { e.TypeCPU} { e.CPUfsb} { e.VRam} {e.VGraphicscard} {e.VHHD} {e.Price} {e.Summa}");
            }
            Console.WriteLine();

        }
    }
}
