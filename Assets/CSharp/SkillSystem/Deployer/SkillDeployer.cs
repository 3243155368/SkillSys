using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//释放器
public abstract class SkillDeployer : MonoBehaviour
{
    private SkillData m_skillData;

    private IAttackSelector select;

    private IImpactEffect[] impactEffect;
    public SkillData SkillData
    {
        get
        {
            return m_skillData;
        }
        set
        {
            m_skillData = value;
            InitDeplopyer();
        }
    }
    //创建算法对象
    private void InitDeplopyer()
    {
        //选区
        select = DeployerConfigFactory.CreateAttackSelector(m_skillData);
        //影响
        impactEffect = DeployerConfigFactory.CreateImpactEffect(m_skillData);
    }

    //执行算法对象,儿子去自己管理自己的释放方式
    public void CalculateTargets()
    {
        m_skillData.attackTargets = select.SleectTarget(m_skillData, transform);
        for (int i = 0; i < m_skillData.attackTargets.Length; i++)
        {
            print(m_skillData.attackTargets[i].name);
        }
    }
    //影响
    public void ImpactTargets()
    {
        for (int i = 0; i < impactEffect.Length; i++)
        {
            impactEffect[i].Execute(this);
        }
    }
    //释放方式,不同的释放器的，释放方式不一样，所以父类不去写具体代码
    public abstract void DeploySkill();

}
