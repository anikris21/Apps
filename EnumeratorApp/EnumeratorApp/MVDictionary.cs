using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorApp
{
    // IEnumerable<KeyValuePair>
    internal class MVDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        Dictionary<K,  List<V>> dictionary;

        public MVDictionary() { }

        IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            return dictionary.GetEnumerator();
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
