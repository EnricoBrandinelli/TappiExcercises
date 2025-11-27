using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.Cell
{
    public class BackupCell:Cell
    {
        private int OldVal;

        public BackupCell(int v):base(v)
        {
            OldVal = 0;
        }
        
        public BackupCell() : this(0) { }

        public override void SetVal(int v)
        {
            OldVal = getVal();
            base.SetVal(v);
        }

        public override void Clear()
        {
            OldVal = getVal();
            base.Clear();
        }

        public void Restore()
        {
            int tmp = getVal();
            base.SetVal(OldVal);
            OldVal = tmp;
        }



    }
}
