using System;
using TrackInfo.Models;

namespace TrackInfo.Interfaces
{
    public interface ITrackVisitor
    {
        void Visit(Track track);
    }
}
