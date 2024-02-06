namespace MobileReg.Data
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Advanced Text Data", menuName = "Data/AdvancedText")]
    public class SO_AdvancedTextData : ScriptableObject
    {
        public string Prefix => _prefix;
        public string Suffix => _suffix;
        public Color TextColor => _textColor;

        [SerializeField] string _prefix;
        [SerializeField] string _suffix;
        
        [Space(10)]
        [SerializeField] Color _textColor;

        public string GetFullText(string text) => _prefix + text + Suffix;
        
    }
}