using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

[CreateAssetMenu (menuName = "AI/Enemy/Goblin/DecideEvents/GoblinFinishedNotification")]
public class GoblinFinishedNotification : DecideEvents {

    public override bool MatchedChangeCondition(AICharacterBrain _Brain)
    {
        if (_Brain.m_SensorManager.m_SensorData.m_FinishedDoingCurrentLearnedBehavior)
        {
            return true;
        }
        return false;
    }
}
