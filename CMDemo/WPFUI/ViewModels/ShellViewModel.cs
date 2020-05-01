using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
		private string  _firstName ="Zoli";
		private string _lastName;
		private  BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
		private PersonModel _selectedPerson;

		public ShellViewModel()
		{
			People.Add(new PersonModel { FirstName = "Zoli", LastName="Toth" });
			People.Add(new PersonModel { FirstName = "Rege", LastName = "Papp" });
			People.Add(new PersonModel { FirstName = "Aranka", LastName = "Szabo" });
		}

		public string FirstName
		{
			get { return _firstName; }
			set 
			{
				_firstName = value;
				NotifyOfPropertyChange(() => FirstName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string LastName
		{
			get { return _lastName; }
			set
			{
				_lastName = value;
				NotifyOfPropertyChange(() => LastName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string FullName
		{
			get { return $"{FirstName} {LastName}"; }		
		}

		public  BindableCollection<PersonModel> People
		{
			get { return _people; }
			set { _people = value; }
		}
				
		public PersonModel SelectedPerson
		{
			get { return _selectedPerson; }
			set
			{
				_selectedPerson = value;
				NotifyOfPropertyChange(() => SelectedPerson);
			}
		}

		#region Clear Text
		//These CanClearText() method disables the button if the name TextbBoxes are empty.
		//Naming is important! "Can" and the same paramaters binding CanClearText() method
		//to ClearText() method (Which is the x:Name of the button.)
		//ClearText() method must receive the same parameters even is it doesn't use them.
		/// <summary>
		/// Enables or disables the button Clear Text button
		/// </summary>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <returns></returns>
		public bool CanClearText(string firstName, string lastName) => !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName);
		//{
		//	return !String.IsNullOrWhiteSpace(firstName) || !String.IsNullOrWhiteSpace(lastName)
		//}

		public void ClearText(string firstName, string lastName)
		{
			FirstName = "";
			LastName = "";
		}

		#endregion


		public void LoadPageOne()
		{
			//For this metoh, we inhereted this class from Conductor class.
			ActivateItem(new FirstChildViewModel());
		}

		public void LoadPageTwo()
		{			
			ActivateItem(new SecondChildViewModel());
		}
	}
}
