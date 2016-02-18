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
            //pythonSource = System.IO.File.ReadAllText(@"..\..\firstPartPyhon.py");
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
                //pictureBox1.Image = new Bitmap(dlg.FileName);
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

            //"x^3-2*x^2=14"
            //We search for something. Notice that we spelled it wrong.
            QueryResult results = wolfram.Query(rez.pitanje);

            //This fetches the pods that did not complete. It is only here to show how to use it.
            //This returns the pods, but also adds them to the original QueryResults.
            results.RecalculateResults();

            //Here we output the Wolfram|Alpha results.
            if (results.Error != null)
                odgovor = "Woops, where was an error: " + results.Error.Message;
            //Console.WriteLine(odgovor);

            if (results.DidYouMean.HasElements())
            {
                foreach (DidYouMean didYouMean in results.DidYouMean)
                {
                    odgovor = "Did you mean: " + didYouMean.Value;
                    // Console.WriteLine(odgovor);
                }
            }

            //Results are split into "pods" that contain information. Those pods can also have subpods.
            foreach (Pod p in results.Pods)
            {
                if (!p.Title.Equals(""))
                    odgovor += p.Title + "\n";
                //Console.WriteLine(p.Title);
                if (p.SubPods.HasElements())
                {
                    foreach (SubPod subPod in p.SubPods)
                    {
                        odgovor += subPod.Plaintext + "\n";
                        // Console.WriteLine(subPod.Plaintext);
                    }
                }
                // Console.WriteLine("\n");
            }


            if (results.Warnings != null)
            {
                if (results.Warnings.Translation != null)
                {
                    odgovor = "Translation: " + results.Warnings.Translation.Text;
                    //Console.WriteLine("Translation: " + results.Warnings.Translation.Text);
                }
                if (results.Warnings.SpellCheck != null)
                {
                    odgovor = "Spellcheck: " + results.Warnings.SpellCheck.Text;
                    //Console.WriteLine("Spellcheck: " + results.Warnings.SpellCheck.Text);
                }
            }

            //Console.WriteLine("\nEND!");
            //Console.ReadLine();

            NapraviResenje(odgovor);

        }

        private void solveButton_Click_1(object sender, EventArgs e)
        {
            label1.Text = "";

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
                    rez.pitanje = myString;
                    label1.Text = myString;
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
