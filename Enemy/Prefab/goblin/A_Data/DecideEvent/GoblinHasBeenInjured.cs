using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

[CreateAssetMenu (menuName = "AI/Enemy/Goblin/DecideEvents/GoblinHasBeenInjured")]
public class GoblinHasBeenInjured : DecideEvents {
    [Range (0,1)]
    [Tooltip("判定为受伤害状态的百分比")]
    [SerializeField]
    private float injuredHealthPercent=0.2f;
    public override bool MatchedChangeCondition(AICharacterBrain _Brain)
    {

        //if (_Brain.GetComponent<MonsterHealth>())
        //{
        //    if (_Brain.GetComponent<MonsterHealth>().m_CharacterHealthPoint <=injuredHealthPercent*_Brain.GetComponent<MonsterHealth>().m_CharacterOriginalHealth)
        //    {
        //        return true;
        //    }
        //}
        if (_Brain.GetComponent<NPCAI.Damageable>())
        {
            if (_Brain.GetComponent<NPCAI.Damageable>().GetHealth()<=injuredHealthPercent*_Brain.GetComponent<NPCAI.Damageable>().startHealth)
            {
                return true;
            }
        }
        return false;

    }
}
