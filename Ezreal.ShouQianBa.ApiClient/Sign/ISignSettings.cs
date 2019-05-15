using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DataAnnotations;

namespace Ezreal.ShouQianBa.ApiClient.Sign
{
    public interface ISignSettings
    {
        /// <summary>
        /// 签名序列号
        /// </summary>
        [IgnoreSerialized]
        string SerialNo { get; }

        /// <summary>
        /// 签名Key
        /// </summary>
        [IgnoreSerialized]
        string Key { get; }
    }
}
