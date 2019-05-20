using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTEKT_Side_Gear
{
    class I_MR_List<I_MR_Point> : IList<I_MR_Point>
    {
        //Interface IList
        public I_MR_Point this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => this.Count();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(I_MR_Point item)
        {
            this.Add(item);
        }

        public void Clear()
        {
            this.Clear();
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
            throw new NotImplementedException();
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


    }
}
