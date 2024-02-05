namespace MobileReg.Data
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Advanced Text Data", menuName = "Data/AdvancedText")]
    public class SO_AdvancedTextData : ScriptableObject
    {
        public string Suffix => _suffix;
        public string Prefix => _prefix;
        public Color TextColor => _textColor;

        [SerializeField] string _suffix;
        [SerializeField] string _prefix;
        
        [Space(10)]
        [SerializeField] Color _textColor;

        public string GetFullText(string text) => _prefix + text + Suffix;
        
    }
}