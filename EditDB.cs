﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkHours {
	public partial class EditDB : Form {
		public EditDB() {
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
		public bool Execute () {
			return (ShowDialog() == DialogResult.OK);
		}
	}
}
