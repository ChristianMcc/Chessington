﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var player = Player;

            availableMoves.Add(Square.At(currentSquare.Row - 2, currentSquare.Col + 1));
            availableMoves.Add(Square.At(currentSquare.Row - 2, currentSquare.Col - 1));
            availableMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col + 2));
            availableMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col - 2));
            availableMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col + 2));
            availableMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col - 2));
            availableMoves.Add(Square.At(currentSquare.Row + 2, currentSquare.Col + 1));
            availableMoves.Add(Square.At(currentSquare.Row + 2, currentSquare.Col - 1));

            var movesToRemove = new List<Square>();

            foreach (var square in availableMoves)
            {
                if (square.Row < 0 || square.Col < 0 || square.Row > 7 || square.Col > 7)
                {
                    movesToRemove.Add(square);
                    continue;
                }

                if (board.GetPiece(square) != null && board.GetPiece(square).Player == board.CurrentPlayer)
                {
                    movesToRemove.Add(square);
                }
            }

            availableMoves = availableMoves.Except(movesToRemove).ToList();

            return availableMoves;
        }
    }
}