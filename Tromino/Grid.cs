using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Tromino
{
    class Grid
    {
        public int OrderOfGrid;
        public int SizeOfGridTile;
        public Graphics GraphicsObj;
        public Pen BasicPen;
        private bool FirstTileSet = false;

        public int StartX = 10;
        public int StartY = 10;

        private int FirstTileX;
        private int FirstTileY;
        private List<Point> Tiles = new List<Point>();

        enum TrominoPositions {
            UpLeft, UpRight, DownLeft, DownRight
        };

        public Grid(int orderOfGrid, int sizeOfGridTile, Graphics graphicsObj)
        {
            OrderOfGrid = orderOfGrid;
            SizeOfGridTile = sizeOfGridTile;
            GraphicsObj = graphicsObj;
            BasicPen = new Pen(Color.Black);
        }

        public void Draw()
        {
            GraphicsObj.Clear(SystemColors.Control);

            GraphicsObj.DrawLine(BasicPen, new Point(StartX, StartY), new Point((int)Math.Pow(2, OrderOfGrid) * SizeOfGridTile + StartX, StartY));
            GraphicsObj.DrawLine(BasicPen, new Point(StartX, StartY), new Point(StartX, (int)Math.Pow(2, OrderOfGrid) * SizeOfGridTile + StartY));

            for (int i = 1; i <= Math.Pow(2, OrderOfGrid); i++)
            {
                GraphicsObj.DrawLine(BasicPen, new Point(StartX, StartY + i * SizeOfGridTile), new Point((int)Math.Pow(2, OrderOfGrid) * SizeOfGridTile + StartX, StartY + i * SizeOfGridTile));
                GraphicsObj.DrawLine(BasicPen, new Point(StartX + i * SizeOfGridTile, StartY), new Point(StartX + i * SizeOfGridTile, (int)Math.Pow(2, OrderOfGrid) * SizeOfGridTile + StartY));
            }

            FirstTileSet = false;
        }

        public void SetFirstTile(Point p)
        {
            if (FirstTileSet == true) return;
            FirstTileX = ((p.X - StartX) / SizeOfGridTile) * SizeOfGridTile + StartX;
            FirstTileY = ((p.Y - StartY) / SizeOfGridTile) * SizeOfGridTile + StartY;
            GraphicsObj.FillRectangle(new SolidBrush(Color.HotPink), FirstTileX, FirstTileY, SizeOfGridTile, SizeOfGridTile);
            GraphicsObj.DrawRectangle(BasicPen, FirstTileX, FirstTileY, SizeOfGridTile, SizeOfGridTile);
            FirstTileSet = true;
            Divide(OrderOfGrid, new Point(StartX, StartY));
        }

        public void Divide(int orderOfGrid, Point pos)
        {
            if (orderOfGrid == 1)
            {
                if ((FirstTileX == pos.X && FirstTileY == pos.Y) || CheckForPriorTile(pos))
                    SetTromino(TrominoPositions.DownRight, pos, Color.Aqua);

                else if ((FirstTileX == (pos.X + SizeOfGridTile) && FirstTileY == pos.Y) || CheckForPriorTile(new Point(pos.X + SizeOfGridTile, pos.Y)))
                    SetTromino(TrominoPositions.DownLeft, pos, Color.Firebrick);

                else if ((FirstTileX == pos.X && FirstTileY == (pos.Y + SizeOfGridTile)) || CheckForPriorTile(new Point(pos.X, pos.Y + SizeOfGridTile)))
                    SetTromino(TrominoPositions.UpRight, pos, Color.Green);

                else //if ((FirstTileX == (pos.X + SizeOfGridTile) && FirstTileY == (pos.Y + SizeOfGridTile)) || CheckForPriorTile())
                    SetTromino(TrominoPositions.UpLeft, pos, Color.Wheat);
            }
            else
            {
                Point p1 = pos,
                      p2 = new Point(pos.X + (int)(Math.Pow(2, orderOfGrid) / 2) * SizeOfGridTile, pos.Y),
                      p3 = new Point(pos.X, pos.Y + (int)(Math.Pow(2, orderOfGrid) / 2) * SizeOfGridTile),
                      p4 = new Point(pos.X + (int)(Math.Pow(2, orderOfGrid) / 2) * SizeOfGridTile,
                      pos.Y + (int)(Math.Pow(2, orderOfGrid) / 2) * SizeOfGridTile);
                int decrementedOrderOfGrid = orderOfGrid - 1;

                CheckAndSetTiles(p1, p2, p3, p4);

                Divide(decrementedOrderOfGrid, p1);
                Divide(decrementedOrderOfGrid, p2);
                Divide(decrementedOrderOfGrid, p3);
                Divide(decrementedOrderOfGrid, p4);

            }
        }

        private void CheckAndSetTiles(Point p1, Point p2, Point p3, Point p4)
        {
            int nrOfTiles = (p2.X - p1.X) / SizeOfGridTile;

            if (!(FirstTileX >= p1.X && FirstTileX < (p1.X + nrOfTiles*SizeOfGridTile) && FirstTileY >= p1.Y && FirstTileY < (p1.Y + nrOfTiles*SizeOfGridTile))
                    && !CheckForPriorTiles(p1, nrOfTiles))
            {
                Point p = new Point();
                p.X = p1.X + (SizeOfGridTile * (nrOfTiles - 1));
                p.Y = p1.Y + (SizeOfGridTile * (nrOfTiles - 1));
                Tiles.Add(p);
                GraphicsObj.FillRectangle(new SolidBrush(Color.CadetBlue), p.X, p.Y, SizeOfGridTile, SizeOfGridTile);
                //GraphicsObj.DrawRectangle(BasicPen, p.X, p.Y, SizeOfGridTile, SizeOfGridTile);
            }

            if (!(FirstTileX >= p2.X && FirstTileX < (p2.X + nrOfTiles*SizeOfGridTile) && FirstTileY >= p2.Y && FirstTileY < (p2.Y + nrOfTiles*SizeOfGridTile)) 
                    && !CheckForPriorTiles(p2, nrOfTiles))
            {
                Point p = new Point();
                p.X = p2.X;
                p.Y = p2.Y + (SizeOfGridTile * (nrOfTiles - 1));
                Tiles.Add(p);
                GraphicsObj.FillRectangle(new SolidBrush(Color.CadetBlue), p.X, p.Y, SizeOfGridTile, SizeOfGridTile);
                //GraphicsObj.DrawRectangle(BasicPen, p.X, p.Y, SizeOfGridTile, SizeOfGridTile);
            }

            if (!(FirstTileX >= p3.X && FirstTileX < (p3.X + nrOfTiles*SizeOfGridTile) && FirstTileY >= p3.Y && FirstTileY < (p3.Y + nrOfTiles*SizeOfGridTile)) 
                   && !CheckForPriorTiles(p3, nrOfTiles))
            {
                Point p = new Point();
                p.X = p3.X + (SizeOfGridTile * (nrOfTiles - 1));
                p.Y = p3.Y;
                Tiles.Add(p);
                GraphicsObj.FillRectangle(new SolidBrush(Color.CadetBlue), p.X, p.Y, SizeOfGridTile, SizeOfGridTile);
                //GraphicsObj.DrawRectangle(BasicPen, p.X, p.Y, SizeOfGridTile, SizeOfGridTile);
            }

            if (!(FirstTileX >= p4.X && FirstTileX < (p4.X + nrOfTiles*SizeOfGridTile) && FirstTileY >= p4.Y && FirstTileY < (p4.Y + nrOfTiles*SizeOfGridTile)) 
                && !CheckForPriorTiles(p4, nrOfTiles))
            {
                Point p = new Point();
                p.X = p4.X;
                p.Y = p4.Y;
                Tiles.Add(p);
                GraphicsObj.FillRectangle(new SolidBrush(Color.CadetBlue), p.X, p.Y, SizeOfGridTile, SizeOfGridTile);
                //GraphicsObj.DrawRectangle(BasicPen, p.X, p.Y, SizeOfGridTile, SizeOfGridTile);
            }
        }

        private bool CheckForPriorTiles(Point p, int nrOfTiles)
        {
            for (int i = 0; i < Tiles.Count(); i++)
                if (Tiles[i].X >= p.X && Tiles[i].X < (p.X + (nrOfTiles*SizeOfGridTile)) && Tiles[i].Y >= p.Y && Tiles[i].Y < (p.Y + (nrOfTiles*SizeOfGridTile)))
                {
                    return true;
                }

            return false;
        }

        private bool CheckForPriorTile(Point p)
        {
            for (int i = 0; i < Tiles.Count(); i++)
                if (Tiles[i].X == p.X && Tiles[i].Y == p.Y)
                {
                    return true;
                }

            return false;
        }

        private Point[] GetTrominoPointsByPosition(TrominoPositions pos, Point p)
        {
            switch (pos)
            {
                case TrominoPositions.UpLeft:
                    return new Point[] {
                        new Point(p.X, p.Y),
                        new Point(p.X + 2 * SizeOfGridTile, p.Y),
                        new Point(p.X + 2 * SizeOfGridTile, p.Y + SizeOfGridTile),
                        new Point(p.X + SizeOfGridTile, p.Y + SizeOfGridTile),
                        new Point(p.X + SizeOfGridTile, p.Y + 2 * SizeOfGridTile),
                        new Point(p.X, p.Y + 2 * SizeOfGridTile),
                        new Point(p.X, p.Y),
                    };
                case TrominoPositions.DownLeft:
                    return new Point[] {
                        new Point(p.X, p.Y),
                        new Point(p.X + SizeOfGridTile, p.Y),
                        new Point(p.X + SizeOfGridTile, p.Y + SizeOfGridTile),
                        new Point(p.X + 2 * SizeOfGridTile, p.Y + SizeOfGridTile),
                        new Point(p.X + 2 * SizeOfGridTile, p.Y + 2 * SizeOfGridTile),
                        new Point(p.X, p.Y + 2 * SizeOfGridTile),
                        new Point(p.X, p.Y),
                    };
                case TrominoPositions.UpRight:
                    return new Point[] {
                        new Point(p.X, p.Y),
                        new Point(p.X + 2 * SizeOfGridTile, p.Y),
                        new Point(p.X + 2 * SizeOfGridTile, p.Y + 2 * SizeOfGridTile),
                        new Point(p.X + SizeOfGridTile, p.Y + 2 * SizeOfGridTile),
                        new Point(p.X + SizeOfGridTile, p.Y + SizeOfGridTile),
                        new Point(p.X, p.Y + SizeOfGridTile),
                        new Point(p.X, p.Y),
                    };
                case TrominoPositions.DownRight:
                    return new Point[] {
                        new Point(p.X + SizeOfGridTile, p.Y),
                        new Point(p.X + 2 * SizeOfGridTile, p.Y),
                        new Point(p.X + 2 * SizeOfGridTile, p.Y + 2 * SizeOfGridTile),
                        new Point(p.X, p.Y + 2 * SizeOfGridTile),
                        new Point(p.X, p.Y + SizeOfGridTile),
                        new Point(p.X + SizeOfGridTile, p.Y + SizeOfGridTile),
                        new Point(p.X + SizeOfGridTile, p.Y),
                    };
                default:
                    return new Point[] { };
            }
        }

        private void SetTromino(TrominoPositions trominoPos, Point baseQuadrantPos, Color brushColor)
        {
            GraphicsObj.FillPolygon(new SolidBrush(brushColor), GetTrominoPointsByPosition(trominoPos, baseQuadrantPos));
            GraphicsObj.DrawPolygon(BasicPen, GetTrominoPointsByPosition(trominoPos, baseQuadrantPos));
        }

    }
}
