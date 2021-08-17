
namespace LiveNationWebAPI.Model
{
    public class Rule
    {
        private string _key;
        private string _value;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Rule(string key, string value)
        {
            _key = key;
            _value = value;
        }
    }
}
