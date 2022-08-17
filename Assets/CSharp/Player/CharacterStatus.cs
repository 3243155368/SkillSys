using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//角色属性状态
public class CharacterStatus : MonoBehaviour
{
    [SerializeField]
    private float hp;
    public float HP
    {
        get
        {
            return hp;
        }
    }
    [SerializeField]
    private int maxHp;
    public int MaxHp
    {
        get
        {
            return maxHp;
        }
    }
    [SerializeField]
    private int sp;
    public int SP
    {
        get
        {
            return sp;
        }
    }
    [SerializeField]
    private int maxSp;
    public int MaxSp
    {
        get
        {
            return MaxSp;
        }
    }
    [SerializeField]
    private int baseAtk;
    public int BaseAtk
    {
        get
        {
            return baseAtk;
        }
    }
    [SerializeField]
    private int defence;
    public int Defence
    {
        get
        {
            return defence;
        }
    }
    [SerializeField]
    private int attackInterval;
    public int AttackInterval
    {
        get
        {
            return attackInterval;
        }
    }
    [SerializeField]
    private int attackDistance;
    public int AttackDistance
    {
        get
        {
            return attackDistance;
        }
    }

    public void CostSP(int costhp)
    {
        sp -= costhp;
    }
    public void DamageHP(float damagehp)
    {
        hp -= damagehp; ;
    }
}
