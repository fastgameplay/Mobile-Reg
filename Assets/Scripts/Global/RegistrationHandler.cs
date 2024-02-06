namespace MobileReg.Global
{
    using System.Collections;
    using MobileReg.Data;
    using ScriptableEvents;
    using UnityEngine;
    using UnityEngine.Networking;

    public class RegistrationHandler : MonoBehaviour
    {
        [SerializeField] private SO_UrlInfo _checkURL;
        [SerializeField] private SO_UrlInfo _registerURL;
        [SerializeField] private SO_BaseEvent<string, NumberInfo> _onRegistrationRequest;
        [SerializeField] private SO_BaseEvent<bool> _onRegistrationCompleted;




        IEnumerator CheckUser(string id, NumberInfo number) {
            var form = new WWWForm();
            form.AddField("ID", id);
            form.AddField("Phone", number.FullNumber);

            using (UnityWebRequest www = UnityWebRequest.Post(_checkURL.URL, form)) {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success) {
                    ProcessCheckResponse(www.downloadHandler.text, id, number);
                }
                else {
                    Debug.LogError("Error: " + www.error);
                    _onRegistrationCompleted.Invoke(false);
                }
            }
        }

        IEnumerator RegisterUser(string id, NumberInfo number) {
            Debug.Log("Started Registration");
            var form = new WWWForm();
            form.AddField("ID", id);
            form.AddField("Country", number.CountryCode);
            form.AddField("Operator", number.OperatorCode);
            form.AddField("Number", number.FullNumber);
            print(form);
            using (UnityWebRequest www = UnityWebRequest.Post(_registerURL.URL, form)) {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success) {
                    
                    ProcessRegisterResponse(www.downloadHandler.text);
                }
                else {
                    Debug.LogError("Error: " + www.error);
                }
            }
        }

        private void ProcessCheckResponse(string response, string id, NumberInfo number) {
            Debug.Log(response);
            if (response.Equals("NoExist")) {
                StartCoroutine(RegisterUser(id, number));
            }
            else {
                Debug.Log("User Already Exists");
                _onRegistrationCompleted.Invoke(false);
            }
        }

        private void ProcessRegisterResponse(string response) {
            Debug.Log(response);

            bool registrationSuccess = response.Equals("RegOK");

            _onRegistrationCompleted.Invoke(registrationSuccess);
        }

        private void OnRegistrationRequest(string id, NumberInfo number) {
            StartCoroutine(CheckUser(id, number));
        } 

        private void OnEnable() {
            _onRegistrationRequest += OnRegistrationRequest;
        } 

        private void OnDisable() {
            _onRegistrationRequest -= OnRegistrationRequest;
        } 
    }
}