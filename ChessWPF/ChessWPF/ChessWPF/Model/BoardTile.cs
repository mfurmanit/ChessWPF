using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ChessWPF.Model
{
    class BoardTile : INotifyPropertyChanged
    {
        private int index;
        private SolidColorBrush background;
        private SolidColorBrush stroke;
        private bool isActive;
        private BoardFigure figure;

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
                OnPropertyChanged("Index");
            }
        }

        public SolidColorBrush Background
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
                OnPropertyChanged("Background");
            }
        }

        public SolidColorBrush Stroke
        {
            get
            {
                return stroke;
            }
            set
            {
                stroke = value;
                OnPropertyChanged("Stroke");
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        public BoardFigure Figure
        {
            get
            {
                return figure;
            }
            set
            {
                figure = value;
                OnPropertyChanged("Figure");
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
