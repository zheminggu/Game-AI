using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class SurfaceConsciousManager
    {
        public  SurfaceConscious m_AISurfaceConscious;
        private AISettings aiSettings; 
        private AICharacterBrain brain;

        public void Initialize(AICharacterBrain _Brain)
        {
            brain = _Brain;
            aiSettings = _Brain.GetComponent<AISettings>();
            if (aiSettings.m_SurfaceConscious)
            {
                m_AISurfaceConscious.Initialize(brain);
            }
            
        }

        public void OnCalled(List<Decisions> _Decisions)
        {
            m_AISurfaceConscious.GetDealNeededDecisions(_Decisions);
            m_AISurfaceConscious.DealWithDecisions();
        }

    }

}
