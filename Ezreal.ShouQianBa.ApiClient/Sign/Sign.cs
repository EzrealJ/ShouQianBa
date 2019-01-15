using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DataAnnotations;

namespace Ezreal.ShouQianBa.ApiClient.Sign
{
    /// <summary>
    /// 签名对象
    /// </summary>
    /// <typeparam name="TSignProvider"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public class Sign<TSignProvider, TData> where TSignProvider : SignProvider
    {
        /// <summary>
        /// 完整的签名体
        /// </summary>
        public virtual string Authorization
        {
            get
            {
                if (string.IsNullOrWhiteSpace(SerialNo))
                {
                    throw new ArgumentNullException(nameof(SerialNo));
                }

                if (string.IsNullOrWhiteSpace(SignContent))
                {
                    throw new ArgumentNullException(nameof(SignContent));
                }
                return $"{SerialNo} {SignContent}";
            }
        }
        /// <summary>
        /// 签名首部的序列号
        /// </summary>
        [IgnoreSerialized]
        public virtual string SerialNo { get; set; }
        /// <summary>
        /// 签名内容
        /// </summary>
        [IgnoreSerialized]
        public virtual string SignContent { get; set; }
        /// <summary>
        /// 签名的数据对象
        /// </summary>
        [IgnoreSerialized]
        public virtual TData DataObject { get; set; }
        /// <summary>
        /// 签名提供者
        /// </summary>
        [IgnoreSerialized]
        public virtual TSignProvider SignProvider { get; set; }
    }
}
