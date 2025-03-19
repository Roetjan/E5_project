using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using MakersMarkt.Classes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MakersMarkt.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
                string username = UsernameInput.Text;
                string email = EmailInput.Text;
                string password = PasswordInput.Password;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    await ShowDialog("Error", "All fields are required!", "OK");
                    return;
                }

                using (var db = new AppDbContext())
                {
                    var emailFound = db.Users.FirstOrDefault(u => u.Email == email);
                    var userFound = db.Users.FirstOrDefault(u => u.Username == username);
                    if (emailFound == null && userFound == null)
                    {
                        await ShowDialog("Error", "Email already registered!","OK");
                        return;
                    }

                    string hashedPassword = SecureHasher.Hash(password);

                    User newUser = new User
                    {
                        Username = username,
                        Email = email,
                        Password = hashedPassword
                    };

                    db.Users.Add(newUser);
                    await db.SaveChangesAsync();

                    await ShowDialog("Success", "Registration successful!", "OK");
                }
        }
        private async Task ShowDialog(string title, string content, string closeButtonText)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = closeButtonText,
                XamlRoot = this.XamlRoot
            };

            await dialog.ShowAsync();
        }
    }
}
