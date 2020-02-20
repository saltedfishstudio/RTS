using UnityEngine;

namespace RTS.Core
{
    /// <summary>
    /// 실제 게임오브젝트를 관리하는 메인 비헤이비어
    /// </summary>
    public abstract class Actor<T> : MonoBehaviour where T : Entity
    {
        [SerializeField] 
        protected T mainEntity;

    }
}