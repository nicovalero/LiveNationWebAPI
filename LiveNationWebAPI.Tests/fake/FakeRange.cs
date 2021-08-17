using LiveNationWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveNationWebAPI.Tests.fake
{
    public class FakeRange : IRange
    {
        private bool _isValidRangeResult;
        private List<int> _getSequenceResult;
        public bool IsValidRangeResult
        {
            get { return _isValidRangeResult; }
            set { _isValidRangeResult = value; }
        }
        public List<int> GetSequenceResult
        {
            get { return _getSequenceResult; }
            set { _getSequenceResult = value; }
        }

        public bool IsValidRange()
        {
            return _isValidRangeResult;
        }

        public List<int> GetSequence()
        {
            return _getSequenceResult;
        }
    }
}
