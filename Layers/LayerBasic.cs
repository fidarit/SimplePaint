namespace SimplePaint
{
    public abstract class LayerBasic : IDisposable
    {
        protected readonly Canvas ownCanvas;

        public string Name = "Слой";
        public bool IsEnabled = true;

        public Bitmap ResultImage { get; protected set; }
        public virtual Image SourceImage => ResultImage;

        public LayerBasic(Canvas ownCanvas)
        {
            this.ownCanvas = ownCanvas;
            ResultImage = ownCanvas.CreateNewBitmap();

            if (!ownCanvas.Layers.Contains(this))
                ownCanvas.AddLayer(this);
        }

        public LayerBasic(LayerBasic layer)
        {
            ownCanvas = layer.ownCanvas;
            Name = layer.Name;
            IsEnabled = layer.IsEnabled;
            ResultImage = (Bitmap)layer.ResultImage.Clone();
        }

        public virtual void Render() { }

        public virtual void Dispose()
        {
            ResultImage?.Dispose();
        }
    }
}
