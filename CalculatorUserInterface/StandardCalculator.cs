using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathLibrary;
namespace CalculatorUserInterface
{
    public partial class StandardCalculator : Form
    {
        private MainMenu _mainMenu;
        private TableLayoutPanel _dynamicTableLayoutPanel;
        private TextBox input;
        List<Button> ButtonList = new List<Button>();
        private Button _square, _root, _clear, _closedBracket, _openBracket, _backSpace, _reciprocal, _scientificForm, _equalTo;
        const int WIDTH = 55;
        const int HEIGHT = 85;


        public StandardCalculator()
        {
            InitializeComponent();
            Form1_Load();
        }

        public void Form1_Load()
        {
            //adding main menu
            _mainMenu = new MainMenu();
            MenuItem Edit = _mainMenu.MenuItems.Add(Properties.Resources.Edit);
            Edit.MenuItems.Add(new MenuItem(Properties.Resources.Copy, Copy_Click));
            Edit.MenuItems.Add(new MenuItem(Properties.Resources.Paste, Paste_Click));
            MenuItem Exit = _mainMenu.MenuItems.Add(Properties.Resources.Exit, Exit_Click);
            MenuItem Help = _mainMenu.MenuItems.Add(Properties.Resources.Help, Help_Click);
            this.Menu = _mainMenu;


            //creating buttons from 0 to 10;
            for (int i = 0; i < 10; i++)
            {
                Button button = new Button();
                button.Text = i.ToString();
                button.Name = "Button" + i.ToString();
                button.Click += new System.EventHandler(this.allButtons_Click);
                ButtonList.Add(button);

            }

            //creating buttons for arithmetic opearions;
            string[] ArithmeticOperations = new string[] { "+", "-", "*", "/", "mod" };
            for (int i = 0; i < ArithmeticOperations.Length; i++)
            {
                Button button = new Button();
                button.Text = ArithmeticOperations[i];
                button.Name = "Button" + ArithmeticOperations[i];
                button.Click += new System.EventHandler(this.arithmetic_Click);
                ButtonList.Add(button);

            }
            //  string resxFile = @".\Resources.resx";
            //creating Input and Output Textbox
            input = new TextBox();
            input.Location = new Point(5, 5);
            input.AutoSize = true;
            input.Width = 370;
            input.Height = 60;
            input.Name = "input";
            input.Text = "0";
            input.Multiline = true;
            this.Controls.Add(input);

            //creating TableLayout
            _dynamicTableLayoutPanel = new TableLayoutPanel();
            _dynamicTableLayoutPanel.AutoSize = true;
            _dynamicTableLayoutPanel.Location = new System.Drawing.Point(5, 70);
            _dynamicTableLayoutPanel.Name = "TableLayoutPanel";
            //  _dynamicTableLayoutPanel.Size = new System.Drawing.Size(345, 410);
            _dynamicTableLayoutPanel.TabIndex = 0;
            _dynamicTableLayoutPanel.BackColor = Color.RoyalBlue;
            _dynamicTableLayoutPanel.ColumnCount = 6;
            _dynamicTableLayoutPanel.RowCount = 4;
            _dynamicTableLayoutPanel.ForeColor= Color.White;
            //scientific form button
            _scientificForm = new Button();
            _scientificForm.Text = "Scientific Calculator";
            _scientificForm.Click += new System.EventHandler(this.ScientificClick);
            ButtonList.Add(_scientificForm);

            //Creating Equal Button
            _equalTo = new Button();
            _equalTo.Text = "=";
            _equalTo.Click += new System.EventHandler(this._Equal_Click);
            ButtonList.Add(_equalTo);

            _openBracket = new Button();
            _openBracket.Text = "(";
            _openBracket.Click += new System.EventHandler(this.allButtons_Click);
            ButtonList.Add(_openBracket);

            _closedBracket = new Button();
            _closedBracket.Text = ")";
            _closedBracket.Click += new System.EventHandler(this.allButtons_Click);
            ButtonList.Add(_closedBracket);


            //creating square button
            _square = new Button();
            _square.Text = "x^2";
            _square.Click += new System.EventHandler(this.allOperations_Click);
            ButtonList.Add(_square);

            //creating root button
            _root = new Button();
            _root.Text = "root";
            _root.Click += new System.EventHandler(this.allOperations_Click);
            ButtonList.Add(_root);

            //creating clear button
            _clear = new Button();
            _clear.Text = "C";
            _clear.Click += new System.EventHandler(this._clear_Click);
            ButtonList.Add(_clear);

            //creating Back button
            _backSpace = new Button();
            _backSpace.Text = "back";
            _backSpace.Click += new System.EventHandler(this._backSpace_Click);
            ButtonList.Add(_backSpace);

            //creating reciprocal button
            _reciprocal = new Button();
            _reciprocal.Text = "1/x";
            _reciprocal.Click += new System.EventHandler(this._reciprocal_Click);
            ButtonList.Add(_reciprocal);



            //adding Button in table layout panel
            ToolTip toolTip = new ToolTip();
            toolTip.OwnerDraw = true;
            toolTip.BackColor = System.Drawing.Color.Red;


            int[] index = new int[] { 11, 4, 10, 16, 3, 9, 15, 2, 8, 14, 22, 21, 20, 19, 6, 18, 23, 5, 17, 1, 7, 0, 12, 13 };
            for (int i = 0; i < ButtonList.Count; i++)
            {
                // While index[i] and arr[i] are not fixed
                while (index[i] != i)
                {
                    // Store values of the target (or correct)
                    // position before placing arr[i] there
                    int oldTargetI = index[index[i]];
                    Button oldTargetE = ButtonList[index[i]];

                    // Place arr[i] at its target (or correct)
                    // position. Also copy corrected index for
                    // new position
                    ButtonList[index[i]] = ButtonList[i];
                    index[index[i]] = index[i];

                    // Copy old target values to arr[i] and
                    // index[i]
                    index[i] = oldTargetI;
                    ButtonList[i] = oldTargetE;
                }
            }



            int position = 0;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 5; j++)
                {

                    _dynamicTableLayoutPanel.Controls.Add(ButtonList[position], i, j);
                    ButtonList[position].Height = WIDTH;
                    ButtonList[position].Width = HEIGHT;
                    //   toolTip.SetToolTip(ButtonList[position], "Click" + ButtonList[position].Name);
                    toolTip.SetToolTip(ButtonList[position], "Click");


                    position++;
                }
            }

