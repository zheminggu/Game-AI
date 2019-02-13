using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AI
{
    public class Debugger : MonoBehaviour
    {

        public GameObject m_EnemyTarget;

        public bool m_HaveEnemy;

        public GameObject m_EvadeTarget;

        public bool m_NeedEvade;

        [SerializeField]
        Text stateText;

        public List<ShownState> states;


        public List<GameObject> neighbors;

        private Dictionary<string, AISettings.RelationShip> peopleInMemory;

        public int elementInDictioanry;

        public Decisions CurrentDecision;

        public string currentState;

        private SensorData sensorData;

        private AICharacterBrain brain;
        // Use this for initialization
        protected virtual void Start()
        {
            brain = GetComponent<AICharacterBrain>();
            sensorData = brain.m_SensorManager.m_SensorData;
            neighbors = sensorData.m_Neighbors;
            peopleInMemory = brain.m_AIMemory.m_Acquaintance;
            if(stateText)
            {
                StartCoroutine(ShowState());
            }

        }
        protected void Update()
        {
            elementInDictioanry = peopleInMemory.Keys.Count;
            m_EnemyTarget = sensorData.m_EnemyTarget;
            m_HaveEnemy = sensorData.m_HaveEnemy;
            m_EvadeTarget = sensorData.m_EvadeTarget;
            m_NeedEvade = sensorData.m_NeedEvade;
            //Debug.Log(brain.m_LearnedBehaviorManager.m_Decisions);
            CurrentDecision = brain.m_LearnedBehaviorManager.m_Decisions;
        }

        void UpdateStateText()
        {
            if (CurrentDecision)
            {
                foreach (var state in states)
                {
                    foreach (var _state in state.states)
                    {
                        if(CurrentDecision.name.Contains(_state.name))
                        {
                            currentState = state.stateName;
                            stateText.text = state.stateName;
                            return;
                        }
                    }
                }
            }
        }

        IEnumerator ShowState()
        {
            while(true)
            {
                yield return new WaitForSeconds(0.1f);
                UpdateStateText();
            }
        }
    }

    [System.Serializable]
    public class ShownState
    {
        public string stateName;
        public List<Decisions> states = new List<Decisions>();
    }
}

