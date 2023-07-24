using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Quartz.Util;

namespace nes_workflow
{
    public class QuartzScheduler
    {
        [STAThread]
        public static void Main()
        {
            try
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Type[] types = asm.GetTypes();

                IDictionary<int, Type> typeMap = new Dictionary<int, Type>();
                int counter = 1;

                //Console.WriteLine("Select Job to run: ");
                List<Type> typeList = new List<Type>();
                foreach (Type t in types)
                {
                    if (new List<Type>(t.GetInterfaces()).Contains(typeof(QuartzSchedulerJob)))
                    {
                        typeList.Add(t);
                    }
                }

                // sort for easier readability
                typeList.Sort(new TypeNameComparer());

                foreach (Type t in typeList)
                {
                    string counterString = string.Format("[{0}]", counter).PadRight(4);
                    Console.WriteLine("{0} {1} {2}", counterString, t.Namespace.Substring(t.Namespace.LastIndexOf(".") + 1), t.Name);
                    //QS_BLL.WriteLog(string.Format("{0} {1} {2}", counterString, t.Namespace.Substring(t.Namespace.LastIndexOf(".") + 1), t.Name));
                    typeMap.Add(counter++, t);
                }

                Type eType = typeMap[1];
                QuartzSchedulerJob QSJobCron = ObjectUtils.InstantiateType<QuartzSchedulerJob>(eType);
                QSJobCron.Run();
                Console.WriteLine("QuartzSchedulerJob run successfully.");
                //QS_BLL.WriteLog("QuartzSchedulerJob run successfully.");
            }
            catch (Exception ex)
            {
                //QS_BLL.WriteLog("Error running QuartzSchedulerJob: " + ex.Message + ": " + ex.InnerException + ": " + ex.StackTrace);
                Console.WriteLine("Error running QuartzSchedulerJob: " + ex.Message + ": " + ex.InnerException + ": " + ex.StackTrace);
                Console.WriteLine(ex.ToString());

            }
            Console.Read();
        }

        public class TypeNameComparer : IComparer<Type>
        {
            public int Compare(Type t1, Type t2)
            {
                if (t1.Namespace.Length > t2.Namespace.Length)
                {
                    return 1;
                }

                if (t1.Namespace.Length < t2.Namespace.Length)
                {
                    return -1;
                }

                return t1.Namespace.CompareTo(t2.Namespace);
            }
        }
    }
}