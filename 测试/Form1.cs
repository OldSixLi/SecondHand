using System;
using System.Windows.Forms;
using 测试.Properties;
namespace 测试
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        #region 关于继承的例子
        /// <summary>
        /// 关于继承的例子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var b = new B();
            b.Minus(9, 4);
            var ask = new A();
            ask.Cheng();
        }
        public void Sum(int i, int j)
        {
            int sum = i + j;
            MessageBox.Show("我是本来的Sum方法：" + sum.ToString());
        }
        //sealed  class A//TODO sealed  是密封修饰符，可以使类不被继承
        #region 被继承的类
        class A
        {
            private void Sum(int i, int j) // 当更改为private时，方法不可以被类以外的类使用
            {
                int sum = i + j + 100;
                MessageBox.Show("我是A类中的方法Sum，比原来的相加值+100：" + sum.ToString());
            }
            //  引用同一类之内的私有方法，可以被其他类使用
            public void Cheng()
            {
                Sum(4, 4);
            }
        }
        #endregion
        #region 继承A类
        class B : A
        {
            public void Minus(int i, int j)
            {
                int minus = i * j;
                MessageBox.Show("我是A类中的方法，两数相乘："+ minus.ToString());
                //继承A的方法，同时可以少写代码
                Cheng();
            }
            public new void ChengBenDi()
            {
                MessageBox.Show(Resources.B_ChengBenDI_3);
            }
        }

        #endregion
        #endregion

        #region 关于接口的例子
        /// <summary>
        /// 接口
        /// </summary>
        public interface IBankAccount
        {
            void One(string s);
            void Two();
            bool Three();

        }
        /// <summary>
        /// 接口实现
        /// </summary>
        class JieKouShiXIan : IBankAccount
        {
            public void One(string s)
            {
                MessageBox.Show(@"实现接口方法类中的第一个方法：One" + s);
            }

            public void Two()
            {
                MessageBox.Show(@"实现接口方法类中的第二个方法：Two");
            }

            public bool Three()
            {
                IBankAccount ib = new JieKouShiXIan();
                ib.One("第三个方法");
                return true;
            }
        }

        /// <summary>
        /// 直接引用接口，实现功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            IBankAccount ibank = new JieKouShiXIan();
            ibank.One("直接使用接口");
            ibank.Three();
        }
        #endregion

        #region 关于多态的例子
        public void MessageUser(string mess)
        {
            MessageBox.Show(@"只传入了一个参数" + mess);
        }

        public void MessageUser(string mess, DateTime dt)
        {
            MessageBox.Show(@"传入两个参数" + mess + @"当前时间是" + dt.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageUser(txtMess.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageUser(txtMess.Text, DateTime.Now);
        }
        #endregion

        #region 关于虚方法例子

        #region 被引用，在其他类继承时，需要对参数进行重写进行赋值
        class Xufangfalei
        {
            protected int width, height;
            public Xufangfalei(int a = 0, int b = 0)
            {
                width = a;
                height = b;
            }
            /// <summary>
            /// 只有在方法是虚方法时才可以进行重写
            /// </summary>
            /// <returns></returns>
            public virtual int Area()
            {
                MessageBox.Show("我是虚方法：");
                return 0;
            }
        }
        #endregion
        #region 第一个方法，不使用Base对Width进行赋值
        class FirstOverride : Xufangfalei  //继承类
        {
            public FirstOverride(int a = 0, int b = 0)
            //此处不对原Xufangfalei中的width进行赋值，所以后期方法中width一直是0
            {

            }
            public override int Area() //重写
            {
                MessageBox.Show("第一次重写：");
                return (width * height);
            }
        }
        #endregion
        #region 第二个方法，对Xufangfalei进行赋值，width不为0
        class Secondoverride : Xufangfalei
        {
            //此处对原Xufangfalei方法中的width进行赋值，后期可以取到width
            public Secondoverride(int a = 0, int b = 0)
                : base(a, b)
            {

            }
            public override int Area()
            {
                MessageBox.Show("第二次重写：");
                return (width * height / 2);
            }
        }
        #endregion
        #region 重新编写的类，对以上进行引用
        class Caller
        {
            public void CallArea(Xufangfalei sh)//这的 参数是虚方法类Xufangfalei  
            {
                int a = sh.Area();//根据传入的方法的实例化，求出面积
                MessageBox.Show("面积：" + a.ToString());
            }
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            var c = new Caller();
            //实例化第一个方法当做参数
            var r = new FirstOverride(100, 100);
            //实例化第二个方法当做参数
            var t = new Secondoverride(100, 100);
            c.CallArea(r);
            c.CallArea(t);
        }
        #endregion


    }
}
