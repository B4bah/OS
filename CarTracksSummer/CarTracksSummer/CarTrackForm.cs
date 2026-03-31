using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarTracksSummer
{
    public partial class CarTrackForm : Form
    {
        CarList _carList;

        public CarTrackForm(CarList carList)
        {
            _carList = carList
            InitializeComponent();
        }


    }
}
