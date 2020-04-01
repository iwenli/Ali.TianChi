using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Ali.TianChi.Competition
{
    /// <summary>
    /// https://tianchi.aliyun.com/competition/entrance/231759/information
    /// </summary>
    class Docker
    {
        /*
            任务描述
            参与者可分阶段提交容器镜像完成以下3个任务（分数依次占 30/30/40），根据评分系统的分数返回验证任务的完成情况。

            输出Hello world
            计算 /tcdata/num_list.csv中一列数字的总和。
            在/tcdata/num_list.csv文件中寻找最大的10个数，从大到小生成一个ListList.
            num_list.csv文件中只有一列不为负的整数，其中存在重复值，示例如下：

            102
            6
            11
            11

            生成入口脚本run.sh，放置于镜像工作目录。运行后生成结果result.json放置于工作目录（与run.sh同目录），评分系统将根据result.json进行打分。json文件如下所示：

            {  
                "Q1":"Hello world", 
                "Q2":sum值, 
                "Q3":[top10_list]
            }
        */

        public static void Run()
        {
            var currnetPath = Environment.CurrentDirectory;
            var dataFileFullPath = Path.Combine(currnetPath, "tcdata", "num_list.csv");
            var resultJsonFullPath = Path.Combine(currnetPath, "result.json");

            if (!File.Exists(dataFileFullPath))
            {
                Console.WriteLine($"not exists file:{dataFileFullPath}");
                return;
            }
            
            var list = File.ReadAllLines(dataFileFullPath).Select(m => Convert.ToInt32(m));
            //var list = Enumerable.Range(1, 1000).Where(m => m % 3 == 0);
            var max = list.Max();
            var top10 = list.OrderByDescending(m => m).Take(10);
            var obj = new
            {
                Q1 = "Hello world",
                Q2 = max,
                Q3 = top10
            };


            var result = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            // Console.WriteLine($"run success.{Environment.NewLine}{result}");
            File.WriteAllText(resultJsonFullPath, result, Encoding.UTF8);
        }
    }
}
