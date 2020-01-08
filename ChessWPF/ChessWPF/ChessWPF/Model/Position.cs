using System;

namespace ChessWPF.Model
{
	/// <summary>
	/// Define position on the board
	/// </summary>
	/// <seealso cref="System.IEquatable{ChessWPF.Model.Position}" />
	public class Position : IEquatable<Position>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Position"/> class.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <param name="row">The row.</param>
		public Position(int column, int row)
		{
			Column = column;
			Row = row;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Position"/> class.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <exception cref="ArgumentException">
		/// position cannot be null or empty
		/// or
		/// position length should equal 2
		/// or
		/// invalid column index position
		/// or
		/// invalid row index position
		/// or
		/// invalid row index position
		/// </exception>
		public Position(string position)
		{
			if (string.IsNullOrEmpty(position))
				throw new ArgumentException("position cannot be null or empty");

			if (position.Length != 2)
				throw new ArgumentException("position length should equal 2");

			char columnIndex = position[0];
			switch (columnIndex)
			{
				case 'A':
					Column = 0;
					break;
				case 'B':
					Column = 1;
					break;
				case 'C':
					Column = 2;
					break;
				case 'D':
					Column = 3;
					break;
				case 'E':
					Column = 4;
					break;
				case 'F':
					Column = 5;
					break;
				case 'G':
					Column = 6;
					break;
				case 'H':
					Column = 7;
					break;
				default:
					throw new ArgumentException("invalid column index position");
			}

			int rowIndex = 0;
			if (!int.TryParse(position[1].ToString(), out rowIndex))
				throw new ArgumentException("invalid row index position");

			if (rowIndex < 1 || rowIndex > 8)
				throw new ArgumentException("invalid row index position");

			Row = 8 - rowIndex;
		}

		/// <summary>
		/// Gets or sets the column.
		/// </summary>
		/// <value>
		/// The column.
		/// </value>
		public int Column { get; set; }

		/// <summary>
		/// Gets or sets the row.
		/// </summary>
		/// <value>
		/// The row.
		/// </value>
		public int Row { get; set; }

		/// <summary>
		/// Gets the index of the tile.
		/// </summary>
		/// <value>
		/// The index of the tile.
		/// </value>
		public int TileIndex
		{
			get => Column + Row * 8;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
		/// </returns>
		public bool Equals(Position other)
		{
			return other == null ? false : Column == other.Column && Row == other.Row;
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="pos1">The pos1.</param>
		/// <param name="pos2">The pos2.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator ==(Position pos1, Position pos2)
		{
			if (ReferenceEquals(pos1, pos2))
				return true;

			if (ReferenceEquals(pos1, null))
				return false;

			if (ReferenceEquals(pos2, null))
				return false;

			return pos1.Equals(pos2);
		}

		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="pos1">The pos1.</param>
		/// <param name="pos2">The pos2.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator !=(Position pos1, Position pos2)
		{
			return !(pos1 == pos2);
		}

		/// <summary>
		/// Converts to string.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			string pos = "";
			switch (Column)
			{
				case 0:
					pos += "A";
					break;
				case 1:
					pos += "B";
					break;
				case 2:
					pos += "C";
					break;
				case 3:
					pos += "D";
					break;
				case 4:
					pos += "E";
					break;
				case 5:
					pos += "F";
					break;
				case 6:
					pos += "G";
					break;
				case 7:
					pos += "H";
					break;
			}

			int row = 8 - Row;
			pos += row.ToString();
			return pos;
		}
	}
}
