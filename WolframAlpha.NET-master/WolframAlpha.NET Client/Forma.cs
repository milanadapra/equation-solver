using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WolframAlphaNET.Objects;
using System.Configuration;
using WolframAlphaNET;
using WolframAlphaNET.Misc;
using System.Diagnostics;
using System.IO;

namespace WolframAlphaNETClient
{
    public partial class Forma : Form
    {
        private Object neuronskaMreza = new Object();
        private static String pythonSource;
        public static Rezultati rez = new Rezultati();
        public OpenFileDialog fbd = new OpenFileDialog();
        public static string _appId = ConfigurationManager.AppSettings["AppId"];
        private String fileName;

        public Forma()
        {
            InitializeComponent();
        }
        public void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                pictureBox1.BackgroundImage = new Bitmap(dlg.FileName);
                pictureNameTb.Text = dlg.FileName;
                fileName = dlg.FileName;
                solveButton.Enabled = true;
            }
        }


        public static void Odradi()
        {
            String odgovor = "";

            //Create the Engine.
            WolframAlpha wolfram = new WolframAlpha(_appId);
            wolfram.ScanTimeout = 0.1f; //We set ScanTimeout really low to get a quick answer. See RecalculateResults() below.
            wolfram.UseTLS = true; //Use encryption

            QueryResult results = wolfram.Query(rez.pitanje);

            //This returns the pods, but also adds them to the original QueryResults.
            results.RecalculateResults();

            //Here we output the Wolfram|Alpha results.
            if (results.Error != null)
                odgovor = "Woops, where was an error: " + results.Error.Message;

            if (results.DidYouMean.HasElements())
            {
                foreach (DidYouMean didYouMean in results.DidYouMean)
                {
                    odgovor = "Did you mean: " + didYouMean.Value;
                }
            }

            //Results are split into "pods" that contain information. Those pods can also have subpods.
            foreach (Pod p in results.Pods)
            {
                if (!p.Title.Equals(""))
                    odgovor += p.Title + "\n";
                if (p.SubPods.HasElements())
                {
                    foreach (SubPod subPod in p.SubPods)
                    {
                        odgovor += subPod.Plaintext + "\n";
                    }
                }
            }


            if (results.Warnings != null)
            {
                if (results.Warnings.Translation != null)
                {
                    odgovor = "Translation: " + results.Warnings.Translation.Text;
                }
                if (results.Warnings.SpellCheck != null)
                {
                    odgovor = "Spellcheck: " + results.Warnings.SpellCheck.Text;
                }
            }


            NapraviResenje(odgovor);

        }

        private void solveButton_Click_1(object sender, EventArgs e)
        {
            label1.Text = "";
            resenjertx.Text = "";

            try
            {
                string python = @"C:\Users\Bole\Anaconda2\python.exe";
                string myPythonApp = @"..\..\python\read.py";
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcessStartInfo.Arguments = myPythonApp + " " + fileName;

                Process myProcess = new Process();
                myProcess.StartInfo = myProcessStartInfo;
                myProcess.Start();

                StreamReader myStreamReader = myProcess.StandardOutput;
                string myString = myStreamReader.ReadLine();

                myProcess.WaitForExit();
                myProcess.Close();

                if (myString != null)
                {
                    label1.Text = myString;
                    rez.pitanje = myString;
                }
            }
            catch (Exception ek)
            {
                Console.WriteLine(ek);
            }


            Odradi();

            resenjertx.Text = rez.rezultat;
            
        }

        public static void NapraviResenje(string odgovor)
        {
            odgovor = odgovor.Replace("Plot", "");
            odgovor = odgovor.Replace("Number line", "");
            odgovor = odgovor.Replace("Roots in the complex plane", "");
            rez.Rezultat = odgovor;
        }

        private void Forma_Load(object sender, EventArgs e)
        {
           
        }

    }
}
