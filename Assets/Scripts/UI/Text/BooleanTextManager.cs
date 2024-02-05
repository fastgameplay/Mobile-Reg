namespace MobileReg.UI{
    using UnityEngine;
    using ScriptableEvents;
    using MobileReg.Data;
    using TMPro;
    public class BooleanTextManager : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private SO_BaseEvent<bool> _onTextStateChange;
        [SerializeField] private SO_BaseEvent _onTextCloseRequest;
        [Space(10)]
        [Header("Reference")] 
        [SerializeField] private TextMeshProUGUI _currentText;
        [SerializeField] private SO_BasicTextData _negativeText;
        [SerializeField] private SO_BasicTextData _positiveText;

        private void OnTextStateChange(){

        }
        private void OnTextCloseRequest(){

        }
        private void OnEnable() {
            _onTextCloseRequest += OnTextStateChange;
            _onTextCloseRequest += OnTextCloseRequest;
        }   
        private void OnDisable() {
            _onTextCloseRequest -= OnTextStateChange;
            _onTextCloseRequest -= OnTextCloseRequest;

        }    

    }
}