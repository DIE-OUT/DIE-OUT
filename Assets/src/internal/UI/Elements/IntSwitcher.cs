﻿using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DieOut.UI.Elements {
    
    public class IntSwitcher : MonoBehaviour {
        
        [SerializeField] private TMP_Text _label;
        [SerializeField] private List<int> _options = new List<int>();
        private List<int> Options {
            get => _options;
            set {
                _options = value;
                _index = 0;
                Refresh();
            }
        }
        private int _index;
        private int Index {
            get => _index;
            set {
                if(value < 0)
                    _index = 0;
                else if((value + 1) > _options.Count)
                    _index = _options.Count - 1;
                else
                    _index = value;
                Refresh();
            }
        }

        private void Awake() {
            Refresh();
        }

        public int GetSelected() {
            if(_index < 0 || (_index + 1) > _options.Count)
                return default;
            return Options[_index];
        }
        
        public void Next() {
            Index++;
        }
        
        public void Prev() {
            Index--;
        }
        
        private void Refresh() {
            _label.text = GetSelected().ToString();
        }
        
    }
    
}