
namespace MobileReg.Global
{
    using MobileReg.Data;
    using UnityEngine;
    using System.Collections;
    using System;
    public class IDAcquisition : MonoBehaviour
    {
        [SerializeField] SO_UrlInfo _urlInfo;
        void Start()
        {
            StartCoroutine(GetKeyFromServer());
        }

        IEnumerator GetKeyFromServer() {
            using (WWW www = new WWW(_urlInfo.URL)) {
                yield return www;

                if (string.IsNullOrEmpty(www.error)) {
                    ProcessJSON(www.text);
                }
                else {
                    Debug.Log("Error: " + www.error);
                }
            }
        }

        void ProcessJSON(string jsonString){
            try {
                // Разбираем JSON-ответ
                JSONObject jsonObject = new JSONObject(jsonString);

                // Проверяем наличие ключа "Keys" в ответе
                if (jsonObject.HasField("Keys"))
                {
                    JSONObject keysObject = jsonObject.GetField("Keys");

                    // Проверяем наличие массива ключей
                    if (keysObject.IsArray)
                    {
                        foreach (JSONObject keyObject in keysObject.list)
                        {
                            // Получаем значение ключа "Key"
                            string key = keyObject.GetField("Key").str;

                            // Извлекаем "ID" из ключа "Key"
                            string id = ExtractID(key);

                            // Используем полученный "ID" для дальнейших действий
                            Debug.Log("ID: " + id);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("Error while processing JSON: " + e.Message);
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
