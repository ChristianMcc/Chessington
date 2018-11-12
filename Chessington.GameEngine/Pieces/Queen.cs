using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            for (var i = 0; i < 8; i++)
                availableMoves.Add(Square.At(currentSquare.Row, i));
            for (var i = 0; i < 8; i++)
                availableMoves.Add(Square.At(i, currentSquare.Col));

            for (var i = 0; i < 8; i++)
                availableMoves.Add(Square.At(i, i));

            for (var i = 1; i < 8; i++)
                availableMoves.Add(Square.At(i, 8 - i));

            availableMoves.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));

            return availableMoves;
        }
    }
}