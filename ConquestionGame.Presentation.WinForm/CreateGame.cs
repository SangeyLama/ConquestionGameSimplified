﻿using ConquestionGame.Presentation.WinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConquestionGame.Presentation.WinForm
{
    public partial class CreateGame : Form
    {
        ConquestionServiceClient client = new ConquestionServiceClient();
        public CreateGame()
        {
            InitializeComponent();
 
            comboBox2.DataSource = client.RetrieveAllQuestionSets();
            comboBox2.DisplayMember = "Title";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) &&  comboBox2.SelectedItem != null)
            {
                //label4.Text = comboBox1.SelectedText;
                QuestionSet questionSet = client.RetrieveQuestionSetByTitle(comboBox2.Text);
                client.CreateGame(new Game { Name = textBox1.Text }, questionSet.Title, Int32.Parse(maskedTextBox1.Text));
                Game game = client.ChooseGame(textBox1.Text, false); ;
              
                //QuestionSet questionSet = client.RetrieveQuestionSetByTitle(comboBox2.Text);
             
                //client.AddQuestionSet(game, questionSet);
                client.AddPlayer(game, PlayerCredentials.Instance.Player);


                MessageBox.Show("Game created!", "Info",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                (new Lobby(game)).Show();
            }
            else
            {
                MessageBox.Show("All fields must be filled!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateGame_Load(object sender, EventArgs e)
        {
            label4.Text = PlayerCredentials.Instance.Player.Name;
            // Not supposed to create a game on loading the page Tamas.
            //service.CreateGame(new Game { Name = textBox1.Text});
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new JoinGame()).Show();
        }

        private void CreateGame_Closing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
