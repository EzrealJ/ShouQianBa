using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Generic;
using Ezreal.ShouQianBa.ApiClient.ApiParameterModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.ShouQianBa.ApiClient.Sign
{
    public class TerminalSignProvider : SignProvider
    {
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

        public TerminalSignProvider(TerminalSignSettings terminalSignSettings = null)
        {
            TerminalSignSettings = terminalSignSettings;
        }



        public void Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel) where TRequestParameterModel : RequestModel
        {
            if (requestParameterModel == null)
            {
                throw new ArgumentNullException(nameof(requestParameterModel));
            }
            base.Sign(requestParameterModel);
        }

        public void Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel, TerminalSignSettings terminalSignSettings) where TRequestParameterModel : RequestModel
        {
            this.TerminalSignSettings = terminalSignSettings;
            this.Sign(requestParameterModel);
        }

        public void Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel, string terminalSerialNo, string terminalKey) where TRequestParameterModel : RequestModel
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
            this.Sign(requestParameterModel);
        }
    }
}
