using _Scripts.Definition;
using UnityEngine;

namespace qtLib.Helper
{
    public partial class MessageDispatcher
    {
        public class SwitchFooterTabMessage : MessageObject
        {
            public ETab tab;
            public bool isShow;
        }
    }
}