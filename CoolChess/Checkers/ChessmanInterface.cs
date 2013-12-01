using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolChess.Checkers
{
    public interface ChessmanInterface
    {
        void setTemplate(Cell cell);

        players getColor();

        List<List<Position>> getAvailableMoves(Position p);

        List<List<Position>> getCaptureMoves(Position p);

        chessmen getType();
    }
}
