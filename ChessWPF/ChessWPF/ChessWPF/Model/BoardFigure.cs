using ChessWPF.Model.Constants;
using System.Collections.Generic;

namespace ChessWPF.Model
{
	public class BoardFigure
	{
		public BoardFigure()
		{
		}

		public BoardFigure(FigureType type, FigureColor color, Position position)
		{
			Type = type;
			Color = color;
			Position = position;
		}

		public FigureType Type { get; set; }

		public FigureColor Color { get; set; }

		public int TileIndex { get => Position.TileIndex; }

		public Position Position { get; set; }

		public List<Position> PossiblePositions { get; set; } = new List<Position>();
    }
}
