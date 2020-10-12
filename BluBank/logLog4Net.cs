using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluBank
{
    public static class logLog4Net
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static log4net.ILog getObj()
        {
            return log;
        }
    }
}