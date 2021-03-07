using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CDS.DynamicAPI.Mockup
{
    public class DataCollection<T> : Collection<T>
    {
        public void AddRange(params T[] items)
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
        public void AddRange(IEnumerable<T> items)
        {
            AddRange(items); 
        }
        public T[] ToArray()
        {
            var resultArray = new T[Items.Count];
            for(int i=0;i<Items.Count;i++)
            {
                resultArray[i] = Items[i];
            }
            return resultArray;
        }
    }
}
