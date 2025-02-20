using System.ComponentModel;

namespace HotelAccounting;

public class ModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
	public int p; 
	protected void Notify(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}