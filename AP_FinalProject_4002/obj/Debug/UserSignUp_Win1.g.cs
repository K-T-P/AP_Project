﻿#pragma checksum "..\..\UserSignUp_Win1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "64668ED6B54A29E9AFA4F1610E33EDA93CAF2E35AF7A014E0EB3865C8613BC68"
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
    /// UserSignUp_Win1
    /// </summary>
    public partial class UserSignUp_Win1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\UserSignUp_Win1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\UserSignUp_Win1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\UserSignUp_Win1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FristnameTxtBx;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\UserSignUp_Win1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastnameTxtBx;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\UserSignUp_Win1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneNumTxtBx;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\UserSignUp_Win1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UserSignUpNextBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/AP_FinalProject_4002;component/usersignup_win1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserSignUp_Win1.xaml"
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
            
            #line 46 "..\..\UserSignUp_Win1.xaml"
            this.CloseBtn.Click += new System.Windows.RoutedEventHandler(this.CloseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\UserSignUp_Win1.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FristnameTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.LastnameTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PhoneNumTxtBx = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.UserSignUpNextBtn = ((System.Windows.Controls.Button)(target));
            
            #line 181 "..\..\UserSignUp_Win1.xaml"
            this.UserSignUpNextBtn.Click += new System.Windows.RoutedEventHandler(this.UserSignUpNextBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

