using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCooling : CollectionsController
{
    public float reductionTemperation;
    public float extraCoolingSpeed;
    public float durationTime;
    public override void SpecialEffects()
    {
        if (!(tc.isWaterCooling))
        {
            tc.temperation -= reductionTemperation;
            tc.coolingSpeed += extraCoolingSpeed;
            tc.isWaterCooling = true;
            StartCoroutine(Reset());
        }
    }
    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(durationTime);
        tc.coolingSpeed -= extraCoolingSpeed;
        tc.isWaterCooling = false;
    }
}
