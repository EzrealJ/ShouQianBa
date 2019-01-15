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

        public Sign<TerminalSignProvider, TRequestParameterModel> Sign<TRequestParameterModel>(TRequestParameterModel requestParameterModel, TerminalSignSettings terminalSignSettings) where TRequestParameterModel : ITerminalSignable
        {
            this.TerminalSignSettings = terminalSignSettings;
            return this.Sign(requestParameterModel);
        }

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
