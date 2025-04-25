using System;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using MySql.Data.MySqlClient;

namespace MyMusic
{
    public partial class Form1 : Form
    {
        private WaveOutEvent waveOut;        // Objek untuk memutar audio
        private AudioFileReader audioFileReader; // Objek untuk membaca file audio
        private string currentlyPlayingFile; // Menyimpan file yang sedang diputar
        private string connectionString = "Server=localhost;Database=mymusic_db;Uid=root;Pwd=;"; // Sesuaikan dengan koneksi Anda

        public Form1()
        {
            InitializeComponent();
            LoadSongsFromDatabase();
        }

        private void LoadSongsFromDatabase()
        {
            listViewSongs.Items.Clear();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT filepath FROM songs";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listViewSongs.Items.Add(reader.GetString("filepath"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading songs: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Audio Files|*.mp3;*.wav";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string query = "INSERT INTO songs (title, filepath) VALUES (@title, @filepath)";
                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@title", fileName);
                                cmd.Parameters.AddWithValue("@filepath", filePath);
                                cmd.ExecuteNonQuery();
                            }
                            listViewSongs.Items.Add(filePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error adding song: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                string oldFilePath = listViewSongs.SelectedItems[0].Text;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Audio Files|*.mp3;*.wav";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string newFilePath = openFileDialog.FileName;

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                string query = "UPDATE songs SET filepath = @filepath WHERE filepath = @oldFilePath";
                                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                                {
                                    cmd.Parameters.AddWithValue("@filepath", newFilePath);
                                    cmd.Parameters.AddWithValue("@oldFilePath", oldFilePath);
                                    cmd.ExecuteNonQuery();
                                }
                                listViewSongs.SelectedItems[0].Text = newFilePath;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error editing song: " + ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih lagu yang ingin diedit.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                string filePath = listViewSongs.SelectedItems[0].Text;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM songs WHERE filepath = @filepath";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@filepath", filePath);
                            cmd.ExecuteNonQuery();
                        }
                        listViewSongs.Items.Remove(listViewSongs.SelectedItems[0]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting song: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih lagu yang ingin dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedItems.Count > 0)
            {
                string filePath = listViewSongs.SelectedItems[0].Text;

                if (File.Exists(filePath))
                {
                    StopAudio();

                    currentlyPlayingFile = filePath;
                    waveOut = new WaveOutEvent();
                    audioFileReader = new AudioFileReader(filePath);
                    waveOut.Init(audioFileReader);
                    waveOut.Play();
                }
                else
                {
                    MessageBox.Show("File tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih lagu yang ingin diputar.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopAudio();
        }

        private void StopAudio()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }

            currentlyPlayingFile = null;
        }
    }
}
