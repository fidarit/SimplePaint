﻿namespace SimplePaint.Models.Layers
{
    internal class Layer : LayerBasic
    {
        public Layer(Canvas ownCanvas) : base(ownCanvas)
        {
        }

        public Layer(LayerBasic layer) : base(layer)
        {
        }
    }
}
