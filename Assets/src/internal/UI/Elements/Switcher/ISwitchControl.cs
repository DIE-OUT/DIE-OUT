namespace DieOut.UI.Elements {
    
    public delegate void OnValueChanged(object value, string valueAsText);
    
    public interface ISwitchControl {
        public void SelectFirst();
        public void SelectPrev();
        public void SelectNext();
        public void SelectLast();
        public object GetValue();
        public string GetValueAsText();
        public event OnValueChanged OnValueChanged;
    }
    
}
