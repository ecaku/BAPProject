﻿using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.Tools.LogTool
{

    public class NLogAdapter : ICustomLogger
    {
        public void LogError(string message)
        {
            var logger = LogManager.GetLogger("loggerFile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
