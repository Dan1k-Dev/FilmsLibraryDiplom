﻿#pragma checksum "..\..\..\Pages\RateFilmPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1AC56AE6AA966ADF5184AE274B6C966CCE10A7636386614F2157B4FF6A864313"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Frolov_Cinema.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Frolov_Cinema.Pages {
    
    
    /// <summary>
    /// RateFilmPage
    /// </summary>
    public partial class RateFilmPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Pages\RateFilmPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Filmidd;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\RateFilmPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RateDigital;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\RateFilmPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RateUpBtn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\RateFilmPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RateDownBtn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\RateFilmPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OkBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Frolov_Cinema;component/pages/ratefilmpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\RateFilmPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Filmidd = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.RateDigital = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.RateUpBtn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Pages\RateFilmPage.xaml"
            this.RateUpBtn.Click += new System.Windows.RoutedEventHandler(this.RateUpBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RateDownBtn = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Pages\RateFilmPage.xaml"
            this.RateDownBtn.Click += new System.Windows.RoutedEventHandler(this.RateDownBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.OkBtn = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Pages\RateFilmPage.xaml"
            this.OkBtn.Click += new System.Windows.RoutedEventHandler(this.OkBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

