using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersIDK
{
    public abstract class LayerBasic
    {
        protected readonly Canvas ownCanvas;

        public string Name = "Слой";
        public bool IsEnabled = true;

        public Bitmap ResultImage { get; protected set; }


        public LayerBasic(Canvas ownCanvas)
        {
            this.ownCanvas = ownCanvas;
            if (!ownCanvas.Layers.Contains(this))
                ownCanvas.Layers.Add(this);

            ResultImage = ownCanvas.CreateNewBitmap();
        }

        public LayerBasic(LayerBasic layer)
        {
            ownCanvas = layer.ownCanvas;
            Name = layer.Name;
            IsEnabled = layer.IsEnabled;
            ResultImage = (Bitmap)layer.ResultImage.Clone();
        }

        public virtual void Render() { }
    }
}
