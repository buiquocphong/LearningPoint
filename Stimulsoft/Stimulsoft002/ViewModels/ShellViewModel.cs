﻿using Caliburn.Micro;
using Stimulsoft002.Contracts;
using Stimulsoft002.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stimulsoft002.ViewModels
{
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel:Screen, IShellViewModel
    {
         #region Private Variables
        private IList<ProductModel> _ProductCollection;
        #endregion

        #region Constructor
        public ShellViewModel()
        {
            _ProductCollection = new List<ProductModel>()
            {
                new ProductModel() { Name = "Product 1", Price = 100 },
                new ProductModel() { Name = "Product 2", Price = 200 }
            };

            ActiveReport = new Stimulsoft.Report.StiReport();
            ActiveReport.RegBusinessObject("Products", _ProductCollection);
            ActiveReport.Dictionary.Synchronize();
        }
        #endregion

        private Stimulsoft.Report.StiReport _ActiveReport;

        public Stimulsoft.Report.StiReport ActiveReport
        {
            get { return _ActiveReport; }
            set
            {
                _ActiveReport = value;
                this.NotifyOfPropertyChange(nameof(ActiveReport));
            }
        }
    }
}
