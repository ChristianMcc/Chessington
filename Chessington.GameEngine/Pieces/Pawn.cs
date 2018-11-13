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
            if (Player == Player.White && currentSquare.Row >= 1 && board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col)) == null)
            {
                if (currentSquare.Col > 0)
                {
                    var diagonalLeftSquare = new Square(currentSquare.Row - 1, currentSquare.Col - 1);
                    if (board.GetPiece(diagonalLeftSquare) != null &&
                        board.GetPiece(diagonalLeftSquare).Player != Player)
                    {
                        availableMoves.Add(diagonalLeftSquare);
                    }
                }

                if (currentSquare.Col < 7)
                {
                    var diagonalRightSquare = new Square(currentSquare.Row - 1, currentSquare.Col + 1);

                    if (board.GetPiece(diagonalRightSquare) != null &&
                        board.GetPiece(diagonalRightSquare).Player != Player)
                    {
                        availableMoves.Add(diagonalRightSquare);
                    }
                }
                
                if (currentSquare.Row == 7 && board.GetPiece(Square.At(currentSquare.Row - 2, currentSquare.Col)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row - 2, currentSquare.Col));
                }

                availableMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col));
                
            }

            if (Player == Player.Black && currentSquare.Row <= 6 && board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col)) == null)
            {
                if (currentSquare.Col > 0)
                {
                    var diagonalLeftSquare = new Square(currentSquare.Row + 1, currentSquare.Col - 1);
                    if (board.GetPiece(diagonalLeftSquare) != null &&
                        board.GetPiece(diagonalLeftSquare).Player != Player)
                    {
                        availableMoves.Add(diagonalLeftSquare);
                    }
                }

                if (currentSquare.Col < 7)
                {
                    var diagonalRightSquare = new Square(currentSquare.Row + 1, currentSquare.Col + 1);

                    if (board.GetPiece(diagonalRightSquare) != null &&
                        board.GetPiece(diagonalRightSquare).Player != Player)
                    {
                        availableMoves.Add(diagonalRightSquare);
                    }
                }

                if (currentSquare.Row == 1 && board.GetPiece(Square.At(currentSquare.Row + 2, currentSquare.Col)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row + 2, currentSquare.Col));
                }
                availableMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col));
                
            }

            var movesToRemove = new List<Square>();

            foreach (var square in availableMoves)
            {
                if (square.Row < 0 || square.Col < 0 || square.Row > 7 || square.Col > 7)
                {
                    movesToRemove.Add(square);
                }
            }

            availableMoves = availableMoves.Except(movesToRemove).ToList();

            return availableMoves;

        }
    }
}