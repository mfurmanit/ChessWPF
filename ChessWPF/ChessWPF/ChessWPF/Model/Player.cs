using ChessWPF.Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWPF.Model
{
    public class Player : Utils.BindableBase
    {
        private string name;
        private FigureColor selectedColor;

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
    }
}
