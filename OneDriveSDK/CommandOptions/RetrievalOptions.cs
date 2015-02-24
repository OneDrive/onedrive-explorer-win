using System.Collections.Generic;

namespace OneDrive
{
    public abstract class RetrievalOptions
    {
        public abstract IEnumerable<ODataOption> ToOptions();

        protected static IEnumerable<ODataOption> EmptyCollection { get { return new ODataOption[0]; } }
    }
}
