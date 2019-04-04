using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Generic;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.Sign
{
    /// <summary>
    /// 设备签名提供者
    /// </summary>
    public class TerminalSignProvider : SignProvider
    {
        /// <summary>
        /// 设备签名配置
        /// </summary>
        public TerminalSignSettings TerminalSignSettings
        {
            get
            {
                return new TerminalSignSettings() { TerminalKey = this.Key, TerminalSerialNo = this.SerialNo };
            }
            set
            {
                this.SerialNo = value.TerminalSerialNo;
                this.Key = value.TerminalKey;

            }
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public TerminalSignProvider(TerminalSignSettings terminalSignSettings = null)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
        {
            TerminalSignSettings = terminalSignSettings;
        }


        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="TRequestParameterModel"></typeparam>
        /// <param name="requestParameterModel"></param>
        /// <returns></returns>
        public new Sign<TerminalSignProvider, TRequestParameterModel> Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel) where TRequestParameterModel : ITerminalSignable
        {
            if (requestParameterModel == null)
            {
                throw new ArgumentNullException(nameof(requestParameterModel));
            }
            return new Sign<TerminalSignProvider, TRequestParameterModel>()
            {
                SerialNo = this.SerialNo,
                SignContent = this.GetSignContent(requestParameterModel),
                DataObject = requestParameterModel,
                SignProvider = this
            };
        }
        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="TRequestParameterModel"></typeparam>
        /// <param name="requestParameterModel"></param>
        /// <param name="terminalSignSettings"></param>
        /// <returns></returns>
        public Sign<TerminalSignProvider, TRequestParameterModel> Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel, TerminalSignSettings terminalSignSettings) where TRequestParameterModel : ITerminalSignable
        {
            this.TerminalSignSettings = terminalSignSettings;
            return this.Sign(requestParameterModel);
        }
        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="TRequestParameterModel"></typeparam>
        /// <param name="requestParameterModel"></param>
        /// <param name="terminalSerialNo"></param>
        /// <param name="terminalKey"></param>
        /// <returns></returns>
        public Sign<TerminalSignProvider, TRequestParameterModel> Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel, string terminalSerialNo, string terminalKey) where TRequestParameterModel : ITerminalSignable
        {


            if (string.IsNullOrWhiteSpace(terminalSerialNo))
            {
                throw new ArgumentException("message", nameof(terminalSerialNo));
            }

            if (string.IsNullOrWhiteSpace(terminalKey))
            {
                throw new ArgumentException("message", nameof(terminalKey));
            }

            this.SerialNo = terminalSerialNo;
            this.Key = terminalKey;
            return this.Sign(requestParameterModel);
        }
    }
}
