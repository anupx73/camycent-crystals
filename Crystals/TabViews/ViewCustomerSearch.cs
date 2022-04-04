using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crystals.TabViews
{
    public partial class ViewCustomerSearch : UserControl
    {
        private MainForm m_Form = null;
        public ViewCustomerSearch(MainForm form)
        {
            InitializeComponent();
            m_Form = form;
        }

        private void aptBtnGo_Click(object sender, EventArgs e)
        {
            m_Form.EventAppoint_Go(sender, e);
        }


    }
}
