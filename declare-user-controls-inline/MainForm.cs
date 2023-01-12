
using System.Diagnostics;
using System.Windows.Forms;

namespace declare_user_controls_inline
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Declare a flow layout panel in code.
            // Add it to the main form control collection
            var flowLayoutPanel = new FlowLayoutPanel
            {
                Name = "flowLayoutPanel",
                Dock = DockStyle.Fill,
            };
            this.Controls.Add(flowLayoutPanel);

            for (char c = 'A'; c < 'D'; c++)
            {
                var userControl = new CustomUserControl
                {
                    Name = $"userControl{c}",  // No space, start with lowercase
                    Text = $"UserControl {c}", // Visible name
                    Margin = new Padding(10, 2, 10, 2),
                    Width = flowLayoutPanel.Width - 20,
                };
                flowLayoutPanel.Controls.Add(userControl);
            }

            // T E S T
            // Then, to use the control, retrieve it
            // from the Controls collection by name.
            CustomUserControl? loopback = GetUserControl("userControlA");
            Debug.Assert(loopback != null, "Expecting to retrieve user control by name");
        }

        // Then, to use the control, retrieve it
        // from the Controls collection by name.
        CustomUserControl? GetUserControl(string name)
        {
            var layoutPanel = Controls["flowLayoutPanel"] as FlowLayoutPanel;
            return layoutPanel.Controls[name] as CustomUserControl;
        }
    }
}