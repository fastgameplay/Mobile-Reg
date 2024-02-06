namespace MobileReg.Global
{
    using UnityEngine;
    using MobileReg.Data;
    using System.Collections;

    public class ObjectDisabler : MonoBehaviour
    {
        [SerializeField] SO_AppData _applicationData;

        [SerializeField] GameObject _objectToDisable;

        private IEnumerator DisableObject(){
            yield return new WaitForSeconds(_applicationData.DisableTextAfterTime);
            if(_objectToDisable == null) gameObject.SetActive(false);
            else _objectToDisable.SetActive(false);
        }
        private void OnEnable() {

        }
    }
}
