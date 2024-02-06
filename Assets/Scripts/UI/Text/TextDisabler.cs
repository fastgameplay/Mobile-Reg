namespace MobileReg.UI
{
    using UnityEngine;
    using TMPro;
    using MobileReg.Data;
    using System.Collections;
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextDisabler : MonoBehaviour
    {
        [SerializeField] SO_AppData _applicationData;

        [SerializeField] TextMeshProUGUI _objectToDisable;
        private void Awake() {
            if(_objectToDisable == null) _objectToDisable = GetComponent<TextMeshProUGUI>();
        }
        private IEnumerator DisableObject(){
            yield return new WaitForSeconds(_applicationData.DisableTextAfterTime);
            
            _objectToDisable.enabled = false;
        }
        public void DisableTextObject() {
            StartCoroutine("DisableObject");
        }
    }
}
