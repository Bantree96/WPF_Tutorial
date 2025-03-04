using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace GUI_MouseMove.Models
{
	public class MoveThumb : Thumb
	{
		public MoveThumb()
		{
			DragDelta += new DragDeltaEventHandler(MoveThumb_Dragdelta);
		}

		private void MoveThumb_Dragdelta(object sender, DragDeltaEventArgs e)
		{
			Control designerItem = DataContext as Control;

			if(designerItem != null)
			{
				double left = Canvas.GetLeft(designerItem);
				double top = Canvas.GetTop(designerItem);

				Canvas.SetLeft(designerItem, left + e.HorizontalChange);
				Canvas.SetTop(designerItem, top + e.VerticalChange);
			}
		}
	}
}
