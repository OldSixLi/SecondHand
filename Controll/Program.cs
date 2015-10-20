using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Controll
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 委托示例
            //委托相当于声明一个命令，这个命令里可以包含很多的事件，比如要求小明买电影票，则在声明后
            //直接调用命令就可以了，如果想要干多个事，就是委托链，利用+=，进行运行。


            //Console.WriteLine("委托示例：");
            //var tc = new Xiaoming();
            //Delegates.Xiaowang xiaowang = tc.Maichepiao;
            //xiaowang += tc.ZaiMaichepiao;
            //xiaowang();//委托
            //Console.ReadLine();
            #endregion


            #region 事件示例
            //Console.WriteLine("事件示例：");
            ////实例化一个出版社
            //Publisher publisher = new Publisher();

            ////给这个出火影忍者的事件注册感兴趣的订阅者，此例中是小明
            //publisher.OnPublish += new Publisher.PublishEventHander(MrMing.Receive);
            ////另一种事件注册方式
            ////publisher.OnPublish += MrMing.Receive;

            ////发布者在这里触发出版火影忍者的事件
            //publisher.issue();

            //Console.ReadKey();
            #endregion


            #region 打印乘法表

            PrintMultiplication print = new PrintMultiplication();
            print.Print();
            Console.ReadLine();

            #endregion

        }
    }


    #region 事件


    //发布者（Publiser)
    public class Publisher
    {
        //声明一个出版的委托
        public delegate void PublishEventHander();
        //在委托的机制下我们建立以个出版事件
        public event PublishEventHander OnPublish;
        //事件必须要在方法里去触发，出版社发布新书方法
        public void issue()
        {
            //如果有人注册了这个事件，也就是这个事件不是空
            if (OnPublish != null)
            {
                Console.WriteLine("最新一期的《火影忍者》今天出版哦！");
                OnPublish();//事件
            }
        }
    }

    //Subscriber 订阅者，无赖小明
    public class MrMing
    {
        //对事件感兴趣的事情，这里指对出版社的书感兴趣
        public static void Receive()
        {
            Console.WriteLine("嘎嘎，我已经收到最新一期的《火影忍者》啦！！");
        }
    }

    //Subscriber 订阅者，悲情人物小张
    public class MrZhang
    {
        //对事件感兴趣的事情
        public static void Receive()
        {
            Console.WriteLine("幼稚，这么大了，还看《火影忍者》，SB小明！");
        }
    }
    #endregion


    #region 口诀

    public class PrintMultiplication
    {
        public void Print()
        {
            Console.Write(" *|");

            for (int i = 1; i < 10; i++)
            {
                Console.Write("  " + i);
            }
            Console.Write("\n");
            Console.Write("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _\n");
            for (int i = 1; i < 10; i++)
            {
                string s = "";
                s += i + " |";
                for (int j = 1; j <= i; j++)
                {

                    int ji = i * j;
                    string geshu = "  " + ji.ToString();
                    //string geshu = j.ToString() + "*" + i.ToString() + "="+ji.ToString()+"  ";
                    s += geshu;


                }

                Console.WriteLine(s);
            }

        }
    }


    #endregion
}


