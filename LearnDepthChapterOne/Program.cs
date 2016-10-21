﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnDepthChapterOne
{
    class Program
    {
        static void Main(string[] args)
        {
            // decimal类型是一个128位的数据类型
            decimal da1 = 34287786090351m;
            int i = 10;
            decimal abc = da1 + i;

            ClassCSharpVersion1 P1 = new ClassCSharpVersion1("P3",100);

            // 岔开一句，静态类型是类中与其属性无关的方法都可以被声明成静态方法;
            // 静态方法与实例化方法的执行效率其实并没有太大差别;
            ClassCSharpVersion1.print();

            //实例化4个版本C#的类;
            ArrayList list = ClassCSharpVersion1.GetSample();
            List<ClassCSharpVersion2> list2 = ClassCSharpVersion2.GetSample();
            List<ClassCSharpVersion3> list3 = ClassCSharpVersion3.GetSample();
            List<ClassCSharpVersion4> list4 = ClassCSharpVersion4.GetSample();

            // C#1调用实现ICompare接口的排序类
            Console.WriteLine("----以下是C#1的排序结果----");
            list.Sort(new ClassSortCSharpVer1());
            foreach(ClassCSharpVersion1 listsort in list)
            {
                Console.WriteLine(listsort.ToString());
            }
            Console.WriteLine("----C#1的排序结束----");

            Console.WriteLine("----以下是C#2的排序结果----");
            list4.Sort(new ClassSort());
            foreach(ClassCSharpVersion4 listsort in list4)
            {
                
                Console.WriteLine(listsort.ToString());

            }
            Console.WriteLine("----C#2的排序结束----");

            // 这个也是一个C#2特性的写法，使用委托（匿名方法）将CompareTo这样的方法直接返回
            list2.Sort(
                delegate (ClassCSharpVersion2 x, ClassCSharpVersion2 y)
                {
                    return x.Name.CompareTo(y.Name);
                }
            );

            // 以下这两个是利用了Lambda表达式中使用compare
            list3.Sort((x, y) => x.Name.CompareTo(y.Name));
            // 此处不打印了;

            // 更加简洁的Lambda表达式的使用
            foreach (ClassCSharpVersion3 listsort in list3.OrderBy(p => p.Name))
            {
                Console.WriteLine(listsort);
            }

            // 以下是查询代码;
            // 通过循环遍历，查询出来价格大于10的产品
            foreach(ClassCSharpVersion1 listselect in list)
            {
                if(listselect.Price >= 300)
                {
                    Console.WriteLine("C#Version1中价格大于300的产品有："+listselect.ToString());
                }
            }

            // 实现了一个委托，这个委托入参为ClassCSharpVersion2,并且返回值为Predicate<ClassCSharpVersion2>
            Predicate<ClassCSharpVersion2> test = delegate (ClassCSharpVersion2 p) { return p.Price > 100; };
            // FindAll的签名为：FindAll(Predicate<T>),所以在上边要实现一个委托;
            List<ClassCSharpVersion2> match = list2.FindAll(test);

            // print变量也是一个委托;
            Action<ClassCSharpVersion2> print = Console.WriteLine;
            match.ForEach(print);

            // ClassCSharpVersion重载ToString尝试下打印
            string A = list[2].ToString();
            string B = list2[1].ToString();

            Console.WriteLine(A);
            Console.WriteLine(B);

            Console.Read();
            return;
        }
    }

}
