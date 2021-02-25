using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageModJson
{
    public partial class Form1 : Form
    {
        public List<string> GarageModFiles = new List<string>();
        public string ServerProfilesFolderDir { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ServerProfilesFolderDir))
            {
                for (int i = 0; i < GarageModFiles.Count; i++)
                {
                    var DCBankingJson = File.ReadAllText(GarageModFiles[i]);
                    var JsonMeta = new DepositaryData();
                    JsonConvert.PopulateObject(DCBankingJson, JsonMeta);

                    var GarageNewJson = new DepositaryData();
                    GarageNewJson.m_SteamID = JsonMeta.m_SteamID;
                    GarageNewJson.m_PlayerName = JsonMeta.m_PlayerName;



                    GarageNewJson.vehicleData = JsonMeta.vehicleData;
                    if (!Directory.Exists(ServerProfilesFolderDir + @"\Depositary_System\ParsedData\"))
                        Directory.CreateDirectory(ServerProfilesFolderDir + @"\Depositary_System\ParsedData\");
                    using (StreamWriter file = File.CreateText(ServerProfilesFolderDir + @"\Depositary_System\ParsedData\" + JsonMeta.m_SteamID + ".json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, GarageNewJson);
                    }
                }

                MessageBox.Show("DONE!");


            }
            else
            {
                MessageBox.Show("ERROR!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fileCount = 0;
            using (var fdg = new FolderBrowserDialog())
            {
                DialogResult result = fdg.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fdg.SelectedPath))
                {
                    string[] filenames = Directory.GetFiles(fdg.SelectedPath + @"\Depositary_System\PlayerData\");
                    ServerProfilesFolderDir = fdg.SelectedPath;
                    foreach (string filename in filenames)
                    {
                        if (filename.Contains(".json"))
                        {
                            fileCount++;
                            GarageModFiles.Add(filename);
                        }
                    }
                    MessageBox.Show("found " + fileCount + " files \nIn folder please convert it now!");
                    button2.Visible = true;
                }
            }
        }
    }
}
