﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeaveMgt.Views.StaffViews.Employee
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeAppShell : Shell
    {
        public EmployeeAppShell()
        {
            InitializeComponent();
        }
    }
}