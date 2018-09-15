using AcademyPayment.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademyPayment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            keyValuePairs.Add(1, 1);
            var x = keyValuePairs.FirstOrDefault(m => m.Key == 21);
            myEntities my = new myEntities();
        }

        private void Form1_Load(object sender, EventArgs e)  { }
    }
    class myEntities : _DbContext
    {
        public myEntities() : base("con", "sqlDb") { }

        public override void Initializer()
        {
            throw new NotImplementedException();
        }
    }
}
