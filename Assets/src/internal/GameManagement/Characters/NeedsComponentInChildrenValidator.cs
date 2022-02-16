using System;
using Afired.GameManagement.Characters;
using Sirenix.OdinInspector.Editor.Validation;
using UnityEngine;

[assembly: RegisterValidator(typeof(NeedsComponentInChildrenValidator))]
namespace Afired.GameManagement.Characters {
    
    public class NeedsComponentInChildrenValidator : AttributeValidator<NeedsComponentInChildren, GameObject> {
        
        protected override void Validate(ValidationResult result) {
            if(ValueEntry.SmartValue == null)
                return;

            foreach(Type type in Attribute.Types) {
                
                if(ValueEntry.SmartValue.GetComponentInChildren(type) == null) {
                    result.ResultType = ValidationResultType.Error;
                    result.Message = $"'{type.Name}' component is required";
                }
                
            }
            
        }
        
    }
    
}
