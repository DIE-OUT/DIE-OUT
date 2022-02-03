using System.Collections;
using System.Collections.Generic;
using DieOut.GameModes;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes.Beerenbusch {
    
}
public class Beere : MonoBehaviour {

    public void TriggerPickUp(Movable player) {
        player.GetComponent<Health>().TriggerDamage(5);
        Destroy(this);
    }
}
