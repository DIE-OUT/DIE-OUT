using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DieOut.GameMode.Interactions
{
    


[RequireComponent(typeof(Collider))]
public class Tackle : MonoBehaviour
{
    private Enemy _enemy;
    
    private InputTable _inputTable;

    [SerializeField] private float cooldown;
    [SerializeField] private float stunDuration;
    [SerializeField] private float immunity;

    //private bool _inTackleRange;
    private bool _inCooldown = false;

    private void Awake()
    {
        _inputTable = new InputTable();

        _inputTable.CharacterControls.Tackle.performed += Tackling;
    }

    private void OnEnable()
    {
        _inputTable.Enable();
    }

    private void OnDisable()
    {
        _inputTable.Disable();
    }

    void Start()
    {
        _enemy = FindObjectOfType<Enemy>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("in tackle range");
            //_inTackleRange = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("not in tackle range");
            //_inTackleRange = false;
        }
    }

    IEnumerator TackleCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        Debug.Log("cooldown finished");
        _inCooldown = false;
    }

    IEnumerator TackleStunDuration()
    {
        yield return new WaitForSeconds(stunDuration);
        Debug.Log("tackle stopped");
    }
    
    IEnumerator TackleImmunity()
    {
        yield return new WaitForSeconds(stunDuration + immunity);
        Debug.Log("tackle immunity OFF");
        _enemy.tackleImmunity = false;
    }

    private void Tackling(InputAction.CallbackContext _)
    {
        if (_enemy.inTackleRange == true && _inCooldown == false && _enemy.tackleImmunity == false)
        {
            Debug.Log("tackling");
            _inCooldown = true;
            Debug.Log("in cooldown");
            StartCoroutine(TackleCooldown());
            _enemy.tackleImmunity = true;
            Debug.Log("tackle immunity ON");
            StartCoroutine(TackleImmunity());
            StartCoroutine(TackleStunDuration());
        }
    }
}
}