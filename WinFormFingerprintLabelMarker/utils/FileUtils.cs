using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormFingerprintLabelMarker.model;

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

                File.AppendAllLines(filePath, data);

            } else
            {
                using (StreamWriter outputFile = new StreamWriter(filePath))
                {
                    foreach (string line in data)
                        outputFile.WriteLine(line);
                }
            }            
            
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

                        Directory.CreateDirectory(folder);

                        folder = Path.Combine(folder, string.Format("{0}_{1}.{2}", g._imageName.Split('.')[0], image.Key.ToString()), format);

                        g._sing._image.Save(folder, ImageFormat.Bmp);

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
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
                
        public static Dictionary<SingularityType,List<GroundTruth>> buildImageData(Dictionary<String, List<GroundTruth>> map)
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
    }
}
