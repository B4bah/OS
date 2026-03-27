using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackInfo.Models
{
    public class Track : ITrack
    {
        private string _name;
        private List<Point> _points;

        private void AddPoint(Point point)
        {
            
        }

        private void Accept(ITrackVisitor)
        {

        }

        public float GetLength()
        {
            throw new NotImplementedException();
        }
    }
}
