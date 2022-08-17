using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSkillDeployer : SkillDeployer
{
    public override void DeploySkill()
    {
        transform.SetParent(SkillData.owner.transform); 
        //选择怪物
        CalculateTargets();
        //执行影响算法
        ImpactTargets();
    }
}
