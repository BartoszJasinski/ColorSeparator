using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using ColorSeparator.Data;
using ColorSeparator.Utils;

namespace ColorSeparator
{
    public partial class ColorSeparator : Form
    {
        private ProgramData programData = new ProgramData();

        public ColorSeparator()
        {
            InitializeComponent();
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files|*.jpg|PNG Files|*.png|All Files|*.*";
            Stream fileStream = null;

            if (openFileDialog.ShowDialog() == DialogResult.OK && (fileStream = openFileDialog.OpenFile()) != null)
            {
                string fileName = openFileDialog.FileName;
                programData.loadedImage = Image.FromFile(fileName);
                programData.resizedImage = ImageAlgorithms.ResizeImage(programData.loadedImage, loadedImagePictureBox.Width, loadedImagePictureBox.Height);
                loadedImagePictureBox.Image = programData.resizedImage;
            }
        }

        private void ToGrayscaleButton_Click(object sender, EventArgs e)//TODO maybe i can add different grayscale computing methods
        {
            if (programData.loadedImage == null)
                return;

            loadedImagePictureBox.Image = ImageAlgorithms.Convert2Grayscale(programData.resizedImage);
        }

        private void saveOutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPG Files|*.jpg|PNG Files|*.png|All Files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                loadedImagePictureBox.Image.Save(saveFileDialog.FileName);
            }

        }
    }
}
