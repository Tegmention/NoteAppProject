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
            int compareDate = x.LastModTime.CompareTo(y.LastModTime);
            return -compareDate;
        }
    }
}
