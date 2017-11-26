using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tromino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Grid Grid;

        private void btnDrawGrid_Click(object sender, EventArgs e)
        {
            int orderOfGrid = (int)nudOrderOfGrid.Value;
            int sizeOfGridTile = (int)nudSizeOfGridTile.Value;
            Graphics graphicsObj = pnlMain.CreateGraphics();

            Grid = new Grid(orderOfGrid, sizeOfGridTile, graphicsObj);
            Grid.Draw();
            lblInstruction.Visible = true;
        }

        private void pnlMain_Click(object sender, EventArgs e)
        {
            Grid.SetFirstTile(pnlMain.PointToClient(Cursor.Position));
        }
    }
}
