using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//攻击选取的方法
public interface IAttackSelector
{
    Transform[] SleectTarget(SkillData data,Transform skillTF);
}
