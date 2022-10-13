using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator_Zdjec
{
    public struct ImageFile
    {
        public string path;
        public DateTime creationDate;
        public DateTime modificationDate;
        public string creationDateString;
        public string modificationDateString;



        public ImageFile(string file)
        {
            this.path = file;
            this.creationDate = File.GetCreationTime(file);
            this.creationDateString = creationDate.ToString("MM/dd/yyyy");
            this.modificationDate = File.GetLastWriteTime(file);
            this.modificationDateString = modificationDate.ToString("MM/dd/yyyy");
        }
    }
}
