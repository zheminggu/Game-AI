using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI
{
    /// <summary>
    /// 遇到时能转换成为patrol的事件
    /// </summary>
    [CreateAssetMenu (menuName ="AI/DecideEvents/PatrolEvents")]
    public class PatrolDecideEvent : DecideEvents {

        public override bool MatchedChangeCondition(AICharacterBrain _Brain)
        {
            return false;
        }

    }

}

