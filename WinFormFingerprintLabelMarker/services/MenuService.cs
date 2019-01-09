using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormFingerprintLabelMarker.model;
using WinFormFingerprintLabelMarker.utils;

namespace WinFormFingerprintLabelMarker.services
{
    class MenuService
    {
        public string[] loadDataset(FolderBrowserDialog folderBrowser)
        {
            List<string> files = new List<string>();

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string [] paths = Directory.GetFiles(@"C:\Users\ricar\Downloads\spd_train_dataset\DataBase_0001_0210");

                foreach (string path in paths)
                {
                    files.Add(Path.GetFileName(path));
                }
                
                return files.ToArray();
            }

            return null;
        }

        public Singularity markLabel(MouseEventArgs e, PictureBox image)
        {
            SingularityType type = SingularityType.None;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    type = SingularityType.Core;
                    break;
                case MouseButtons.Middle:
                    type = SingularityType.Delta;
                    break;
                case MouseButtons.Right:
                    type = SingularityType.Neg;
                    break;
            }

            Singularity sing = new Singularity(e.X, e.Y, type);

            sing._image = markArea(image, sing);

            return sing;
        }

        public string getMousePosition(MouseEventArgs e)
        {
            return string.Format("(x, y) - ({0},{1})  (width, height) - ({2}, {3})", e.X, e.Y, e.X+GraphicsUtils.offset, e.Y+GraphicsUtils.offset);
        }

        public void storeCurrentImage(Image img)
        {
            GraphicsUtils._currentImage = img;
        }

        public Image getCurrentImage()
        {
            return GraphicsUtils._currentImage;
        }

        public void addGroundTruth(Dictionary<String, List<GroundTruth>> map, string nameImage, GroundTruth g)
        {
            List<GroundTruth> l;
            if(!map.TryGetValue(nameImage, out l))
            {
                map.Add(nameImage, new List<GroundTruth>());
            }
                        
            map[nameImage].Add(g);
        }

        public void removeLastSingularity(Dictionary<String, List<GroundTruth>> map, string nameImage)
        {
            map[nameImage].RemoveAt(map[nameImage].Count - 1);
        }

        private Image markArea(PictureBox image, Singularity sing)
        {
            try
            {
                                
                return GraphicsUtils.drawRectangle(image, sing);

            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }
    }
}
