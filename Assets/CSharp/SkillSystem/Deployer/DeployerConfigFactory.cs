using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployerConfigFactory
{
    public static IAttackSelector CreateAttackSelector(SkillData data)
    {
        return CreatObject<IAttackSelector>(data.selectorType.ToString());
    }
    public static IImpactEffect[] CreateImpactEffect(SkillData data)
    {
        IImpactEffect[] impactEffect = new IImpactEffect[data.impactType.Length];
        for (int i = 0; i < data.impactType.Length; i++)
        {
            impactEffect[i] = CreatObject<IImpactEffect>(data.impactType[i]);
        }
        return impactEffect;
    }

    private static T CreatObject<T>(string className) where T : class
    {
        Type type = Type.GetType(className);
        return Activator.CreateInstance(type) as T;
    }
}
