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
            var currentSquare = board.FindPiece(this);
            if (Player == Player.White && board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col)) == null)
            {
                if (currentSquare.Row == 7 && board.GetPiece(Square.At(currentSquare.Row - 2, currentSquare.Col)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row - 2, currentSquare.Col));
                }

                availableMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col));
                
            }

            if (Player == Player.Black && board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col)) == null)
            {
                if (currentSquare.Row == 1 && board.GetPiece(Square.At(currentSquare.Row + 2, currentSquare.Col)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row + 2, currentSquare.Col));
                }
                availableMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col));
                
            }
            
            return availableMoves;

        }
    }
}