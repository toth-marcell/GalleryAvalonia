using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GalleryAvalonia.Model
{
    public class GalleryModel
    {

        private string[] _adjectives = { "Ethereal", "Fleeting", "Forgotten", "Golden", "Luminous", "Misty", "Nocturnal", "Radiant", "Silent", "Solitary" };

        private string[] _nouns = { "Dream", "Echo", "Garden", "Harbor", "Horizon", "Memory", "Passage", "Reflection", "Twilight", "Whisper" };

        private string[] _painterNames = { "Leonardo da Vinci", "Michelangelo", "Vincent van Gogh", "Claude Monet", "Pablo Picasso" };

        private string[] _artworkConditions = { "Pristine", "Lightly Aged", "Restored", "Weathered" };

        Random rng;
        List<GalleryPainting> Paintings;
        public GalleryModel(int numOfPaintings)
        {
            rng = new();
            Paintings = [];
        }
        private void GenerateGallery(int numOfPaintings)
        {
            for (int i = 0; i < numOfPaintings; i++)
            {
                Paintings.Add(new(_adjectives[rng.Next(0, _adjectives.Length)] + " " + _nouns[rng.Next(0, _nouns.Length)], _painterNames[rng.Next(0, _painterNames.Length)], _artworkConditions[rng.Next(0, _artworkConditions.Length)], rng.Next(100, 1000), new($"avassets://GalleryAvalonia/Assets/{rng.Next(1, 8)}.jpg")));
                ;
            }
        }
    }
    }
