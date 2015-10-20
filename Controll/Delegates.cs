using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controll
{
   public class Delegates
    {

        public delegate void Xiaowang();//定义委托，小王命令
        private static void MultipleRun(Xiaowang method, int count)
        {
            for (int i = 0; i < count; i++)
            {
                method();
            }
        }
    }


   class Xiaoming //小明
   {
       public void Maichepiao()//小明要干的事
       {
           Console.WriteLine("小明买车票");
       }

       public void ZaiMaichepiao()
       {
           Console.WriteLine("小明又买了一张车票！");
       }
   }
}
