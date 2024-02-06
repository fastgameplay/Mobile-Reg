namespace MobileReg.Global
{
    public struct NumberInfo
    {
        public string FullNumber {get; private set;}
        public string CountryCode  {get; private set;}
        public string OperatorCode {get; private set;}
        public string PhoneNumber  {get; private set;}
        public NumberInfo(string countryCode, string operatorCode, string phoneNumber){
            CountryCode = $"+{countryCode}";
            OperatorCode = operatorCode;
            PhoneNumber = phoneNumber;
            FullNumber = $"{CountryCode}({OperatorCode}){PhoneNumber}";
        }
    }
}