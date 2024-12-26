using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X2402邹君诚_若雪咖啡
{
    struct Product  //定义结构体，产品
    {
        public string Name;
        public double Price;
        public Product(string name, double price) //构造函数初始化商品名称和价格
        {
            Name = name;
            Price = price;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //界面
            displayWelcomeScreen();  //使用方法输出界面

            //功能实现

 
            Product[] mune = new Product[]    //定义商品数组
            { 
                new Product("美食咖啡",12.0),
                new Product("拿铁咖啡",15.5), 
                new Product("香草拿铁",16.5),
                new Product("抹茶拿铁",16.5),
                new Product("意式浓缩",10.0)
            };
             //定义变量
            int choise = 0;           //选择           
            string choiseName = " ";  //被选择的名称
            double choisePrise = 0;    //被选择商品价格

            double amount = 0;           //总计
            int num = 0;                //数量
            double pay = 0;            //单次价格
            double paid = 0;            //实付
            double change=0;          //找零
            

            while (true)
            {
                displayMenu();  //输出菜单
                Console.WriteLine("请输入您的选择：");
                if (!int.TryParse(Console.ReadLine(), out choise) || choise <= 0 || choise > 6)
                {
                    Console.WriteLine("输入错误，请重新输入：");
                    continue;
                }
                else if (choise == 6)
                {
                    break;
                }

                choiseName = mune[choise - 1].Name;
                choisePrise = mune[choise - 1].Price;
                Console.WriteLine($"请问您需要几杯{choiseName}？"); 
                if (!int.TryParse(Console.ReadLine(), out num)||num<0) 
                {
                    Console.WriteLine("输入错误，请重新输入：");
                }      
                pay = num * choisePrise;
                amount += pay;
            }
            Console.WriteLine($"应付金额为{amount},请问您实付金额多少？");
            while (!double.TryParse(Console.ReadLine(), out paid)||paid<=0)
            {
                Console.WriteLine("输入错误，请重新输入：");
            }
            change = paid - amount;
            while (change < 0)
            {
                double more = 0;
                Console.WriteLine($"您付的钱还不够，您还需付{0-change}");
                Console.WriteLine($"请支付：");
                while (!double.TryParse(Console.ReadLine(), out more) ||more <= 0)
                {
                    Console.WriteLine("输入错误，请重新输入！");
                }
                change += more;
            }
            Console.WriteLine($"您一共点了{num}杯{choiseName}。\n账单为：\n应付 {amount}元\n实付 {paid}元\n找零 {change}元");
            Console.WriteLine("喜欢您来，欢迎下次光临！");

            //暂停页面查看结果
            Console.ReadLine();

        }
        static void displayWelcomeScreen()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-                                -");
            Console.WriteLine("-        模拟自动售货机          -");
            Console.WriteLine("-            若雪咖啡            -");
            Console.WriteLine("-        NO.5 2024-12-26         -");
            Console.WriteLine("-                                -");
            Console.WriteLine("----------------------------------");
        }
        static void displayMenu()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-                                -");
            Console.WriteLine("-            喜欢您来            -");
            Console.WriteLine("-        1-美式咖啡     12.0元   -");
            Console.WriteLine("-        2-拿铁咖啡     15.5元   -");
            Console.WriteLine("-        3-香草拿铁     16.5元   -");
            Console.WriteLine("-        4-抹茶拿铁     16.5元   -");
            Console.WriteLine("-        5-意式浓缩     10.0元   -");
            Console.WriteLine("-        6-退出点餐              -");
            Console.WriteLine("-                                -");
            Console.WriteLine("----------------------------------");
        }
    }
}`
