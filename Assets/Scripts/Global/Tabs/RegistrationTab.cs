namespace MobileReg.Global
{
    using ScriptableEvents;
    using UnityEngine;
    using TMPro;
    public class RegistrationTab : MonoBehaviour
    {
        [Header("Input Fields")]
        [SerializeField] TMP_InputField _countryCode;
        [SerializeField] TMP_InputField _operatorCode;
        [SerializeField] TMP_InputField _phoneNumber;

        [Space(10)]
        [Header("Events")]
        [SerializeField] SO_BaseEvent<NumberInfo> _onNumberAcquired;

        private NumberInfo GetFullNumber(){
            return new NumberInfo(_countryCode.text, _operatorCode.text, _phoneNumber.text);
        }
        public void RegisterBtn(){
            _onNumberAcquired.Invoke(GetFullNumber());
        }
    }
}