using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WordScrambleGame
{
    public partial class IndexForm : Form
    {
        //variables
        private List<string> allWords = new List<string>();
        private List<string> failedAttempts = new List<string>();
        private Random rand = new Random();
        private string currentWord = "";
        private int attempts = 0;
        private int guessed = 0;

        // Form controls
        private Label lblTitle;
        private Label lblScrambledLabel;
        private Label lblScrambledWord;
        private Label lblYourGuess;
        private TextBox txtGuess;
        private Button btnCheck;
        private Button btnSkip;
        private Label lblFailedLabel;
        private ListBox lstFailed;
        private Label lblAttemptsLabel;
        private Label lblAttemptsValue;
        private Label lblGuessedLabel;
        private Label lblGuessedValue;

        public IndexForm()
        {
            InitializeComponent();
            LoadWords();
            NewWord();
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblScrambledLabel = new Label();
            lblScrambledWord = new Label();
            lblAttemptsLabel = new Label();
            lblAttemptsValue = new Label();
            lblGuessedLabel = new Label();
            lblGuessedValue = new Label();
            lblYourGuess = new Label();
            txtGuess = new TextBox();
            btnCheck = new Button();
            btnSkip = new Button();
            lblFailedLabel = new Label();
            lstFailed = new ListBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(255, 128, 0);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Comic Sans MS", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.MaximumSize = new Size(734, 70);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(734, 70);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "WORD SCRAMBLE GAME";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblScrambledLabel
            // 
            lblScrambledLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblScrambledLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScrambledLabel.ForeColor = SystemColors.ControlLightLight;
            lblScrambledLabel.Location = new Point(207, 92);
            lblScrambledLabel.MaximumSize = new Size(300, 30);
            lblScrambledLabel.Name = "lblScrambledLabel";
            lblScrambledLabel.Size = new Size(300, 30);
            lblScrambledLabel.TabIndex = 1;
            lblScrambledLabel.Text = "SCRAMBLED";
            lblScrambledLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblScrambledWord
            // 
            lblScrambledWord.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblScrambledWord.BackColor = Color.LightGray;
            lblScrambledWord.BorderStyle = BorderStyle.FixedSingle;
            lblScrambledWord.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblScrambledWord.Location = new Point(123, 122);
            lblScrambledWord.MaximumSize = new Size(462, 80);
            lblScrambledWord.Name = "lblScrambledWord";
            lblScrambledWord.Size = new Size(462, 80);
            lblScrambledWord.TabIndex = 2;
            lblScrambledWord.Text = "?????";
            lblScrambledWord.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAttemptsLabel
            // 
            lblAttemptsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblAttemptsLabel.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAttemptsLabel.ForeColor = SystemColors.ControlLightLight;
            lblAttemptsLabel.Location = new Point(634, 114);
            lblAttemptsLabel.MaximumSize = new Size(80, 25);
            lblAttemptsLabel.Name = "lblAttemptsLabel";
            lblAttemptsLabel.Size = new Size(80, 25);
            lblAttemptsLabel.TabIndex = 3;
            lblAttemptsLabel.Text = "ATTEMPTS";
            lblAttemptsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAttemptsValue
            // 
            lblAttemptsValue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblAttemptsValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblAttemptsValue.ForeColor = Color.Red;
            lblAttemptsValue.Location = new Point(644, 139);
            lblAttemptsValue.MaximumSize = new Size(60, 40);
            lblAttemptsValue.Name = "lblAttemptsValue";
            lblAttemptsValue.Size = new Size(60, 40);
            lblAttemptsValue.TabIndex = 4;
            lblAttemptsValue.Text = "0";
            lblAttemptsValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGuessedLabel
            // 
            lblGuessedLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblGuessedLabel.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGuessedLabel.ForeColor = SystemColors.Control;
            lblGuessedLabel.Location = new Point(634, 194);
            lblGuessedLabel.MaximumSize = new Size(80, 25);
            lblGuessedLabel.Name = "lblGuessedLabel";
            lblGuessedLabel.Size = new Size(80, 25);
            lblGuessedLabel.TabIndex = 5;
            lblGuessedLabel.Text = "GUESSED";
            lblGuessedLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGuessedValue
            // 
            lblGuessedValue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblGuessedValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblGuessedValue.ForeColor = Color.Green;
            lblGuessedValue.Location = new Point(644, 219);
            lblGuessedValue.MaximumSize = new Size(60, 40);
            lblGuessedValue.Name = "lblGuessedValue";
            lblGuessedValue.Size = new Size(60, 40);
            lblGuessedValue.TabIndex = 6;
            lblGuessedValue.Text = "0";
            lblGuessedValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblYourGuess
            // 
            lblYourGuess.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblYourGuess.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold);
            lblYourGuess.ForeColor = SystemColors.ControlLightLight;
            lblYourGuess.Location = new Point(123, 236);
            lblYourGuess.MaximumSize = new Size(120, 30);
            lblYourGuess.Name = "lblYourGuess";
            lblYourGuess.Size = new Size(120, 30);
            lblYourGuess.TabIndex = 7;
            lblYourGuess.Text = "YOUR GUESS:";
            lblYourGuess.Click += lblYourGuess_Click;
            // 
            // txtGuess
            // 
            txtGuess.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtGuess.Font = new Font("Segoe UI", 14F);
            txtGuess.Location = new Point(249, 228);
            txtGuess.MaximumSize = new Size(336, 32);
            txtGuess.Name = "txtGuess";
            txtGuess.PlaceholderText = "Type your guess here...";
            txtGuess.Size = new Size(336, 32);
            txtGuess.TabIndex = 8;
            // 
            // btnCheck
            // 
            btnCheck.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCheck.BackColor = Color.FromArgb(255, 128, 0);
            btnCheck.FlatStyle = FlatStyle.Flat;
            btnCheck.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCheck.ForeColor = Color.White;
            btnCheck.Location = new Point(123, 300);
            btnCheck.MaximumSize = new Size(160, 50);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(160, 50);
            btnCheck.TabIndex = 9;
            btnCheck.Text = "CHECK";
            btnCheck.UseVisualStyleBackColor = false;
            btnCheck.Click += BtnCheck_Click;
            // 
            // btnSkip
            // 
            btnSkip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSkip.BackColor = Color.Orange;
            btnSkip.FlatStyle = FlatStyle.Flat;
            btnSkip.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnSkip.ForeColor = Color.White;
            btnSkip.Location = new Point(425, 300);
            btnSkip.MaximumSize = new Size(160, 50);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(160, 50);
            btnSkip.TabIndex = 10;
            btnSkip.Text = "SKIP";
            btnSkip.UseVisualStyleBackColor = false;
            btnSkip.Click += BtnSkip_Click;
            // 
            // lblFailedLabel
            // 
            lblFailedLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblFailedLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFailedLabel.ForeColor = SystemColors.ButtonHighlight;
            lblFailedLabel.Location = new Point(266, 389);
            lblFailedLabel.MaximumSize = new Size(171, 30);
            lblFailedLabel.Name = "lblFailedLabel";
            lblFailedLabel.Size = new Size(171, 30);
            lblFailedLabel.TabIndex = 11;
            lblFailedLabel.Text = "FAILED ATTEMPTS";
            // 
            // lstFailed
            // 
            lstFailed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstFailed.BackColor = Color.WhiteSmoke;
            lstFailed.Font = new Font("Segoe UI", 10F);
            lstFailed.ItemHeight = 17;
            lstFailed.Location = new Point(123, 422);
            lstFailed.MaximumSize = new Size(462, 106);
            lstFailed.Name = "lstFailed";
            lstFailed.Size = new Size(462, 106);
            lstFailed.TabIndex = 12;
            // 
            // IndexForm
            // 
            AcceptButton = btnCheck;
            BackColor = Color.Black;
            ClientSize = new Size(734, 601);
            Controls.Add(lblTitle);
            Controls.Add(lblScrambledLabel);
            Controls.Add(lblScrambledWord);
            Controls.Add(lblAttemptsLabel);
            Controls.Add(lblAttemptsValue);
            Controls.Add(lblGuessedLabel);
            Controls.Add(lblGuessedValue);
            Controls.Add(lblYourGuess);
            Controls.Add(txtGuess);
            Controls.Add(btnCheck);
            Controls.Add(btnSkip);
            Controls.Add(lblFailedLabel);
            Controls.Add(lstFailed);
            Name = "IndexForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Word Scramble";
            Load += IndexForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadWords()
        {
            string filePath = "words.txt";

            if (File.Exists(filePath))
            {
                allWords = File.ReadAllLines(filePath).ToList();
                allWords = allWords.Where(w => !string.IsNullOrWhiteSpace(w)).ToList();
            }
            else
            {
                allWords = new List<string>
                {
                    "cat", "dog", "fish", "bird", "house", "car", "apple",
                    "happy", "smile", "water", "light", "music", "dream",
                    "sleep", "phone", "table", "chair", "window", "flower"
                };
            }
        }

        private void NewWord()
        {
            if (allWords.Count == 0)
            {
                MessageBox.Show($"Congratulations! You guessed {guessed} words correctly!");
                Application.Exit();
                return;
            }

            int randomIndex = rand.Next(allWords.Count);
            currentWord = allWords[randomIndex];
            lblScrambledWord.Text = ScrambleWord(currentWord);
            attempts = 0;
            failedAttempts.Clear();
            UpdateUI();
            txtGuess.Text = "";
            txtGuess.Focus();
        }

        private string ScrambleWord(string word)
        {
            char[] letters = word.ToCharArray();
            for (int i = letters.Length - 1; i > 0; i--)
            {
                int randomPos = rand.Next(i + 1);
                char temp = letters[i];
                letters[i] = letters[randomPos];
                letters[randomPos] = temp;
            }
            return new string(letters);
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string userGuess = txtGuess.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(userGuess))
            {
                MessageBox.Show("Please type a guess!");
                txtGuess.Focus();
                return;
            }

            if (userGuess == currentWord.ToLower())
            {
                guessed++;
                MessageBox.Show($"CORRECT! The word was '{currentWord}'.");
                allWords.Remove(currentWord);
                NewWord();
            }
            else
            {
                attempts++;

                if (!failedAttempts.Contains(userGuess))
                {
                    failedAttempts.Add(userGuess);
                }

                if (attempts >= 10)
                {
                    MessageBox.Show($"10 attempts! The word was '{currentWord}'. Moving on...");
                    allWords.Remove(currentWord);
                    NewWord();
                }
                else
                {
                    UpdateUI();
                    txtGuess.Text = "";
                    txtGuess.Focus();
                }
            }
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Skip?", "Skip",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                allWords.Remove(currentWord);
                NewWord();
            }
        }

        private void UpdateUI()
        {
            lblAttemptsValue.Text = attempts.ToString();
            lblGuessedValue.Text = guessed.ToString();

            lstFailed.Items.Clear();
            foreach (string failed in failedAttempts)
            {
                lstFailed.Items.Add(failed);
            }

            if (attempts >= 7)
                lblScrambledWord.BackColor = Color.LightSalmon;
            else if (attempts >= 4)
                lblScrambledWord.BackColor = Color.LightYellow;
            else
                lblScrambledWord.BackColor = Color.LightGray;
        }

        private void lblYourGuess_Click(object sender, EventArgs e)
        {

        }

        private void IndexForm_Load(object sender, EventArgs e)
        {

        }
    }
}