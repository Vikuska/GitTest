using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollector
{
    public sealed class BigNativeResource
    {
        private Int32 m_size;
        public BigNativeResource(Int32 size)
        {
            m_size = size;
            // Пусть уборщик думает, что объект занимает больше памяти
            if (m_size > 0) GC.AddMemoryPressure(m_size);
            Console.WriteLine("BigNativeResource create.");
        }
        ~BigNativeResource()
        {
            // Пусть уборщик думает, что объект освободил больше памяти
            if (m_size > 0) GC.RemoveMemoryPressure(m_size);
            Console.WriteLine("BigNativeResource destroy.");
        }
    }
}
