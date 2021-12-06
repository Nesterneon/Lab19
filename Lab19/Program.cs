using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class ComputerModel
    {
        public int code { get; set; }
        public string brand { get; set; }
        public string processor { get; set; }
        public double processorFrequency { get; set; }
        public int RAM { get; set; }
        public string SSD { get; set; }
        public int videoСardMemory { get; set; }
        public int price { get; set; }
        public int number { get; set; }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            List<ComputerModel> ListComputerModel = new List<ComputerModel>()
            {
                new ComputerModel() { code = 111, brand = "Acer Aspire TC", processor = "Intel Core i5 10400F", processorFrequency = 2.9, RAM = 8, SSD = "512ГБ", videoСardMemory = 4, price = 65000, number = 35 },
                new ComputerModel() { code = 222, brand = "MSI MAG Infinite", processor = "Intel Core i5 11400F", processorFrequency = 2.6, RAM = 16, SSD = "512ГБ", videoСardMemory = 12, price=130000, number=4},
                new ComputerModel() { code = 333, brand = "Acer Aspire XC-330", processor = "AMD A4 9120e", processorFrequency = 1.5, RAM = 4, SSD = "500ГБ", videoСardMemory = 1, price=17000, number=10},
                new ComputerModel() { code = 444, brand = "Apple W 8core", processor = "Intel Xeon W", processorFrequency = 3.5, RAM = 768, SSD = "2ТБ", videoСardMemory = 16, price=1665000, number=1},
                new ComputerModel() { code = 555, brand = "HP Pavilion Gaming", processor = "Intel Core i5 11400F", processorFrequency = 2.6, RAM = 16, SSD = "512ГБ", videoСardMemory = 4, price=84000, number=5},
                new ComputerModel() { code = 666, brand = "HyperPC Lite", processor = "Intel Core i5 11400F", processorFrequency = 2.6, RAM = 16, SSD = "1ТБ", videoСardMemory = 6, price=155000, number=3},
            };

            //// список, отсортированный по увеличению стоимости
            var result = ListComputerModel.OrderBy(t => t.price);

            foreach (ComputerModel d in result)
                Console.WriteLine($"{d.code} {d.brand},{d.processor},{d.price}");
            Console.ReadKey();

            //// самый дорогой и самый бюджетный компьютер
            int max = ListComputerModel.Max(d => d.price);
            int min = ListComputerModel.Min(d => d.price);
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.ReadKey();

            //// список, сгруппированный по типу процессора
            var groupprocessor = from listComputerModel in ListComputerModel
                                 group listComputerModel by listComputerModel.processor;

            foreach (IGrouping<string, ComputerModel> g in groupprocessor)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.brand);
                Console.WriteLine();
            }
            Console.ReadKey();

            //// есть ли хотя бы один компьютер в количестве не менее 30 штук ?
            bool result1 = ListComputerModel.Any(u => u.number > 30); //false
            if (result1)
                Console.WriteLine("Есть компьютеры в количестве не менее 30 штук");
            else
                Console.WriteLine("Нет компьютеров в количестве не менее 30 штук");
            Console.ReadKey();

            // определить все компьютеры с объемом ОЗУ не ниже, чем указано
            Console.WriteLine("Введите значение объема ОЗУ");
            int n = int.Parse(Console.ReadLine());
            List<ComputerModel> computerModels1 = ListComputerModel
                .Where(d => d.RAM > n)
                .ToList();
            foreach (ComputerModel d in computerModels1)
                Console.WriteLine($"{d.code} {d.brand},{d.processor}, {d.processorFrequency},{d.RAM},{d.SSD},{d.videoСardMemory},{d.price},{d.number}");
            Console.ReadKey();

            //// определить все компьютеры с указанным процессором
            Console.WriteLine("Введите название процессора");
            string s = Console.ReadLine();
            List<ComputerModel> computerModels2 = ListComputerModel
                .Where(d => d.processor == s)
                .ToList();
            foreach (ComputerModel d in computerModels2)
                Console.WriteLine($"{d.code} {d.brand},{d.processor}, {d.processorFrequency},{d.RAM},{d.SSD},{d.videoСardMemory},{d.price},{d.number}");
            Console.ReadKey();
        }
    }
}
