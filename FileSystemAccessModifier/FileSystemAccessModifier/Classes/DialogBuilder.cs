using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FileSystemAccessModifier.Classes
{
    public class CustomDialog
    {
        private IDialogCallback dialogCallback;
        private String title;
        private String content;
        private String primaryButtonText;
        private String secondaryButtonText;

        public CustomDialog(IDialogCallback dialogCallback, String title, String content, String primaryButtonText, String secondaryButtonText)
        {
            this.dialogCallback = dialogCallback;
            this.title = title;
            this.content = content;
            this.primaryButtonText = primaryButtonText;
            this.secondaryButtonText = secondaryButtonText;
        }

        public async void ShowDialog(Object argument)
        {
            ContentDialog SaveData = new ContentDialog
            {
                Title = title,
                Content = content,
                PrimaryButtonText = primaryButtonText,
                SecondaryButtonText = secondaryButtonText
            };
            ContentDialogResult result = await SaveData.ShowAsync();

            if (dialogCallback != null)
                dialogCallback.NotifyFromDialog(result, argument);
        }
    }
}
