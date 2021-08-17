using LiveNationWebAPI.Model;
using System.Collections.Generic;

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
