using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {

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
            // Вывод даты/времени вызова этого метода
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            // Принудительный вызов уборщика мусора в этой программе
            GC.Collect();
    }
    }
}
