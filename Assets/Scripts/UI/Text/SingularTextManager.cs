namespace MobileReg.UI{
    using UnityEngine;
    using MobileReg.Data;
    using ScriptableEvents;
    using TMPro;

    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SingularTextManager : MonoBehaviour{
        [SerializeField] private SO_BaseEvent<string> _onTextEnableRequest;
        [SerializeField] private SO_AdvancedTextData _textData;
        private TextMeshProUGUI _currentText;

        private void Awake() {
            _currentText = GetComponent<TextMeshProUGUI>();
        }
        private void Start() {
            _currentText.color = _textData.TextColor;    
        }
        private void TextEnableRequest(string text){
            _currentText.enabled = true;
            _currentText.text = _textData.GetFullText(text);
        }
        private void OnEnable() {
            _onTextEnableRequest += TextEnableRequest;
        }
        private void OnDisable(){
            _onTextEnableRequest -= TextEnableRequest;
        }

    }
}