using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveNationWebAPI.Model
{
    public static class DictionaryReversion
    {
        public static Dictionary<B, A> Reverse<A,B>(Dictionary<A, B> dictionary){
            try
            {
                Dictionary<B, A> reversedDictionary = new Dictionary<B, A>();
                reversedDictionary = dictionary.ToDictionary(x => x.Value, x => x.Key);

                return reversedDictionary;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
