using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    /// <summary>
    /// 运行时AI会拥有的记忆
    /// </summary>
    public class AIMemory
    {
        private AISettings aiSetting;
        /// <summary>
        /// AI看到的人
        /// </summary>
        public Dictionary<string,AISettings.RelationShip> m_Acquaintance=new Dictionary<string, AISettings.RelationShip>();

        public void InitializeDictionary(AICharacterBrain _Brain)
        {
            aiSetting = _Brain.GetComponent<AISettings>();

            //将所有用户设置的关系加入dictionary
            //Debug.Log(aiSetting.m_PreSetAcquaintanceInfo.Count);
            for (int i = 0; i < aiSetting.m_PreSetAcquaintanceInfo.Count; i++) {
                m_Acquaintance.Add(aiSetting.m_PreSetAcquaintanceInfo[i].PreSetObject.name, aiSetting.m_PreSetAcquaintanceInfo[i].PreSetRelationship);
            }    
        }
    }
}

