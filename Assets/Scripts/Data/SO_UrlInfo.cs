namespace MobileReg.Data{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "Url Info", menuName = "Data/URL")]
    public class SO_UrlInfo : ScriptableObject
    {
        public string URL => _url;
        [SerializeField] private string _url;
    }

}

