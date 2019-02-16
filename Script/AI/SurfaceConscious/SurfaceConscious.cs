using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class SurfaceConscious : ScriptableObject
    {
        protected List<Decisions> m_dealNeededDecisions;
        protected AICharacterBrain m_brain;
        public virtual void Initialize(AICharacterBrain _Brain)
        {
            m_brain = _Brain;
        }
        public virtual void DealWithDecisions() { }
        public virtual void GetDealNeededDecisions(List<Decisions> _Decisions)
        {
            m_dealNeededDecisions = _Decisions;
        }
    }

}
