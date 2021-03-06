﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Money_Manager_Port
{
    public class HamburgerButton : PictureBox
    {
        public ToolTip toolTip = new ToolTip();

        public Form InstanceForm
        {
            get
            {
                return FindForm();
            }
        }

        public HamburgerButton()
        {
            Size = new Size(24, 24);
            SizeMode = PictureBoxSizeMode.StretchImage;
            Image = Properties.Resources.HamburgerButtonStandard;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Image = Properties.Resources.HamburgerButtonPress;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Image = Properties.Resources.HamburgerButtonOn;
            if (Parent.Size == new Size(283, 654))
            {
                toolTip.SetToolTip(this, "Ελαχιστοποίηση παραθύρου πλοήγησης");
            }
            else
            {
                toolTip.SetToolTip(this, "Μεγιστοποίηση παραθύρου πλοήγησης");
            }

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Image = Properties.Resources.HamburgerButtonStandard;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Image = Properties.Resources.HamburgerButtonOn;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            SearchBar sb = new SearchBar();
            foreach (var sb1 in Parent.Controls)
            {
                if (sb1 is SearchBar)
                {
                    sb = (SearchBar)sb1;
                }
            }
            sb.Visible = !(Parent.Size == new Size(283, 654));
            Parent.Size = Parent.Size == new Size(283, 654) ? Parent.Size = new Size(40, 654) : Parent.Size = new Size(283, 654);
        }
    }
    public class HamburgerMenu : Panel
    {
        public HamburgerButton hamburgerButton = new HamburgerButton();

        public HamburgerMenu()
        {
            BackColor = Color.FromArgb(6, 19, 40);
            Size = new Size(283, 654);
            hamburgerButton.Location = new Point(11, 16);
            Controls.Add(hamburgerButton);
        }
    }
    public class HamburgerItem : Panel
    {
        public ToolTip toolTip = new ToolTip();
        public Label ItemText = new Label();
        public PictureBox ItemImage = new PictureBox();
        public PictureBox CurrentItem = new PictureBox();

        [Description("The text displayed on this HamburgerItem."), Category("Data")]
        public string HamburgerItemText
        {
            get
            {
                return ItemText.Text;
            }
            set
            {
                ItemText.Text = value;
            }
        }
        [Description("The text displayed on this HamburgerItem."), Category("Data")]
        public Image HamburgerItemImage
        {
            get
            {
                return ItemImage.Image;
            }
            set
            {
                ItemImage.Image = value;
            }
        }
        [Description("The text displayed when mouse enters the HamburgerItem."), Category("Data")]
        public string HamburgerToolTip { get; set; }
        [Description("Side color displayed for the selected HamburgerItem."), Category("Data")]
        public Color IsFirstItem
        {
            get
            {
                return CurrentItem.BackColor;
            }
            set
            {
                CurrentItem.BackColor = value;
            }
        }

        public HamburgerItem()
        {
            ItemText.Click += (sender, e) =>
            {
                OnClick(e);
            };
            ItemText.MouseEnter += (sender, e) =>
            {
                BackColor = Color.FromArgb(30, 66, 123);
                toolTip.SetToolTip(ItemText, HamburgerToolTip);
            };
            ItemText.MouseUp += (sender, e) =>
            {
                BackColor = Color.FromArgb(30, 66, 123);
            };
            ItemText.MouseDown += (sender, e) =>
            {
                BackColor = Color.FromArgb(4, 10, 21);
            };
            ItemText.MouseLeave += (sender, e) =>
            {
                BackColor = Color.FromArgb(6, 19, 40);
            };
            ItemImage.Click += (sender, e) =>
            {
                OnClick(e);
            };
            ItemImage.MouseEnter += (sender, e) =>
            {
                BackColor = Color.FromArgb(30, 66, 123);
                toolTip.SetToolTip(ItemImage, HamburgerToolTip);
            };
            ItemImage.MouseUp += (sender, e) =>
            {
                BackColor = Color.FromArgb(30, 66, 123);
            };
            ItemImage.MouseDown += (sender, e) =>
            {
                BackColor = Color.FromArgb(4, 10, 21);
            };
            ItemImage.MouseLeave += (sender, e) =>
            {
                BackColor = Color.FromArgb(6, 19, 40);
            };
            CurrentItem.BackColor = Color.White;
            CurrentItem.Size = new Size(5, 35);
            CurrentItem.Location = new Point(0, 0);
            ItemText.AutoSize = true;
            ItemText.Font = new Font("Century Gothic", 10);
            ItemText.ForeColor = Color.White;
            ItemText.Location = new Point(35, 8);
            ItemText.BackColor = Color.Transparent;
            ItemImage.SizeMode = PictureBoxSizeMode.StretchImage;
            ItemImage.Location = new Point(2, -2);
            ItemImage.Size = new Size(40, 40);
            Size = new Size(283, 35);
            Cursor = Cursors.Hand;
            BackColor = Color.FromArgb(6, 19, 40);
            Controls.Add(CurrentItem);
            Controls.Add(ItemText);
            Controls.Add(ItemImage);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackColor = Color.FromArgb(30, 66, 123);
            toolTip.SetToolTip(this, HamburgerToolTip);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = Color.FromArgb(6, 19, 40);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            BackColor = Color.FromArgb(4, 10, 21);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            BackColor = Color.FromArgb(30, 66, 123);
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            List<Control> Items = new List<Control>();
            foreach (Control Item in Parent.Controls)
            {
                if (Item is HamburgerItem)
                {
                    Items.Add(Item);
                }
            }
            foreach (HamburgerItem Item in Items)
            {
                Item.IsFirstItem = Color.FromArgb(6, 19, 40);
            }
            CurrentItem.BackColor = Color.White;
        }
    }
    public class ExitButton : PictureBox
    {
        /// <summary> Δημιουργία του κομπιού για το κλείσιμο του παραθύρου 
        /// </summary>
        public ToolTip toolTip = new ToolTip();
        public Form InstanceForm
        {
            get
            {
                return FindForm();
            }
        }
        public ExitButton()
        {
            Size = new Size(23, 25);
            SizeMode = PictureBoxSizeMode.StretchImage;
            Image = Properties.Resources.CloseButtonStandard;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Image = Properties.Resources.CloseButtonPress;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Image = Properties.Resources.CloseButtonOn;
            toolTip.SetToolTip(this, "Έξοδος");
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Image = Properties.Resources.CloseButtonStandard;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Image = Properties.Resources.CloseButtonOn;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            InstanceForm.Close();
        }
    }
    public class MinimizeButton : PictureBox
    {
        public ToolTip toolTip = new ToolTip();

        public Form InstanceForm
        {
            get
            {
                return FindForm();
            }
        }

        public MinimizeButton()
        {
            Size = new Size(23, 25);
            SizeMode = PictureBoxSizeMode.StretchImage;
            Image = Properties.Resources.MinimizeButtonStandard;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Image = Properties.Resources.MinimizeButtonPress;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Image = Properties.Resources.MinimizeButtonOn;
            toolTip.SetToolTip(this, "Ελαχιστοποίηση");
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Image = Properties.Resources.MinimizeButtonStandard;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Image = Properties.Resources.MinimizeButtonOn;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            InstanceForm.WindowState = FormWindowState.Minimized;
        }
    }
    public class StatusBar : Panel
    {
        private int mousex, mousey;
        private bool drag;

        public Label ApplicationName = new Label();
        public PictureBox Icon = new PictureBox();
        public MinimizeButton MinButton = new MinimizeButton();
        public ExitButton CloseButton = new ExitButton();

        [Description("The text associated with the control."), Category("Appearance")]
        public string _ApplicationName
        {
            get
            {
                return ApplicationName.Text;
            }
            set
            {
                ApplicationName.Text = value;
            }
        }
        [Description("Indicated the Icon for the form."), Category("Appearance")]
        public Image _Icon
        {
            get
            {
                return Icon.Image;
            }
            set
            {
                Icon.Image = value;
            }
        }
        public Form Instance
        {
            get
            {
                return FindForm();
            }
        }

        public StatusBar()
        {
            Dock = DockStyle.Top;
            Height = 25;
            BackColor = Color.FromArgb(11, 134, 196);
            ApplicationName.AutoSize = true;
            ApplicationName.ForeColor = Color.White;
            ApplicationName.Font = new Font("Century Gothic", 10);
            ApplicationName.Location = new Point(35, 2);
            Icon.Size = new Size(18, 18);
            Icon.SizeMode = PictureBoxSizeMode.StretchImage;
            Icon.Location = new Point(10, 3);
            MinButton.Location = new Point(978, 0);
            CloseButton.Location = new Point(1000, 0);
            Controls.Add(ApplicationName);
            Controls.Add(Icon);
            Controls.Add(MinButton);
            Controls.Add(CloseButton);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            drag = true;
            mousex = Cursor.Position.X - Instance.Left;
            mousey = Cursor.Position.Y - Instance.Top;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (drag)
            {
                Instance.Top = Cursor.Position.Y - mousey;
                Instance.Left = Cursor.Position.X - mousex;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            drag = false;
        }
    }
    public class SearchBar : Panel
    {
        public TextBox SearchBox = new TextBox();

        public bool SearchBoxVisible
        {
            get
            {
                return SearchBox.Visible;
            }
            set
            {
                SearchBox.Visible = value;
            }
        }
        public string SearchQuery
        {
            get
            {
                return SearchBox.Text;
            }
        }

        public SearchBar()
        {
            Size = new Size(258, 36);
            BackColor = Color.FromArgb(3, 12, 28);
            SearchBox.Click += (sender, e) =>
            {
                if (SearchBox.Text == "Αναζήτηση")
                {
                    SearchBox.Text = "";
                }
            };
            SearchBox.MouseEnter += (sender, e) =>
            {
                OnMouseEnter(e);
            };
            SearchBox.MouseLeave += (sender, e) =>
            {
                OnMouseLeave(e);
            };
            SearchBox.BackColor = Color.FromArgb(3, 12, 28);
            SearchBox.Size = new Size(222, 35);
            SearchBox.Location = new Point(7, 9);
            SearchBox.AutoSize = false;
            SearchBox.BorderStyle = BorderStyle.None;
            SearchBox.Font = new Font("Century Gothic", 10);
            SearchBox.ForeColor = Color.White;
            SearchBox.Text = "Αναζήτηση";
            Controls.Add(SearchBox);

        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if (Parent.Size == new Size(283, 654))
            {
                BackColor = Color.FromArgb(5, 20, 45);
                Control FoundTheOne = new SearchButton();
                foreach (Control Items in Parent.Controls)
                {
                    if (Items is SearchButton)
                    {
                        FoundTheOne = Items;
                    }
                }
                foreach (Control Item in Controls)
                {
                    Item.BackColor = Color.FromArgb(5, 20, 45);
                }
                FoundTheOne.BackColor = Color.FromArgb(5, 20, 45);

            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (Parent.Size == new Size(283, 654))
            {
                BackColor = Color.FromArgb(3, 12, 28);
                Control FoundTheOne = new SearchButton();
                foreach (Control Items in Parent.Controls)
                {
                    if (Items is SearchButton)
                    {
                        FoundTheOne = Items;
                    }
                }
                foreach (Control Item in Controls)
                {
                    Item.BackColor = Color.FromArgb(3, 12, 28);
                }
                FoundTheOne.BackColor = Color.FromArgb(3, 12, 28);

            }
        }
    }
    public class SearchButton : PictureBox
    {
        public SearchButton()
        {
            Size = new Size(22, 25);
            Image = Properties.Resources.Search;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Image = Properties.Resources._1;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Image = Properties.Resources.Search;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Image = Properties.Resources._1;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Image = Properties.Resources._2;
        }

    }
}
