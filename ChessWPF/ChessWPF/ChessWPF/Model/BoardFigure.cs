using ChessWPF.Model.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWPF.Model
{
    class BoardFigure : INotifyPropertyChanged
    {
        private string path;
        private FigureType type;
        private FigureColor color;
        private string color2;
        private int tileIndex;
        private int row;
        private int column;

        public string Color2
        {
            get
            {
                return color2;
            }
            set
            {
                color2 = value;
                OnPropertyChanged("Color2");
            }
        }

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }

        public FigureType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
    
        public FigureColor Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        public int TileIndex
        {
            get
            {
                return tileIndex;
            }
            set
            {
                tileIndex = value;
                OnPropertyChanged("TileIndex");
            }
        }

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
                OnPropertyChanged("TileIndex");
            }
        }

        public int Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
                OnPropertyChanged("TileIndex");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
