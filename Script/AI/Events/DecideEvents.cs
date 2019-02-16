using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// 遇到能改变当前学习性行为的事件
    /// </summary>
    public class DecideEvents : ScriptableObject
    {
        public virtual bool MatchedChangeCondition(AICharacterBrain _Brain) { return false; }
    }

}
