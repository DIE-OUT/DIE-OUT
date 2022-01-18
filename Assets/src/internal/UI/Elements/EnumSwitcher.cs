using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;
using UnityEngine;
using TMPro;

namespace DieOut.UI.Elements {
    
    public class EnumSwitcher : SerializedMonoBehaviour {
        
        [SerializeField] private TMP_Text _label;
        
        [TypeFilter("GetFilteredTypeList")]
        [OdinSerialize] private Type _enum = null;
        [SerializeField] private int _value;
        private int Value {
            get => _value;
            set {
                _value = value;
                Refresh();
            }
        }
        
        public IEnumerable<Type> GetFilteredTypeList() {
            return typeof(EnumSwitcher).Assembly.GetTypes().Where(x => x.IsEnum);
        }
        
        private void Awake() {
            Value = Value;
        }
        
        public void Next() {
            Value++;
        }
        
        public void Prev() {
            Value--;
        }
        
        private void Refresh() {
            _label.text = Value.ToString();
        }
        
    }
    
}
