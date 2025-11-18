using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using GalleryAvalonia.Model;

namespace GalleryAvalonia.ViewModels
{
    public class GalleryViewModel : ViewModelBase
    {
        private GalleryModel _model;
        ObservableCollection<GalleryPainting> Paintings { get; set; }
        int _currentPaintingNumber;
        public bool NotFirst => _currentPaintingNumber != 1;
        public bool NotLast => _currentPaintingNumber != _model.GetNumberOfPaintings();
        public RelayCommand PreviousCommand { get; private set; }
        public RelayCommand NextCommand { get; private set; }
        public string PaintingNumber => $"{_currentPaintingNumber}/{_model.GetNumberOfPaintings()}";
        public GalleryViewModel(GalleryModel model)
        {
            _model = model;
            Paintings = [];
            _currentPaintingNumber = 1;
            _model.PaintingChanged += _model_PaintingChanged;
            Paintings.Add(_model.GetPainting(0));
            PreviousCommand = new RelayCommand(_model.PrevPainting);
            NextCommand = new RelayCommand(_model.NextPainting);
        }
        private void _model_PaintingChanged(object? sender, GalleryEventArgs e)
        {
            Paintings.Clear();
            Paintings.Add(e.GalleryPainting);
            _currentPaintingNumber = e.PaintingNumber + 1;
            OnPropertyChanged(nameof(Paintings));
            OnPropertyChanged(nameof(NotFirst));
            OnPropertyChanged(nameof(NotLast));
            OnPropertyChanged(nameof(PaintingNumber));
        }

    }
}
