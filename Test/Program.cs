using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NewLife;
using NewLife.Hive;
using NewLife.Log;

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

                cmd.Execute("select * from kbb");
                var dt = cmd.Fetch(100);
                if (dt != null)
                {
                    foreach (var item in dt.Columns)
                    {
                        Console.Write(item + ",");
                    }
                    Console.WriteLine();

                    foreach (var row in dt.Rows)
                    {
                        Console.WriteLine(row.Join(","));
                    }
                }

                for (var i = 0; i < 100_000; i++)
                {
                    var sql = $"insert into kbb (id, name) values ({i + 1},'{DateTime.Now.ToFullString()}')";
                    var sb = new StringBuilder();
                    sb.Append(sql);
                    for (var k = 0; k < 10; k++)
                    {
                        sb.Append(",");
                        sb.Append($"({i + 1},'{DateTime.Now.ToFullString()}')");
                    }
                    sql = sb.ToString();

                    XTrace.WriteLine(sql);
                    cmd.Execute(sql);
                }
            }
        }
    }
}