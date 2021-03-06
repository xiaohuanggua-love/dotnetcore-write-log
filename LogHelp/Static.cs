using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogHelp
{
    public static class Static
    {
        #region 静态方法,但实例方法性能更好(页面上调多次情况)
        static ILog staticLogger; 

        static object _Obj=new object();
        
        static void Init(){
            lock(_Obj){
                if(staticLogger==null)staticLogger=LogHelp.LogFactory.GetLogger("项目日志");
            }
        }
        
        public static void Debug(object message)
        {
            Init();

            staticLogger.Debug(message);
        }

        public static void Error(object message)
        {
            Init();

            staticLogger.Error(message);
        }

        public static void Info(object message)
        {
            Init();

            staticLogger.Info(message);
        }

        public static void Warn(object message)
        {
            Init();

            staticLogger.Warn(message);
        }
        #endregion
    }
}