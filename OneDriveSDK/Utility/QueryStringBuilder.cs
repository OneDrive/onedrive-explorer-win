using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneDrive
{
    public class QueryStringBuilder
    {
        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();
        public QueryStringBuilder()
        {
            StartCharacter = null;
            SeperatorCharacter = '&';
            KeyValueJoinCharacter = '=';
        }

        public QueryStringBuilder(string key, string value)
        {
            this[key] = value;
        }

        public void Clear()
        {
            parameters.Clear();
        }

        public bool HasKeys
        {
            get { return parameters.Count > 0; }
        }

        public char? StartCharacter { get; set; }

        public char SeperatorCharacter { get; set; }

        public char KeyValueJoinCharacter { get; set; }

        public string this[string key]
        {
            get
            {
                if (parameters.ContainsKey(key))
                    return parameters[key];
                else
                    return null;
            }
            set
            {
                parameters[key] = value;
            }
        }

        public bool ContainsKey(string key)
        {
            return parameters.ContainsKey(key);
        }

        public string[] Keys
        {
            get { return parameters.Keys.ToArray(); }
        }

        public void Add(string key, string value)
        {
            parameters[key] = value;
        }

        public void Remove(string key)
        {
            parameters.Remove(key);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var param in parameters)
            {
                if ((sb.Length == 0) && (null != StartCharacter))
                    sb.Append(StartCharacter);
                if ((sb.Length > 0) && (sb[sb.Length - 1] != StartCharacter))
                    sb.Append(SeperatorCharacter);

                sb.Append(param.Key);
                sb.Append('=');
                sb.Append(Uri.EscapeDataString(param.Value));
            }
            return sb.ToString();
        }
    }
}
