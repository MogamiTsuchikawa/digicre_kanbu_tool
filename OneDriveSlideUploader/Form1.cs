using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneDriveSlideUploader
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void SlideListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void SlideListBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach(var file in files)
            {
                var slideData = new SlideData(file);
                SlideData.slideDatas.Add(slideData);
                slideListView.Items.Add(new ListViewItem(new string[] {slideData.filePath,slideData.status.ToString() }));
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void connectCheckBtn_Click(object sender, EventArgs e)
        {
            SlideData.SetupOneDrive(Handle,pathTextBox.Text);
        }
    }
}
