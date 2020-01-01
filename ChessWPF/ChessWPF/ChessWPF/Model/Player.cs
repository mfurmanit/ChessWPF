using ChessWPF.Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWPF.Model
{
    public class Player : IEquatable<Player>
    {
        public Player(string name, FigureColor selectedColor) {
            Name = name;
            SelectedColor = selectedColor;
        }

        public string Name { get; set; }

        public FigureColor SelectedColor { get; set; }

		public int SecondsForMove { get; set; } = 30;

        public bool Equals(Player other)
        {
            return other == null ? false : Name.Equals(other.Name) && SelectedColor == other.SelectedColor;
        }

    }
}
