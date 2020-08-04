using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Globalization;

namespace Project
{
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine RecEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US")); //RecognitionEngine Created. and What's Culture ? = (Nationality accent , culture)en-US)
        SpeechSynthesizer Cloud = new SpeechSynthesizer(); //Voice Synt created.

        public MainWindow() //Wpf.Form Starting in build.
        {
            InitializeComponent();
            RecEngine.SetInputToDefaultAudioDevice(); //Default Device on set  
            Choices choices = new Choices("Open League of legends", "Open Uplay", "Open Steam"); //Manually Choices if you want add it type to choices in.
            GrammarBuilder grammar = new GrammarBuilder(choices); //Grammer created
            Grammar grammarr = new Grammar(grammar); 
            RecEngine.LoadGrammar(grammarr);
            RecEngine.SpeechRecognized += heard; 
            RecEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        void heard(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "Open Discord")
            {
                Cloud.Speak("Okey");
                System.Diagnostics.Process.Start(""); //Folder Path
            }             
            if(e.Result.Text == "Close")
            {
                Cloud.Speak("Okey");
                this.Close();
            }
            else
            {
                Cloud.Speak("I Don't Understand you !");
            }

        }       
    }
}
