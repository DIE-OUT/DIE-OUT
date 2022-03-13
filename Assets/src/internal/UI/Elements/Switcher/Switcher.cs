using System;
using System.Collections;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Afired.UI.Elements {
    
    public class Switcher : Selectable {
        
        private ISwitchControl _control;
        private ISwitchControl Control {
            get => _control ?? throw new Exception("There is no switch control assigned");
            set => _control = value;
        }
        [SerializeField] private TMP_Text _label;
        
        public bool HasControl() {
            return !(_control is null);
        }
        
        public void AssignControl(ISwitchControl switchControl) {
            if(!(_control is null))
                Control.OnValueChanged -= UpdateLabel;
            Control = switchControl;
            if(!(switchControl is null)) {
                Control.OnValueChanged += UpdateLabel;
                UpdateLabel();
            }
        }
        
        public void SelectPrev() {
            Control.SelectPrev();
        }
        
        public void SelectNext() {
            Control.SelectNext();
        }
        
        private void UpdateLabel(object value, string valueAsText) {
            _label.text = valueAsText;
        }
        
        public void UpdateLabel() {
            _label.text = Control.GetValueAsText();
        }
        
        private void Press() {
            // don't run if element gets disabled during the press
            if (!IsActive() || !IsInteractable())
                return;

            UISystemProfilerApi.AddMarker("Button.onClick", this);
            
            DoStateTransition(SelectionState.Pressed, false);
            StartCoroutine(OnFinishSubmit());
        }
        
        private IEnumerator OnFinishSubmit() {
            var fadeTime = colors.fadeDuration;
            var elapsedTime = 0f;

            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }

            DoStateTransition(currentSelectionState, false);
        }
        
        public override void OnMove(AxisEventData eventData) {
            switch(eventData.moveDir) {
                case MoveDirection.Left:
                    SelectPrev();
                    Press();
                    return;
                case MoveDirection.Right:
                    SelectNext();
                    Press();
                    return;
                default:
                    base.OnMove(eventData);
                    break;
            }
        }
        
    }
    
}
