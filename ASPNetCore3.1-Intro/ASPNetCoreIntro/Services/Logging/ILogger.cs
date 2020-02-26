using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreIntro.Services.Logging
{
    public interface ILogger // yazım kuralı -> interface'ler I ile başlar
    {
        void Log(string logMessage);
    }
}
