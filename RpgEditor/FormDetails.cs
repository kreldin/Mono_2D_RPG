using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpgLibrary;
using RpgLibrary.Items;

namespace RpgEditor
{
    public partial class FormDetails : Form
    {
        protected static ItemManager ItemManager;
        protected static EntityDataManager EntityDataManager;

        public FormDetails()
        {
            InitializeComponent();

            if (ItemManager == null)
                ItemManager = new ItemManager();

            if (EntityDataManager == null)
                EntityDataManager = new EntityDataManager();
        }
    }
}
