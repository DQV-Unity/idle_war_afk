using _Scripts.Definition;

namespace qtLib.Helper
{
    public partial class MessageDispatcher
    {
        public enum EEvent
        {
            IAPPurchaseSucceeded,
            OnCoinChanged,
            SwitchTab,
            CharacterChanged,
            EquipmentChanged,
        }
        
        public class SwitchFooterTabMessage : MessageObject
        {
            public ETab tab;
            public bool isShow;
        }
    }
}