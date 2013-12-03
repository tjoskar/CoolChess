using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoolChess.Checkers;

namespace CoolChess
{
    // Interaction logic for Cell.xaml
    public partial class Cell : UserControl
    {
        public SolidColorBrush pieceFillColor { get; set; }
        private Chessman chessman = null;
        private static Dictionary<string, DataTemplate> templates = new Dictionary<string, DataTemplate>();
        private cellColor _color;

        public Cell(cellColor color)
        {
            InitializeComponent();
            this._color = color;
            this.restore();

            // It will exist 64 Cell instances but only one templates Dictionary (static)
            if (templates.Count() == 0)
            {
                templates.Add("Rook", (DataTemplate)FindResource("RookTemplate"));
                templates.Add("Knight", (DataTemplate)FindResource("KnightTemplate"));
                templates.Add("Bishop", (DataTemplate)FindResource("BishopTemplate"));
                templates.Add("Queen", (DataTemplate)FindResource("QueenTemplate"));
                templates.Add("King", (DataTemplate)FindResource("KingTemplate"));
                templates.Add("Pawn", (DataTemplate)FindResource("PawnTemplate"));
            }
        }

        public void setBlack()
        {
            this._color = cellColor.Black;
            this.hide();
            this.black.Visibility = Visibility.Visible;
        }

        public void setWhite()
        {
            this._color = cellColor.White;
            this.hide();
            this.white.Visibility = Visibility.Visible;
        }

        public void setSelected()
        {
            this.hide();
            this.selected.Visibility = Visibility.Visible;
        }

        public void setTarget()
        {
            this.hide();
            this.target.Visibility = Visibility.Visible;
        }

        public void setAvailable()
        {
            this.hide();
            this.available.Visibility = Visibility.Visible;
        }

        // Restor to the default color
        public void restore()
        {
            if (this._color == cellColor.Black)
            {
                this.setBlack();
            }
            else if (this._color == cellColor.White)
            {
                this.setWhite();
            }
        }

        public void setPiece(Chessman chessman)
        {
            this.chessman = chessman;
            this.DataContext = chessman;
            this.chessman.setTemplate(this);
        }

        public void removePiece()
        {
            this.chessman = null;
            this.DataContext = null;
            piece.ContentTemplate = null;
        }

        public bool hasPiece()
        {
            return (this.chessman != null);
        }

        public Chessman getPiece()
        {
            return this.chessman;
        }

        public DataTemplate getTemplate(String name)
        {
            return templates[name];
        }

        private void hide()
        {
            if (this.selected.IsVisible)
            {
                this.selected.Visibility = Visibility.Hidden;
            }
            if (this.target.IsVisible)
            {
                this.target.Visibility = Visibility.Hidden;
            }
            if (this.available.IsVisible)
            {
                this.available.Visibility = Visibility.Hidden;
            }
            if (this.black.IsVisible)
            {
                this.black.Visibility = Visibility.Hidden;
            }
            if (this.white.IsVisible)
            {
                this.white.Visibility = Visibility.Hidden;
            }
        }

        public bool hasColor(playerColor p)
        {
            if (this.hasPiece())
            {
                return (this.chessman.getColor() == p);
            }
            return false;
        }
    }
}
