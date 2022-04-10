using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathfindingExample.Library
{
	public partial class formInformation : Form
	{
		public formInformation()
		{
			InitializeComponent();
		}

		private void formInformation_Load(object sender, EventArgs e)
		{
			AcceptButton = btnClose;
			CancelButton = btnClose;
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
		}
	}
}
