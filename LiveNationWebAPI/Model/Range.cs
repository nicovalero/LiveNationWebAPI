using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveNationWebAPI.Model
{
    public interface IRange
    {
        public bool IsValidRange();
        public List<int> GetSequence();
    }
    public class Range : IRange
    {
        private string _start;
        private string _end;

        public Range(string start, string end)
        {
            _start = start;
            _end = end;
        }

        public int? GetStartAsInt()
        {
            try
            {
                if (_start != null)
                {
                    int startInteger;
                    int.TryParse(_start, out startInteger);
                    return startInteger;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int? GetEndAsInt()
        {
            try
            {
                if (_end != null)
                {
                    int endInteger;
                    int.TryParse(_end, out endInteger);
                    return endInteger;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IsValidRange()
        {
            try
            {
                int? startInteger = GetStartAsInt();
                int? endInteger = GetEndAsInt();

                if (startInteger != null && endInteger != null)
                {
                    if (startInteger <= endInteger)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> GetSequence()
        {
            int? startInteger = GetStartAsInt();
            int? endInteger = GetEndAsInt();
            if (startInteger != null && endInteger != null)
                return Enumerable.Range(startInteger.Value, endInteger.Value - startInteger.Value + 1).ToList();
            else
                return null;
        }
    }
}
