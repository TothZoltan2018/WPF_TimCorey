##################### Environment setup for WPF with Caliburn.Micro #################
1. Install Caliburn.Micro (CM) nuget package
2. Delete MainwWindow.xaml
3. In App.xaml take out StartupUri="MainWindow.xaml"
4. In App.xaml we set the new starter file:

    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary>
                    <!-- This file will start up.-->
                    <local:Bootstrapper x:Key="Bootstrapper" />
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>

5. Project: add Class BootStrapper
using Caliburn.Micro;
using System.Windows;
using WPFUI.ViewModels;

namespace WPFUI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //base.OnStartup(sender, e);
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}


6. Creating the needed directory structure. This is an important NAMING CONVENTION for CM
Adding Models, Views and ViewModels to our project

7. Adding files:
ViewModels\ShellViewModel.cs, make it public and inherit from Screen.
Views\ShellView.xaml

If we run the project, works. Because of naming conventions, Caliburn Micro arranges that the starting ShellViewModel starts the ShellView (the UI).

##################### CM Feature: Enable/Dissable Button by naming conventions ##################### 
ClearText() and CanClearText()

##################### CM Feature: Second form. ##################### 
        <ContentControl Grid.Row="5" Grid.Column="1" Grid.ColumnSpan="5"
                        x:Name="ActiveItem"/> <!--Keyword for CM: This is an active child form-->

Class Screen, which our ViewModel is inhereted from takes care only of rone Form. Therefore we do not inherit from this, but from class Conductor

