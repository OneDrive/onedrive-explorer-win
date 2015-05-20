using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDrive
{
    public class ODExtendedItemReference : ODItemReference
    {
        public ODExtendedItemReference(ODItemReference itemRef)
        {
            this.DriveId = itemRef.DriveId;
            this.Id = itemRef.Id;
            this.Path = itemRef.Path;
        }

        /// <summary>
        /// AdditionalPath enables you to address an item by ID + AdditionalPath. When this reference is converted into
        /// a URL, the value of AdditionalPath is appended to the resolved item.
        /// </summary>
        public string AdditionalPath { get; set; }
    }
}
