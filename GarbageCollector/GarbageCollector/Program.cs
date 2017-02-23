using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"MaxGeneration: {GC.MaxGeneration}");
            Console.WriteLine($"IsServerGC: {GCSettings.IsServerGC}");
            Console.WriteLine($"IsServerGC: {GCSettings.LatencyMode}");

            GCSettings.LatencyMode = GCLatencyMode.Batch;

            // Создание объекта Timer, вызывающего метод TimerCallback
            // каждые 2000 миллисекунд
            Timer t = new Timer(TimerCallback, null, 0, 100);
            // Ждем, когда пользователь нажмет Enter
            Console.ReadLine();

            // Создаем ссылку на переменную t после ReadLine
            // (t не удаляется уборщиком мусора
            // до возвращения управления методом Dispose)
            //t.Dispose();
        }
        private static void TimerCallback(Object o)
        {
            var startDate = DateTime.Now;

            // Вывод даты/времени вызова этого метода
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            // Принудительный вызов уборщика мусора в этой программе
            GC.Collect();

            var endDate = DateTime.Now;
            var totalTime = (endDate - startDate).Milliseconds;
            if (totalTime > 0) Console.WriteLine($"TotalTime = {totalTime}");
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


    }
}
