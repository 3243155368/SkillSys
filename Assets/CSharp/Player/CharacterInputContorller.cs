using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterInputContorller : MonoBehaviour
{
    private CharacterSkillManager skillManager;


    public List<ButtonCtrl> m_SkillButtons;

    private CharacterSkillSystem skillSystem;
    private void Awake()
    {
        skillManager = GetComponent<CharacterSkillManager>();
        skillSystem = GetComponent<CharacterSkillSystem>();
        foreach (var item in m_SkillButtons)
        {
            item.click_EventInt.AddListener(OnSkillButtonDown);
        }

    }
    private void Update()
    {

    }
    private void OnSkillButtonDown(string id)
    {
        //SkillData data = skillManager.PrepareSkill(int.Parse(id));
        //if (data != null)
        //{
        //    skillManager.GenerateSkill(data);
        //}
        skillSystem.AttackUseSkill(int.Parse(id),true);
    }
}
