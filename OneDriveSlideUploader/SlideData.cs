using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;

namespace OneDriveSlideUploader
{
    class SlideData
    {
        public static List<SlideData> slideDatas = new List<SlideData>();
        private static OneDrive oneDrive;
        private string oneDrivePath;
        public static void SetupOneDrive(IntPtr windowHandle,string oneDriveFilePath)
        {
            oneDrive = new OneDrive();
            oneDrive.Setup(windowHandle);

        }
        public enum Status
        {
            Uploading,Done,Failed
        }
        public string filePath { get; set; }
        public Status status { get; set; }

        public SlideData(string filePath)
        {
            filePath = this.filePath;
            status = Status.Uploading;
            Upload();
        }
        async void Upload()
        {
            bool uploadStatus =  await oneDrive.Upload(filePath, oneDrivePath);
            if (uploadStatus) status = Status.Done;
            else status = Status.Failed;
        }
    }
}
