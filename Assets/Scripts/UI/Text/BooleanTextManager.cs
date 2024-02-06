namespace MobileReg.UI{
    using UnityEngine;
    using ScriptableEvents;
    using MobileReg.Data;
    using TMPro;
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BooleanTextManager : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private SO_BaseEvent<bool> _onTextStateChange;
        [SerializeField] private SO_BaseEvent _onTextCloseRequest;
        [Space(10)]
        [Header("Reference")] 
        [SerializeField] private SO_BasicTextData _positiveText;
        [SerializeField] private SO_BasicTextData _negativeText;
        private TextMeshProUGUI _currentText;

        private void Awake() {
            _currentText = GetComponent<TextMeshProUGUI>();
        }
        
        private void OnTextStateChange(bool state){
            _currentText.enabled = true;
            if(state){
                _currentText.text = _positiveText.Text;
                _currentText.color = _positiveText.TextColor;
            } else {
                _currentText.text = _negativeText.Text;
                _currentText.color = _negativeText.TextColor;
            }
            _onTextCloseRequest.Invoke();
        }

        private void OnEnable() {
            _onTextStateChange += OnTextStateChange;
        }   
        private void OnDisable() {
            _onTextStateChange -= OnTextStateChange;
        }    

    }
}