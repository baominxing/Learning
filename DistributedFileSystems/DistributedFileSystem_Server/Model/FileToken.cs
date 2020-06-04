using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileCenter.Model
{
    public class FileToken
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FileId { get; set; }

        public string FileName { get; set; }

        public string ProjectNo { get; set; }

        public string Token { get; set; }

        public string Url { get; set; }
    }
}