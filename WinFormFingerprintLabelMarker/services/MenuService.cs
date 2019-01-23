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
                string supportedExtensions = "*.png,*.bmp,*.jpeg,*.tif";
                var paths = Directory.GetFiles(folderBrowser.SelectedPath, "*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower()));

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

        public SortedDictionary<String, List<GroundTruth>> loadCheckPointFile(OpenFileDialog openFile, PictureBox image, string path)
        {            
            SortedDictionary<String, List<GroundTruth>> dd = null;
            
            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                dd = FileUtils.buildDataFromFile(openFile.FileName, path);                

            }
            openFile.Filter = "";
            return dd;
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

        public Image resetCurrentLabels(SortedDictionary<String, List<GroundTruth>> map, string nameImage)
        {
            List<GroundTruth> l;
            if (map.TryGetValue(nameImage, out l))
            {
                map.Remove(nameImage);
            }

            return getCurrentImage();
        }

        public void addGroundTruth(SortedDictionary<String, List<GroundTruth>> map, string nameImage, GroundTruth g)
        {
            List<GroundTruth> l;
            if (!map.TryGetValue(nameImage, out l))
            {
                map.Add(nameImage, new List<GroundTruth>());
            }

            map[nameImage].Add(g);
        }

        public void removeLastSingularity(SortedDictionary<String, List<GroundTruth>> map, string nameImage)
        {
            List<GroundTruth> l;
            if (map.TryGetValue(nameImage, out l))
            {
                map[nameImage].RemoveAt(map[nameImage].Count - 1);
            }
        }

        public void saveGroundTruth(FolderBrowserDialog folderBrowser, SortedDictionary<String, List<GroundTruth>> map, string datasetName)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {

                List<string> data = FileUtils.buildTextData(map);

                string path = Path.Combine(folderBrowser.SelectedPath, datasetName);

                FileUtils.prepareFolder(path);

                FileUtils.writeTxtFile(data, datasetName, path);

                SortedDictionary<SingularityType, List<GroundTruth>> images = FileUtils.buildImageData(map);

                FileUtils.saveImages(images, path, "bmp");

                map.Clear();

            }

        }

        public Image markArea(PictureBox image, Singularity sing)
        {
            return GraphicsUtils.drawRectangle(image, sing);
        }

        public void updateLabelsCount(SortedDictionary<String, List<GroundTruth>> map, Label core, Label delta, Label neg)
        {
            if (map == null)
                return;

            int c = 0;
            int d = 0;
            int n = 0;

            foreach (var item in map)
            {
                foreach (var g in item.Value)
                {
                    if (SingularityType.Core == g._sing._type)
                        c++;
                    else if (SingularityType.Delta == g._sing._type)
                        d++;
                    else if (SingularityType.Neg == g._sing._type)
                        n++;
                }
            }

            core.Text = c.ToString();
            delta.Text = d.ToString();
            neg.Text = n.ToString();
        }
    }
}
