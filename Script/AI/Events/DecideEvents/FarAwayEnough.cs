using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// 判断是否距离逃离对象足够远
    /// </summary>
    [CreateAssetMenu (menuName = "AI/DecideEvents/FarAwayEnough")]
    public class FarAwayEnough : DecideEvents
    {
        [SerializeField]
        private float farAwayEnoughDistance;
        public override bool MatchedChangeCondition(AICharacterBrain _Brain)
        {
            return FarAwayEnoughFormEvadeTarget(_Brain);
        }
        private bool FarAwayEnoughFormEvadeTarget(AICharacterBrain _brain)
        {
            if ((_brain.m_CurrentTransform.position-_brain.m_SensorManager.m_SensorData.m_EvadeTarget.transform.position).sqrMagnitude>=farAwayEnoughDistance*farAwayEnoughDistance)
            {
                return true;
            }
            return false;
        }
    }

}
