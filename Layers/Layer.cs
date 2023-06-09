using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersIDK
{
    public class Layer
    {
        protected readonly Canvas ownCanvas;

        public string Name = "Слой";
        public bool IsEnabled = true;

        public Bitmap ResultImage { get; protected set; }


        public Layer(Canvas ownCanvas)
        {
            this.ownCanvas = ownCanvas;
            if (!ownCanvas.Layers.Contains(this))
                ownCanvas.Layers.Add(this);

            ResultImage = ownCanvas.CreateNewBitmap();
        }

        public Layer(Layer layer)
        {
            ownCanvas = layer.ownCanvas;
            Name = layer.Name;
            IsEnabled = layer.IsEnabled;
            ResultImage = layer.ResultImage;
        }

        public virtual void Render() { }
    }
}
