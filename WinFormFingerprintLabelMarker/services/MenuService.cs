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
            List<string> files = null;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string[] paths = Directory.GetFiles(folderBrowser.SelectedPath);//@"C:\Users\ricar\Downloads\spd_train_dataset\DataBase_0001_0210");

                files = new List<string>();

                foreach (string path in paths)
                {
                    files.Add(Path.GetFileName(path));
                }

                return files.ToArray();
            }

            return null;
        }

        public string getDatasetName(string path)
        {
            string[] folders = path.Split(Path.DirectorySeparatorChar);
            return folders[folders.Length - 1];
        }

        public string loadCheckPointFile(OpenFileDialog openFile, PictureBox image, string path)
        {
            string result = null;

            if (openFile.ShowDialog() == DialogResult.OK)
            {   
                string [] data = File.ReadAllLines(openFile.FileName);
                string[] txt = null;
                List<GroundTruth> list = new List<GroundTruth>();
                GroundTruth gt = new GroundTruth();
                Dictionary<String, List<GroundTruth>> dd = new Dictionary<string, List<GroundTruth>>();

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].CompareTo("") == 0)
                        continue;

                    txt = data[i].Split(FileUtils._token);

                    if (txt.Length == 1 && txt[0].CompareTo("") != 0)
                    {
                        result = txt[0].Trim();

                        i++;

                        while (i < data.Length && data[i].CompareTo("") != 0)
                        {                            
                            txt = data[i].Split(FileUtils._token);
                            
                            //TODO: restaurar sig.img

                            gt._sing._x = int.Parse(txt[0]);
                            gt._sing._y = int.Parse(txt[1]);
                            gt._sing._type = Singularity.stringToSingType(txt[2].Trim());
                            addGroundTruth(dd, result, gt);

                            i++;
                        }
                    } 
                }

                //foreach (Singularity s in list)
                //{
                //    if (image.Image == null)
                //    {
                //        image.Image = new Bitmap(path + Path.DirectorySeparatorChar + result);
                //        storeCurrentImage(image.Image);
                //        image.Width = image.Image.Width;
                //        image.Height = image.Image.Height;
                //    }

                //    markArea(image, s);
                //}

            }

            return result;
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
               
        public void computeMousePosition(MouseEventArgs e, Label lb1, Label lb2)
        {
            lb1.Text = string.Format("({0},{1})", e.X, e.Y);
            lb2.Text = string.Format("({0},{1})", e.X + GraphicsUtils.offset, e.Y + GraphicsUtils.offset);            
        }

        public void storeCurrentImage(Image img)
        {
            GraphicsUtils._currentImage = img;
        }

        public Image getCurrentImage()
        {
            return GraphicsUtils._currentImage;
        }

        public Image resetCurrentLabels(Dictionary<String, List<GroundTruth>> map, string nameImage)
        {
            List<GroundTruth> l;
            if (map.TryGetValue(nameImage, out l))
            {
                map.Remove(nameImage);
            }

            return getCurrentImage();
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

        public void saveGroundTruth(FolderBrowserDialog folderBrowser, Dictionary<String, List<GroundTruth>> map, string datasetName)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {

                List<string> data = FileUtils.buildTextData(map);

                string path = Path.Combine(folderBrowser.SelectedPath, datasetName);

                FileUtils.prepareFolder(path);

                FileUtils.writeTxtFile(data, datasetName, path);

                Dictionary<SingularityType, List<GroundTruth>> images = FileUtils.buildImageData(map);

                FileUtils.saveImages(images, path, "bmp");

                map.Clear();

            }

        }

        public Image markArea(PictureBox image, Singularity sing)
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
