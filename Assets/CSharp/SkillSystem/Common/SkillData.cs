using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillData
{
    public int skillID;

    public string skillName;
    //技能描述
    public string description;
    /// <summary>
    /// 冷却时间
    /// </summary>
    public float coolTime;
    /// <summary>
    /// 冷却剩余
    /// </summary>
    public float coolRemain;
    /// <summary>
    /// 魔法消耗
    /// </summary>
    public int costSP;
    //攻击距离
    public float attackDistance;
    //攻击角度
    public float attackAngle;
    //攻击目标tags
    public string[] attackTargetTags = { "Enemy" };
    //攻击对象数组
    [HideInInspector]
    public Transform[] attackTargets;
    //技能影响类型
    public string[] impactType = { "CostSP", "Damage" };
    //连击的下一个技能编号
    public int nextBatterId;
    //伤害比率
    public float atkRatio;
    //持续时间
    public float durtionTime;
    //伤害间隔
    public float atkInterval;
    /// <summary>
    /// 技能所属
    /// </summary>
    [HideInInspector]
    public GameObject owner;
    /// <summary>
    ///技能预支件名称
    /// </summary>
    public string prefabName;
    /// <summary>
    /// 预制件对象
    /// </summary>
    [HideInInspector]
    public GameObject skillPrefab;
    //动画名称
    public string animationName;

    //受击特效名称
    public string hitFxName;
    //受击特效预支
    [HideInInspector]
    public GameObject hitFxPrefab;
    //技能等级
    public int level;
    //攻击类型 单攻，群攻
    public SkillAttackType attackType;
    //选择类型 扇形，圆形等
    public SelectorType selectorType;
}
public enum SkillAttackType
{
    Single,
    Group
}
public enum SelectorType
{
    //扇形
    Sector,
    //矩形
    Rectangle
}
