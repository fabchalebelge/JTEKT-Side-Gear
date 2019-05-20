using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTEKT_Side_Gear
{
    class I_MR_List : IList<I_MR_Point>
    {
        //Interface IList
        private List<I_MR_Point> _list = new List<I_MR_Point>();

        public I_MR_Point this[int index] { get => _list[index]; set => _list[index] = value; }

        public int Count { get => _list.Count(); }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(I_MR_Point item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(I_MR_Point item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(I_MR_Point[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<I_MR_Point> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(I_MR_Point item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, I_MR_Point item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(I_MR_Point item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //Spécialisation
        public double AvgI { get => (double)_list.Sum(item => item.I) / _list.Count(); }

    }
}
