When you "drop it from the ToolBox normally", the Designer generates a member declaration for a new user control, but _also_ adds it to the forms `Control` collection. 

Your question states that you would like to declare your user control in code. No problem! We just have to do the same thing that the Designer would do and add it to the `Controls` collection of the caontainer you want to put it in.

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

Then, to use the control, retrieve it from the Controls collection by name.

        CustomUserControl? GetUserControl(string name)
        {
            var layoutPanel = Controls["flowLayoutPanel"] as FlowLayoutPanel;
            return layoutPanel.Controls[name] as CustomUserControl;
        }
    }