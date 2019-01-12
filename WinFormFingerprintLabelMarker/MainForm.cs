﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormFingerprintLabelMarker.model;
using WinFormFingerprintLabelMarker.services;
using WinFormFingerprintLabelMarker.utils;

namespace WinFormFingerprintLabelMarker
{
    public partial class MainForm : Form
    {
        private MenuService _menuService;

        private string _folderPath;

        private string _datasetName;

        private Dictionary<String, List<GroundTruth>> _groundTruth;

        private Image _lastImage;

        public MainForm()
        {
            InitializeComponent();

            _menuService = new MenuService();
            _groundTruth = new Dictionary<string, List<GroundTruth>>();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
           string [] files = _menuService.loadDataset(folderBrowser);
            
            if (files != null)
            {
                listBoxImageNames.DataSource = files;
                _folderPath = folderBrowser.SelectedPath;//@"C:\Users\ricar\Downloads\spd_train_dataset\DataBase_0001_0210";
                string [] folders =_folderPath.Split(Path.DirectorySeparatorChar);
                _datasetName = folders[folders.Length-1];
            }
        }

        private void listBoxImageNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxImageNames.SelectedItem.ToString() != null && _folderPath != null)
            {
                pictureBoxImage.Image = new Bitmap(_folderPath + Path.DirectorySeparatorChar + listBoxImageNames.SelectedItem.ToString());
                _menuService.storeCurrentImage(pictureBoxImage.Image);
                pictureBoxImage.Width = pictureBoxImage.Image.Width;
                pictureBoxImage.Height = pictureBoxImage.Image.Height;
            }
        }
                

        private void pictureBoxImage_MouseClick(object sender, MouseEventArgs e)
        {
            _lastImage = pictureBoxImage.Image;

            Singularity sing = _menuService.markLabel(e, pictureBoxImage);

            try
            {

                _menuService.addGroundTruth(_groundTruth, listBoxImageNames.SelectedItem.ToString(), new GroundTruth(listBoxImageNames.SelectedItem.ToString(), _datasetName, sing));

                if (sing._image != null)
                {
                    pictureBoxPreviewedImage.Image = sing._image;
                }
                
            } catch (OutOfMemoryException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            if (_groundTruth.Count > 0 && _lastImage != null)
            {
                pictureBoxImage.Image = _lastImage;

                _menuService.removeLastSingularity(_groundTruth, listBoxImageNames.SelectedItem.ToString());
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (listBoxImageNames.SelectedItem != null)
            {

                listBoxImageNames.SelectedItem = listBoxImageNames.Items[listBoxImageNames.SelectedIndex + 1];
                _lastImage = null;

            }
        }

        private void pictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            _menuService.computeMousePosition(e, labelUpperLeftPoint, labelBottomRightPoint);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Image = _menuService.resetCurrentLabels(_groundTruth, listBoxImageNames.SelectedItem.ToString());
        }

        private void saveGroundTruthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_groundTruth != null && _groundTruth.Count > 0)
            {
                _menuService.saveGroundTruth(folderBrowser, _groundTruth, _datasetName);
            }
        }

        private void loadCheckpointFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imgName = null;

            if (_folderPath != null)
            {
                imgName = _menuService.loadCheckPointFile(openFileDialog, pictureBoxImage, _folderPath);
            }

            if (imgName == null || listBoxImageNames == null || listBoxImageNames.Items.Count == 0)
            {
                MessageBox.Show("Load the dataset to continue marking!");

            } else
            {
                listBoxImageNames.SelectedItem = imgName;
            }
        }
    }
}
