using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NewLife.Hive;
using NewLife.Hive2;
using NewLife.Log;
using NewLife.Serialization;

namespace Test
{
    class Program
    {
        static void Main(String[] args)
        {
            XTrace.UseConsole();

            try
            {
                Test1();
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }

            Console.WriteLine("OK!");
            Console.ReadKey();
        }

        static void Test1()
        {
            var line = File.ReadLines("account.txt").First();
            var ss = line.Split(",");
            ss = ss.Select(e => e.Trim()).ToArray();

            using (var conn = new HiveConnection(ss[0], ss[1].ToInt(), ss[2], ss[3]))
            {
                var cmd = conn.CreateCommand();
                cmd.Execute("use default");

                var list = cmd.FetchMany(100);
                if (!list.IsEmpty())
                {
                    var dict = list[0] as IDictionary<String, Object>;
                    foreach (var key in dict.Keys)
                    {
                        Console.WriteLine(key + dict[key].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("no result");
                }

                cmd.Execute("select * from kbb");
                var es = cmd.Fetch(100);
                Console.WriteLine(es.ToJson(true));

                var list2 = cmd.FetchMany(100);
                if (!list2.IsEmpty())
                {
                    var dic = list2[0] as IDictionary<String, Object>;
                    foreach (var item in dic)
                    {
                        Console.Write(item.Key + "\t");
                    }
                    Console.WriteLine();

                    foreach (IDictionary<String, Object> row in list2)
                    {
                        foreach (var item in row)
                        {
                            Console.Write(item.Value + "\t");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("no result");
                }

                for (var i = 0; i < 100_000; i++)
                {
                    var sql = $"insert into kbb (id, name) values ({i + 1},'{DateTime.Now.ToFullString()}')";
                    XTrace.WriteLine(sql);
                    cmd.Execute(sql);
                }
            }
        }
    }
}