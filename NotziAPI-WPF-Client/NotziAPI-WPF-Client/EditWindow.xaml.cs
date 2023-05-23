using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Printing;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotizAPI_WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        Notiz currNotiz = new Notiz();
        int openNote;
        bool first = true;
        internal EditWindow(Notiz currNotiz, int openNote)
        {
            InitializeComponent();
            this.openNote = openNote;
            this.currNotiz = currNotiz;
            NoteHeader.Text = currNotiz.titel;
            NoteText.Text = currNotiz.text;
        }

        
        private void textChanged(object sender, TextChangedEventArgs args)
        {
            if (first == false)
            {
                currNotiz.text = NoteText.Text;
                currNotiz.titel = NoteHeader.Text;
                MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

                mainWindow.updateTextAndTitle(openNote,currNotiz.titel, currNotiz.text);
            }
            else
            {
                first = false;
            }

        }
    }
}
