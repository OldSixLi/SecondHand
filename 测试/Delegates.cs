using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 测试
{
    public class Delegates
    {
        delegate void RunOnce();

        private static void MultipleRun(RunOnce method, int count)
        {
            for (int i = 0; i < count; i++)
            {
                method();
            }
        }

        //static void Main(string[] args)
        //{
        //    var tc = new TestClass(); 
        //    MultipleRun(tc.PrintDate, 1000);
        //    MultipleRun(tc.PrintTime, 1000);
        //}
    }

    class TestClass
    {
        public void PrintTime() { Console.WriteLine(DateTime.Now.ToString("HH:mm:ss")); }
        public void PrintDate() { Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd")); }
    }
}

