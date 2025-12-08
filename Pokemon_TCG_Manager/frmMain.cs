using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Pokemon_TCG_Manager
{
    // Navigation form - All components created at runtime
    public partial class frmMain : Form
    {
        private int _userID;
        private frmLogin prevFrm;

        public frmMain(int userid, frmLogin loginFrm)
        {
            InitializeComponent();

            // store values passed in
            _userID = userid;
            prevFrm = loginFrm;

            // Remove original designer built components - just to ensure everything from designer is removed
            if (this.Controls.ContainsKey("label1"))
                this.Controls.RemoveByKey("label1");
            if (this.Controls.ContainsKey("btnGoToCollections"))
                this.Controls.RemoveByKey("btnGoToCollections");

            // Create the runtime UI
            CreateRuntimeNavigation();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // keep existing behavior if you want to use Session
            int userID = Session.LoggedInUserId;
        }

        // Create three evenly spaced, horizontally-growing buttons centered in the form.
        // Buttons: Collections, Search, Wishlist 
        // NEED TO ADD DECK BUTTON
        private void CreateRuntimeNavigation()
        {
            // TableLayoutPanel gives evenly spaced columns (percent)
            var table = new TableLayoutPanel
            {
                Name = "tlpNav",
                ColumnCount = 4,
                RowCount = 1,
                Dock = DockStyle.None,
                AutoSize = false,
                Width = Math.Max(600, this.ClientSize.Width / 2), // initial width
                Height = 60,
            };

            // evenly distribute columns
            table.ColumnStyles.Clear();
            for (int i = 0; i < 4; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333f));

            // center table in the form
            table.Location = new Point((this.ClientSize.Width - table.Width) / 2, (this.ClientSize.Height - table.Height) / 2);
            table.Anchor = AnchorStyles.None;

            // Create buttons
            var btnCollections = MakeNavButton("btnCollections", "Collections");
            var btnSearch = MakeNavButton("btnSearch", "Search");
            var btnWishlist = MakeNavButton("btnWishlist", "Wishlist");
            var btnSetOverview = MakeNavButton("btnSetOverview", "Set Overview");

            // Add click handlers that open target forms by name (reflection-based so missing forms won't break compile)
            btnCollections.Click += (s, e) => OpenFormByName("Pokemon_TCG_Manager.frmCollections");
            btnSearch.Click += (s, e) => OpenFormByName("Pokemon_TCG_Manager.frmSearch");
            btnWishlist.Click += (s, e) => OpenFormByName("Pokemon_TCG_Manager.frmWishlist");
            btnSetOverview.Click += (s, e) => OpenFormByName("Pokemon_TCG_Manager.frmSetOverview");


            // Add buttons to table
            table.Controls.Add(btnCollections, 0, 0);
            table.Controls.Add(btnSearch, 1, 0);
            table.Controls.Add(btnWishlist, 2, 0);
            table.Controls.Add(btnSetOverview, 3, 0);

            // Set each button to fill its cell with some padding
            foreach (Control c in table.Controls)
            {
                c.Margin = new Padding(10);
                c.Dock = DockStyle.Fill;
            }

            // Add to the form
            this.Controls.Add(table);

            // Keep table centered on resize
            this.Resize += (s, e) =>
            {
                table.Width = Math.Max(600, this.ClientSize.Width / 2);
                table.Location = new Point((this.ClientSize.Width - table.Width) / 2, (this.ClientSize.Height - table.Height) / 2);
            };
        }

        private Button MakeNavButton(string name, string text)
        {
            return new Button
            {
                Name = name,
                Text = text,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                BackColor = SystemColors.ControlLight,
                TabIndex = 0,
                UseVisualStyleBackColor = true
            };
        }

        // Attempts to open a Form type by its full name from the current assembly.
        // If the form type has a constructor that accepts an int (userId), it calls that.
        // Otherwise it tries the parameterless constructor. If the type doesn't exist, shows a message.
        private void OpenFormByName(string fullTypeName)
        {
            var asm = Assembly.GetExecutingAssembly();
            var type = asm.GetType(fullTypeName);
            if (type == null)
            {
                MessageBox.Show($"The form '{fullTypeName}' is not implemented yet.", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // prefer (int) constructor if available
                var ctorWithInt = type.GetConstructors().FirstOrDefault(ci =>
                {
                    var ps = ci.GetParameters();
                    return ps.Length == 1 && ps[0].ParameterType == typeof(int);
                });

                Form frm = null;
                if (ctorWithInt != null)
                {
                    frm = (Form)Activator.CreateInstance(type, _userID);
                }
                else
                {
                    // try parameterless
                    var parameterless = type.GetConstructor(Type.EmptyTypes);
                    if (parameterless != null)
                        frm = (Form)Activator.CreateInstance(type);
                    else
                    {
                        // last resort: attempt to find any constructor and provide defaults
                        var ctor = type.GetConstructors().FirstOrDefault();
                        if (ctor != null)
                        {
                            var parameters = ctor.GetParameters()
                                .Select(p => p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType) : null)
                                .ToArray();
                            frm = (Form)ctor.Invoke(parameters);
                        }
                    }
                }

                if (frm != null)
                {
                    // show as dialog to preserve the previous behavior, change as needed
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Could not create instance of '{fullTypeName}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Opening form failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWishlists_Click(object sender, EventArgs e)
        {

        }

        private void btnSetOverview_Click(object sender, EventArgs e)
        {
 

        }

    }
}
