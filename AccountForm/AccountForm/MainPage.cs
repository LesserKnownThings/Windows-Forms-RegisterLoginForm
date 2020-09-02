using AccountForm.Scripts;
using AccountForm.Scripts.PasswordFunctions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AccountForm
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void RegisterAccount(object sender, EventArgs e)
        {
            CreateTheRegisterForm();
        }

        private void Login(object sebder, EventArgs e)
        {
            CreateLoginForm();
        }

        /// <summary>
        /// Creates the register form with all the components
        /// This section also adds the register button and its functionality
        /// </summary>
        private void CreateTheRegisterForm()
        {
            Form form = new Form()
            {
                Width = 300,
                Height = 350,
                BackColor = Color.WhiteSmoke,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label mainText = new Label()
            {
                Left = 105,
                Top = 10,
                Text = "Register Account",
                Font = new Font("Arial", 11, FontStyle.Bold)

            };

            Label registerText = new Label()
            {
                Left = 10,
                Top = 40,
                Text = "User",
                Font = new Font("Arial", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            TextBox registerInput = new TextBox()
            {
                Left = 10,
                Top = 70,
                Font = new Font("Arial", 9),
                Width = 120,
                MaxLength = 15
            };
            Label passText = new Label()
            {
                Left = 10,
                Top = 100,
                Text = "Password",
                Font = new Font("Arial", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            TextBox passInput = new TextBox()
            {
                Left = 10,
                Top = 130,
                Font = new Font("Arial", 9),
                Width = 120,
                PasswordChar = '*'
            };
            Label confirmText = new Label()
            {
                Left = 10,
                Top = 160,
                Text = "Confirm Password",
                Font = new Font("Arial", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Width = 150
            };
            TextBox confirmInput = new TextBox()
            {
                Left = 10,
                Top = 190,
                Font = new Font("Arial", 9),
                Width = 120,
                PasswordChar = '*'
            };
            Button regButton = new Button
            {
                Font = new Font("Arial", 11, FontStyle.Bold),
                Text = "Register",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            Button cancelButon = new Button
            {
                Font = new Font("Arial", 11, FontStyle.Bold),
                Text = "Cancel",
                Dock = DockStyle.Bottom,
                Height = 40,
                DialogResult = DialogResult.Cancel
            };

           

            regButton.Click += async(obj, e) => 
            {
                if (VerifyPassInput(passInput.Text, confirmInput.Text, registerInput.Text))
                {
                    var salt = PasswordActions.GenerateSalt();

                    var reg = await AccountActions.RegisterAccount(new List<string>
                    {
                        $"user={registerInput.Text}",
                        $"password={passInput.Text}",
                        $"salt={salt}"                        
                    });

                    if (reg)
                    {
                        MessageBox.Show("Your account was created");
                        form.Close();
                    }
                    else MessageBox.Show("Something went wrong, please try again later");
                }
                else MessageBox.Show("Something doesn't seem right here. Make sure the fields are not empty and that the passwords match");

                
            };

            form.Controls.Add(mainText);
            form.Controls.Add(registerText);
            form.Controls.Add(registerInput);
            form.Controls.Add(passText);
            form.Controls.Add(passInput);
            form.Controls.Add(confirmText);
            form.Controls.Add(confirmInput);
            form.Controls.Add(regButton);
            form.Controls.Add(cancelButon);

            form.ShowDialog();
        }
        /// <summary>
        /// Creates the login form with all the components
        /// This section also adds the login button and its functionality
        /// </summary>
        private void CreateLoginForm()
        {
            Form form = new Form()
            {
                Width = 300,
                Height = 275,
                BackColor = Color.WhiteSmoke,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label mainText = new Label()
            {
                Left = 125,
                Top = 10,
                Text = "Login",
                Font = new Font("Arial", 11, FontStyle.Bold)

            };

            Label loginText = new Label()
            {
                Left = 10,
                Top = 40,
                Text = "User",
                Font = new Font("Arial", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            TextBox loginInput = new TextBox()
            {
                Left = 10,
                Top = 70,
                Font = new Font("Arial", 9),
                Width = 120,
                MaxLength = 15
            };
            Label passText = new Label()
            {
                Left = 10,
                Top = 100,
                Text = "Password",
                Font = new Font("Arial", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            TextBox passInput = new TextBox()
            {
                Left = 10,
                Top = 130,
                Font = new Font("Arial", 9),
                Width = 120,
                PasswordChar = '*'
            };
            Button logButton = new Button
            {
                Font = new Font("Arial", 11, FontStyle.Bold),
                Text = "Login",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            Button cancelButon = new Button
            {
                Font = new Font("Arial", 11, FontStyle.Bold),
                Text = "Cancel",
                Dock = DockStyle.Bottom,
                Height = 40,
                DialogResult = DialogResult.Cancel
            };

            cancelButon.Click += (o, e) =>
            {
                form.Close();
            };

            logButton.Click += async(o, e) =>
            {
                if (VerifyEmptyLogin(loginInput.Text, passInput.Text))
                {
                    var logResult = await AccountActions.Login(new List<string>
                {
                    $"user={loginInput.Text}",
                    $"password={passInput.Text}"
                });

                    if (logResult)
                    {
                        MessageBox.Show("Welcome Back");
                        form.Close();
                    }
                    else MessageBox.Show("User or password is incorrect");

                }
                else MessageBox.Show("Something is not right here, make sure all fields are filled");
            };

            form.Controls.Add(mainText);
            form.Controls.Add(loginText);
            form.Controls.Add(loginInput);
            form.Controls.Add(passText);
            form.Controls.Add(passInput);
            form.Controls.Add(logButton);
            form.Controls.Add(cancelButon);

            form.ShowDialog();
        }

        /// <summary>
        /// Verifies if one of register forms are empty or if the passwords match
        /// </summary>
        /// <param name="password">the password inputy</param>
        /// <param name="confirm">the password confirmation input</param>
        /// <param name="user">the user input</param>
        /// <returns></returns>
        private bool VerifyPassInput(string password, string confirm, string user)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm) || string.IsNullOrEmpty(user))
                return false;

            return password == confirm;
        }

        /// <summary>
        /// Verifies if the login is empty
        /// </summary>
        /// <param name="user">Input user</param>
        /// <param name="password">Input password</param>
        /// <returns></returns>
        private bool VerifyEmptyLogin(string user, string password)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                return false;

            return true;
        }
        
    }
}
