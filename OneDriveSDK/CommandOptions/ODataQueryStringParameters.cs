using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneDrive
{
    public abstract class ODataOption
    {
        /// <summary>
        /// The query string key for this option
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Returns the value of the query string for this option. To build a query string, you need to use 
        /// something like string.Format("{0}={1}", Name, ToValue());
        /// Returns null if there is no value
        /// </summary>
        /// <returns></returns>
        public abstract string ToValue();

        protected static string NextLevelParameters(IEnumerable<ODataOption> options)
        {
            StringBuilder sb = new StringBuilder();
            if (options.Any())
            {
                sb.Append('(');
                foreach (var opt in options)
                {
                    if (sb[sb.Length - 1] != '(')
                        sb.Append(';');
                    sb.Append(opt.Name);
                    sb.Append('=');
                    sb.Append(opt.ToValue());
                }
                sb.Append(")");
            }
            return sb.ToString();
        }
    }

    public class SelectOData : ODataOption
    {
        public override string Name { get { return "select"; } }

        public string[] FieldNames { get; set; }

        /// <summary>
        /// select=id,name,size
        /// </summary>
        /// <returns></returns>
        public override string ToValue()
        {
            if (null != FieldNames && FieldNames.Length > 0)
                return string.Join(",", FieldNames);
            return null;
        }
    }

    public class TopOData : ODataOption
    {
        public override string Name { get { return "top"; } }

        public int PageSize { get; set; }

        public override string ToValue()
        {
            return PageSize.ToString();
        }
    }

    public class ExpandOData : ODataOption
    {
        public override string Name { get { return "expand"; } }

        /// <summary>
        /// Name of the property / relationship to expand
        /// </summary>
        public string PropertyToExpand { get; set; }

        /// <summary>
        /// Select properties on the expanded objects
        /// </summary>
        public SelectOData Select { get; set; }

        /// <summary>
        /// Expand a property on the expanded objects
        /// </summary>
        public ExpandOData Expand { get; set; }

        /// <summary>
        /// Specify the number of objects to return from the expanded value
        /// </summary>
        public TopOData Top { get; set; }

        public IEnumerable<ODataOption> AdditionalOptions { get; set; }

        /// <summary>
        /// thumbnails
        /// thumbnails(select=medium)
        /// children(select=id,size,name;expand=thumbnails(select=medium))
        /// </summary>
        /// <returns></returns>
        public override string ToValue()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(PropertyToExpand);

            var options = new List<ODataOption>();
            if (null != AdditionalOptions) options.AddRange(AdditionalOptions);
            options.AddRange(new ODataOption[] { Select, Expand, Top }.Where(x => x != null));

            var innerValues = NextLevelParameters(options);
            if (innerValues.Length > 0)
            {
                sb.Append(innerValues);
            }

            return sb.ToString();
        }

        
    }
}
