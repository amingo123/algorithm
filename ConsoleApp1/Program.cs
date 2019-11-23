using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines("1",Encoding.Default);
            }
            catch
            {
                lines = File.ReadAllLines("1.txt", Encoding.Default);
            }
            string name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();
            bool b = int.TryParse(name, out int interval);
            if (!b) interval = 9;

            List<string> list = lines.ToList();

            //while (bb)
            //{
            //    list  = new List<string>();
            //    for (int i = 0; i < lines.Length; i++)
            //    {
            //        int m = i + 1;
            //        if (m % interval == 0)
            //        {
            //            if (lines[i].StartsWith("0") || lines[i].Contains("转") || lines[i].Contains("222"))
            //            {
            //                list.Add(lines[i]);
            //            }
            //            else
            //            {
            //                list.Add("000");
            //                break;
                            
            //            }
            //        }

            //        if (!list.Contains(lines[i]))
            //        {
            //            list.Add(lines[i]);
            //        }
            //    }
            //}

            
            

            StringBuilder sb = new StringBuilder();
            StringBuilder sbr = new StringBuilder();
            StringBuilder sbx = new StringBuilder();
            StringBuilder sbs = new StringBuilder();
            StringBuilder sbx1 = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                //int m = i + 1;
                //if (m % interval == 1 || m % interval == 2 || m % interval == 6)
                //{
                //    sb.AppendLine(list[i]);
                //}

                if (!list[i].Contains("未知") && !list[i].Contains("20") && !list[i].Contains("19") && !list[i].Contains("5") && !list[i].Contains("6") && !list[i].Contains("7") && !list[i].Contains("8") && list[i].Length >= 2 && !list[i].Contains("身份") && !list[i].Contains("成人") && !list[i].Contains("同性") && !list[i].Contains("同订单") && !list[i].Contains("拼房") && !list[i].Contains("护照") && !list[i].Contains("儿"))//姓名
                {
                    sb.AppendLine(list[i]);
                    sbr.AppendLine(list[i]);
                }
                else if (!list[i].Contains("未知") && list[i].Length <=6 && list[i].Length >= 3 && (list[i].Contains("男") || list[i].Contains("成人") || list[i].Contains("女")) || list[i].Contains("儿"))//性别
                {
                    string nannv = list[i].Replace("成人", string.Empty).Replace("\\", string.Empty).Replace("/", string.Empty).Replace("儿童", string.Empty);
                    sb.AppendLine(nannv);
                    sbx.AppendLine(nannv);
                    sb.AppendLine(nannv =="男"?"1":"2");
                    sbx1.AppendLine(nannv == "男" ? "1" : "2");
                }
                else if (!list[i].Contains("未知") && !list[i].StartsWith("+") && list[i].Length <= 18 && list[i].Length >= 8 && !list[i].Contains("身份") && !list[i].Contains("成人") && !list[i].Contains("同性") && !list[i].Contains("同订单") && !list[i].Contains("拼房") && !list[i].Contains("护照") && !list[i].Contains("儿"))//身份证
                {
                    bool a = DateTime.TryParse(list[i].Split(new char[] { '	' })[0], out DateTime x);
                    if (!a)
                    {
                        sb.AppendLine(list[i]);
                        sbs.AppendLine(list[i]);
                        sb.AppendLine("");
                    }
                    //bool a = double.TryParse(list[i], out double x);
                    //if (a)
                    //{

                    //    sb.AppendLine(list[i]);
                    //    sbs.AppendLine(list[i]);
                    //    sb.AppendLine("");
                    //}
                    //else if(list[i].EndsWith("x", StringComparison.CurrentCultureIgnoreCase))
                    //{                        
                    //    sb.AppendLine(list[i]);
                    //    sbs.AppendLine(list[i]);
                    //    sb.AppendLine("");
                    //}
                }
            }

            StringBuilder ss = new StringBuilder();
            

            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllText(@"2.txt", sb.ToString());
            System.IO.File.WriteAllText(@"3.txt", sbr.ToString() +Environment.NewLine + sbx.ToString()+ Environment.NewLine + sbx1.ToString() + Environment.NewLine + sbs.ToString());
        }
    }
} 