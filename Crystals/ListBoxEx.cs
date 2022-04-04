using System.Drawing;
using System.Windows.Forms;

namespace Crystals
{
    public partial class ListBoxEx : ListBox
    {
        public ListBoxEx()
        {
            InitializeComponent();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // prevent from error Visual Designer
            if (this.Items.Count > 0)
            {
                Color colorSelect = Color.FromArgb(210, 210, 210);
                Color colorNormal = Color.FromArgb(255, 255, 255);
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(colorSelect), e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(colorNormal), e.Bounds);
                }

                e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
