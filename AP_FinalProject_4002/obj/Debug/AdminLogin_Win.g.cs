﻿#pragma checksum "..\..\AdminLogin_Win.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "67E5DB7078A7C2B3B822ABF4F6D37F98E40FA1D328966EBEA9BD6359B02E92FC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AP_FinalProject_4002;
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


namespace AP_FinalProject_4002 {
    
    
    /// <summary>
    /// AdminLogin_Win
    /// </summary>
    public partial class AdminLogin_Win : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\AdminLogin_Win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\AdminLogin_Win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\AdminLogin_Win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTxtBx;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\AdminLogin_Win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RmmbrMeCheckBox;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\AdminLogin_Win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ForgotMyPassBtn;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\AdminLogin_Win.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AdminLoginBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/AP_FinalProject_4002;component/adminlogin_win.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminLogin_Win.xaml"
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
            this.CloseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\AdminLogin_Win.xaml"
            this.CloseBtn.Click += new System.Windows.RoutedEventHandler(this.CloseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\AdminLogin_Win.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EmailTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.RmmbrMeCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.ForgotMyPassBtn = ((System.Windows.Controls.Button)(target));
            
            #line 159 "..\..\AdminLogin_Win.xaml"
            this.ForgotMyPassBtn.Click += new System.Windows.RoutedEventHandler(this.ForgotMyPassBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AdminLoginBtn = ((System.Windows.Controls.Button)(target));
            
            #line 174 "..\..\AdminLogin_Win.xaml"
            this.AdminLoginBtn.Click += new System.Windows.RoutedEventHandler(this.AdminLoginBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

