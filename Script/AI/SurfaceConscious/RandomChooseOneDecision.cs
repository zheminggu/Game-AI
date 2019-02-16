using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu (menuName = "AI/SurfaceCouscious/RandomChooseOneDecision")]
    public class RandomChooseOneDecision :SurfaceConscious
    {
        private int lengthOfDecisionList;
        private int choosedDecisionNumber;
        public override void Initialize(AICharacterBrain _Brain)
        {
            base.Initialize(_Brain);
        }
       
        public override void GetDealNeededDecisions(List<Decisions> _Decisions)
        {
            base.GetDealNeededDecisions(_Decisions);
        }
        public override void DealWithDecisions()
        {
            lengthOfDecisionList = m_dealNeededDecisions.Count;
            //Debug.Log(m_brain.gameObject.name + "lengthOfDecisionList is " + lengthOfDecisionList);
            choosedDecisionNumber = Random.Range(0, lengthOfDecisionList);
            //Debug.Log(m_brain.gameObject.name+"choosedDecisionNumber is " + choosedDecisionNumber + m_dealNeededDecisions[choosedDecisionNumber]);
            m_brain.ChangeDecision(m_dealNeededDecisions[choosedDecisionNumber]);
            m_dealNeededDecisions.Clear();
            
        }
    }
}

