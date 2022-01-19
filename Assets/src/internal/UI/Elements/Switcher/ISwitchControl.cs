namespace DieOut.UI.Elements {
    
    public delegate void OnValueChanged(object value, string valueAsText);
    
    public interface ISwitchControl {
        public void Prev();
        public void Next();
        public void Select(object objectToSelect);
        public void SelectIndex(int index);
        public object GetValue();
        public string GetValueAsText();
        public void SetDefaultOptions();
        public event OnValueChanged OnValueChanged;
    }
    
}
