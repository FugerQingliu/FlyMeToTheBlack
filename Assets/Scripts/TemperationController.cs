using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class TemperationController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private PlayerInputController pic;
    public float temperation;
    public float coolingSpeed;
    public float warmingSpeed;
    public float minTemperation;
    public float maxTemperation;
    public bool isWaterCooling;
    public bool isFaning;
    public bool isMegnetic;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        pic = GetComponent<PlayerInputController>();
        playerInputActions.Player.Fire.started += Warming;
    }

    private void Warming(InputAction.CallbackContext context)
    {
        temperation += warmingSpeed;
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void Update()
    {
        if(temperation > minTemperation + coolingSpeed*Time.deltaTime)
            temperation -= coolingSpeed * Time.deltaTime;
        else 
            temperation = minTemperation;
        if(temperation > maxTemperation && !pic.isDead)
            pic.Die();
    }
    private void OnDisable()
    {
        playerInputActions.Disable();
    }
}
