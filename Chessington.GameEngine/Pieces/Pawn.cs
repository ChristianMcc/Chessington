using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            if (Player == Player.White)
            {
                availableMoves.Add(Square.At(6, 0));
            }
            if (Player == Player.Black)
            {
                availableMoves.Add(Square.At(2, 0));
            }

            return availableMoves;

        }
    }
}