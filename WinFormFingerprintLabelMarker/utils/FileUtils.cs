using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormFingerprintLabelMarker.model;
using WinFormFingerprintLabelMarker.services;

namespace WinFormFingerprintLabelMarker.utils
{
    class FileUtils
    {
        private static readonly string _headerFormat = "{0}";

        private static readonly string _bodyFormat = "{0};{1};{2};{3}";

        public static readonly char _token = ';';

        public static void writeTxtFile(List<string> data, string nameFile, string path)
        {
            string filePath = Path.Combine(path, string.Format("{0}.txt", nameFile));
            if (File.Exists(filePath))
            {

                File.Delete(filePath);

            }

            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                foreach (string line in data)
                    outputFile.WriteLine(line);
            }


        }

        public static void prepareFolder(string path)
        {
            Directory.CreateDirectory(path);
        }

        public static void saveImages(Dictionary<SingularityType, List<GroundTruth>> images, string path, string format)
        {
            string folder = null;

            try
            {
                foreach (var image in images)
                {
                    foreach (var g in image.Value)
                    {
                        folder = Path.Combine(path, image.Key.ToString());

                        FileUtils.prepareFolder(folder);
                        string s = string.Format("{0}_{1}_{2}_{3}.{4}", g._imageName.Split('.')[0], image.Key.ToString(), g._sing._x, g._sing._y, format);
                        folder = Path.Combine(folder, s);

                        if (!File.Exists(folder))
                        {
                            g._sing._image.Save(folder, ImageFormat.Bmp);

                        }


                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        public static List<string> buildTextData(Dictionary<String, List<GroundTruth>> map)
        {
            List<string> data = new List<string>();

            string headerData = null;
            StringBuilder bodyData = null;

            foreach (var item in map)
            {
                headerData = string.Format(FileUtils._headerFormat, item.Key);

                bodyData = new StringBuilder();

                foreach (GroundTruth g in item.Value)
                {
                    bodyData.Append(string.Format(FileUtils._bodyFormat, g._sing._x, g._sing._y, g._sing._type.ToString(), Environment.NewLine));
                }

                data.Add(string.Format("{0}{1}{2}", headerData, Environment.NewLine, bodyData.ToString()));

            }

            return data;
        }

        public static Dictionary<SingularityType, List<GroundTruth>> buildImageData(Dictionary<String, List<GroundTruth>> map)
        {
            Dictionary<SingularityType, List<GroundTruth>> data = new Dictionary<SingularityType, List<GroundTruth>>();

            List<GroundTruth> l;
            foreach (var item in map)
            {
                foreach (GroundTruth g in item.Value)
                {
                    if (!data.TryGetValue(g._sing._type, out l))
                    {
                        l = new List<GroundTruth>();
                        data.Add(g._sing._type, l);
                    }

                    l.Add(g);
                }

            }

            return data;
        }

        public static Dictionary<String, List<GroundTruth>> buildDataFromFile(string pathFile, string pathDataset)
        {
            string[] data = File.ReadAllLines(pathFile);
            string[] txt = null;
            string imgName = null;
            string dbName = new DirectoryInfo(pathDataset).Name;
            GroundTruth gt = null;
            Dictionary<String, List<GroundTruth>> groundTruth = new Dictionary<string, List<GroundTruth>>();

            MenuService menuService = new MenuService();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].CompareTo("") == 0)
                    continue;

                txt = data[i].Split(FileUtils._token);

                if (txt.Length == 1)
                {
                    imgName = txt[0].Trim();


                    i++;

                    while (i < data.Length && data[i].CompareTo("") != 0)
                    {
                        txt = data[i].Split(FileUtils._token);
                        gt = new GroundTruth();

                        gt._sing._x = int.Parse(txt[0]);
                        gt._sing._y = int.Parse(txt[1]);
                        gt._sing._type = Singularity.stringToSingType(txt[2].Trim());
                        gt._datasetName = dbName;
                        gt._imageName = imgName;


                        string[] file = imgName.Split('.');
                        string rectImgName = string.Format("{0}_{1}_{2}_{3}.{4}", file[0], gt._sing._type.ToString(), gt._sing._x, gt._sing._y, file[1]);
                        string p = Path.Combine(pathDataset, gt._sing._type.ToString(), rectImgName);
                        if (File.Exists(p))
                        {
                            gt._sing._image = new Bitmap(p);

                        }
                        else
                        {
                            p = p = Path.Combine(pathDataset, imgName);
                            Bitmap b = new Bitmap(p);
                            Rectangle rect = GraphicsUtils.getRectFromSing(gt._sing, b.Width, b.Height);
                            gt._sing._image = b.Clone(rect, b.PixelFormat);
                        }

                        menuService.addGroundTruth(groundTruth, imgName, gt);

                        i++;
                    }
                }
            }

            return groundTruth;
        }
    }
}
