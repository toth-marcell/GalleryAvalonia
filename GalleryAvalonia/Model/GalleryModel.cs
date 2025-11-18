using System;
using System.Collections.Generic;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

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
        int _currentPaintingNumber;
        public GalleryModel(int numOfPaintings)
        {
            rng = new();
            Paintings = [];
            _currentPaintingNumber = 0;
            GenerateGallery(numOfPaintings);
        }
        private void GenerateGallery(int numOfPaintings)
        {
            for (int i = 0; i < numOfPaintings; i++)
            {
                string name = _adjectives[rng.Next(0, _adjectives.Length)] + " " + _nouns[rng.Next(0, _nouns.Length)];
                string creator = _painterNames[rng.Next(0, _painterNames.Length)];
                string condition = _artworkConditions[rng.Next(0, _artworkConditions.Length)];
                int price = rng.Next(100, 1000);
                switch (condition)
                {
                    case "Pristine": price *= 10; break;
                    case "Lightly Aged": price *= 7; break;
                    case "Restored": price *= 3; break;
                    case "Weathered": price -= 50; break;
                }
                Bitmap bitmap = new(AssetLoader.Open(new Uri($"avares://GalleryAvalonia/Assets/Painting{rng.Next(1, 8)}.jpg")));
                Paintings.Add(new(name, creator, condition, price, bitmap));
            }
        }
        public GalleryPainting GetPainting(int n)
        {
            if (n < 0 || n >= Paintings.Count) return Paintings[0];
            return Paintings[n];
        }
        public event EventHandler<GalleryEventArgs> PaintingChanged;
        public void NextPainting()
        {
            if (_currentPaintingNumber < Paintings.Count)
            {
                _currentPaintingNumber++;
                PaintingChanged?.Invoke(this, new(Paintings[_currentPaintingNumber], _currentPaintingNumber));
            }
        }
        public void PrevPainting()
        {
            if (_currentPaintingNumber > 0)
            {
                _currentPaintingNumber--;
                PaintingChanged?.Invoke(this, new(Paintings[_currentPaintingNumber], _currentPaintingNumber));
            }
        }
        public int GetNumberOfPaintings() => Paintings.Count;
    }
}