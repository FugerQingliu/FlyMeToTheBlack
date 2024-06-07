using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFan : CollectionsController
{
    public float extraCoolingSpeed;
    public float extraJumpSpeed;
    public float durationTime;

    public override void SpecialEffects()
    {
        if (!(tc.isFaning))
        {
            tc.coolingSpeed += extraCoolingSpeed;
            pic.jumpSpeed += extraJumpSpeed;
            tc.isFaning = true;
            StartCoroutine(Reset());
        }
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(durationTime);
        tc.coolingSpeed -= extraCoolingSpeed;
        pic.jumpSpeed -= extraJumpSpeed;
        tc.isFaning = false;
    }

}
