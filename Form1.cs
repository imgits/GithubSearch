using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace GithubSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = new SearchItems();
        }

        private void toolStripStartSearch_Click(object sender, EventArgs e)
        {
            string uri = @"https://api.github.com/search/code";
            string query = "q=";
            //tetris +language:assembly&sort=stars&order=desc";
            SearchItems items = propertyGrid1.SelectedObject as SearchItems;
            int count = 0;
            if (items.include_keywords != null)
            {
                string[] include_keywords = items.include_keywords.Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string keyword in include_keywords)
                {
                    query += keyword;
                    count++;
                    query += "+";
                }
            }
            if (items.language !=null && items.language.Trim().Length>0)
            {
                if (count++ > 0) query += "+";
                query += "language:" + items.language.Trim();
            }
            if (items.extensions != null)
            {
                string[] extensions = items.extensions.Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string extension in extensions)
                {
                    if (count++ > 0) query += "+";
                    query += "extension:" + extension;
                }
            }
            //query += "&type=Code&sort=stars&order=desc";
            query += "+in:file";
            //ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            string url = uri + "?" + query;
            toolStripComboBox1.Text = url;
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.15) Gecko/20110303 Firefox/3.6.15";
                    richTextBox1.Text = webClient.DownloadString(url);
                    //var stream = webClient.OpenRead(address);
                    //using (StreamReader sr = new StreamReader(stream))
                    //{
                    //    var page = sr.ReadToEnd();
                    //    richTextBox1.Text = page;
                    //}
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Certificate validation callback.
        /// </summary>
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (error == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
                cert.Subject,
                error.ToString());

            return false;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            toolStripComboBox1.Width = toolStrip1.Width - (toolStripLabel1.Width - toolStripStartSearch.Width) - 200;
        }
    }
}
