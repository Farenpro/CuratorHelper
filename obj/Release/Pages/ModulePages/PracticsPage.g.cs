﻿#pragma checksum "..\..\..\..\Pages\ModulePages\PracticsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C70A12D592B92199519161462F3ACCE13A40D7758DEA8DC160499E166F6AB4AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CuratorHelper.Properties;
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


namespace CuratorHelper.Pages.ModulePages {
    
    
    /// <summary>
    /// PracticsPage
    /// </summary>
    public partial class PracticsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Pages\ModulePages\PracticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddPractice;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Pages\ModulePages\PracticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGPractics;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\ModulePages\PracticsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnDeletePractics;
        
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
            System.Uri resourceLocater = new System.Uri("/CuratorHelper;component/pages/modulepages/practicspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ModulePages\PracticsPage.xaml"
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
            this.BtnAddPractice = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\Pages\ModulePages\PracticsPage.xaml"
            this.BtnAddPractice.Click += new System.Windows.RoutedEventHandler(this.BtnAddPractice_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DGPractics = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.BtnDeletePractics = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Pages\ModulePages\PracticsPage.xaml"
            this.BtnDeletePractics.Click += new System.Windows.RoutedEventHandler(this.BtnDeletePractics_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

