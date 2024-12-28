using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace X2402邹君诚_若雪咖啡
{
    class Product  //定义结构体，产品
    {
        public string Name;
        public double Price;
        public Product(string name, double price) //构造函数初始化商品名称和价格
        {
            Name = name;
            Price = price;
        }
    }
    class OrderItem  //定义类，点单项目
    {
        public string ChoiceName;    //选择名称
        public int Quantity;         //数量
        public double TotalPrice;    //小计
        public OrderItem(string name, int quantity, double totalPrice)
        {
            ChoiceName = name;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //界面
            DisplayWelcomeScreen();  //使用方法输出界面

            //功能实现

 
            Product[] menu = new Product[]    //定义商品数组
            { 
                new Product("美式咖啡",12.0),
                new Product("拿铁咖啡",15.5), 
                new Product("香草拿铁",16.5),
                new Product("抹茶拿铁",16.5),
                new Product("意式浓缩",10.0)
            };
             //定义变量
            int choice = 0;           //选择           
            Hashtable orders = new Hashtable();  //哈希表，存储订单信息
            double amount = 0;           //总计
            int quantity = 0;                //数量
            double paid = 0;            //用户支付金额
            double change=0;          //找零金额
            

            while (true)   //通过循环重复点单
            {
                DisplayMenu();  //输出菜单
                Console.WriteLine("请输入您的选择：");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice <= 0 || choice > 6)
                {
                    Console.WriteLine("输入错误，请重新输入：");
                    continue;
                }
                if (choice == 6)
                {
                    break;
                }

                string choiceName = menu[choice - 1].Name;    //局部变量，当前循环所点商品名称
                double choicePrice = menu[choice - 1].Price;  //局部变量，当前循环所点商品单价
                Console.WriteLine($"请问您需要几杯{choiceName}？"); 
                if (!int.TryParse(Console.ReadLine(), out quantity)||quantity<0) 
                {
                    Console.WriteLine("输入错误，请重新输入：");
                    continue;
                }      
                double pay = quantity * choicePrice;              //局部变量，当前循环小计金额
                amount += pay;

                if (orders.ContainsKey(choiceName))          //选择结构，记录订单信息
                {
                    var order = (OrderItem)orders[choiceName]; //查找是否存在指定键，如果有，更新信息
                    order.Quantity += quantity;
                    order.TotalPrice += pay;
                }
                else                                         //没有，新增记录
                {
                    orders.Add(choiceName,new OrderItem(choiceName,quantity,pay));
                }
                
                Console.WriteLine($"此次您点了{quantity}杯{choiceName},小计{pay}元");
            }

            Console.WriteLine($"应付金额{amount}元，请支付：");
            paid=GetValidated();
            while ((change = paid - amount) < 0)
            {
                Console.WriteLine($"支付失败，您需要支付{amount}元");
                Console.WriteLine("请支付：");
                paid = GetValidated();
            }

            Console.WriteLine("您点的商品如下：");
            foreach (OrderItem order in orders.Values)       //历遍哈希表输出订单信息
            {
                Console.WriteLine($"{order.Quantity}杯{order.ChoiceName}----共{order.TotalPrice}元");
            }
            Console.WriteLine($"账单为：\n应付 {amount}元\n实付 {paid}元\n找零 {change}元");
            Console.WriteLine("喜欢您来，欢迎下次光临！");

            //暂停页面查看结果
            Console.ReadLine();

        }
        static void DisplayWelcomeScreen()      //方法，输出欢迎界面
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("-                                -");
            Console.WriteLine("-        模拟自动售货机          -");
            Console.WriteLine("-            若雪咖啡            -");
            Console.WriteLine("-        NO.5 2024-12-26         -");
            Console.WriteLine("-                                -");
            Console.WriteLine("----------------------------------");
        }
        static void DisplayMenu()               //方法，输出菜单
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
        static double GetValidated()              //方法，获取并校验浮点型数据
        {
            double value;
            while (true) 
            { 
                if (double.TryParse(Console.ReadLine(),out value)&&value>=0)
                {
                    return value;

                }
                else
                {
                    Console.WriteLine("输入错误，请重新输入：");
                }
            }
        }
    }
}
