using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.ClientApp.Helpers
{
    public class ClientChangedMessage : ValueChangedMessage<bool>
    {
        public ClientChangedMessage() : base(true) {}
    }
}
