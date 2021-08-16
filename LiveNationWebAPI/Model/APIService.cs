using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveNationWebAPI.Model
{
    public interface IAPIService
    {
        public string CreateRangeResponse(Range range);
        public List<Rule> GetRules();
    }
    public class APIService: IAPIService
    {
        public string CreateRangeResponse(Range range)
        {
            if (range.IsValidRange())
            {
                int? start = range.GetStartAsInt();
                int? end = range.GetEndAsInt();
                List<int> sequence = Enumerable.Range(start.Value, end.Value - start.Value + 1).ToList();
                StringBuilder result = new StringBuilder();

                foreach(int number in sequence)
                {
                    if (number % 3 != 0 && number % 5 != 0)
                        result.Append(number.ToString());
                    else
                    {
                        if (number % 3 == 0)
                            result.Append("Live");
                        if (number % 5 == 0)
                            result.Append("Nation");
                    }
                    result.Append(" ");
                }

                return result.ToString();
            }
            else
                return null;
        }

        public List<Rule> GetRules()
        {
            return null;
        }
    }
}
