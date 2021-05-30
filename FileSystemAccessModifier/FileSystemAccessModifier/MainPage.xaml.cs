using FileSystemAccessModifier.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FileSystemAccessModifier
{
    public sealed partial class MainPage : Page, IDialogCallback
    {
        public MainPage()
        {
            this.InitializeComponent();

            AppDesign.SetStatusBarColor((Color)this.Resources[PropertyString.SYSTEM_ACCENT_COLOR], Colors.Black);
            AttributeType.ItemsSource = FileManager.attributes;
        }

        private void HelpContentsCheckbox_Click(object sender, RoutedEventArgs e)
        {
            CustomDialog customDialog = new CustomDialog(this, "Info Contents Checkbox", PropertyString.HELP_CONTENTS_TO_FOLDERS, "Close", "");
            customDialog.ShowDialog(null);
        }

        private void ContentsCheckbox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            FileManager.applyOnContentsOfFolder = checkBox.IsChecked.Value;
        }

        private void Button_Click_Confirm_Changes(object sender, RoutedEventArgs e)
        {
            //int attributeValue = FileManager.GetFileAttributeByAttributeIndex(AttributeType.SelectedIndex);
            System.IO.FileAttributes attributeValue = FileManager.GetFileAttributesByString(FileManager.attributes[AttributeType.SelectedIndex]);
            String path = FilePath.Text;
            bool validPath = VerifyFilePath(path);

            if (validPath)
            {
                FileManager.SetAccessModifierForPath(path, (System.IO.FileAttributes)attributeValue);
            }
        }

        private void Button_Click_Read_Modifier(object sender, RoutedEventArgs e)
        {
            String path = FilePath.Text;
            bool validPath = VerifyFilePath(path);

            if (validPath)
            {
                String value = FileManager.GetAccessModifierForPath(path);
                CustomDialog customDialog = new CustomDialog(this, "Access Modifier Info", $"Path: {path}\nValue: {value}", "Close", String.Empty);
                customDialog.ShowDialog(null);
            }
        }

        private bool VerifyFilePath(String path)
        {
            if (!String.IsNullOrEmpty(path) && FileManager.VerifyValidPath(path))
            {
                return true;
            }
            else
            {
                CustomDialog customDialog = new CustomDialog(this, PropertyString.HELP_HINT_PATH_EMPTY, String.Empty, "Close", String.Empty);
                customDialog.ShowDialog(null);
                return false;
            }
        }

        public void NotifyFromDialog(ContentDialogResult dialogResult, object argument)
        {
            
        }
    }
}
