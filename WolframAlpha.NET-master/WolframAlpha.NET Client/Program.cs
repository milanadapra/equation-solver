using System;
using System.Configuration;
using WolframAlphaNET;
using WolframAlphaNET.Misc;
using WolframAlphaNET.Objects;
using System.Windows.Forms;
using System.Threading;

namespace WolframAlphaNETClient
{
    public class Program
    {
        //Insert your App ID into the App.config file
        private static string _appId = ConfigurationManager.AppSettings["AppId"];

        static void Main(string[] args)
        {

            //Odradi();
            Pokreni();
        }

        [STAThread]
        public static void Pokreni()
        {
            Thread th = new Thread(new ThreadStart(delegate
            {
                var window = new Forma();

                try
                {
                    window.ShowDialog();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erorr:"+ex.Message);
                }
            }));

            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();

            while (th.IsAlive)
            {
                //Wait for thread to finish
            }
        }

        public static void Odradi() 
        {
            Rezultati rez = new Rezultati();
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
            Console.WriteLine(odgovor);

            if (results.DidYouMean.HasElements())
            {
                foreach (DidYouMean didYouMean in results.DidYouMean)
                {
                    odgovor = "Did you mean: " + didYouMean.Value;
                    Console.WriteLine(odgovor);
                }
            }

            //Results are split into "pods" that contain information. Those pods can also have subpods.
            foreach (Pod p in results.Pods)
            {
                odgovor += p.Title;
                Console.WriteLine(p.Title);
                if (p.SubPods.HasElements())
                {
                    foreach (SubPod subPod in p.SubPods)
                    {
                        odgovor += subPod.Plaintext;
                        Console.WriteLine(subPod.Plaintext);
                    }
                }
                Console.WriteLine("\n");
            }


            if (results.Warnings != null)
            {
                if (results.Warnings.Translation != null)
                    Console.WriteLine("Translation: " + results.Warnings.Translation.Text);

                if (results.Warnings.SpellCheck != null)
                    Console.WriteLine("Spellcheck: " + results.Warnings.SpellCheck.Text);
            }

            Console.WriteLine("\nEND!");
            Console.ReadLine();
            rez.Rezultat = odgovor;
        }

    }
}
