using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var player = Player;

            availableMoves = DiagonalMovement.GetDiagonalMoves(currentSquare, board, player);

            return availableMoves;
        }
    }
}