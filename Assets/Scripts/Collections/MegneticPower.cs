using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegneticPower : CollectionsController
{
    CapsuleCollider2D cc;
    public float multiplyingPower;
    public float maxTemperatureReductionPower;
    public override void SpecialEffects()
    {
        if (!(tc.isMegnetic))
        {
            cc = tc.GetComponentInChildren<CapsuleCollider2D>();
            cc.size = new Vector2(cc.size.x, cc.size.y * multiplyingPower);
            tc.maxTemperation *= maxTemperatureReductionPower;
            tc.isMegnetic = true;
        }
    }
}
