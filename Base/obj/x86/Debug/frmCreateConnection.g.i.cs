﻿#pragma checksum "..\..\..\frmCreateConnection.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9A6DC1A618269D7CE06064EEE07933B5"
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
    /// frmCreateConnection
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class frmCreateConnection : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDataSource;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAcceptServer;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chcIntegratedSecurity;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbBDName;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtuser;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbTimeWaitCon;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbTimeWaitExecute;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chcIncript;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbTableName;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateBase;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\frmCreateConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_loading;
        
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
            System.Uri resourceLocater = new System.Uri("/Base;component/frmcreateconnection.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\frmCreateConnection.xaml"
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
            
            #line 4 "..\..\..\frmCreateConnection.xaml"
            ((Base.frmCreateConnection)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbDataSource = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.btnAcceptServer = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\frmCreateConnection.xaml"
            this.btnAcceptServer.Click += new System.Windows.RoutedEventHandler(this.btnAcceptServer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.chcIntegratedSecurity = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.cmbBDName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\frmCreateConnection.xaml"
            this.cmbBDName.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbBDName_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtuser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.cmbTimeWaitCon = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.cmbTimeWaitExecute = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.chcIncript = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            this.cmbTableName = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.btnCreateBase = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\frmCreateConnection.xaml"
            this.btnCreateBase.Click += new System.Windows.RoutedEventHandler(this.btnCreateConnection_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.txt_loading = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

