using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTSpiceThemer
{
    internal class Theme
    {
        public string Name { get; set; }
        public Color Wires { get; set; }
        public Color Junctions { get; set; }
        public Color CmpBody { get; set; }
        public Color GpcFlag { get; set; }
        public Color CmpFill { get; set; }
        public Color CmpTxt { get; set; }
        public Color FlgTxt { get; set; }
        public Color SpcDir { get; set; }
        public Color Comment { get; set; }
        public Color Unconnected { get; set; }
        public Color Highlight { get; set; }
        public Color Grid { get; set; }
        public Color GpcAnn { get; set; }
        public Color Back { get; set; }

        public int Code_Wires { get; set; }
        public int Code_Junctions { get; set; }
        public int Code_CmpBody { get; set; }
        public int Code_GpcFlag { get; set; }
        public int Code_CmpFill { get; set; }
        public int Code_CmpTxt { get; set; }
        public int Code_FlgTxt { get; set; }
        public int Code_SpcDir { get; set; }
        public int Code_Comment { get; set; }
        public int Code_Unconnected { get; set; }
        public int Code_Highlight { get; set; }
        public int Code_Grid { get; set; }
        public int Code_GpcAnn { get; set; }
        public int Code_Back { get; set; }
    }
}