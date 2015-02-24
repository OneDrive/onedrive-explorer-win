using System;
using System.Drawing;
using System.Windows.Forms;
using OneDrive;

namespace NewApiBrowser
{
    public partial class OneDriveTile : UserControl
    {
        private ODItem _sourceItem;
        private ODConnection _connection;
        private bool _selected;

        public OneDriveTile()
        {
            InitializeComponent();
        }

        public ODConnection Connection
        {
            get { return _connection; }
            set
            {
                if (value == _connection)
                    return;
                _connection = value;
                SourceItemChanged();
            }
        }
        public ODItem SourceItem
        {
            get { return _sourceItem; }
            set
            {
                if (value == _sourceItem)
                    return;

                _sourceItem = value;
                SourceItemChanged();
            }
        }

        private void SourceItemChanged()
        {
            if (null == SourceItem || null == Connection) return;
            
            labelName.Text = SourceItem.Name;

            LoadThumbnail();
        }

        private async void LoadThumbnail()
        {
            var thumbnail = await _sourceItem.GetDefaultThumbnailUrlAsync(Connection, "Medium");
            if (null != thumbnail)
            {
                string thumbnailUri = thumbnail.Url;
                pictureBoxThumbnail.ImageLocation = thumbnailUri;
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            OnClick(EventArgs.Empty);
        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(EventArgs.Empty);
        }

        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (value != _selected)
                {
                    _selected = value;
                    labelName.Font = _selected ? new Font(labelName.Font, FontStyle.Bold) : new Font(labelName.Font, FontStyle.Regular);
                }
            }
        }
    }
}
