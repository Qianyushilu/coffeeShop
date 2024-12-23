using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X2402邹君诚_若雪咖啡
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //界面
            Console.WriteLine("--------------------------------");
            Console.WriteLine("-                              -");
            Console.WriteLine("-        模拟自动售货机        -");
            Console.WriteLine("-            若雪咖啡          -");
            Console.WriteLine("-        NO1 2024.11.02        -");
            Console.WriteLine("-                              -");
            Console.WriteLine("--------------------------------");

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

            //功能实现

            //.1 定义变量
            int choise = 0;                         //选择
            string[] Names = { "美式咖啡", "拿铁咖啡", "香草拿铁", "抹茶拿铁","意式浓缩" };             //商品名称
            double[] Prices = { 12.0, 15.5, 16.5, 16.5,10 };                    //商品价格
            string choiseName = " ";
            double choisePrise = 0;
            double amount = 0;//总和
            int num = 0;                                 // 商品数量
            double pay=0, paid=0, change;               //应付、实付、找零

            while (true)
            {
                Console.WriteLine("请输入您的选择：");
                if (!int.TryParse(Console.ReadLine(), out choise) || choise <= 0 || choise > 6)
                {
                    Console.WriteLine("输入错误，请重新输入！");
                    continue;
                }
                else if (choise == 6)
                {
                    break;
                }

                choiseName = Names[choise - 1];
                choisePrise = Prices[choise - 1];
                //.2 输入_个数
                Console.WriteLine($"请问您需要几杯{choiseName}？"); //提示
                if (!int.TryParse(Console.ReadLine(), out num)||num<0) 
                {
                    Console.WriteLine("输入错误，请重新输入！");
                }          //输入
                //.3 计算应付
                pay = num * choisePrise;
                amount += pay;
            }
            //.4 输入实付
            Console.WriteLine($"应付金额为{amount},请问您实付金额多少？");  //提示
            if (!double.TryParse(Console.ReadLine(), out paid)) ;
            change = paid - amount;
            if (change < 0)
            {
                Console.WriteLine($"您付的钱还不够，您还需付{0-change}");
            }
            //输入  
            //.5 计算找零

            //.6 输出结果
            Console.WriteLine($"您一共点了{num}杯{choiseName}。\n账单为：\n应付 {amount}元\n实付 {paid}元\n找零 {change}元");
            Console.WriteLine("喜欢您来，欢迎下次光临！");

            //暂停页面查看结果
            Console.ReadLine();

        }
    }
}
