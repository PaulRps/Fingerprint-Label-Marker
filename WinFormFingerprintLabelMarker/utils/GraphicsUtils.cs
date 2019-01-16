using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormFingerprintLabelMarker.model;

namespace WinFormFingerprintLabelMarker.utils
{
    class GraphicsUtils
    {
        public Pen _bluePen { get; set; }
        public Pen _greenPen { get; set; }
        public Pen _redPen { get; set; }
        public static Image _currentImage { get; set; }
        private static GraphicsUtils _instance;
        public static readonly int offset = 25;

        private GraphicsUtils()
        {
            _bluePen = new Pen(Color.Blue, 3);
            _greenPen = new Pen(Color.LightBlue, 3);
            _redPen = new Pen(Color.Crimson, 3);            
        }

        private static GraphicsUtils getInstance()
        {
            if (_instance == null)
            {
                _instance = new GraphicsUtils();
            }

            return _instance;
        }

        private Pen getPen(Singularity sing)
        {
            switch (sing._type)
            {
                case SingularityType.Core:
                    return GraphicsUtils.getInstance()._bluePen;                    
                case SingularityType.Delta:
                    return GraphicsUtils.getInstance()._greenPen;
                    break;
                case SingularityType.Neg:
                    return GraphicsUtils.getInstance()._redPen;
                    break;
            }

            return null;
        }
        
        public static Image drawRectangle(PictureBox image, Singularity sing)
        {
            if (image.Image == null)
            {
                return null;
            }

            Bitmap img = new Bitmap(image.Image);
            Graphics graphic = Graphics.FromImage(img);

            //int width = (2 * GraphicsUtils.offset);
            //int height = (2 * GraphicsUtils.offset);            
            //int x = Singularity.getValidPoint(img.Width, sing._x - GraphicsUtils.offset);
            //int y = Singularity.getValidPoint(img.Height, sing._y - GraphicsUtils.offset);

            //if (x+width > img.Width || y + height > img.Height)
            //{

            //    throw new OutOfMemoryException("The selected area is bigger then image bounds");

            //} 

            Rectangle rect = GraphicsUtils.getRectFromSing(sing, img.Width, img.Height);

            graphic.DrawRectangle(GraphicsUtils.getInstance().getPen(sing), rect);

            image.Image = img;

            return ((Bitmap) _currentImage).Clone(rect, img.PixelFormat);
        }

        public static Rectangle getRectFromSing(Singularity sing, int boundWidth, int boundHeight)
        {
            int width = (2 * GraphicsUtils.offset);
            int height = (2 * GraphicsUtils.offset);
            int x = Singularity.getValidPoint(boundWidth, sing._x - GraphicsUtils.offset);
            int y = Singularity.getValidPoint(boundHeight, sing._y - GraphicsUtils.offset);

            if (x + width > boundHeight || y + height > boundHeight)
            {

                throw new OutOfMemoryException("The selected area is bigger then image bounds");

            }

            return new Rectangle(x, y, width, height); 
        }
    }
}
