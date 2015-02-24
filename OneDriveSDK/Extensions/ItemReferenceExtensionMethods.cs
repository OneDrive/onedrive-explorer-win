using System;

namespace OneDrive
{
    public static class ItemReferenceExtensionMethods
    {
        /// <summary>
        /// Check to see if an ODItemReference instance is valid for use to make API calls.
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="required"></param>
        /// <returns></returns>
        public static bool IsValid(this ODItemReference reference, ItemReferenceRequiredField required = ItemReferenceRequiredField.Default)
        {
            if (null != reference)
            {
                bool hasId = !string.IsNullOrEmpty(reference.Id);
                bool hasPath = !string.IsNullOrEmpty(reference.Path);
                
                if (required == ItemReferenceRequiredField.Default)
                    return (hasId || hasPath);

                bool isValid = true;
                if ((required & ItemReferenceRequiredField.Id) == ItemReferenceRequiredField.Id)
                    isValid &= hasId;
                if ((required & ItemReferenceRequiredField.Path) == ItemReferenceRequiredField.Path)
                    isValid &= hasPath;
                if ((required & ItemReferenceRequiredField.DriveId) == ItemReferenceRequiredField.DriveId)
                    isValid &= !string.IsNullOrEmpty(reference.DriveId);

                return isValid;
            }

            return false;
        }
    }

    [Flags]
    public enum ItemReferenceRequiredField
    {
        Default = 0,
        Id = 1,
        Path = 2,
        DriveId = 4
    }
}
