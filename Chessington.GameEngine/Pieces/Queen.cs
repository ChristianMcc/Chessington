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
            var player = Player;

            var availableDiagonalMoves = DiagonalMovement.GetDiagonalMoves(currentSquare, board, player);
            var availableLateralMoves = LateralMovement.GetLateralMoves(currentSquare, board, player);

            availableMoves = availableLateralMoves.ToList().Concat(availableDiagonalMoves).ToList();
            
            return availableMoves;
        }
    }
}