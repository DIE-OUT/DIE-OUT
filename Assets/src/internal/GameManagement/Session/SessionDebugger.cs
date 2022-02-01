using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Afired.GameManagement.Sessions {
    
    [InfoBox("No session has been created yet", VisibleIf = "@_current == null && EditorApplication.isPlaying")]
    [InfoBox("This will show the current session once in play mode", VisibleIf = "@!EditorApplication.isPlaying")]
    public class SessionDebugger : SerializedMonoBehaviour {

        [BoxGroup("Current Session")]
        [HideLabel] [HideReferenceObjectPicker] [HideIf("@_current == null || !EditorApplication.isPlaying")]
        [OdinSerialize] [ReadOnly] private Session _current {
            get => Session.HasCurrent ? Session.Current : null;
            set { } // needs a setter in order to be serialized by odin
        }
        
    }
    
}
