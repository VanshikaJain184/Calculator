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

    public partial class ScientificCalculator : Form
    {
        private MainMenu _mainMenu;
        private TableLayoutPanel _dynamicTableLayoutPanel;
        private TextBox input;
        List<Button> ButtonList = new List<Button>();
        private Button _square, _root, _clear, _plusMinus, _backSpace, _reciprocal, _decimal, _standardForm, _equalTo;
        private Button _E, _PI, memorySet, _percent, _memoryRead, memoryClear, memoryPlus, _openBracket, _closedBracket;
        const int WIDTH = 55;
        const int HEIGHT = 75;
        public const double PI = 3.1415926535897931;
        public const double E = 2.7182818284590451;
        double MemoryStore = 0;
        double EndResult = 0;

        public ScientificCalculator()
        {
            InitializeComponent();
            Form2_Load();
        }

        public void Form2_Load()
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
                // this.Controls.Add(button);
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
            //scientific form button
            _standardForm = new Button();
            _standardForm.Text = "Standard Calculator";
            _standardForm.Click += new System.EventHandler(this._standardClick);
            ButtonList.Add(_standardForm);

            //Creating Equal Button
            _equalTo = new Button();
            _equalTo.Text = "=";
            _equalTo.Click += new System.EventHandler(this._Equal_Click);
            ButtonList.Add(_equalTo);

            //Creating plusMinus Button
            _plusMinus = new Button();
            _plusMinus.Text = "+/-";
            _plusMinus.Click += new System.EventHandler(this._plusMinus_Click);
            ButtonList.Add(_plusMinus);

            //creating decimal Button
            _decimal = new Button();
            _decimal.Text = ".";
            _decimal.Click += new System.EventHandler(this._decimal_Click);
            ButtonList.Add(_decimal);

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

            _E = new Button();
            _E.Text = "e";
            _E.Click += new System.EventHandler(this._E_Click);
            ButtonList.Add(_E);

            _PI = new Button();
            _PI.Text = "PI";
            _PI.Click += new System.EventHandler(this._PI_Click);
            ButtonList.Add(_PI);

            memorySet = new Button();
            memorySet.Text = "MS";
            memorySet.Click += new System.EventHandler(this.memorySet_Click);
            ButtonList.Add(memorySet);

            _percent = new Button();
            _percent.Text = "%";
            _percent.Click += new System.EventHandler(this.arithmetic_Click);
            ButtonList.Add(_percent);


            _openBracket = new Button();
            _openBracket.Text = "(";
            _openBracket.Click += new System.EventHandler(this.allButtons_Click);
            ButtonList.Add(_openBracket);

            _closedBracket = new Button();
            _closedBracket.Text = ")";
            _closedBracket.Click += new System.EventHandler(this.allButtons_Click);
            ButtonList.Add(_closedBracket);

            _memoryRead = new Button();
            _memoryRead.Text = "MR";
            _memoryRead.Click += new System.EventHandler(this._memoryRead_Click);
            ButtonList.Add(_memoryRead);

            memoryClear = new Button();
            memoryClear.Text = "MC";
            memoryClear.Click += new System.EventHandler(this.memoryClear_Click);
            ButtonList.Add(memoryClear);

            memoryPlus = new Button();
            memoryPlus.Text = "M+";
            memoryPlus.Click += new System.EventHandler(this.memoryPlus_Click);
            ButtonList.Add(memoryPlus);

            //adding Button in table layout panel
            ToolTip toolTip = new ToolTip();
            toolTip.OwnerDraw = true;
            toolTip.BackColor = System.Drawing.Color.Red;


            //adding string symbols unary operations
            string[] operationButtons = new string[] { "sin", "cos", "tan", "log", "cosec", "sec", "cot", "10^x", "exp" };
            for (int i = 0; i < operationButtons.Length; i++)
            {
                Button button = new Button();
                button.Text = operationButtons[i];
                button.Name = operationButtons[i] + "Button";
                button.Click += new System.EventHandler(this.allOperations_Click);
                ButtonList.Add(button);
                // this.Controls.Add(button);
            }

            //creating Input and Output Textbox
            input = new TextBox();
            input.Location = new Point(5, 5);
            input.AutoSize = true;
            input.Width = 550;
            input.Height = 60;
            input.Name = "input";
            input.Text = Properties.Resources.Zero;
            input.Multiline = true;
            this.Controls.Add(input);

            int[] index = new int[] { 29, 22, 28, 34, 21, 27, 33, 20, 26, 32, 40, 39, 38, 37, 24, 36, 41, 23, 35, 19, 25, 18, 30, 31, 5, 11, 17, 4, 10, 16, 12, 0, 6, 1, 7, 13, 3, 14, 8, 2, 9, 15 };
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
            //creating TableLayout
            _dynamicTableLayoutPanel = new TableLayoutPanel();
            _dynamicTableLayoutPanel.AutoSize = true;
            _dynamicTableLayoutPanel.Location = new System.Drawing.Point(5, 70);
            _dynamicTableLayoutPanel.Name = "TableLayoutPanel";
            _dynamicTableLayoutPanel.TabIndex = 0;
            
            _dynamicTableLayoutPanel.ColumnCount = 7;
            _dynamicTableLayoutPanel.RowCount = 6;
            _dynamicTableLayoutPanel.BackColor = Color.SkyBlue;
            _dynamicTableLayoutPanel.ForeColor = Color.Blue;
            //  _dynamicTableLayoutPanel.SizeType = SizeType.AutoSize;
            try
            {
                int position = 0;
                for (int i = 0; i <= 6; i++)
                {
                    for (int j = 0; j <= 5; j++)
                    {

                        _dynamicTableLayoutPanel.Controls.Add(ButtonList[position], i, j);
                        ButtonList[position].Height = WIDTH;
                        ButtonList[position].Width = HEIGHT;
                        ButtonList[position].Dock = DockStyle.Fill;

                        toolTip.SetToolTip(ButtonList[position], "Click" + ButtonList[position].Name);
                        position++;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please add accurate number of Buttons.");
            }
            this.Controls.Add(_dynamicTableLayoutPanel);

        }
        private void StandardFormButtonClick(object sender, EventArgs e)
        {

            StandardCalculator f1 = new StandardCalculator();
            this.Hide();
            f1.Show();
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
        private void Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(input.Text);
        }
        private void Paste_Click(object sender, EventArgs e)
        {
            input.Text = Clipboard.GetText();
        }

        private void _Equal_Click(object sender, EventArgs e)
        {
            try
            {
                double ans = Evaluate.evaluatePostfix(input.Text);
                input.Clear();
                EndResult = ans;
                input.Text = ans.ToString();
            }
            catch(Exception ex)
            {
                input.Text = "INVALID INPUT";
            }
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
        private void memorySet_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStore = Double.Parse(input.Text);
            }
            catch(Exception ex)
            {
                input.Text = "Can't set memory value! Evaluate First";
            }
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
            Button b = sender as Button;
            input.Text = "0";
        }



        private void _plusMinus_Click(object sender, EventArgs e)
        {

            if (input.Text.StartsWith("-"))
            {
                //It's negative now, so strip the `-` sign to make it positive
                input.Text = input.Text.Substring(1);
            }
            else if (!string.IsNullOrEmpty(input.Text) && decimal.Parse(input.Text) != 0)
            {
                //It's positive now, so prefix the value with the `-` sign to make it negative
                input.Text = "-" + input.Text;
            }
        }

        private void _decimal_Click(object sender, EventArgs e)
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
        private void _E_Click(object sender, EventArgs e)
        {
            int index = input.Text.Length;
            index--;

            if (input.Text == "0" || char.IsNumber(input.Text[index]))
                input.Text = E.ToString();
            else
                input.Text += E;
        }
        private void _PI_Click(object sender, EventArgs e)
        {
            int index = input.Text.Length;
            index--;

            if (input.Text == "0" || char.IsNumber(input.Text[index]))
                input.Text = PI.ToString();
            else
                input.Text += PI;
        }



        private void _memoryRead_Click(object sender, EventArgs e)
        {
            input.Text = MemoryStore.ToString();
        }
        private void memoryClear_Click(object sender, EventArgs e)
        {
            MemoryStore = 0;
        }
        private void memoryPlus_Click(object sender, EventArgs e)
        {
            MemoryStore += EndResult;
            input.Text = MemoryStore.ToString();
        }
        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1.To swich on basic calculator from scientific, click on standard Calculator Button.\n" +
                "2. sin, cos, tan , cot, cosec and sec will calculate trignometric functions.\n" +
                "3. log will perform lograthmic operation.\n" +
                "4. To use percentage write in format divisor%dividend, percentage will be calculated.\n" +
                "5. e and PI will have constant values.\n" +
                "6.Memory operators will show history.\n" +
                "7.To exit click on exit from main menu.\n" +
                "Thank you for using Scientific Calcualtor");
        }
            
        private void _standardClick(object sender, EventArgs e)
        {
            this.Hide();
            StandardCalculator f1 = new StandardCalculator();
            f1.Show();

        }
    }
}
