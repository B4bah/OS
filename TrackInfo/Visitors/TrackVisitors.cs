using System;
using TrackInfo.Models;
using TrackInfo.Interfaces;

namespace TrackInfo.Visitors
{
    public class LengthCalculatorVisitor : ITrackVisitor
    {
        public double Length
        {
            get { return 0; }
        }

        private void Visit(Track track)
        {
            throw new NotImpelementedException();
        }
    }
}