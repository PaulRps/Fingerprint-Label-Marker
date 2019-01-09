using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormFingerprintLabelMarker.model
{
    class GroundTruth
    {
        public string _imageName { get; set; }
        public string _datasetName { get; set; }
        public Singularity _sing { get; set; }

        public GroundTruth(string imageName, string datasetName, Singularity sing)
        {
            _imageName = imageName;
            _datasetName = datasetName;
            _sing = sing;

        }
    }
}
