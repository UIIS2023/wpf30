﻿#pragma checksum "..\..\..\FrmKupovina.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75372933FBA4B8091E60464F77441E8EC8E4BEAE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPFTERETANA;


namespace WPFTERETANA {
    
    
    /// <summary>
    /// FrmKupovina
    /// </summary>
    public partial class FrmKupovina : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIDKupovine;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVrstaKupovine;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBrojRacuna;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIznosPopusta;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIDRobe;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIDZaposlenog;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbIDKlijenta;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtDatum;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\FrmKupovina.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbxPopust;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFTERETANA;component/frmkupovina.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\FrmKupovina.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtIDKupovine = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\FrmKupovina.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\FrmKupovina.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtVrstaKupovine = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtBrojRacuna = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtIznosPopusta = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cbIDRobe = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cbIDZaposlenog = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.cbIDKlijenta = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.dtDatum = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 11:
            this.cbxPopust = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

