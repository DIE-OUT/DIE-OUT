namespace Afired.GameManagement.Characters {
    
    /// <summary>
    /// interface for custom injection of ItemPosition component
    /// </summary>
    public interface IItemPositionTagReceiver {
        
        public void ReceiveItemPositionTag(ItemPositionTag itemPositionTag);
        
    }
    
}
