using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能管理器
/// </summary>
public class CharacterSkillManager : MonoBehaviour
{
    public SkillData[] skills;

    private CharacterStatus m_CharacterStatus;


    private void Start()
    {
        m_CharacterStatus = GetComponent<CharacterStatus>();
        for (int i = 0; i < skills.Length; i++)
        {
            InitSkill(skills[i]);
        }

    }
    //初始化技能
    private void InitSkill(SkillData skillData)
    {
        //拿到技能的预支
        skillData.skillPrefab = Resources.Load<GameObject>("Skill/"+skillData.prefabName);
        skillData.owner = gameObject;
    }
    //冷却
    public SkillData PrepareSkill(int id)
    {
        SkillData data = skills.Find(s => s.skillID == id);
        if (data != null && data.coolRemain <= 0 && data.costSP <= m_CharacterStatus.SP)
        {
            return data;
        }
        else
        {
            return null;
        }
    }
    //生成技能
    public void GenerateSkill(SkillData data)
    {
        GameObject skillGo = Instantiate(data.skillPrefab, transform.position, transform.rotation);
        SkillDeployer skillDeployer = skillGo.GetComponent<SkillDeployer>();
        skillDeployer.SkillData = data;//释放器拿到数据，创建算法
        skillDeployer.DeploySkill();//内部执行
        Destroy(skillGo, data.durtionTime);
        StartCoroutine(CoolTimeDown(data));
    }
    //技能冷却
    private IEnumerator CoolTimeDown(SkillData data)
    {
        data.coolRemain = data.coolTime;
        WaitForSeconds wait = new WaitForSeconds(1);
        while (data.coolRemain > 0)
        {
            yield return wait;
            data.coolRemain--;
        }

    }

}
