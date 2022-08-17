using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostSP : IImpactEffect
{
    public void Execute(SkillDeployer deployer)
    {
        var status = deployer.SkillData.owner.GetComponent<CharacterStatus>();
        if (status != null)
        {
            status.CostSP(deployer.SkillData.costSP); 
        }
    }
}
