using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    class NoteComparer : IComparer<Note>
    {
        public int Compare(Note x, Note y)
        {
            if (x.LastModTime > y.LastModTime)
            {
                return -1;
            }
            else if(x.LastModTime < y.LastModTime)
            {
                return 1;
            }
            return 0;
            //throw new NotImplementedException();
        }
    }
}
