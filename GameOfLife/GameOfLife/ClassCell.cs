using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class ClassCell:PictureBox
    {
        public ClassCell()
        {
            Width = 20; 
            Height = 20;
            BackColor = Color.Gray;
            BorderStyle= BorderStyle.FixedSingle;
        }
    }
}
