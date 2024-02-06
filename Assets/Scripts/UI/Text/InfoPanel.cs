namespace MobileReg.UI{
    using UnityEngine;
    using TMPro;
    public class InfoPanel : MonoBehaviour
    {
        public string Text {
            get => _phoneHolder.text;
            set => _phoneHolder.text = value;
        }
        [SerializeField] TextMeshProUGUI _phoneHolder;
    }
}