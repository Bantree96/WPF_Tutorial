using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DotDraw
{
	public class MainViewModel
	{
        public ObservableCollection<Point> Points { get; set; }
        public ICommand AddPointCommand { get; }

        public MainViewModel()
        {
            Points = new ObservableCollection<Point>();
            AddPointCommand = new RelayCommand<Point>(AddPoint);
        }

        private void AddPoint(Point point)
        {
            Points.Add(point);
        }
    }
}
