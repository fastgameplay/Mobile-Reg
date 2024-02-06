namespace MobileReg.Global
{
    using UnityEngine;
    using MobileReg.Data;
    using System.Collections.Generic;
    using System.Collections;
    using UnityEngine.Networking;
    using MobileReg.UI;
    using ScriptableEvents;

    public class ListTab : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private SO_BaseEvent<string> _onPhoneTextChange;
        [Space(10)]
        [Header("Reference")]
        [SerializeField] private SO_UrlInfo _howMany;
        [SerializeField] private SO_UrlInfo _phoneNumbers;
        [Space(10)]
        [SerializeField] private Transform _contentPanel;
        [SerializeField] private InfoPanel _infoPrefab;
        private int currentNumberOfPeople = 0;
        private List<string> numbersList = new List<string>();

        void Start()
        {

            UpdateList();
        }

        IEnumerator GetNumberOfPeople() {
            using (UnityWebRequest www = UnityWebRequest.Get(_howMany.URL)) {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success) {
                    _onPhoneTextChange.Invoke(www.downloadHandler.text);
                }
                else {
                    Debug.Log("Error: " + www.error);
                }
            }
        }

        public void UpdateList() {
            StartCoroutine(GetNumberOfPeople());

            foreach (Transform child in _contentPanel) {
                Destroy(child.gameObject);
            }
            StartCoroutine(GenerateNewRectangles());

            for (int i = 0; i < currentNumberOfPeople; i++)
            {
                InfoPanel newRectangle = Instantiate(_infoPrefab, _contentPanel);
            }
        }

        IEnumerator GenerateNewRectangles() {
            using (UnityWebRequest www = UnityWebRequest.Get(_phoneNumbers.URL)) {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success) {
                    string[] numbers = www.downloadHandler.text.Split(' ');
                    for (int i = 0; i < numbers.Length-1; i++) {
                        InfoPanel newRectangle = Instantiate(_infoPrefab, _contentPanel);
                        newRectangle.Text = $"{i+1}) {numbers[i]}";
                    }
                }
                else {
                    Debug.Log("Error: " + www.error);
                }
            }
        }
    }
}