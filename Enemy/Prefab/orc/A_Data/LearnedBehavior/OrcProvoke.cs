using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;
[CreateAssetMenu(menuName = "AI/Enemy/Orc/LearnedBehavior/OrcProvoke")]
public class OrcProvoke : LearnedBehavior {
    public string m_Skill;

    public override void Initialize(AICharacterBrain _Brain)
    {
        base.Initialize(_Brain);
        m_brain.m_SensorManager.m_SensorData.m_FinishedDoingCurrentLearnedBehavior = false;
        _Brain.m_BaseMoveManager.ChangeMoveTarget(_Brain.m_CurrentTransform);
        m_Animator.SetFloat("Speed", 0);
        m_Animator.SetTrigger(m_Skill);
        
    }
    public override void PlayLearnedBehavior()
    {
        m_brain.m_SensorManager.m_SensorData.m_FinishedDoingCurrentLearnedBehavior = true;


    }
}
