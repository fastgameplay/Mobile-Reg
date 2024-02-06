namespace MobileReg.Global
{
    using ScriptableEvents;
    using UnityEngine;
    public class AppFlowController : MonoBehaviour
    {

        [Header("References")]
        [SerializeField] GameObject _getIDTab;
        [SerializeField] GameObject _registrationTab;
        [SerializeField] GameObject _infoTab;
        [Header("Events")]
        [SerializeField] SO_BaseEvent<string> _onIDAcquired;
        [SerializeField] SO_BaseEvent<NumberInfo> _onNumberAcquired;
        [SerializeField] SO_BaseEvent<string,NumberInfo> _onRegistrationRequest;
        [SerializeField] SO_BaseEvent<bool> _onRegistrationComplited;
        [SerializeField] SO_BaseEvent<bool> _onRegistrationTextState;


        string _savedID = "QrFBaDG1";
        NumberInfo _savedNumber;
        private void OnIDAcquired(string id){
            // _savedID = id;
            _getIDTab.SetActive(false);
            _registrationTab.SetActive(true);
        }
        private void OnNumberAcquired(NumberInfo number){
            _savedNumber = number;
            _onRegistrationRequest.Invoke(_savedID,number);
        }
        private void OnRegistrationComplited(bool state){
            _registrationTab.SetActive(false);
            _infoTab.SetActive(true);
            _onRegistrationTextState.Invoke(state);

        }
        private void OnEnable() {
            _onIDAcquired += OnIDAcquired;
            _onNumberAcquired += OnNumberAcquired;
            _onRegistrationComplited += OnRegistrationComplited;
        }
        private void OnDisable(){
            _onIDAcquired -= OnIDAcquired;
            _onNumberAcquired -= OnNumberAcquired;
            _onRegistrationComplited -= OnRegistrationComplited;
        }
    }
}