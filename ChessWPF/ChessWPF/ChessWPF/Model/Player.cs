using ChessWPF.Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWPF.Model
{
	/// <summary>
	/// Define player
	/// </summary>
	/// <seealso cref="System.IEquatable{ChessWPF.Model.Player}" />
	public class Player : IEquatable<Player>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="Player"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="selectedColor">Color of the selected.</param>
		public Player(string name, FigureColor selectedColor) {
            Name = name;
            SelectedColor = selectedColor;
        }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the color of the selected.
		/// </summary>
		/// <value>
		/// The color of the selected.
		/// </value>
		public FigureColor SelectedColor { get; set; }

		/// <summary>
		/// Gets or sets the seconds for move.
		/// </summary>
		/// <value>
		/// The seconds for move.
		/// </value>
		public int SecondsForMove { get; set; } = 30;

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
		/// </returns>
		public bool Equals(Player other)
        {
            return other == null ? false : Name.Equals(other.Name) && SelectedColor == other.SelectedColor;
        }

    }
}
