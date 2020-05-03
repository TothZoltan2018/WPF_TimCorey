using Caliburn.Micro;
using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemoUI.ViewModels
{
    public class ShellViewModel
    {
        public BindableCollection<PersonModel> People { get; set; }
        DataAccess dataAccess = new DataAccess();

        public ShellViewModel()
        {
            //DataAccess dataAccess = new DataAccess();
            People = new BindableCollection<PersonModel>(dataAccess.GetPeople());
        }

        public void AddPerson()
        {
            //DataAccess dataAccess = new DataAccess();

            int maxId = 0;
            if(People.Count > 0)
                maxId = People.Max(p => p.PersonId);

            People.Add(dataAccess.GetPerson(maxId + 1));
        }

        public void RemovePerson()
        {
            if (People.Count == 0)
            {
                return;
            }
            //DataAccess dataAccess = new DataAccess();
            People.Remove(dataAccess.GetRandomItem(People.ToArray()));
        }
    }
}
