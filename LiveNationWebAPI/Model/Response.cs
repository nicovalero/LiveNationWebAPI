using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveNationWebAPI.Model
{
    public class Response
    {
        private string _result;
        private Dictionary<string, string> _summary;

        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public Dictionary<string, string> Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
    }
}
