using ChessWPF.Model.Constants;
using System.Collections.Generic;

namespace ChessWPF.Model
{
	public class BoardFigure
	{

		public FigureType Type { get; set; }

		public FigureColor Color { get; set; }

		public int TileIndex { get; set; }

		public List<Position> PossiblePositions { get; set; } = new List<Position>();
    }
}
