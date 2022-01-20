using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DieOut.GameMode.Interactions {
    public class Tackleable : MonoBehaviour {
        public bool tackleImmunity = false;

        // Das müsste eher in den PlayerController
        [SerializeField] public int health = 100;
    }
}