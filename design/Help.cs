using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design
{
    public partial class Help : Component
    {
        public Help()
        {
            InitializeComponent();
        }

        public Help(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
