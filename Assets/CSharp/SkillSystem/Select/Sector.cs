using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : IAttackSelector
{
    //扇形，圆形选区
    public Transform[] SleectTarget(SkillData data, Transform skillTF)
    {
        List<Transform> targets = new List<Transform>();
        for (int i = 0; i < data.attackTargetTags.Length; i++)
        {
            GameObject[] tempGOArray = GameObject.FindGameObjectsWithTag(data.attackTargetTags[i]);
            targets.AddRange(tempGOArray.Select(g => g.transform));
        }
        targets = targets.FindAll(t => Vector3.Distance(t.position, skillTF.position) <= data.attackDistance
        &&Vector3.Angle(skillTF.forward,t.position-skillTF.position)<=data.attackAngle/2);

        targets = targets.FindAll(t => t.GetComponent<CharacterStatus>().HP > 0);

        if(data.attackType == SkillAttackType.Group || targets.Count ==  0)
        {
            return targets.ToArray();
        }
        //距离最近的
        Transform minDis = targets.ToArray().GetMin(t => Vector3.Distance(t.position, skillTF.position));
        return new Transform[] { minDis };

    }
}