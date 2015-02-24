using System;

namespace OneDrive.DataType
{
    public class ODUserProfile : ODDataModel
    {
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public string Username { get; set; }

        public string Organization { get; set; }
    }
}
