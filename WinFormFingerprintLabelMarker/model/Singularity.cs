using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormFingerprintLabelMarker.model
{
    class Singularity
    {
        public int _x { get; set; }
        public int _y { get; set; }
        public Image _image { get; set; }
        public SingularityType _type { get; set; }        

        public Singularity(int x, int y, SingularityType type)
        {
            _x = x;
            _y = y;
            _type = type;                       
        }

        public static int getValidPoint(int bound, int position)
        {
            if (position >= 0 && position <= bound)
            {
                return position;

            }
            else if (position < 0)
            {
                return 0;

            }
            else if (position > bound)
            {
                return bound;

            }

            return 0;
        }
    }

    enum SingularityType
    {
        None,
        Core = 1,
        Delta = 2,
        Neg = 3,
    }

}
