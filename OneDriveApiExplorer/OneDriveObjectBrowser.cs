using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OneDrive;
using Newtonsoft.Json.Linq;

namespace NewApiBrowser
{
    public partial class OneDriveObjectBrowser : UserControl
    {
        private ODDataModel _item;
        private PropertyDisplayFormat _format;
        public OneDriveObjectBrowser()
        {
            InitializeComponent();
            comboBoxPropertyFormat.SelectedIndex = (int)this.DisplayFormat;
            PropertyDisplayFormatChanged();
        }

        public ODDataModel SelectedItem
        {
            get
            {
                return _item;
            }
            set
            {
                if (value == _item) return;
                _item = value;
                SelectedItemChanged();
            }
        }

        [System.ComponentModel.Browsable(true)]
        public PropertyDisplayFormat DisplayFormat
        {
            get { return _format; }
            set
            {
                if (value == _format) return;
                _format = value;
                comboBoxPropertyFormat.SelectedIndex = (int)_format;
                PropertyDisplayFormatChanged();
            }
        }

        private void SelectedItemChanged()
        {
            BuildPropertyUI(this.SelectedItem);
        }

        private void PropertyDisplayFormatChanged()
        {
            switch (this.DisplayFormat)
            {
                case PropertyDisplayFormat.RawJson:
                    treeViewProperties.Visible = false;
                    textBoxRawJson.Visible = true;
                    textBoxRawJson.Dock = DockStyle.Fill;
                    break;

                case PropertyDisplayFormat.TreeNode:
                    textBoxRawJson.Visible = false;
                    treeViewProperties.Visible = true;
                    treeViewProperties.Dock = DockStyle.Fill;
                    break;

                default:
                    throw new NotImplementedException();
            }

            BuildPropertyUI(this.SelectedItem);
        }

        private void BuildPropertyUI(ODDataModel item)
        {
            if (null == item) return;

            switch (this.DisplayFormat)
            {
                case PropertyDisplayFormat.TreeNode:
                    var propertyNodes = ItemToTreeNodes(item);
                    treeViewProperties.Nodes.Clear();
                    treeViewProperties.Nodes.AddRange(propertyNodes.ToArray());
                    break;
                case PropertyDisplayFormat.RawJson:
                    var jsonData = item.JsonString();
                    textBoxRawJson.Text = jsonData;
                    break;
            }
        }

        private static List<TreeNode> ItemToTreeNodes(ODDataModel item)
        {
            JObject origItem = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(item.JsonString());
            return ObjectToTreeNodes(origItem);
        }

        private static List<TreeNode> ObjectToTreeNodes(JObject obj)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (var prop in obj)
            {
                string name = prop.Key;
                JToken value = prop.Value;

                var node = CreateNode(name, value);
                nodes.Add(node);
            }
            return nodes;
        }

        

        private static TreeNode CreateNode(string key, JToken value)
        {
            TreeNode node = new TreeNode(key);

            switch (value.Type)
            {
                case JTokenType.String:
                    node.Text += "=\"" + value + "\"";
                    break;
                case JTokenType.Integer:
                case JTokenType.Float:
                    node.Text += "=" + value;
                    break;
                case JTokenType.Object:
                    JObject obj = (JObject)value;
                    var childNodes = ObjectToTreeNodes(obj);
                    node.Nodes.AddRange(childNodes.ToArray());
                    break;
                case JTokenType.Array:
                    JArray array = (JArray)value;
                    for (int i = 0; i < array.Count; i++)
                    {
                        node.Nodes.Add(CreateNode(string.Format("[{0}]", i), array[i]));
                    }
                    break;
                case JTokenType.Date:
                    DateTimeOffset dt = (DateTimeOffset)value;
                    node.Text += "=\"" + dt.ToString("u") + "\"";
                    break;
                case JTokenType.Boolean:
                    node.Text += "=" + ((bool)value);
                    break;
                case JTokenType.Null:
                    node.Text += "=null";
                    break;
                default:
                    node.ToolTipText = "Unsupported object type: " + value.Type;
                    node.Text = string.Format("{0}~=[{2}]{1}", node.Text, value, value.Type);
                    break;
            }
            
            node.Tag = value.ToString();
            return node;
        }

        private void comboBoxPropertyFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DisplayFormat = (PropertyDisplayFormat)((ComboBox)sender).SelectedIndex;
        }

        [System.ComponentModel.Browsable(true)]
        public override string Text
        {
            get { return labelSelectedItemProperties.Text; }
            set { labelSelectedItemProperties.Text = value; }
        }

        private void copyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == treeViewProperties.SelectedNode) return;

            string value = treeViewProperties.SelectedNode.Tag as string;
            if (null != value)
            {
                Clipboard.SetText(value);
            }
        }

        private void copyRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == treeViewProperties.SelectedNode) return;

            string value = treeViewProperties.SelectedNode.Text;
            if (null != value)
            {
                Clipboard.SetText(value);
            }
        }
    }

    public enum PropertyDisplayFormat
    {
        RawJson,
        TreeNode
    }
}
