﻿using System;
using DieOut.Helper;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace DieOut.Sessions {
    
    [InfoBox("This will show the current session once in play mode", VisibleIf = "@!EditorApplication.isPlaying")]
    public class Sessions : SerializedMonoBehaviour {

        public static Session Current => _instance.Get()._current ?? throw new Exception("There is no current session");
        
//        [BoxGroup("Current Session")]
//        [InfoBox("There has not yet been created a session", VisibleIf = "@_current == null")]
//        [Button("Create new Session")] [HideInEditorMode]
//        private void CreateSession(Session session) {
//            _current = new Session();
//        }
        [BoxGroup("Current Session")]
        [HideLabel] [HideReferenceObjectPicker] [HideIf("@_current == null || !EditorApplication.isPlaying")]
        [OdinSerialize] private Session _current;
        private static SingletonInstance<Sessions> _instance;
        
        private void Awake() {
            _instance.Init(this);
            _current = null;
        }
        
        public static void SetNew(Session session) {
            _instance.Get()._current = session;
        }
        
    }
    
}