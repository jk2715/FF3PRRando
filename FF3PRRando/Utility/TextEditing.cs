using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF3PR.Data.Entities;

namespace FF3PRRando.Utility
{
    public class TextEditing
    {
        private readonly string _textDirectory;
        private readonly string _outputDirectory;
        private readonly JsonReader _reader;

        public TextEditing(string magiciteExportDirectory, string outputDirectory, int seed)
        {
            _textDirectory = $@"{magiciteExportDirectory}\message\Assets\GameAssets\Serial\Data\Message\story_mes_en.txt";
            _outputDirectory = $@"{outputDirectory}\FF3PRR_{seed}";
            _reader = new JsonReader(magiciteExportDirectory, outputDirectory, seed);
        }

        // Add some extra text to make it clear to the player that mallets are available in order to access the Mini status
        public void AddMalletText()
        {
            var text = File.ReadAllText(_textDirectory);
            var outputDirectory = $@"{_outputDirectory}\message\Assets\GameAssets\Serial\Data\Message";
            var keyDirectory = $@"{_outputDirectory}\message\keys";
            text = text.Replace(@"I'm a gnome from Tozus Forest to the south, here to draw water from this magic wellspring.<P>\nYou're welcome to pay us a visit, but you'll need to cast Mini on yourselves first. We can't have big folk smashing the place up!", @"I'm a gnome from Tozus Forest to the south, here to draw water from this magic wellspring.<P>\nYou're welcome to pay us a visit, but you'll need to cast Mini on yourselves first. You can use the Mallets you get from this healing spring if you can't use any magic!");
            text = $"{text}\nE0250_00_999_a_01\tObtained Mallet x8!";
            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);
            File.WriteAllText($@"{outputDirectory}\story_mes_en.txt", text);
            var export = new Export
            {
                Keys = ["story_mes_en"],
                Values = ["Assets/GameAssets/Serial/Data/Message/story_mes_en"]
            };
            _reader.WriteToExportFile(keyDirectory, export);
        }
    }
}
