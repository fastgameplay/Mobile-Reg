namespace MobileReg.Data
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "App Data", menuName = "Data/App")]
    public class SO_AppData : ScriptableObject
    {
        public float DisableTextAfterTime => _disableTextAfterTime;
        [SerializeField] private float _disableTextAfterTime;

    }
}
