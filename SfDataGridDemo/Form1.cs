using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGrid_WF
{
    public partial class Form1 : Form
    {
        List<OrderInfo> list = new List<OrderInfo>();

        public Form1()
        {
            InitializeComponent();

            list.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", "Berlin"));
            list.Add(new OrderInfo(1002, "Ana Trujilo", "Mexico", "ANATR", "Mexico D.F."));
            list.Add(new OrderInfo(1003, "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F."));
            list.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London"));
            list.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", "Lula"));

            this.sfDataGrid1.DataSource = list;
            sfDataGrid1.TableControl.MouseMove += TableControl_MouseMove;
            sfDataGrid1.QueryCellStyle += sfDataGrid1_QueryCellStyle;
            sfDataGrid1.TableControl.MouseLeave += TableControl_MouseLeave;
        }


        int hoveredRowIndex = -1;

        void TableControl_MouseLeave(object sender, EventArgs e)
        {
            //To remove the hovered row color while the mouse is leaves the SfDataGrid.
            sfDataGrid1.TableControl.Invalidate(sfDataGrid1.TableControl.GetRowRectangle(hoveredRowIndex, true));
            hoveredRowIndex = -1;
        }

        void sfDataGrid1_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            if (e.RowIndex == hoveredRowIndex)
            {
                //Set the back color for the hovered row cells.
                e.Style.BackColor = Color.Yellow;
            }
        }

        void TableControl_MouseMove(object sender, MouseEventArgs e)
        {
            var rowColumnIndex = this.sfDataGrid1.TableControl.PointToCellRowColumnIndex(this.sfDataGrid1.TableControl.PointToClient(Cursor.Position));

            // Update the hovered row index.
            if (hoveredRowIndex != rowColumnIndex.RowIndex)
            {
                sfDataGrid1.TableControl.Invalidate(sfDataGrid1.TableControl.GetRowRectangle(hoveredRowIndex, true));
                hoveredRowIndex = rowColumnIndex.RowIndex;
                sfDataGrid1.TableControl.Invalidate(sfDataGrid1.TableControl.GetRowRectangle(hoveredRowIndex, true));
            }
        }
    }
}


