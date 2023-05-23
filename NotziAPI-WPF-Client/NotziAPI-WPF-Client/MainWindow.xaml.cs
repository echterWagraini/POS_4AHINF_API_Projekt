using MarkdownSharp;
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
using MarkdownSharp;
using System.Diagnostics;

namespace NotizAPI_WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Notiz> notes = new List<Notiz>();
        int openNote= 0;
        Notiz currNotiz = new Notiz();
        string apiurl="http://10.0.0.171:4200/notiz";

        public MainWindow()
        {
            InitializeComponent();
            OpenNote_Click(null, null);
        }

        private void NewNote_Click(object sender, RoutedEventArgs e)
        {
            newNote("New Note " + (notes.Count+1).ToString(), "Click to edit ...",null,null,null);
        }
        private void newNote(string titel, string text,string id,string creationDate, string tag)
        {
            Notiz newNote = new Notiz();
            newNote.titel = titel;
            newNote.text = text;
            newNote.id = id;
            newNote.creationDate=creationDate;
            newNote.tag=tag;

            NoteList.Items.Add(newNote.titel);

            notes.Add(newNote);

 
            openNote = notes.Count - 1;
            currNotiz = newNote;

            textToMarkDown(newNote.titel + "\n\n"+newNote.text);
        }
        public void textToMarkDown(String mdText)
        {
            var markdown = new MarkdownSharp.Markdown();
            string html = "<Style>body {font-family: Arial;}</Style>"+markdown.Transform("# "+mdText);

            if (html.Length > 0)
            {
                WebBrowser.NavigateToString(html);
            } 
        }
        public void updateTextAndTitle(int note, String title, String text)
        {
            if (note == openNote)
            {
                textToMarkDown(title + "\n\n" + text);
            }
            
            if (notes.Count != 0)
            {
                notes[note].text = text;

                notes[note].titel = title;

                NoteList.Items[note] = title;
            }
        }
        private void NoteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Switch to the selected note
            if (notes.Count != 0 && NoteList.SelectedIndex!=-1)
            {
                openNote = NoteList.SelectedIndex;
                currNotiz = notes[NoteList.SelectedIndex];
                textToMarkDown(notes[openNote].titel + "\n\n"+notes[openNote].text);
            }
        }

        private void OpenNote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                notes.Clear();
                NoteList.Items.Clear();
                WebBrowser.NavigateToString(" ");

                HttpClient httpclient = new HttpClient();

                string data = "";
                data = httpclient.GetStringAsync(apiurl).Result;

                var list = JsonSerializer.Deserialize<List<Notiz>>(data);
                if (list != null)
                {
                    foreach (Notiz n in list)
                    {
                        newNote(n.titel, n.text,n.id,n.creationDate,n.tag);
                    }
                }
            }
            catch (Exception ex)
            {
                string messageBoxText = ex.Message;
                string caption = "Error!";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }
        private void SaveNote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient httpclient = new HttpClient();

                string data2 = "";
                data2 = httpclient.GetStringAsync(apiurl).Result;
                var list = JsonSerializer.Deserialize<List<Notiz>>(data2);

                for (int i=0;i<notes.Count;i++)
                {
                    Notiz n = notes[i];
                    if (n != null)
                    {
                        var noteJson = JsonSerializer.Serialize(n);
                        var requestContent = new StringContent(noteJson, Encoding.UTF8, "application/json");
                        if (list.Find(x => x.id==n.id) != null)
                        {
                            var response = httpclient.PutAsync(apiurl + "/"+n.id, requestContent);
                        }
                        else
                        {
                            var response = httpclient.PostAsync(apiurl, requestContent);
                        }
                    }
                }
                ReloadAll();
            }
            catch (Exception ex)
            {
                string messageBoxText = ex.Message;
                string caption = "Error!";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ReloadAll()
        {
            notes.Clear();
            NoteList.Items.Clear();
            WebBrowser.NavigateToString(" ");

            OpenNote_Click(null,null);
        }
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {


            if (NoteList.SelectedIndex== -1)
            {
                return;
            }
            else
            {
                int index = NoteList.SelectedIndex;
                SaveNote_Click(null, null);
                //Note aus DB entfernen falls bereits gesaved
                try
                {
                    HttpClient httpclient = new HttpClient();

                    string data = "";
                    data = httpclient.GetStringAsync(apiurl).Result;
                    var list = JsonSerializer.Deserialize<List<Notiz>>(data);

                    Notiz n = notes[index];

                    if(n!=null&&list!=null)
                    {
                        if (JsonSerializer.Serialize(list[index])==JsonSerializer.Serialize(n))
                        {
   
                            httpclient.DeleteAsync(apiurl+"/" + n.id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string messageBoxText = ex.Message;
                    string caption = "Error!";
                    MessageBoxButton button = MessageBoxButton.YesNoCancel;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }

                //Note aus App entfernen
                notes.RemoveAt(index);
                NoteList.Items.RemoveAt(index);
                openNote = 0;
            }
        }
        private void ChangeUrl_Click(object sender, RoutedEventArgs e)
        {
            string temp = Microsoft.VisualBasic.Interaction.InputBox("Current URL: \n"+apiurl, "Change API-URL", "...");
            if (temp != "..."&&temp!=null&&temp.Length > 0)
            {
                apiurl = temp;
            }
        }
        public void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (NoteList.SelectedIndex != -1)
            {
                EditWindow editWindow = new EditWindow(notes[NoteList.SelectedIndex],NoteList.SelectedIndex);
                editWindow.Show();
            }
        }
    }
}
