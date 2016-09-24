﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FiloKiralama.Dialog.Arac;

namespace FiloKiralama.Control
{
    public partial class AracListControl : UserControl
    {
        public AracListControl()
        {
            InitializeComponent();

            var showButtonColumn = new DataGridViewButtonColumn { Name = "show_column", Text = "Göster", Width = 100 };
            const int columnIndex = 0;
            if (this.aracGrid.Columns["show_column"] == null)
            {
                this.aracGrid.Columns.Insert(columnIndex, showButtonColumn);
            }

            aracGrid.CellClick += aracGrid_CellClick;
        }

        void aracGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != aracGrid.Columns["show_column"].Index) return;
            var rowIndex = e.RowIndex;
            var arac = aracGrid.Rows[rowIndex].DataBoundItem as Entity.Arac;
            var dialog = new AracEditDialog { Arac = arac };
            dialog.Show(this);

        }
    }
}
