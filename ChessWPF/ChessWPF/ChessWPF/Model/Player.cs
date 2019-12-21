using ChessWPF.Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWPF.Model
{
    public class Player : Utils.BindableBase, IEquatable<Player>
    {
        private string name;
        private FigureColor selectedColor;
        private int secondsForMove = 30;

        public Player(string name, FigureColor selectedColor) {
            this.name = name;
            this.selectedColor = selectedColor;
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public FigureColor SelectedColor
        {
            get => selectedColor;
            set => SetProperty(ref selectedColor, value);
        }

        public int SecondsForMove
        {
            get => secondsForMove;
            set => SetProperty(ref secondsForMove, value);
        }

        public bool Equals(Player other)
        {
            return other == null ? false : this.name.Equals(other.Name) && this.selectedColor == other.SelectedColor;
        }

    }
}
