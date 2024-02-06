namespace MobileReg.Global
{
    using UnityEngine;
    using UnityEngine.Networking;
    using Newtonsoft.Json.Linq; 
    using System;
    using System.Collections;
    using MobileReg.Data;
    using ScriptableEvents;

    public class IDAcquisition : MonoBehaviour
    {
        [SerializeField] SO_UrlInfo _urlInfo;
        [SerializeField] SO_BaseEvent<string> _onIDAcquired;
        [SerializeField] SO_BaseEvent<bool> _onIDAcquisitionTextState;
        public void StartAcquisition() {
            StartCoroutine(GetKeyFromServer());
        }

        IEnumerator GetKeyFromServer() {
            using (UnityWebRequest www = UnityWebRequest.Get(_urlInfo.URL)) {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success) {
                    ProcessJSON(www.downloadHandler.text);
                }
                else {
                    Debug.Log("Error: " + www.error);
                    _onIDAcquisitionTextState.Invoke(false);
                }
            }
        }

        void ProcessJSON(string jsonString){
            try {
                // Разбираем JSON-ответ с помощью JSON.NET
                JObject jsonObject = JObject.Parse(jsonString);

                // Получаем массив ключей "Keys"
                JArray keysArray = (JArray)jsonObject["Keys"];

                // Перебираем элементы массива
                foreach (JObject keyObject in keysArray.Children<JObject>()) {

                    // Получаем значение ключа "Key"
                    string key = keyObject["Key"].ToString();
                    if(key == "No Key") continue;
                    // Извлекаем "ID" из ключа "Key"
                    string id = ExtractID(key);

                    _onIDAcquired.Invoke(id);
                    _onIDAcquisitionTextState.Invoke(true);
                    
                    break;
                }
            }
            catch (Exception e) {
                Debug.Log("Error while processing JSON: " + e.Message);
                _onIDAcquisitionTextState.Invoke(false);
            }
        }

        string ExtractID(string key)
        {
            string id = "";

            // Извлекаем каждый второй символ из ключа "Key"
            for (int i = 1; i < key.Length; i += 2)
            {
                id += key[i];
            }

            return id;
        }

    }
    
}
