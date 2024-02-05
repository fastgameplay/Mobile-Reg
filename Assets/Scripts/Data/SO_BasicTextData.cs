using UnityEngine;
namespace MobileReg.Data
{
    [CreateAssetMenu(fileName = "Basic Text Data", menuName = "Data/BasicText")]
    public class SO_BasicTextData : MonoBehaviour
    {
        public string Text => _text;
        public Color TextColor => _textColor;
        [SerializeField] private string _text;
        [SerializeField] private Color _textColor;
    }
}