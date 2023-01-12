using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace declare_user_controls_inline
{
    public partial class CustomUserControl : UserControl
    {
        public CustomUserControl() => InitializeComponent();
        public new string Text
        {
            get => label1.Text; 
            set => label1.Text = value;
        }
    }
}
