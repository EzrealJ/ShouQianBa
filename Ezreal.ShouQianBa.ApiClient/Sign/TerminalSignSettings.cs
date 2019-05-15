using WebApiClient.DataAnnotations;

namespace Ezreal.ShouQianBa.ApiClient.Sign
{
    /// <summary>
    /// 终端签名配置
    /// </summary>
    public class TerminalSignSettings : ISignSettings
    {
        /// <summary>
        /// 终端序列号
        /// </summary>
        [IgnoreSerialized] public string TerminalSerialNo { get; set; }
        /// <summary>
        /// 终端Key
        /// </summary>
        [IgnoreSerialized] public string TerminalKey { get; set; }

        string ISignSettings.SerialNo => this.TerminalSerialNo;

        string ISignSettings.Key => this.TerminalKey;
    }
}