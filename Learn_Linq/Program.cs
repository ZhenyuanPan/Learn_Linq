using System;
using System.Collections.Generic;
using System.Linq;

namespace Learn_Linq
{
    class Program
    {
        string makeCalsh = "";
        static void Main(string[] args)
        {
            #region linq查询并排序

            //int[] scores = new int[] { 97, 92, 81, 60 };
            ////IEnumerable<int> scoreQuery = from score in scores where score > 80 select score;
            ////降序排列
            ////var scoreQuery = from score in scores where score > 80 orderby score descending select score;
            ////生序排列
            //var scoreQuery = from score in scores where score > 80 orderby score ascending select score;
            //foreach (int item in scoreQuery)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            string[] languages = { "Java", "C#", "Delphi", "VB.net", "C++Builder","Kylix","Perl","Python"};

            //以item的长度进行分组 放到 lengthGroups 这里面
            var query = from item in languages
                        group item by item.Length into lengthGroups
                        //以lengthGroups的键值进行排序 按字符串的长度进行了排序
                        //涉及到协变与逆变
                        orderby lengthGroups.Key
                        select lengthGroups;
            //输出一下看看结果
            foreach (var item in query)
            {
                Console.WriteLine("string of length{0}",item.Key);
                foreach (var str in item)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
