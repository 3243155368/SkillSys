using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//封装技能系统，提供简单的技能释放功能
[RequireComponent(typeof(CharacterSkillManager))]
public class CharacterSkillSystem : MonoBehaviour
{
    private CharacterSkillManager m_SkillManager;
    //技能队列
    SkillData skillData;
    private Animator animator;
    private void Start()
    {
        m_SkillManager = GetComponent<CharacterSkillManager>();
        //GetComponent<AnimationEvent>().
        animator = GetComponent<Animator>();
        GetComponent<AnimationEventBehaviour>().attackHandler = DeploySkill;
    }

    //用动画系统控制，当动画播到什么时候去生成技能
    private void DeploySkill()
    {      
        //生成技能
        m_SkillManager.GenerateSkill(skillData);
    }

    public void AttackUseSkill(int skillId,bool isBatter = false)
    {
        if (isBatter&&skillData!=null)
            skillId = skillData.nextBatterId;
        //准备技能
        skillData = m_SkillManager.PrepareSkill(skillId);
        if (skillData == null) return;
        //播放动画
        GetComponent<AnimationEventBehaviour>().PlaySkillAnim(skillData.animationName);

        //如果单攻 朝向目标，或者走向目标

        //选中目标
    }

    //使用随机技能(为NPC提供)
    public void UseRandomSkill()
    {
        //需求：从管理器中挑选随机的技能
        var usableSkills = m_SkillManager.skills.FindAll(s => m_SkillManager.PrepareSkill(s.skillID) != null);
        if (usableSkills.Length == 0) return;
        int index = Random.Range(0, usableSkills.Length);
        AttackUseSkill(usableSkills[index].skillID);
    }
}
