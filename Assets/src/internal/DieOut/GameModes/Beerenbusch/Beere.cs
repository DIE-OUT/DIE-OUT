using System.Collections;
using System.Collections.Generic;
using DieOut.GameModes;
using DieOut.GameModes.Beerenbusch;
using DieOut.GameModes.Interactions;
using UnityEngine;

namespace DieOut.GameModes.Beerenbusch {
    
}
public class Beere : MonoBehaviour {

    private PickUpBeere _pickUpBeere;
    
    public void TriggerPickUp(Movable player) {
        player.GetComponent<Health>().TriggerDamage(5);
        this.gameObject.SetActive(false);

        _pickUpBeere = player.GetComponent<PickUpBeere>();
        _pickUpBeere._beeren.Remove(this);
    }
}
