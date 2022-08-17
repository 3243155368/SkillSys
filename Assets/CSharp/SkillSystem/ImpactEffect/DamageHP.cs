using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHP : IImpactEffect
{
    public void Execute(SkillDeployer deployer)
    {
        deployer.StartCoroutine(RepeatDamage(deployer));
    }
    private IEnumerator RepeatDamage(SkillDeployer deployer)
    {
        float atkTime = 0;
        do
        {
            OnceDamage(deployer);
            yield return new WaitForSeconds(deployer.SkillData.atkInterval);
            atkTime += deployer.SkillData.atkInterval;
            deployer.CalculateTargets();
        } while (atkTime < deployer.SkillData.durtionTime);
    }
    //单次伤害
    private void OnceDamage(SkillDeployer deployer)
    {
        float atk = deployer.SkillData.atkRatio * deployer.SkillData.owner.GetComponent<CharacterStatus>().BaseAtk;
        foreach (var item in deployer.SkillData.attackTargets)
        {
            item.GetComponent<CharacterStatus>().DamageHP(atk);
        }
    }
}
