using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MicroMsg_ToolBox
{
    class PickFiles
    {
        private static List<StorageFile> files = null;
        static PickFiles ()
        {
            if (files == null)
            {
                files = new List<StorageFile>();
            }
        }

        public static List<StorageFile> PickedFiles
        {
            get { return files; }
        }
    }
}
