using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollector
{
    public sealed class LimitedResource
    {
        // Создаем объект HandleCollector и передаем ему указание перейти к очистке,когда в куче появится два или более объекта LimitedResource
        private static HandleCollector s_hc = new HandleCollector("LimitedResource", 2);
        public LimitedResource()
        {
            // Сообщаем HandleCollector, что в кучу добавлен еще один объект LimitedResource
            s_hc.Add();
            Console.WriteLine("LimitedResource create. Count={0}", s_hc.Count);
        }
        ~LimitedResource()
        {
            // Сообщаем HandleCollector, что один объект LimitedResource удален из кучи
            s_hc.Remove();
            Console.WriteLine("LimitedResource destroy. Count={0}", s_hc.Count);
        }
    }
}
