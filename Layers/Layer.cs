using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePaint
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
