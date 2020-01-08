using ChessWPF.Model.Constants;
using System.Collections.Generic;

namespace ChessWPF.Model
{
	/// <summary>
	/// Define figure with the figure properties like color, type, position
	/// </summary>
	public class BoardFigure
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BoardFigure"/> class.
		/// </summary>
		public BoardFigure()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BoardFigure"/> class.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="color">The color.</param>
		/// <param name="position">The position.</param>
		public BoardFigure(FigureType type, FigureColor color, Position position)
		{
			Type = type;
			Color = color;
			Position = position;
		}

		/// <summary>
		/// Gets or sets the type of the figure.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public FigureType Type { get; set; }

		/// <summary>
		/// Gets or sets the color of the figure.
		/// </summary>
		/// <value>
		/// The color.
		/// </value>
		public FigureColor Color { get; set; }


		/// <summary>
		/// Gets the index of the tile.
		/// </summary>
		/// <value>
		/// The index of the tile.
		/// </value>
		public int TileIndex { get => Position.TileIndex; }

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>
		/// The position.
		/// </value>
		public Position Position { get; set; }

		/// <summary>
		/// Gets or sets the possible positions.
		/// </summary>
		/// <value>
		/// The possible positions.
		/// </value>
		public List<Position> PossiblePositions { get; set; } = new List<Position>();
	}
}
