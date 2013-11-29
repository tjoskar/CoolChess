using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CoolChess.Checkers
{
    public class Chessman
    {
        private ChessmanInterface _pice;

        public SolidColorBrush FillColor { get; set; }
        public SolidColorBrush StrokeColor { get; set; }

        public Chessman(ChessmanInterface strategy)
        {
            this._pice = strategy;
            if (this._pice.getColor() == players.White) {
                FillColor = new SolidColorBrush(Colors.White);
                StrokeColor = new SolidColorBrush(Colors.Black);
            }
            else
            {
                FillColor = new SolidColorBrush(Colors.Black);
                StrokeColor = new SolidColorBrush(Colors.White);
            }
        }
        
        public void setTemplate(Cell cell)
        {
            _pice.setTemplate(cell);
        }

        public players getColor()
        {
            return _pice.getColor();
        }

        public List<List<Position>> getAvailableMoves(Position p)
        {
            return _pice.getAvailableMoves(p);
        }
    }
}