            this.Controls.Add(_dynamicTableLayoutPanel);
        }

        private void Exit_Click(Object sender, System.EventArgs e)
        {
            Application.Exit();
        }
        private void allButtons_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (input.Text == "0" && !(input.Text == null))
            {
                input.Text = button.Text;
            }
            else
                input.Text += button.Text;
        }
        private void arithmetic_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            input.Text += button.Text;
        }
        private void allOperations_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (input.Text == "0" && !(input.Text == null))
            {
                if (button.Text == "10^x")
                {
                    input.Text = "10^(";
                }
                else
                    input.Text = button.Text + "(";
            }
            else if (button.Text == "10^x")
            {
                input.Text = "10^(";
            }
            else
                input.Text += button.Text + "(";
        }
        private void Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(input.Text);
        }
        private void Paste_Click(object sender, EventArgs e)
        {
            input.Text = Clipboard.GetText();
        }
        private void _reciprocal_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (input.Text == "0" && !(input.Text == null))
            {

                input.Text = "1/";
            }
            else
                input.Text += "1/";
        }
        private void _backSpace_Click(object sender, EventArgs e)
        {
            int index = input.Text.Length;
            index--;
            input.Text = input.Text.Remove(index);
            if (input.Text == "")
            {
                input.Text = "0";
            }
        }
        private void _clear_Click(object sender, EventArgs e)
        {

            input.Text = "0";
        }


        private void _square_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            input.Text += button.Text;
        }

        private void _plusMinus_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            input.Text += button.Text;
        }

        private void _decimal_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            input.Text += button.Text;
        }
        private void ScientificClick(object sender, EventArgs e)
        {
            this.Hide();
            ScientificCalculator f2 = new ScientificCalculator();
            f2.Show();
        }
        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1.To swich to scientific calculator from standard, click on scientific Calculator Button.\n" +
                "2. +,-,*, / and mod will perform arithmetic operations.\n" +
                "3. root, 1/x and x^2 (x square) will perform functionality respectively.\n" +
                "4. To use percentage write in format divisor%dividend, percentage will be calculated.\n" +
                "5. '(' and ')' can be given to evaluate full expression.\n" +
                "6.To exit click on exit from main menu.\n" +
                "Thank you for using Standard Calcualtor");
        }

        private void _Equal_Click(object sender, EventArgs e)
        {
            double ans = 0;
            try
            {
                if (input.Text.StartsWith("-"))
                {
                    input.Text = "0-" + input.Text;
                }
                ans = Evaluate.evaluatePostfix(input.Text);
                input.Clear();
                input.Text = ans.ToString();
            }
            catch (Exception ex)
            {
                input.Text = "INVALID INPUT";
            }


        }


    }
}
