using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezreal.SDK.ShouQianBa.Sign
{
    public class TerminalSignProvider<TRequestParameterModel> : SignProvider where TRequestParameterModel : ApiParameterModels.Request.RequestModel
    {
        public TerminalSignProvider()
        {
        }

        public TerminalSignProvider(TRequestParameterModel requestParameterModel, ITerminalSignToken terminalSignToken)
        {
            if (requestParameterModel == null)
            {
                throw new ArgumentNullException(nameof(requestParameterModel));
            }

            if (terminalSignToken == null)
            {
                throw new ArgumentNullException(nameof(terminalSignToken));
            }
            this.SerialNo = terminalSignToken.TerminalSerialNo;
            this.Sign(requestParameterModel, terminalSignToken.TerminalKey);
        }

        public TerminalSignProvider(TRequestParameterModel requestParameterModel, string terminalSerialNo, string terminalKey)
        {
            if (requestParameterModel == null)
            {
                throw new ArgumentNullException(nameof(requestParameterModel));
            }

            if (string.IsNullOrWhiteSpace(terminalSerialNo))
            {
                throw new ArgumentException("message", nameof(terminalSerialNo));
            }

            if (string.IsNullOrWhiteSpace(terminalKey))
            {
                throw new ArgumentException("message", nameof(terminalKey));
            }
            this.SerialNo = terminalSerialNo;
            this.Sign(requestParameterModel, terminalKey);
        }
    }
}
