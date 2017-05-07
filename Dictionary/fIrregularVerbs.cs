using Dictionary.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class frmIrregularVerbs : Form
    {
        public frmIrregularVerbs()
        {
            InitializeComponent();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmIrregularVerbs_Load(object sender, EventArgs e)
        {
            LoadDatabase(dataGridView1);
        }

        void LoadDatabase(DataGridView dtgv)
        {
            Verbs verb = new Verbs();
            var source = verb.GetAllVerbs();
            dtgv.DataSource = source;
        }
    }
}
