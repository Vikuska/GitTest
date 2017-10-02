using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////////DEMO1
            //Console.WriteLine($"MaxGeneration: {GC.MaxGeneration}"); //максимальное поколение, поддерживаемое управляемой кучей
            //Console.WriteLine($"IsServerGC: {GCSettings.IsServerGC}");
            //Console.WriteLine($"IsServerGC: {GCSettings.LatencyMode}");
            //GCSettings.LatencyMode = GCLatencyMode.Batch;

            //GC.RegisterForFullGCNotification(1,50);
            //GC.GetTotalMemory(true);

            //// Создание объекта Timer, вызывающего метод TimerCallback каждые 2000 миллисекунд
            //Timer t = new Timer(TimerCallback, null, 0, 2000);
            //// Ждем, когда пользователь нажмет Enter
            //Console.ReadLine();

            //// Создаем ссылку на переменную t после ReadLine (t не удаляется уборщиком мусора до возвращения управления методом Dispose)
            ////t.Dispose();


            ///////////////DEMO2
            MemoryPressureDemo(0); // 0 вызывает нечастую уборку мусора
            MemoryPressureDemo(10 * 1024 * 1024); // 10 Mбайт вызывают частую
                                                  // уборку мусора
            HandleCollectorDemo();

            Console.ReadLine();
        }

        private static void TimerCallback(Object o)
        {
            var startDate = DateTime.Now;

            // Вывод даты/времени вызова этого метода
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            // Принудительный вызов уборщика мусора в этой программе
            GC.Collect(1, GCCollectionMode.Default, false);

            var endDate = DateTime.Now;
            var totalTime = (endDate - startDate).Milliseconds;
            if (totalTime > 0) Console.WriteLine($"TotalTime = {totalTime}");


            Console.WriteLine($"GC.CollectionCount(0): {GC.CollectionCount(0)}");
            Console.WriteLine($"GC.CollectionCount(1): {GC.CollectionCount(1)}");
            Console.WriteLine($"GC.CollectionCount(2): {GC.CollectionCount(2)}");
        }

        private static void LowLatencyDemo()
        {
            GCLatencyMode oldMode = GCSettings.LatencyMode;

            System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                GCSettings.LatencyMode = GCLatencyMode.LowLatency;
                // Здесь выполняется код
            }
            finally
            {
                GCSettings.LatencyMode = oldMode;
            }
        }



        ///////// использование и результат работы методов сжатия памяти и класса HandleCollector
        private static void MemoryPressureDemo(Int32 size)
        {
            Console.WriteLine();
            Console.WriteLine("MemoryPressureDemo, size={0}", size);
            // Создание набора объектов с указанием их логического размера
            for (Int32 count = 0; count < 15; count++)
            {
                new BigNativeResource(size);
            }
            // В демонстрационных целях очищаем все
            GC.Collect();
        }

        private static void HandleCollectorDemo()
        {
            Console.WriteLine();
            Console.WriteLine("HandleCollectorDemo");
            for (Int32 count = 0; count < 10; count++) new LimitedResource();
            // В демонстрационных целях очищаем все
            GC.Collect();
        }
    }
}
