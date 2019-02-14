using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDemo
{
    public class DefaultTerminalInfo
    {
        /// <summary>
        /// 【必须】设备唯一身份ID
        /// </summary>

        static public string DeviceID { get; set; } = "TestDevice@1";

        /// <summary>
        /// 终端名
        /// </summary> 
        static public string Name { get; set; } = "用于Api测试的终端";
    }
}
