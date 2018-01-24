using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleDriveUploader.GoogleDrive;
using System.IO;

namespace GoogleDriveUploader.View
{
    class GoogleDriveExample
    {
        GoogleDriveService _service;

        //GoogleDriveExample
        public GoogleDriveExample()
        {
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        //UploadFile
        public void UploadFile(string uploadFileName)
        {
            const string CONTENT_TYPE = "image/jpeg";
            _service.UploadFile(uploadFileName, CONTENT_TYPE);
        }
    }
}
