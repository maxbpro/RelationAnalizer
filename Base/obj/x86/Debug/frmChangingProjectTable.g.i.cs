﻿#pragma checksum "..\..\..\frmChangingProjectTable.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0255F588BD03239B8CBF1DFF27D63174"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
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


namespace Base {
    
    
    /// <summary>
    /// frmChangingProjectTable
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class frmChangingProjectTable : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\frmChangingProjectTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNameTable;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\frmChangingProjectTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNameDataSet;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\frmChangingProjectTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtBLockWithTableName;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\frmChangingProjectTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridForNewBase;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\frmChangingProjectTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn name;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\frmChangingProjectTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn Step;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\frmChangingProjectTable.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNext;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Base;component/frmchangingprojecttable.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\frmChangingProjectTable.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 7 "..\..\..\frmChangingProjectTable.xaml"
            ((Base.frmChangingProjectTable)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\frmChangingProjectTable.xaml"
            ((Base.frmChangingProjectTable)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtNameTable = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtNameDataSet = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtBLockWithTableName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.DataGridForNewBase = ((System.Windows.Controls.DataGrid)(target));
            
            #line 38 "..\..\..\frmChangingProjectTable.xaml"
            this.DataGridForNewBase.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.DataGridForNewBase_SelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.name = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.Step = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.btnNext = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\..\frmChangingProjectTable.xaml"
            this.btnNext.Click += new System.Windows.RoutedEventHandler(this.btnNext_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
